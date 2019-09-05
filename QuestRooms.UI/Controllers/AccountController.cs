using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using QuestRooms.DAL.Entities;
using QuestRooms.UI.App_Start;
using QuestRooms.UI.Models;
using QuestRooms.UI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace QuestRooms.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserRegisterModel model) {
            RegisterResult @out = new RegisterResult { result = false};

            PasswordError err;

            if ((model.Email ?? "").Length < 1) @out.err_msg = "Pleause input email!";
            else if (!Validator.EmailIsValid(model.Email)) @out.err_msg = "Incorrect email!";
            else if (UserManager.FindByEmail(model.Email) != null)  @out.err_msg = "User with this email is already registered!";
            else if ((model.Password ?? "").Length < 1) @out.err_msg = "Pleause input password!";
            else if (!Validator.PasswordIsValid(model.Password, out err))
            {
                switch (err)
                {
                    case PasswordError.Length:
                        @out.err_msg = "Minimum 6 symbols, maximum 12 symbols";
                        break;
                    case PasswordError.Whitespace:
                        @out.err_msg = "No white space";
                        break;
                    case PasswordError.Upper:
                        @out.err_msg = "At least 1 upper case letter";
                        break;
                    case PasswordError.Lover:
                        @out.err_msg = "At least 1 lower case letter";
                        break;
                    case PasswordError.SpecificSymbol:
                        @out.err_msg = "At least 1 special char";
                        break;
                    default:
                        @out.err_msg = "ERROR";
                        break;
                }
            }
            else if ((model.RepeatPassword ?? "").Length < 1) @out.err_msg = "Pleause repeat password!";
            else if (model.Password != model.RepeatPassword) @out.err_msg = "Incorrect repeat password!";
            else {
               
                AppUser user = new AppUser { Email = model.Email, UserName = model.Email };
                IdentityResult hs = UserManager.Create(user, model.Password);
                if (hs.Succeeded) {
                    ClaimsIdentity claim = UserManager.CreateIdentity(user,
                             DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    @out.result = true;
                }
                else @out.err_msg = "ERROR";
            }
            return Json(@out);
        }

        public RedirectToRouteResult LogOut() {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "QuestRooms");
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLogInModel model)
        {
            LogInResult @out = new LogInResult { result = false };

            PasswordError err;

            if ((model.Email ?? "").Length < 1) @out.err_msg = "Pleause input email!";
            else if (!Validator.EmailIsValid(model.Email)) @out.err_msg = "Incorrect email!";
            else if ((model.Password ?? "").Length < 1) @out.err_msg = "Pleause input password!";
            else if (!Validator.PasswordIsValid(model.Password, out err))
            {
                switch (err)
                {
                    case PasswordError.Length:
                        @out.err_msg = "Minimum 6 symbols, maximum 12 symbols";
                        break;
                    case PasswordError.Whitespace:
                        @out.err_msg = "No white space";
                        break;
                    case PasswordError.Upper:
                        @out.err_msg = "At least 1 upper case letter";
                        break;
                    case PasswordError.Lover:
                        @out.err_msg = "At least 1 lower case letter";
                        break;
                    case PasswordError.SpecificSymbol:
                        @out.err_msg = "At least 1 special char";
                        break;
                    default:
                        @out.err_msg = "ERROR";
                        break;
                }
            }
            else {
                AppUser user = UserManager.Find(model.Email, model.Password);
                if (user != null) {
                    ClaimsIdentity claim = UserManager.CreateIdentity(user,
                                    DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    @out.result = true;
                }
                else @out.err_msg = "Incorrect password or login";
            }
            return Json(@out);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private AppUserManager _userManager;

        public AppUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}