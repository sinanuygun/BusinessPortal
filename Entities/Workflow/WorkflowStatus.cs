namespace BusinessPortal.Entities
{
    public enum WorkflowStatus
    {
        Pending,    // Workflow başlatıldı ama henüz tamamlanmadı
        InProgress, // Workflow üzerinde çalışılıyor
        Completed,  // Workflow tamamlandı
        Rejected    // Workflow reddedildi
    }
}
