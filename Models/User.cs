using System.ComponentModel.DataAnnotations;

namespace bank_accounts_api.Models
{
    public class User
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        
        public Amount? Balance { get; set; }
        public List<UserAccount>? UserAccounts { get; set; }

        public User(string name, string surname)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Surname = surname;
        }
    }
}

