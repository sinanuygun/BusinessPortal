namespace Tenant
{
    public sealed class TenantManager
    {
        private static readonly object LockObject = new object();
        private static TenantManager _tenantManager;
        private List<TenantItem> _items = new List<TenantItem>();

        private TenantManager()
        {
            LoadTenants();
        }

        private void LoadTenants()
        {
            _items = CacheManager.Current.Get(CacheKeys.Tenant.DataListOfTenants) as List<TenantItem>;

            if (_items == null)
            {
                LoadTenantsFromDatabase();
            }
        }
        private void LoadTenantsFromDatabase()
        {
            _items = new List<TenantItem>();
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[MasterConfigurationSection.Current.ConnectionString].ConnectionString);
            try
            {
                var command = new SqlCommand(@"
                SELECT Name, BaseConnectionString , LogConnectionString FROM [Tenant] with(nolock) where IsActive=1
                ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    _items.Add(new TenantItem()
                    {
                        Name = Convert.ToString(reader["Name"]),
                        BaseConnectionString = Convert.ToString(reader["BaseConnectionString"]),
                        LogConnectionString = Convert.ToString(reader["LogConnectionString"])
                    });
                }
                CacheManager.Current.Add(CacheKeys.Tenant.DataListOfTenants, _items);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            catch (Exception exx)
            {
                throw new Exception(exx.Message, exx);
            }
            finally
            {
                connection.Close();
            }
        }


        public static TenantManager Current => _tenantManager ?? Initialize();

        private static TenantManager Initialize()
        {
            if (_tenantManager != null) return _tenantManager;
            lock (LockObject)
            {
                _tenantManager = new TenantManager();
            }

            return _tenantManager;
        }

        public List<TenantItem> Items => _items;

        public void Refresh()
        {
            LoadTenantsFromDatabase();
        }

        public TenantItem this[string name]
        {
            get { return String.IsNullOrEmpty(name) ? null : _items.FirstOrDefault(c => c.Name == name); ; }
        }

        public TenantItem GetTenant
        {
            get
            {
                return String.IsNullOrEmpty(Security.Identity.Current.Application.Tenant) ? null :
                    _items.FirstOrDefault(c => c.Name == Security.Identity.Current.Application.Tenant);
            }
        }
    }
}
