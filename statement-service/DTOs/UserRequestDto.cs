using System.ComponentModel.DataAnnotations;

namespace statement_service.DTOs
{
    public class UserRequestDto
    {
        [Required]
        [MaxLength(36)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [MaxLength(128)]
        public string Login { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }

        [Required]
        [MaxLength(128)]
        public string Role { get; set; }

        [MaxLength(128)]
        public string Faculty { get; set; }

        [MaxLength(128)]
        public string Specialty { get; set; }

        [MaxLength(128)]
        public string Degree { get; set; }

        [MaxLength(128)]
        public string Group { get; set; }

        [MaxLength(128)]
        public string PhoneNumber { get; set; }

        [MaxLength(128)]
        public string DateBirth { get; set; }
    }
}
