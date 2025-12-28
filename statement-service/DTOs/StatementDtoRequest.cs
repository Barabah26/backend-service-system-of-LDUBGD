using System.ComponentModel.DataAnnotations;

namespace statement_service.DTOs
{
    public class StatementDtoRequest
    {
        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "YearBirthday is required")]
        public string YearBirthday { get; set; }

        [Required(ErrorMessage = "Group is required")]
        public string Group { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Faculty is required")]
        public string Faculty { get; set; }

        [Required(ErrorMessage = "TypeOfStatement is required")]
        public string TypeOfStatement { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public long UserId { get; set; }
    }
}
