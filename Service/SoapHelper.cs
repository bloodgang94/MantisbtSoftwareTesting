using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mantisbt.MantisService;
using Mantisbt.Models;

namespace Mantisbt.Service
{
    public class SoapHelper
    {
        private readonly MantisConnectPortTypeClient _client;
        public SoapHelper()
        {
            _client = new MantisConnectPortTypeClient();
        }

        public IEnumerable<Project> GetProjects(string user = "root", string password = "")
        {
            var projects = _client.mc_projects_get_user_accessible(user, password);
            return  projects.Select(x => new Project()
            {
                Id = int.Parse(x.id), 
                Name = x.name, 
                Description = x.description, 
                State = int.Parse(x.status.id),
                Visibility = int.Parse(x.view_state.id),
                IsInheritCriteria = x.inherit_global

            });
        }

        public string AddNewProject(ProjectData project, string user = "root", string password = "")
        {
            var result = _client.mc_project_add(user, password, project);
            return result;
        }
    }
}
