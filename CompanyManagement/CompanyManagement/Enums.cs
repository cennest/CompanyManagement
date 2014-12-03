using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement
{
     public class Enums
    {
       public enum Department
        {
            HR = 1,
            ReasearchAndDevelopment = 2,
            Finance = 3,
            Development = 4
        }
        public enum Status
        {
            NotStarted = 1,
            Active = 2,
            Completed = 3,
            Delayed = 4
        }
         public enum Technology
        {
            DotNet = 1,
            Java = 2,
            Android = 3,
            iOS = 4
        } 
    }
}
