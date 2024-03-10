using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GoalTracker.Models
{
    public class Student
    {
        [Key]
       public int Id { get; set; }
        [Required]
       public string Name { get; set; }
        [Required]

       public string Email { get; set; }
       public string Phone { get; set; }
        [Required]
        [ForeignKey("GroupId")]
       public int GroupId { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }
    }
}
