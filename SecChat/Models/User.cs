using System.ComponentModel.DataAnnotations;

namespace SecChat.Models
{
    public class User
    {
        public User() 
        {
            messageList = new List<Message>();
        }
        [Key]
        public int Id { get; set; }

        [Display (Name = "user name")]

        public string Name { get; set; }

        public string password {  get; set; }

        [Display (Name =" nickname")]
        public string nickName { get; set; }

        public List<Message> messageList { get; set; }
    }


    
    
}
