using AcademicGradeManagementApp.Util;
using Bussiness.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Assignment2.Extensions;

namespace AcademicGradeManagementApp.Utils
{
    public class PageModelBase : PageModel
    {
        public AccountDTO? LoggedInAccount { get; set; }
        public string[] authorizedRoles = new string[] { };

        public PageModelBase()
        {

        }

        private IActionResult DefaultPageByRole(AccountDTO account)
        {
            if (account.Role?.RoleName?.ToLower() == Constants.STUDENT_ROLE)
            {
                return RedirectToPage(Constants.DEFAULT_STUDENT_PAGE);
            }
            else if(account.Role?.RoleName?.ToLower() == Constants.TEACHER_ROLE)
            {
                return RedirectToPage(Constants.DEFAULT_TEACHER_PAGE);
            } else
            {
                return RedirectToPage(Constants.DEFAULT_TMO_PAGE);
            }
        }

        public bool HasAuthorized()
        {
            LoggedInAccount = HttpContext.Session.Get<AccountDTO>(Constants.LOGIN_ACCOUNT_SESSION_NAME);

            //NOT LOGIN + GUEST can acess --> true
            if (LoggedInAccount is null)
            {
                if (IsGuestFeature())
                {
                    return true;
                }
            }
            //HAS LOGIN + check role
            else
            {
                foreach (string r in authorizedRoles)
                {
                    if (r == LoggedInAccount?.Role?.RoleName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public IActionResult LoginBasedFeatureRedirect()
        {
            if (LoggedInAccount is null)
            {
                return RedirectToPage(Constants.LOGIN_URL);
            }
            else
            {
                return DefaultPageByRole(LoggedInAccount);
            }
        }

        private bool IsGuestFeature()
        {
            foreach (string role in authorizedRoles)
            {
                if (role == Constants.GUEST_ROLE)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
