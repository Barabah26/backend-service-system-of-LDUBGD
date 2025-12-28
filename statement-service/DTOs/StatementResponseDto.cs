namespace statement_service.DTOs
{
    public class StatementResponseDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string YearBirthday { get; set; }
        public string Group { get; set; }
        public string PhoneNumber { get; set; }
        public string Faculty { get; set; }
        public string TypeOfStatement { get; set; }
        public long UserId { get; set; }
        public string Status { get; set; }
        public bool? IsReady { get; set; }


    }
}
