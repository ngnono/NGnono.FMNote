using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.Models.Enums;
using NGnono.FMNote.Repository;
using NGnono.FMNote.WebSite4App.Core.Models.DTO.Account;
using NGnono.FMNote.WebSite4App.Core.Models.ViewModel;
using NGnono.FMNote.WebSupport.Models;
using NGnono.FMNote.WebSupport.Mvc.Controllers;
using NGnono.FMNote.WebSupport.Mvc.Filters;
using NGnono.Framework.Models;
using NGnono.Framework.Security.Cryptography;
using System;
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
            var userEntity = ServiceInvoke(unitOfWork => unitOfWork.UserRepository.Get(v =>
                                                                                  String.Compare(v.Name, userName,
                                                                                                 StringComparison.OrdinalIgnoreCase) == 0)
                                                              .FirstOrDefault());


            if (userEntity == null)
            {
                return null;
            }

            return PwdSecurityHelper.CheckEqual(password, userEntity.Password) ? userEntity : null;

        }

        private string SetPassword(int userId, string newPwd, string oldPwd)
        {
            return ServiceInvoke(unitOfWork =>
                {
                    var userEntity = unitOfWork.UserRepository.Get(v => v.Id == userId).FirstOrDefault();
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

                    unitOfWork.UserRepository.Update(userEntity);

                    return null;
                });


            //using (UnitOfWork)
            //{
            //    var userEntity = UnitOfWork.UserRepository.Get(v => v.Id == userId).FirstOrDefault();
            //    if (userEntity == null)
            //    {
            //        return "用户未找到";
            //    }

            //    if (PwdSecurityHelper.CheckEqual(oldPwd, userEntity.Password))
            //    {
            //        userEntity.Password = PwdSecurityHelper.ComputeHash(newPwd);
            //        userEntity.UpdatedDate = DateTime.Now;
            //    }
            //    else
            //    {
            //        return "原密码错";
            //    }

            //    UnitOfWork.UserRepository.Update(userEntity);
            //}

            //return null;
        }


        internal struct MethodResult<T, TCode, TMsg>
        {
            public T Data { get; set; }

            public TCode StatusCode { get; set; }

            public TMsg Message { get; set; }

            public bool IsSuccess { get; set; }
        }

        private MethodResult<UserEntity, int, string> InsertUser(UserEntity user)
        {
            var result = new MethodResult<UserEntity, int, string>();

            //check user name
            ServiceInvoke<IFMNoteEFUnitOfWork>(v =>
                {
                    //1 check
                    //2 insert
                    var checkUserName =
                        v.UserRepository.Get(g => String.Compare(g.Name, user.Name, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault() == null;

                    if (!checkUserName)
                    {
                        result.StatusCode = 2;
                        result.Message = "用户名已存在，请换个名字！";
                        result.Data = null;
                    }
                    else
                    {
                        user.Password = PwdSecurityHelper.ComputeHash(user.Password);

                        result.Data = v.UserRepository.Insert(user);
                        result.IsSuccess = true;
                        result.StatusCode = 1;
                    }
                });

            return result;
            //return ExecFunc(v => v.UserRepository.Insert(user));

            //return ItemSetter(user, (unitOfWork, userEntity) => unitOfWork.UserRepository.Insert(userEntity));

            //using (UnitOfWork)
            //{
            //    user.Password = PwdSecurityHelper.ComputeHash(user.Password);
            //    var userEntity = UnitOfWork.UserRepository.Insert(user);

            //    return userEntity;
            //}
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

            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection, LoginViewModel model, string returnUrl)
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
        public ActionResult ChangePassword(FormCollection formCollection, ChangePasswordViewModel viewModel)
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
        public ActionResult Register(FormCollection formCollection, RegisterViewModel viewModel, string returnUrl)
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

                var result = InsertUser(tempUserEntity);

                if (result.IsSuccess)
                {
                    //写认证
                    SetAuthorize(new WebSiteUser(result.Data.Name, result.Data.Id, result.Data.ScreenName));

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("username", "用户名已经存在,请换个新名称！");
                }
            }

            ModelState.AddModelError("", "验证错误.");

            return View(viewModel);
        }


    }
}
