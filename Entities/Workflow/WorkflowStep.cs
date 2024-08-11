namespace BusinessPortal.Entities
{
    public class WorkflowStep
    {
        public int Id { get; set; } // Primary key
        public int WorkflowTemplateId { get; set; } // Foreign key to WorkflowTemplate
        public string Name { get; set; } // Adım adı (e.g., "Yönetici Onayı")
        public string Description { get; set; } // Adım açıklaması
        public int StepOrder { get; set; } // Adımın sırası (1, 2, 3, ...)
        public string RequiredRole { get; set; } // Bu adımı onaylayacak rol (e.g., "Manager")
    }
}
