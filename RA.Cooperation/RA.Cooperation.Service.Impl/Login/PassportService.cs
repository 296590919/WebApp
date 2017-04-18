using Common;
using Common.DTO;
using Cooperation.DTO.Login;
using Cooperation.Entity.Login;
using Cooperation.Service.Interface.Login;
using DataAccess;

namespace Cooperation.Service.Impl.Login
{
    public class PassportService : IPassportService
    {
        public Result<UserInfoDTO> CheckLogin(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return new Result<UserInfoDTO>()
                {
                    IsSuccess = false,
                    ReturnMessage = "登录失败，用户名或密码不能为空"
                };
            }
            var userInfo = DbUtilityFactory.GetDbUtility().GetSingle<UserEntity>(a => a.userName == userName);
            var passwordMd5 = Security.GetMD5(password);
            if (userInfo == null || userInfo.passwordMd5 != passwordMd5)
            {
                return new Result<UserInfoDTO>()
                {
                    IsSuccess = false,
                    ReturnMessage = "登录失败，用户名或密码错误"
                };
            }
            else
            {
                return new Result<UserInfoDTO>()
                {
                    IsSuccess = true,
                    ReturnMessage = "成功",
                    ReturnValue = new UserInfoDTO()
                    {
                        cookiePassport = userInfo.userNameMd5 + userInfo.passwordMd5,
                        userName = userName,
                        userID = userInfo.userID,
                        userLevel = userInfo.userLevel,
                        nickName = userInfo.nickName
                    }
                };
            }
        }

        public Result<UserInfoDTO> CheckUser(string passport)
        {
            var userNameMd5 = passport.Substring(0, 32);
            var passwordMd5 = passport.Substring(32);
            var userInfo = DbUtilityFactory.GetDbUtility().GetSingle<UserEntity>(a => a.userNameMd5 == userNameMd5);
            if (userInfo != null && userInfo.passwordMd5 == passwordMd5)
            {
                return new Result<UserInfoDTO>()
                {
                    IsSuccess = true,
                    ReturnValue = new UserInfoDTO()
                    {
                        cookiePassport = userInfo.userNameMd5 + userInfo.passwordMd5,
                        userName = userInfo.userName,
                        userID = userInfo.userID,
                        userLevel = userInfo.userLevel,
                        nickName = userInfo.nickName
                    }
                };
            }
            else
            {
                return new Result<UserInfoDTO>()
                {
                    IsSuccess = false,
                    ReturnMessage = "登录失效，请重新登录"
                };
            }
        }

        public Result<UserInfoDTO> GetUserObj(int userID)
        {
            var userInfo = DbUtilityFactory.GetDbUtility().GetSingle<UserEntity>(a => a.userID == userID);
            if (userID != 0 && userInfo != null)
            {
                return new Result<UserInfoDTO>()
                {
                    IsSuccess = true,
                    ReturnValue = new UserInfoDTO()
                    {
                        nickName = userInfo.nickName,
                        userID = userInfo.userID,
                        userLevel = userInfo.userLevel,
                        userName = userInfo.userName
                    }
                };
            }
            else
            {
                return new Result<UserInfoDTO>()
                {
                    IsSuccess = false,
                    ReturnMessage = "没有找到此userID的记录"
                };
            }
        }

        public Result<int> Register(RegisterDTO registerInfo)
        {
            #region 参数判断
            if (string.IsNullOrEmpty(registerInfo.nickName))
            {
                return new Result<int>()
                {
                    IsSuccess = false,
                    ReturnMessage = "昵称不能为空",
                };
            }
            if (string.IsNullOrEmpty(registerInfo.userName))
            {
                return new Result<int>()
                {
                    IsSuccess = false,
                    ReturnMessage = "用户名不能为空",
                };
            }
            if (string.IsNullOrEmpty(registerInfo.password))
            {
                return new Result<int>()
                {
                    IsSuccess = false,
                    ReturnMessage = "密码不能为空",
                };
            }
            #endregion
            #region 判重
            var data = DbUtilityFactory.GetDbUtility().GetSingle<UserEntity>(a => a.userName == registerInfo.userName);
            if (data != null)
            {
                return new Result<int>()
                {
                    IsSuccess = false,
                    ReturnMessage = "该用户名已存在"
                };
            }
            #endregion
            var user = new UserEntity()
            {
                nickName = registerInfo.nickName,
                userLevel = 1,
                userName = registerInfo.userName,
                passwordMd5 = Security.GetMD5(registerInfo.password),
                userNameMd5 = Security.GetMD5(registerInfo.userName)
            };
            return new Result<int>()
            {
                IsSuccess = true,
                ReturnMessage = "注册成功",
                ReturnValue = DbUtilityFactory.GetDbUtility().Add<UserEntity>(user)
            };
        }

    }
}
