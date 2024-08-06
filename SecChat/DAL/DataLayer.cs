using SecChat.Models;
using Microsoft.EntityFrameworkCore;

namespace SecChat.DAL
{
    public class DataLayer : DbContext
    {
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();
            seed();
        }
        private void seed()
        {
            if (!Users.Any())
            {
                User user = createNewUser();
                SaveChanges();

            }

        }

        public User createNewUser()
        {
            User user = new User();
            user.Name = "menachem";
            user.nickName = "meni";
            user.password = "password";
            user.messageList = createNewMessage(user);
            Users.Add(user);
            return user;
        }

        public List<Message> createNewMessage(User user)
        {
            Message message = new Message();
            List<Message> messages = new List<Message>();
            message.Text = "somthing";
            message.Date = DateTime.Now;
            message.user = user;
            messages.Add(message);
            Messages.Add(message);
            return messages;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }



        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.
                UseSqlServer(new DbContextOptionsBuilder(),
                connectionString).Options;

        }
    }
}
