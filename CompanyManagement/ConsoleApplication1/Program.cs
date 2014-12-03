using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int employeeId = 1, technologyId = 1, projectId = 2;
            DataLayer dataLayer = new DataLayer();
            IEnumerable<Project> projects = dataLayer.GetAllProjects();
            Console.WriteLine("GetAllProjects()");
            foreach (Project item in projects)
            {
                Console.WriteLine(item.ProjectName);

            }

            List<TechnologyMaster> technologies = dataLayer.GetAllTechnologies();
            Console.WriteLine("GetAllTechnologies()");
            foreach (TechnologyMaster item in technologies)
            {
                Console.WriteLine(item.TechnologyName);
            }

            List<Employee> employees = dataLayer.GetAllEmployeesForProject(projectId);
            Console.WriteLine("GetAllEmployeesForProject(2)");
            foreach (Employee item in employees)
            {
                Console.WriteLine(item.EmployeeName);
            }


            //GetEmployeeCountForProject
            int noOfEmployees = dataLayer.GetEmployeeCountForProject(projectId);
            Console.WriteLine("GetEmployeeCountForProject(2)");
            Console.WriteLine(noOfEmployees);



            //GetAllDelayedProjects();
            List<Project> delayedProjects = dataLayer.GetAllDelayedProjects();
            Console.WriteLine("GetAllDelayedProjects()");
            foreach (Project item in delayedProjects)
            {
                Console.WriteLine(item.ProjectName);

            }

            //GetAllProjectsForEmployee(int employeeID)
            List<Project> projectsForEmployee = dataLayer.GetAllProjectsForEmployee(employeeId);
            Console.WriteLine("GetAllProjectsForEmployee(1)");
            foreach (Project item in projectsForEmployee)
            {
                Console.WriteLine(item.ProjectName);
            }

            //GetAllTasksForEmployee(int employeeID)
            List<TaskInformation> tasksForEmployee = dataLayer.GetAllTasksForEmployee(employeeId);
            Console.WriteLine("GetAllTasksForEmployee(1)");

            foreach (var item in tasksForEmployee)
            {
                Console.WriteLine(item.TaskName);

            }
            //GetAllTechnologyProjects(int  technologyID)
            List<Project> projectForTechnology = dataLayer.GetAllTechnologyProjects(technologyId);
            Console.WriteLine("GetAllTechnologyProjects(1)");
            foreach (Project item in projectForTechnology)
            {
                Console.WriteLine(item.ProjectName);
            }
            //GetAllActiveTasksForProject(int projectID)
            List<TaskInformation> activeTasks = dataLayer.GetAllActiveTasksForProject(projectId);
            Console.WriteLine("GetAllActiveTasksForProject(2)");
            foreach (TaskInformation item in activeTasks)
            {
                if (item.StatusId == (int)Enums.Status.Active)
                {
                    Console.WriteLine(item.TaskName);
                }

            }
            //GetProjectCountForEmployee(int employeeID)
            int projectCount = dataLayer.GetProjectCountForEmployee(employeeId);
            Console.WriteLine("GetProjectCountForEmployee(1)");
            Console.WriteLine(projectCount);


            //GetAllActiveProjectsManagedByEmployee(int employeeID)
            List<Project> activeProjectForEmployee = dataLayer.GetAllActiveProjectsManagedByEmployee(employeeId);
            Console.WriteLine("GetAllActiveProjectsManagedByEmployee(1)");
            foreach (Project item in activeProjectForEmployee)
            {
                if (item.StatusId == (int)Enums.Status.Active)
                {
                    Console.WriteLine(item.ProjectName);
                }
            }
            //GetAllDelayedTasksForEmployee(int employeeID)
            List<TaskInformation> delayedTaskForEmployee = dataLayer.GetAllDelayedTasksForEmployee(employeeId);
            Console.WriteLine("GetAllDelayedTasksForEmployee(1)");
            foreach (TaskInformation item in delayedTaskForEmployee)
            {
                if (item.StatusId == (int)Enums.Status.Active)
                {
                    Console.WriteLine(item.TaskName);
                }
                Console.WriteLine();
            }
            List<TechnologyMaster> technologiesForEmployee = dataLayer.GetAllTechnologiesForEmployee(employeeId);
            Console.WriteLine("GetAllTechnologiesForEmployee");
            foreach (TechnologyMaster item in technologiesForEmployee)
            {
                Console.WriteLine(item.TechnologyName);
            }

            List<TaskInformation> technologyTaskForEmployee = dataLayer.GetAllTechnologyTasksForEmployee(technologyId, employeeId);
            Console.WriteLine("GetAllTechnologyTasksForEmployee(1, 1)");
            foreach (TaskInformation item in technologyTaskForEmployee)
            {
                Console.WriteLine(item.TaskName);
            }


            Console.ReadKey();
        }
    }
}
