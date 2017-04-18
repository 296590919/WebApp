using Common;
using Cooperation.DTO.Login;
using Cooperation.Service.Interface.Login;
using Cooperation.Web.Models;
using Framework.IoC;
using System;
using System.Web.Mvc;
using Common.DTO;

namespace Cooperation.Web.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 展示登录页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// cookie验证
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckLogin(LoginModel loginInfo)
        {
            Result<UserInfoDTO> result;
            var svc = LocalServiceLocator.GetService<IPassportService>();

            if (loginInfo.action == "login")
            {
                result = svc.CheckLogin(loginInfo.userName, loginInfo.password);
            }
            else if (loginInfo.action == "check")
            {
                result = svc.CheckUser(loginInfo.passport);
            }
            else
            {
                result = new Result<UserInfoDTO>()
                {
                    IsSuccess = false,
                    ReturnMessage = "不能识别的操作"
                };
            }
            return new JsonResult() { Data = result };
        }

        [HttpPost]
        public JsonResult Register(RegisterDTO registerInfo)
        {
            return new JsonResult()
            {
                Data = LocalServiceLocator.GetService<IPassportService>().Register(registerInfo)
            };
        }

    }
}