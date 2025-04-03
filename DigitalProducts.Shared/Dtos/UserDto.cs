namespace DigitalProducts.Shared.Dtos
{
    public class UserDto
    {
        public enum RoleUser
        {
            NormalUser, 
            Admin
        }

        public UserDto(string name,string email ,string password, RoleUser role) 
        { 
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; } 
        public RoleUser Role { get; set; }
    }
}
