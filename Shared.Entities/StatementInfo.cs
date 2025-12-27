using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared.Entities
{
    [Table("statement_info")]
    public class StatementInfo
    {
        [Key]
        [ForeignKey("Statement")]
        [Column("id")]
        public long Id { get; set; }  // Використовуємо той же Id, що в Statement (MapsId)

        [Column("is_ready")]
        public bool? IsReady { get; set; }

        [Column("statement_status")]
        public StatementStatus StatementStatus { get; set; }

        [JsonIgnore]
        public virtual Statement Statement { get; set; }
    }
}
