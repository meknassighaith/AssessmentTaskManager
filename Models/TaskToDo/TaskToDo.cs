
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TaskManagementAPI.Models.TaskToDo
{
    public class TaskToDo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "A Title  is mandatory")]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public TStatus Status { get; set; } // "Open", "In Progress", "Closed"

        //[ForeignKey("AssignedUser")]
        public int AssignedUserId { get; set; }

        


        // Method to update only the status of the task
        public void UpdateStatus(TStatus status) => Status = status;

        internal void Update(TaskToDo task)
        {
            Title = task.Title;
            Description = task.Description;
            Status = task.Status;
            AssignedUserId = task.AssignedUserId;
        }
    }

    // Enum for Task Status
    public enum TStatus
    {
        Open = 0,
        InProgress = 1,
        Closed = 2
    }
}
