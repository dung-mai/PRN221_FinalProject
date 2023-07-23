using AcademicGradeManagementApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcademicGradeManagementApp.Pages
{
    public class IndexModel : PageModelBase
    {
        public IndexModel()
        {
            authorizedRoles = new string[] { "student", "teacher", "TMO" };
        }

        public IActionResult OnGet()
        {
            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }


            return Page();
        }
    }
}
