using Microsoft.EntityFrameworkCore;
using Requirements.Hub.Infrastructure.Entities;

namespace Requirements.Hub.Infrastructure
{
    public class ProjectContext : RequirementsHubDbContext
    {
        public IList<ShortProject> GetAllShortProject()
        {
            return Project.Select(p => new ShortProject { Name = p.Name, Id = p.Id }).ToList();
        }

        public Project GetProjectByName(string projectName)
        {
            var project = Project.Include(r => r.Requirement).FirstOrDefault(p => p.Name == projectName);

            if (project == null)
                throw new Exception("Project not found");

            return project;
        }

        public Project UpdateProject(Project project)
        {
            var proj = Project.FirstOrDefault(p => p.Name == project.Name);

            if (project == null)
                throw new Exception("Project not found");

            proj = project;

            SaveChanges();

            return project;
        }

        public void SetShortProject(Project project)
        {
            Project.Add(project);

            SaveChanges();
        }
    }
}