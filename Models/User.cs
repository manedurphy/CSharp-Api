using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class User
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public string Username { get; set; }

        public List<TodoItem> TodoItems { get; set; }
    }
}
