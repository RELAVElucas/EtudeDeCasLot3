using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Client
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
