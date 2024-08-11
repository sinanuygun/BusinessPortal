namespace BusinessPortal.Entities
{
    public class Log
    {
        public int Id { get; set; } // Primary key

        public LogLevel LogLevel { get; set; } // Log seviyesi (Info, Create, Update, Delete, Warning, Critical)

        public DateTime LogDateTime { get; set; } = DateTime.Now; // Logun tarihi ve saati

        public string Company { get; set; } // Logu atan firma

        public string Username { get; set; } // Logu atan kullanıcı

        public string Project { get; set; } // Logu atan proje

        public string FunctionName { get; set; } // Logu atan fonksiyonun adı

        public int? LineNumber { get; set; } // Hatanın satır numarası (hata durumunda)

        public string LogMessage { get; set; } // Log mesajı (örneğin, ex.Message)

        public string LogDetail { get; set; } // Log detayı (örneğin, ex.InnerException.Message)
    }
}
