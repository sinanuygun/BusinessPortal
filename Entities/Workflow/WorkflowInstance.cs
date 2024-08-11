namespace BusinessPortal.Entities
{
    public class WorkflowInstance
    {
        public int Id { get; set; } // Primary key
        public int WorkflowTemplateId { get; set; } // Foreign key to WorkflowTemplate
        public Guid UserId { get; set; } // Workflow'u başlatan kullanıcı
        public WorkflowStatus Status { get; set; } // Workflow'un mevcut durumu (Pending, InProgress, Completed, Rejected)
        public DateTime StartedAt { get; set; } // Workflow'un başlama tarihi
        public DateTime? CompletedAt { get; set; } // Workflow'un tamamlanma tarihi (nullable olabilir)
        public List<WorkflowStepInstance> StepInstances { get; set; } // Bu workflow'a ait adımların durumları
    }
}
