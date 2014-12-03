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

      //GetAllTechnologies()
        public List<TechnologyMaster> GetAllTechnologies()
        {
            List<TechnologyMaster> technologies=(from technology in companyManagementDataContext.TechnologyMasters select technology).ToList();
            return technologies;
        }
       
        public  IEnumerable<Employee> GetAllEmployeesForProject(int projectID)
        {
            IEnumerable<int> innerquery = from allemployee in companyManagementDataContext.EmployeeProjects
                                         where  allemployee.ProjectId==projectID
                                         select allemployee.EmployeeId;

                             
            IEnumerable<Employee> result = from employee in companyManagementDataContext.Employees
                                            where innerquery.Contains(employee.EmployeeId)
                                            select employee;
            return result;
        }

        //GetEmployeeCountForProject(int projectID)
        public int GetEmployeeCountForProject(int projectID)
        {
            List<EmployeeProject> EmployeeCount = (from count in companyManagementDataContext.EmployeeProjects
                                where count.ProjectId == projectID
                                select count).ToList();

            return EmployeeCount.Count();

        }
        //GetAllDelayedProjects();

        public IEnumerable<Project> GetAllDelayedProjects()
        {
            IEnumerable<Project> delayedProject = from delayed in companyManagementDataContext.Projects
                                                        where delayed.StatusId == (int)Status.Delayed
                                                        select delayed;
            return delayedProject;
        }


      
    }


}

