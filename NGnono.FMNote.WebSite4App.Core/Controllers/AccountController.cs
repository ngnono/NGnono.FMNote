using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.Repository;
using NGnono.FMNote.WebSite4App.Core.Models.VO;
using NGnono.FMNote.WebSupport.Models;
using NGnono.FMNote.WebSupport.Mvc.Controllers;
using NGnono.FMNote.WebSupport.Mvc.Filters;
using System;
using System.Web.Mvc;
using System.Linq;

namespace NGnono.FMNote.WebSite4App.Core.Controllers
{
    public class AccountController : UserController
    {
        private IFMNoteEFUnitOfWork _unitOfWork;

        public AccountController(IFMNoteEFUnitOfWork efUnitOfWork)
        {
            _unitOfWork = efUnitOfWork;
        }

        [LoginAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View(new LoginVO());
        }

        ////
        //// POST: /Account/Login

        [HttpPost]
        public ActionResult Login(FormCollection formCollection, LoginVO model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userModel =
                    _unitOfWork.UserRepository.Get(
                        v =>
                        String.Compare(v.Name, model.UserName, System.StringComparison.OrdinalIgnoreCase) == 0 &&
                        String.CompareOrdinal(v.Password, model.Password) == 0).FirstOrDefault();

                if (userModel == null)
                {
                    ModelState.AddModelError("", "用户名或密码错误.");
                }
                else
                {
                    //写认证
                    SetAuthorize(new WebSiteUser(userModel.Name, userModel.Id, userModel.Petname));

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Account");
                }
            }
            else
            {
                ModelState.AddModelError("", "参数验证失败.");
            }

            return View(model);
        }

        ////
        //// POST: /Account/LogOff

        public ActionResult LogOut()
        {
            base.Signout();

            return RedirectToAction("Index", "Home");
        }

        [LoginAuthorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [LoginAuthorize]
        public ActionResult ChangePassword(FormCollection formCollection, ChangePasswordVO viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_userService.SetPassword(CurrentUser.CustomerId, viewModel.OldPassword, viewModel.NewPassword))
                {
                    return View("ChangePasswordSuccess");
                }

                ModelState.AddModelError("", "OldPassword 错误.");
            }
            else
            {
                ModelState.AddModelError("", "验证错误.");
            }

            return View(viewModel);
        }

        ////
        //// GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        ////
        //// GET: /Account/Register
        [HttpPost]
        public ActionResult Register(FormCollection formCollection, RegisterVO viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userEntity = new UserEntity();
                userEntity.CreatedDate = DateTime.Now;
                userEntity.UpdatedDate = DateTime.Now;
                userEntity.Description = String.Empty;
                userEntity.EMail = viewModel.Email;
                userEntity.Gender = 0;
                userEntity.LastLoginDate = DateTime.Now;
                userEntity.Logo = String.Empty;
                userEntity.Mobile = String.Empty;
                userEntity.Name = viewModel.UserName;
                userEntity.Password = viewModel.Password;
                userEntity.Petname = viewModel.Nickname;
                userEntity.Status = (int)DataStatus.Normal;
                userEntity.UserLevel = (int)UserLevel.User;

                var e = _customerRepository.Insert(userEntity);

                //写认证
                SetAuthorize(new WebSiteUser(e.Name, e.Id, e.Nickname, UserRole.User));

                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "验证错误.");
            }

            return View(viewModel);
        }
    }
}
