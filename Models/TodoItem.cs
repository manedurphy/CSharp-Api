using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class TodoItem
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsComplete { get; set; }

        [Required]
        public long UserId { get; set; }
    }
}
