using System;
using System.Collections.Generic;

namespace BusinessPortal.Entities
{
    public class WorkflowTemplate
    {
        public int Id { get; set; } // Primary key
        public string Module { get; set; } // Örneğin, "İzin", "Avans", "Araç İstek"
        public string Name { get; set; } // Workflow adı (e.g., "İzin Onayı Workflow'u")
        public string Description { get; set; } // Workflow açıklaması
        public List<WorkflowStep> Steps { get; set; } // Bu workflow'a ait adımlar
    }
}
