using System;
using System.ComponentModel.DataAnnotations;

public class Project
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Title { get; set; }
    
    [Required, MaxLength(250)]
    public string Description { get; set; }

    [Required, MaxLength(1000)]
    public string Content { get; set; }

    public List<BlogPost> BlogPosts { get; set; }

    [Required]
    public string ThumbnailPath { get; set; }
}