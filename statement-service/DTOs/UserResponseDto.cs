using System.Collections.Generic;

namespace statement_service.DTOs
{
    public class UserResponseDto
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public string Degree { get; set; }
        public string Group { get; set; }
        public string PhoneNumber { get; set; }
        public string DateBirth { get; set; }

        public List<StatementResponseDto> Statements { get; set; } = new List<StatementResponseDto>();
    }
}
