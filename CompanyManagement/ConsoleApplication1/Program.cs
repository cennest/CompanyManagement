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
            const int EMPLOYEEID = 1, TECHNOLOGYID = 1, PROJECTID = 2;
            DataLayer dataLayer = new DataLayer();
            List<Project> projects = dataLayer.GetAllProjects();
            Console.WriteLine("GetAllProjects()");
            foreach (Project project in projects)
            {
                Console.WriteLine(project.ProjectName);
            }

            List<TechnologyMaster> technologies = dataLayer.GetAllTechnologies();
            Console.WriteLine("GetAllTechnologies()");
            foreach (TechnologyMaster technology in technologies)
            {
                Console.WriteLine(technology.TechnologyName);
            }

            List<Employee> employees = dataLayer.GetAllEmployeesForProject(PROJECTID);
            Console.WriteLine("GetAllEmployeesForProject(2)");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.EmployeeName);
            }


            //GetEmployeeCountForProject
            int noOfEmployees = dataLayer.GetEmployeeCountForProject(PROJECTID);
            Console.WriteLine("GetEmployeeCountForProject(2)");
            Console.WriteLine(noOfEmployees);



            //GetAllDelayedProjects();
            List<Project> delayedProjects = dataLayer.GetAllDelayedProjects();
            Console.WriteLine("GetAllDelayedProjects()");
            foreach (Project project in delayedProjects)
            {
                Console.WriteLine(project.ProjectName);
            }

            //GetAllProjectsForEmployee(int employeeID)
            List<Project> projectsForEmployee = dataLayer.GetAllProjectsForEmployee(EMPLOYEEID);
            Console.WriteLine("GetAllProjectsForEmployee(1)");
            foreach (Project project in projectsForEmployee)
            {
                Console.WriteLine(project.ProjectName);
            }

            //GetAllTasksForEmployee(int employeeID)
            List<TaskInformation> tasksForEmployee = dataLayer.GetAllTasksForEmployee(EMPLOYEEID);
            Console.WriteLine("GetAllTasksForEmployee(1)");

            foreach (TaskInformation task in tasksForEmployee)
            {
                Console.WriteLine(task.TaskName);
            }
            //GetAllTechnologyProjects(int  technologyID)
            List<Project> projectForTechnology = dataLayer.GetAllTechnologyProjects(TECHNOLOGYID);
            Console.WriteLine("GetAllTechnologyProjects(1)");
            foreach (Project project in projectForTechnology)
            {
                Console.WriteLine(project.ProjectName);
            }
            //GetAllActiveTasksForProject(int projectID)
            List<TaskInformation> activeTasks = dataLayer.GetAllActiveTasksForProject(PROJECTID);
            Console.WriteLine("GetAllActiveTasksForProject(2)");
            foreach (TaskInformation task in activeTasks)
            {
                if (task.StatusId == (int)Enums.Status.Active)
                {
                    Console.WriteLine(task.TaskName);
                }
            }
            //GetProjectCountForEmployee(int employeeID)
            int projectCount = dataLayer.GetProjectCountForEmployee(EMPLOYEEID);
            Console.WriteLine("GetProjectCountForEmployee(1)");
            Console.WriteLine(projectCount);


            //GetAllActiveProjectsManagedByEmployee(int employeeID)
            List<Project> activeProjectForEmployee = dataLayer.GetAllActiveProjectsManagedByEmployee(EMPLOYEEID);
            Console.WriteLine("GetAllActiveProjectsManagedByEmployee(1)");
            foreach (Project project in activeProjectForEmployee)
            {
                if (project.StatusId == (int)Enums.Status.Active)
                {
                    Console.WriteLine(project.ProjectName);
                }
            }
            //GetAllDelayedTasksForEmployee(int employeeID)
            List<TaskInformation> delayedTaskForEmployee = dataLayer.GetAllDelayedTasksForEmployee(EMPLOYEEID);
            Console.WriteLine("GetAllDelayedTasksForEmployee(1)");
            foreach (TaskInformation task in delayedTaskForEmployee)
            {
                if (task.StatusId == (int)Enums.Status.Active)
                {
                    Console.WriteLine(task.TaskName);
                }
                Console.WriteLine();
            }
            List<TechnologyMaster> technologiesForEmployee = dataLayer.GetAllTechnologiesForEmployee(EMPLOYEEID);
            Console.WriteLine("GetAllTechnologiesForEmployee");
            foreach (TechnologyMaster technology in technologiesForEmployee)
            {
                Console.WriteLine(technology.TechnologyName);
            }

            List<TaskInformation> technologyTaskForEmployee = dataLayer.GetAllTechnologyTasksForEmployee(TECHNOLOGYID, EMPLOYEEID);
            Console.WriteLine("GetAllTechnologyTasksForEmployee(1, 1)");
            foreach (TaskInformation task in technologyTaskForEmployee)
            {
                Console.WriteLine(task.TaskName);
            }


            Console.ReadKey();
        }
    }
}
