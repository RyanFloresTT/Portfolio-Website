using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class BlogPost
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; }
    
    public DateTime PublishedOn {get; set;}
    public DateTime LastUpdatedOn {get; set;}

    [Required, MaxLength(1000)]
    public string Content { get; set; }

    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("ProjectId")]
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    [Required]
    public string ThumbnailPath { get; set; }
}