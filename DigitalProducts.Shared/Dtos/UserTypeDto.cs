using static DigitalProducts.Shared.Dtos.UserDto;

namespace DigitalProducts.Shared.Dtos
{
    public class UserTypeDto
    {
        public UserTypeDto(string name, string email, RoleUser role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public RoleUser Role { get; set; }

    }
}
