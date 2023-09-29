using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class BlogPostService
{
    private readonly ApplicationDbContext _dbContext;

    public BlogPostService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<BlogPost> GetBlogPosts()
    {
        return _dbContext.BlogPosts.ToList();
    }

    public BlogPost GetBlogPostById(int id)
    {
        return _dbContext.BlogPosts.FirstOrDefault(bp => bp.Id == id);
    }

    public void CreateBlogPost(BlogPost blogPost)
    {
        blogPost.LastUpdatedOn = DateTime.UtcNow;

        blogPost.PublishedOn = DateTime.UtcNow;

        _dbContext.BlogPosts.Add(blogPost);
        _dbContext.SaveChanges();
    }

    public void UpdateBlogPost(BlogPost blogPost)
    {
        var existingBlogPost = _dbContext.BlogPosts.FirstOrDefault(bp => bp.Id == blogPost.Id);

        if (existingBlogPost != null)
        {
            existingBlogPost.Title = blogPost.Title;
            existingBlogPost.Content = blogPost.Content;
            existingBlogPost.ThumbnailPath = blogPost.ThumbnailPath;

            existingBlogPost.LastUpdatedOn = DateTime.UtcNow;

            _dbContext.SaveChanges();
        }
    }

    public void DeleteBlogPost(int id)
    {
        var blogPostToDelete = _dbContext.BlogPosts.FirstOrDefault(bp => bp.Id == id);

        if (blogPostToDelete != null)
        {
            _dbContext.BlogPosts.Remove(blogPostToDelete);
            _dbContext.SaveChanges();
        }
    }
}
