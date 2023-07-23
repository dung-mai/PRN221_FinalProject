using AcademicGradeManagementApp.Util;
using AcademicGradeManagementApp.Utils;
using Business.IRepository;
using Bussiness.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Assignment2.Extensions;

namespace AcademicGradeManagementApp.Pages
{
    public class LoginModel : PageModelBase
    {
        private IAccountRepository _accountRepository;

        public LoginModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            authorizedRoles = new string[] { "guest" };
        }

        public IActionResult OnGet()
        {
            if (!HasAuthorized())
            {
                return LoginBasedFeatureRedirect();
            }
            return Page();
        }

        public IActionResult OnPost(string? email, string? password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["Error"] = "Vui lòng nhập đủ thông tin email và mật khẩu";
                return Page();
            }
            AccountDTO? account = _accountRepository.GetAccountByEmail(email);

            //IF input email & password is incorrect
            if (account is null || account.Status == 0)
            {
                TempData["Error"] = "Tài khoản không tồn tại";
                return Page();
            }
            else if (!account.Password.Equals(password))
            {
                TempData["Error"] = "Vui lòng kiểm tra lại thông tin tài khoản";
                return Page();
            }
            else
            {
                TempData["Success"] = "Đăng nhập thành công";
                if (account.Role.RoleName.Equals("student"))
                {
                    HttpContext.Session.Set(Constants.LOGIN_ACCOUNT_SESSION_NAME, account);
                    return RedirectToPage("/Index");
                }
                return Page();
            }
        }
    }
}
