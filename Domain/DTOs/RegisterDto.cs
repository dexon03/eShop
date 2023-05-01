using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}", 
        ErrorMessage = "Password must be between 4 and 8 characters and contain one uppercase letter, " +
                       "one lowercase letter, and one number. (No special characters allowed")]
    public string Password { get; set; }
    [Required]
    public string DisplayName { get; set; }
    [Required]
    public string UserName { get; set; }

}