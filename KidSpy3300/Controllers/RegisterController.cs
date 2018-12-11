using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BusinessLogic;
using DAL;
using DAL.Model;
using KidSpy3300.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KidSpy3300.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISchoolClass _schoolClasses;
        private readonly IUserAccount _userAccount;
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager; 

        public RegisterController(ISchoolClass schoolClasses, UserManager<UserAccount> userManager, IUserAccount userAccount, SignInManager<UserAccount> signInManager)
        {
            _schoolClasses = schoolClasses;
            _userManager = userManager;
            _userAccount = userAccount;
            _signInManager = signInManager;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogInAction(RegisterModel registerModel)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            UserAccount user = await _userManager.FindByEmailAsync(registerModel.LoginLogin);
            var passwordResult = new PasswordHasher<UserAccount>().VerifyHashedPassword(user,user.PasswordHash,registerModel.LoginPassword);

            if (passwordResult == PasswordVerificationResult.Failed)
                return Error();

            await _signInManager.SignInAsync(user, true);
            
            if(user is ParentAccount)
                return RedirectToAction("Index","ParentAccount");
            
            return RedirectToAction("Index","TeacherAccount");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAction(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result;
                UserAccount user;
                UserAccountType accountType = registerModel.isTeacher ? UserAccountType.TeacherAccount : UserAccountType.ParentAccount;

                var pH = new PasswordHasher<UserAccount>();

                if (accountType == UserAccountType.TeacherAccount)
                {
                    var newTeacher = new TeacherAccount
                    {
                        UserName = registerModel.RegisterLogin, /*ALSO KNOWN AS EMAIL */
                        Email = registerModel.RegisterLogin,
                        Name = registerModel.FirstName,
                        LastName = registerModel.LastName,
                    };

                    newTeacher.PasswordHash = pH.HashPassword(newTeacher, registerModel.RegisterPassword);
                    _schoolClasses.GetById(registerModel.TeacherSchoolClassId).TeacherAccount = newTeacher;
                    result = await _userManager.CreateAsync(newTeacher);
                    user = (UserAccount) newTeacher;
                }
                else
                {
                    var newParent = new ParentAccount()
                    {
                        UserName = registerModel.RegisterLogin, /*ALSO KNOWN AS EMAIL */
                        Email = registerModel.RegisterLogin,
                        Name = registerModel.FirstName,
                        LastName = registerModel.LastName,
                        PasswordHash = registerModel.RegisterPassword
                    };

                    newParent.PasswordHash = pH.HashPassword(newParent, registerModel.RegisterPassword);
                    result = await _userManager.CreateAsync(newParent);
                    user = (UserAccount) newParent;
                }

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, true);

                    return RedirectToAction("Success");
                }
            }

            return RedirectToAction("Error");
        }

        public IActionResult Index()
        {
            var schoolClassModel = _schoolClasses.GetAllNotTaken();
            var scListing = schoolClassModel.Select(_ => new SchoolClassModel
            {
                Id = _.Id,
                Name = _.Name
            });

            var model = new RegisterModel()
            {
                SchoolClasses = scListing
            };

            return View(model);
        }

        [Authorize]
        public IActionResult Success()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
