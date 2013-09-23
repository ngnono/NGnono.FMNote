using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.Models.Enums;
using NGnono.FMNote.WebSite4App.Core.Models.DTO.Account;
using NGnono.FMNote.WebSite4App.Core.Models.VO;
using NGnono.FMNote.WebSupport.Models;
using NGnono.FMNote.WebSupport.Mvc.Controllers;
using NGnono.FMNote.WebSupport.Mvc.Filters;
using NGnono.Framework.Security.Cryptography;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace NGnono.FMNote.WebSite4App.Core.Controllers
{
    public class AccountController : UserController
    {
        #region .ctor

        public AccountController()
        {
        }

        #endregion

        #region methods

        private UserEntity CheckUser(string userName, string password)
        {
            using (UnitOfWork)
            {
                var userEntity = UnitOfWork.UserRepository.Get(v =>
                            String.Compare(v.Name, userName, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();

                if (userEntity == null)
                {
                    return null;
                }

                return PwdSecurityHelper.CheckEqual(password, userEntity.Password) ? userEntity : null;
            }
        }

        private string SetPassword(int userId, string newPwd, string oldPwd)
        {
            using (UnitOfWork)
            {
                var userEntity = UnitOfWork.UserRepository.Get(v => v.Id == userId).FirstOrDefault();
                if (userEntity == null)
                {
                    return "用户未找到";
                }

                if (PwdSecurityHelper.CheckEqual(oldPwd, userEntity.Password))
                {
                    userEntity.Password = PwdSecurityHelper.ComputeHash(newPwd);
                    userEntity.UpdatedDate = DateTime.Now;
                }
                else
                {
                    return "原密码错";
                }

                UnitOfWork.UserRepository.Update(userEntity);
            }

            return null;
        }

        private UserEntity InsertUser(UserEntity user)
        {
            using (UnitOfWork)
            {
                user.Password = PwdSecurityHelper.ComputeHash(user.Password);
                var userEntity = UnitOfWork.UserRepository.Insert(user);

                return userEntity;
            }
        }

        #endregion

        [LoginAuthorize]
        public ActionResult Index()
        {
            var vo = new IndexDTO { ShowName = CurrentUser.ShowName };

            return View(vo);
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View(new LoginVO());
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection, LoginVO model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userModel = CheckUser(model.UserName, model.Password);

                if (userModel == null)
                {
                    ModelState.AddModelError("", "用户名或密码错误.");
                }
                else
                {
                    //写认证
                    SetAuthorize(new WebSiteUser(userModel.Name, userModel.Id, userModel.ScreenName));

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

        public ActionResult LogOff()
        {
            Signout();

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
                var msg = SetPassword(CurrentUser.CustomerId, viewModel.NewPassword, viewModel.OldPassword);


                if (String.IsNullOrEmpty(msg))
                {
                    return View("ChangePasswordSuccess");
                }

                ModelState.AddModelError("", msg);
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
                var tempUserEntity = new UserEntity
                    {
                        Status = (int)DataStatus.Normal,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        //CreatedUser = CurrentUser.CustomerId,
                        //UpdatedUser = CurrentUser.CustomerId,
                        Description = String.Empty,
                        EMail = viewModel.Email,
                        Gender = 0,
                        LastLoginDate = DateTime.Now,
                        Logo = String.Empty,
                        Mobile = String.Empty,
                        Name = viewModel.UserName,
                        Password = viewModel.Password,
                        ScreenName = viewModel.ScreenName,

                        UserLevel = (int)UserLevel.User
                    };

                var userEntity = InsertUser(tempUserEntity);

                //写认证
                SetAuthorize(new WebSiteUser(userEntity.Name, userEntity.Id, userEntity.ScreenName));

                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "验证错误.");

            return View(viewModel);
        }
    }
}
