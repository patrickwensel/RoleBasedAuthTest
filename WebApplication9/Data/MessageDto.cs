using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication9.Data
{
    [Table("Messages")]
    public class MessageDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid MessageID { get; set; }
        [Required]
        public string FromUserID { get; set; }
        [Required]
        public string ToUserID { get; set; }
        [Required]
        public string MessageText { get; set; }
        [Required]
        public DateTime MessageDateTime { get; set; } = DateTime.UtcNow;
    }
}
