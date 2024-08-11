using System;

namespace BusinessPortal.Entities
{
    public class WorkflowStepInstance
    {
        public int Id { get; set; } // Primary key
        public int WorkflowInstanceId { get; set; } // Foreign key to WorkflowInstance
        public int WorkflowStepId { get; set; } // Foreign key to WorkflowStep
        public string Status { get; set; } // Adımın durumu (e.g., "Pending", "Completed", "Rejected")
        public DateTime? CompletedAt { get; set; } // Adımın tamamlanma tarihi
    }
}
