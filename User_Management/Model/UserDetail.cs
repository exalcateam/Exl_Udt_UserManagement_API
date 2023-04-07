using System.ComponentModel.DataAnnotations;

namespace User_Management.Model
{
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Emp_ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DOB { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public byte[] Photo { get; set; }
    }
}
