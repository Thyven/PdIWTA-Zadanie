using Lab4.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Lab4.DTO
{
    public class TestUserDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
