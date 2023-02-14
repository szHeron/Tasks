using Tasks.Enums;

namespace Tasks.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public TaskState State { get; set; }
        public Guid? UserId { get; set; }
        public virtual UserModel? User { get; set; }
    }
}
