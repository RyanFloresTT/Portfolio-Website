using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class ProjectService
{
    private readonly ApplicationDbContext _dbContext;

    public ProjectService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Project> GetProjects()
    {
        return _dbContext.Projects.ToList();
    }

    public Project GetProjectById(int id)
    {
        return _dbContext.Projects.FirstOrDefault(p => p.Id == id);
    }

    public void CreateProject(Project project)
    {
        _dbContext.Projects.Add(project);
        _dbContext.SaveChanges();
    }

    public void UpdateProject(Project project)
    {
        var existingProject = _dbContext.Projects.FirstOrDefault(p => p.Id == project.Id);

        if (existingProject != null)
        {
            existingProject.Title = project.Title;
            existingProject.Description = project.Description;
            existingProject.Content = project.Content;
            existingProject.ThumbnailPath = project.ThumbnailPath;

            _dbContext.SaveChanges();
        }
    }

    public void DeleteProject(int id)
    {
        var projectToDelete = _dbContext.Projects.FirstOrDefault(p => p.Id == id);

        if (projectToDelete != null)
        {
            _dbContext.Projects.Remove(projectToDelete);
            _dbContext.SaveChanges();
        }
    }
}
