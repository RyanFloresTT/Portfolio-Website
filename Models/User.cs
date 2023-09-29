using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class User : IdentityRole{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string UserName { get; set; }

    [Required, MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    [Required, MaxLength(100)]
    public string Email { get; set; }

    [Required, MaxLength(128)]
    public string PasswordHash { get; set; }

    [Required, MaxLength(128)]
    public string Salt { get; set; }
    public List<BlogPost> BlogPosts { get; set; }
}
