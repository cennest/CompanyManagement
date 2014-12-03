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

            DataLayer dataLayer = new DataLayer();
            IEnumerable<Project> projects = dataLayer.GetAllProjects();
            foreach (Project item in projects)
            {
                Console.WriteLine(item.ProjectName);

            }

            List<TechnologyMaster> technologies = dataLayer.GetAllTechnologies();
            foreach (TechnologyMaster item in technologies)
            {
                Console.WriteLine(item.TechnologyName);
            }

            List<Employee> employees = dataLayer.GetAllEmployeesForProject(2);
            foreach (Employee item in employees)
            {
                Console.WriteLine(item.EmployeeName);
            }


            //GetEmployeeCountForProject
            int noOfEmployees = dataLayer.GetEmployeeCountForProject(2);
            Console.WriteLine(noOfEmployees);



            //GetAllDelayedProjects();
            List<Project> delayedProjects = dataLayer.GetAllDelayedProjects();
            foreach (Project item in delayedProjects)
            {
                Console.WriteLine(item.ProjectName);

            }

            //GetAllProjectsForEmployee(int employeeID)
            List<Project> projectsForEmployeeId = dataLayer.GetAllProjectsForEmployee(1);
            foreach  (Project item in projectsForEmployeeId)
            {
                Console.WriteLine(item.ProjectName);
            }

            //GetAllTasksForEmployee(int employeeID)
            List<TaskInformation> tasks = dataLayer.GetAllTasksForEmployee(1);

            foreach (var item in tasks)
            {
                Console.WriteLine(item.TaskName);

            }
            //GetAllTechnologyProjects(int  technologyID)
            List<Project> projectForTcchnology = dataLayer.GetAllTechnologyProjects(0);
            foreach (Project item in projectForTcchnology)
            {
                Console.WriteLine(item.ProjectName);
            }
            //GetAllActiveTasksForProject(int projectID)
            List<TaskInformation> activeTasks = dataLayer.GetAllActiveTasksForProject(1);
            foreach (TaskInformation item in activeTasks)
            {
                if (item.StatusId==(int) Status.Active)
                {
                    Console.WriteLine(item.TaskName);
                }
                
            }
            //GetProjectCountForEmployee(int employeeID)
            int projectCount = dataLayer.GetProjectCountForEmployee(1);
            Console.WriteLine(projectCount);


            //GetAllActiveProjectsManagedByEmployee(int employeeID)
            List<Project> activeProjectForEmployee = dataLayer.GetAllActiveProjectsManagedByEmployee(1);
            foreach(Project item in activeProjectForEmployee)
            {
                if (item.StatusId==(int)Status.Active)
                {
                    Console.WriteLine(item.ProjectName);
                }
            }
            //GetAllDelayedTasksForEmployee(int employeeID)
            List<TaskInformation> delayedTaskForEmployee = dataLayer.GetAllDelayedTasksForEmployee(1);
            foreach (TaskInformation item in delayedTaskForEmployee)
            {
                if (item.StatusId==(int) Status.Active)
                {
                    Console.WriteLine(item.TaskName);
                }
                Console.WriteLine();
            }
            List<TechnologyMaster> technologiesForEmployee = dataLayer.GetAllTechnologiesForEmployee(1);
            foreach (TechnologyMaster item in technologiesForEmployee)
            {
                Console.WriteLine(item.TechnologyName);
            }

            List<TaskInformation> technologyTaskForEmployee = dataLayer.GetAllTechnologyTasksForEmployee(1, 1);
          {
              foreach (TaskInformation item in technologyTaskForEmployee)
              {
                  Console.WriteLine(item.TaskName);
              }
          }

            Console.ReadKey();
        }    }
}
