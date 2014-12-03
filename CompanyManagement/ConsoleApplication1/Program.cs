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
            //IEnumerable<Project> projects = dataLayer.GetAllProjects();
            //foreach (Project item in projects)
            //{
            //    Console.WriteLine(item.ProjectName);
                
            //}

            //List<TechnologyMaster> technologies = dataLayer.GetAllTechnologies();
            //foreach (TechnologyMaster item in technologies)
            //{
            //    Console.WriteLine(item.TechnologyName);
            //}

            IEnumerable<Employee> employee = dataLayer.GetAllEmployeesForProject(2);
            foreach (var item in employee)
            {
                Console.WriteLine(item.EmployeeName);
            }


            //GetEmployeeCountForProject
            int noOfEmployees = dataLayer.GetEmployeeCountForProject(2);
            Console.WriteLine(noOfEmployees);
            //GetAllDelayedProjects();

            //IEnumerable<Project> delayedproject = dataLayer.GetAllDelayedProjects();
            //foreach (var item in delayedproject)
            //{
            //    Console.WriteLine(item.ProjectName);

            //}





            

            Console.ReadKey();
        }    }
}
