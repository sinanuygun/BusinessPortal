using BusinessPortal.Data;
using BusinessPortal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BusinessPortal.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly BusinessPortalContext _context;

        public WorkflowService(BusinessPortalContext context)
        {
            _context = context;
        }

        public void StartWorkflow(int workflowTemplateId, Guid userId)
        {
            var workflowTemplate = _context.WorkflowTemplates.Include(wt => wt.Steps)
                                                             .FirstOrDefault(wt => wt.Id == workflowTemplateId);
            if (workflowTemplate == null)
            {
                throw new Exception("Workflow template not found");
            }

            var workflowInstance = new WorkflowInstance
            {
                WorkflowTemplateId = workflowTemplateId,
                UserId = userId,
                Status = "Pending",
                StartedAt = DateTime.Now,
                StepInstances = workflowTemplate.Steps.Select(step => new WorkflowStepInstance
                {
                    WorkflowStepId = step.Id,
                    Status = "Pending"
                }).ToList()
            };

            _context.WorkflowInstances.Add(workflowInstance);
            _context.SaveChanges();
        }

        public void CompleteStep(int workflowInstanceId, int stepId)
        {
            var stepInstance = _context.WorkflowStepInstances
                                       .FirstOrDefault(si => si.WorkflowInstanceId == workflowInstanceId && si.WorkflowStepId == stepId);

            if (stepInstance == null)
            {
                throw new Exception("Step instance not found");
            }

            stepInstance.Status = "Completed";
            stepInstance.CompletedAt = DateTime.Now;

            _context.WorkflowStepInstances.Update(stepInstance);
            _context.SaveChanges();

            // Check if all steps are completed to update the workflow status
            var workflowInstance = _context.WorkflowInstances
                                           .Include(wi => wi.StepInstances)
                                           .FirstOrDefault(wi => wi.Id == workflowInstanceId);

            if (workflowInstance != null && workflowInstance.StepInstances.All(si => si.Status == "Completed"))
            {
                workflowInstance.Status = "Completed";
                workflowInstance.CompletedAt = DateTime.Now;
                _context.WorkflowInstances.Update(workflowInstance);
                _context.SaveChanges();
            }
        }

        public WorkflowInstance GetWorkflowInstance(int workflowInstanceId)
        {
            return _context.WorkflowInstances.Include(wi => wi.StepInstances)
                                             .FirstOrDefault(wi => wi.Id == workflowInstanceId);
        }
    }
}
