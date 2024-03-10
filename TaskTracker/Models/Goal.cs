using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GoalTracker.Models;

namespace GoalTracker.Models
{
    public class Goal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Target { get; set; } = 0;
        [Required]
        public int Record { get; set; } = 0;
        [Required]
        public Boolean IsCompleted { get; set; } = false;
        [Required]

        public DateTime? AssignmentDate { get; set;}
        [Required]
        public DateTime? Deadline{ get; set;}

        [Required] 
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        [ValidateNever]
        public Student Student { get; set; }



    }
}
