using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared.Entities
{
    [Table("statement")]
    public class Statement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("full_name")]
        public string FullName { get; set; }

        [Required]
        [Column("year_birthday")]
        public string YearBirthday { get; set; }

        [Required]
        [Column("group_name")]
        public string Group { get; set; }

        [Required]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("faculty")]
        public string Faculty { get; set; }

        [Required]
        [Column("type_of_statement")]
        public string TypeOfStatement { get; set; }

        [JsonIgnore]
        public virtual StatementInfo StatementInfo { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public long UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
