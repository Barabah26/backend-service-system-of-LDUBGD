using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public long UserId { get; set; }

        [Required]
        [MaxLength(36)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(128)]
        [Column("login")]
        public string Login { get; set; }

        [Required]
        [MaxLength(128)]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(128)]
        [Column("role")]
        public string Role { get; set; }

        [MaxLength(128)]
        [Column("faculty")]
        public string Faculty { get; set; }

        [MaxLength(128)]
        [Column("specialty")]
        public string Specialty { get; set; }

        [MaxLength(128)]
        [Column("degree")]
        public string Degree { get; set; }

        [MaxLength(128)]
        [Column("student_group")]
        public string Group { get; set; }

        [MaxLength(128)]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [MaxLength(128)]
        [Column("date_birth")]
        public string DateBirth { get; set; }
        public virtual List<Statement> Statements { get; set; } = new List<Statement>();
        //public virtual List<ForgotPassword> ForgotPasswords { get; set; } = new List<ForgotPassword>();
    }
}
