using System.Web;
using System.Web.Mvc;
using KMS.EmployeeManagement.App_Start;

namespace KMS.EmployeeManagement
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
        }
    }
}
