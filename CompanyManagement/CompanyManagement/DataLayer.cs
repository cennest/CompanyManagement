using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement
{
    public class DataLayer
    {
        CompanyManagementDataContextDataContext companyManagementDataContext = new CompanyManagementDataContextDataContext();

        public List<Project> GetAllProjects()
        {
            List<Project> projects = (from project in companyManagementDataContext.Projects
                                      select project).ToList<Project>();
            return projects;
        }

        public List<TechnologyMaster> GetAllTechnologies()
        {
            List<TechnologyMaster> technologies = (from technology in companyManagementDataContext.TechnologyMasters
                                                   select technology).ToList<TechnologyMaster>();
            return technologies;
        }

        public List<Employee> GetAllEmployeesForProject(int projectID)
        {
            List<Employee> employees = (from employee in companyManagementDataContext.Employees
                                        where employee.EmployeeProjects.Any(employeeProject => employeeProject.ProjectId == projectID)
                                        select employee).ToList<Employee>();
            return employees;

        }

        public int GetEmployeeCountForProject(int projectID)
        {
            int employeeCount = (from count in companyManagementDataContext.EmployeeProjects
                                 where count.ProjectId == projectID
                                 select count).Count();
            return employeeCount;
        }

        public List<Project> GetAllDelayedProjects()
        {
            List<Project> delayedProjects = (from project in companyManagementDataContext.Projects
                                             where project.StatusId == (int)Enums.Status.Delayed
                                             select project).ToList<Project>();
            return delayedProjects;
        }

        public List<Project> GetAllProjectsForEmployee(int employeeID)
        {
            List<Project> projects = (from project in companyManagementDataContext.Projects
                                      where project.EmployeeProjects.Any(employeeProject => employeeProject.EmployeeId == employeeID)
                                      select project).ToList<Project>();
            return projects;

        }

        public List<TaskInformation> GetAllTasksForEmployee(int employeeID)
        {
            List<TaskInformation> tasks = (from task in companyManagementDataContext.TaskInformations
                                           where companyManagementDataContext.EmployeeTasks.Any(employeeTask => employeeTask.EmployeeId == employeeID)
                                           select task).ToList<TaskInformation>();
            return tasks;
        }

        public List<Project> GetAllTechnologyProjects(int technologyID)
        {
            List<Project> projects = (from project in companyManagementDataContext.Projects
                                      where companyManagementDataContext.ProjectTechnologies.Any(projectTechnology => projectTechnology.TechnologyId == technologyID)
                                      select project).ToList<Project>();
            return projects;
        }

        public List<TaskInformation> GetAllActiveTasksForProject(int projectID)
        {
            List<TaskInformation> activeTasks = (from task in companyManagementDataContext.TaskInformations
                                                 where (companyManagementDataContext.ProjectTasks.Any(projectTask => projectTask.ProjectId == projectID && task.StatusId == (int)Enums.Status.Active))
                                                 select task).ToList<TaskInformation>();
            return activeTasks;
        }

        public int GetProjectCountForEmployee(int employeeID)
        {
            int projectCount = (from project in companyManagementDataContext.EmployeeProjects
                                where project.EmployeeId == employeeID
                                select project).Count();
            return projectCount;
        }

        public List<Project> GetAllActiveProjectsManagedByEmployee(int employeeID)
        {
            List<Project> projects = (from project in companyManagementDataContext.Projects
                                      where companyManagementDataContext.EmployeeProjects.Any(employeeProject => employeeProject.EmployeeId == employeeID && project.StatusId == (int)Enums.Status.Active)
                                      select project).ToList<Project>();
            return projects;
        }

        public List<TaskInformation> GetAllDelayedTasksForEmployee(int employeeID)
        {
            List<TaskInformation> tasks = (from task in companyManagementDataContext.TaskInformations
                                           where companyManagementDataContext.EmployeeTasks.Any(employeeTask => employeeTask.EmployeeId == employeeID && task.StatusId == (int)Enums.Status.Delayed)
                                           select task).ToList<TaskInformation>();
            return tasks;
        }

        public List<TechnologyMaster> GetAllTechnologiesForEmployee(int employeeID)
        {
            List<int> technologyIds = (from projectTechnology in companyManagementDataContext.ProjectTechnologies
                                       where companyManagementDataContext.EmployeeProjects.Any(employeeProject => employeeProject.EmployeeId == employeeID)
                                       select projectTechnology.TechnologyId).ToList<int>();
            List<TechnologyMaster> technologies = (from technology in companyManagementDataContext.TechnologyMasters
                                                   where technologyIds.Contains(technology.TechnologyId)
                                                   select technology).ToList<TechnologyMaster>();
            return technologies;
        }

        public List<TaskInformation> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
        {
            List<TaskInformation> tasks = (from task in companyManagementDataContext.TaskInformations
                                           where companyManagementDataContext.TechnologyTasks.Any(o => o.TechnologyId == technologyID) && companyManagementDataContext.EmployeeTasks.Any(p => p.EmployeeId == employeeID)
                                           select task).ToList<TaskInformation>();
            return tasks;
        }
    }
}

