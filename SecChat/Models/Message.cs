using System.ComponentModel.DataAnnotations;

namespace SecChat.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Display (Name ="text")]
        public string Text { get; set; }


        public User user { get; set; }

        [Display (Name = "time stemp")]
        public DateTime Date { get; set; }
    }
}
