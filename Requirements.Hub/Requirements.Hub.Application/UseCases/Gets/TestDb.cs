using Requirements.Hub.Infrastructure;
using Requirements.Hub.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements.Hub.Application.UseCases.Gets
{
    public class TestDb
    {
        public void Execute()
        {
            using (var context = new RequirementsHubDbContext())
            {
                // Criar um novo projeto com requisitos
                var project = new Project
                {
                    Name = "Meu Projeto"
                };

                project.Requirement = new List<Requirement>
            {
                new Requirement { Description = "Requisito 1", Funcionality = "Funcionalidade 1" },
                new Requirement { Description = "Requisito 2", Funcionality = "Funcionalidade 2" }
            };

                // Adicionar o projeto ao contexto
                context.Project.Add(project);

                // Salvar mudanças no banco de dados
                context.SaveChanges();

                Console.WriteLine("Projeto e requisitos salvos com sucesso!");
            }
        }
    }
}
