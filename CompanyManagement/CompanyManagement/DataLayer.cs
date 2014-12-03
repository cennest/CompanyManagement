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
        //GetAllEmployeesForProject(int projectID)
        public List<Employee> GetAllEmployeesForProject(int projectID)
        {

            List<int> employeeIds= (from allemployee in companyManagementDataContext.EmployeeProjects
                                          where allemployee.ProjectId == projectID
                                          select allemployee.EmployeeId).ToList();


            List<Employee> employees = (from employee in companyManagementDataContext.Employees
                                           where  employeeIds.Contains(employee.EmployeeId)
                                           select employee).ToList();
            return employees;
        }

        //GetEmployeeCountForProject(int projectID)
        public int GetEmployeeCountForProject(int projectID)
        {
            List<EmployeeProject> employeeCount = (from count in companyManagementDataContext.EmployeeProjects
                                where count.ProjectId == projectID
                                select count).ToList();

            return employeeCount.Count();

        }
        //GetAllDelayedProjects();

        public List<Project> GetAllDelayedProjects()
        {
            List<Project> delayedProjects = (from delayed in companyManagementDataContext.Projects
                                                        where delayed.StatusId == (int)Status.Delayed
                                                        select delayed).ToList();
            return delayedProjects;
        }

      public  List<Project> GetAllProjectsForEmployee(int employeeID)
        {
            List<int> employeeIds = (from project in companyManagementDataContext.EmployeeProjects
                                    where project.EmployeeId == employeeID
                                    select project.ProjectId).ToList();
            List<Project> projects = (from project in companyManagementDataContext.Projects
                                      where employeeIds.Contains(project.ProjectId)
                                      select project).ToList();
            return projects;

        }
        //GetAllTasksForEmployee(int employeeID)
    public   List<TaskInformation> GetAllTasksForEmployee(int employeeID)
      {
          List<int> taskIds = (from task in companyManagementDataContext.EmployeeTasks
                               where task.EmployeeId == employeeID
                               select task.TaskId).ToList();
          List<TaskInformation> tasks = (from task in companyManagementDataContext.TaskInformations
                              where taskIds.Contains(task.TaskId)
                              select task).ToList();
          return tasks;
      }

        //GetAllTechnologyProjects(int  technologyID)
      public List<Project> GetAllTechnologyProjects(int  technologyID)
      {
      List<int> projectIds=(from project in companyManagementDataContext.ProjectTechnologies
                            where project.TechnologyId==technologyID
                            select project.ProjectId).ToList();
          List<Project> projects=(from project in companyManagementDataContext.Projects
                                          where projectIds.Contains(project.ProjectId)select project).ToList();
          return projects;
      }
      // GetAllActiveTasksForProject(int projectID)
      public List<TaskInformation> GetAllActiveTasksForProject(int projectID)

      {
          List<int> projectIds = (from project in companyManagementDataContext.ProjectTasks
                                  where project.ProjectId == projectID
                                  select project.TaskId).ToList();
           List<TaskInformation> tasks=(from task in companyManagementDataContext.TaskInformations
                                       where projectIds.Contains(task.TaskId)
                                       select task).ToList();
           return tasks;
      }
        //GetAllTechnologiesForEmployee(int employeeID)



        //GetProjectCountForEmployee(int employeeID)


      public int GetProjectCountForEmployee(int employeeID)
      {
          List<EmployeeProject> projectCount = (from project in companyManagementDataContext.EmployeeProjects
                                                where project.EmployeeId == employeeID
                                                select project).ToList();
          return projectCount.Count();
      }
        //GetAllActiveProjectsManagedByEmployee(int employeeID)

     public List<Project> GetAllActiveProjectsManagedByEmployee(int employeeID)
      {
          List<int> projectIds = (from project in companyManagementDataContext.EmployeeProjects
                                 where project.EmployeeId == employeeID
                                 select project.ProjectId).ToList();
          List<Project> projects = (from project in companyManagementDataContext.Projects
                                    where projectIds.Contains(project.ProjectId)
                                    select project).ToList();
          return projects;
      }

        //GetAllDelayedTasksForEmployee(int employeeID)
    public
        List<TaskInformation> GetAllDelayedTasksForEmployee(int employeeID)
     {

         List<int> taskIds = (from task in companyManagementDataContext.EmployeeTasks
                              where task.EmployeeId == employeeID
                              select task.TaskId).ToList();
         List<TaskInformation> tasks = (from task in companyManagementDataContext.TaskInformations
                                        where taskIds.Contains(task.TaskId)
                                        select task).ToList();
         return tasks;

     }
        //GetAllTechnologiesForEmployee(int employeeID)
   public  List<TechnologyMaster> GetAllTechnologiesForEmployee(int employeeID)
    {
        List<int> projectIds = (from project in companyManagementDataContext.EmployeeProjects
                                where project.EmployeeId == employeeID
                                select project.ProjectId).ToList();
        List<int> technologyIds = (from technology in companyManagementDataContext.ProjectTechnologies
                                   where projectIds.Contains(technology.ProjectId)
                                   select technology.TechnologyId).ToList();
        List<TechnologyMaster> technologies = (from technology in companyManagementDataContext.TechnologyMasters
                                               where technologyIds.Contains(technology.TechnologyId)
                                               select technology).ToList();
        return technologies;
    }

   public List<TaskInformation> GetAllTechnologyTasksForEmployee(int technologyID, int employeeID)
   {

       List<int> taskIdsEmployee = (from taskIds in companyManagementDataContext.EmployeeTasks
                                    where taskIds.EmployeeId == employeeID
                                    select taskIds.TaskId).ToList();
       List<int> taskIdsTechnology = (from taskIds in companyManagementDataContext.TechnologyTasks
                                      where taskIds.TechnologyId == technologyID
                                      select taskIds.TaskId).ToList();
       List<TaskInformation> tasks=( from   task     in companyManagementDataContext.TaskInformations
                                     where (taskIdsEmployee.Contains(task.TaskId))&& (taskIdsTechnology.Contains(task.TaskId))
                                     select task).ToList();
       return tasks;





      
     

   }
    }


}

