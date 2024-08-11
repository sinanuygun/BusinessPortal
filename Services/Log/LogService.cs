using BusinessPortal.Data;
using BusinessPortal.Entities;
using Microsoft.AspNetCore.Http;

namespace BusinessPortal.Services
{
    public class LogService : ILogService
    {
        private readonly BusinessPortalContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _projectName;

        public LogService(BusinessPortalContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _projectName = "ExampleProject"; // Burada proje adını statik olarak belirleyebilirsiniz veya bir config dosyasından alabilirsiniz
        }

        public void Log(Log log)
        {
            log.Company = GetCompany();
            log.Username = GetUsername();
            log.Project = _projectName;

            _context.Logs.Add(log);
            _context.SaveChanges();
        }

        private string GetCompany()
        {
            // Şirket bilgilerini belirlemek için bir yöntem
            // Örneğin, kullanıcının oturum açtığı şirketi bu şekilde alabilirsiniz
            return _httpContextAccessor.HttpContext?.User?.FindFirst("Company")?.Value ?? "UnknownCompany";
        }

        private string GetUsername()
        {
            // Kullanıcı adını almak için bir yöntem
            return _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "UnknownUser";
        }
    }
}
