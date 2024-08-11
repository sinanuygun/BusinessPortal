using BusinessPortal.Entities;
using System;

namespace BusinessPortal.Services
{
    public interface IWorkflowService
    {
        void StartWorkflow(int workflowTemplateId, Guid userId);
        void CompleteStep(int workflowInstanceId, int stepId);
        WorkflowInstance GetWorkflowInstance(int workflowInstanceId);
    }
}
