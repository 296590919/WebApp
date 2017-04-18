using Common;
using Common.DTO;
using Cooperation.DTO.Login;

namespace Cooperation.Service.Interface.Login
{
    public interface IPassportService
    {
        Result<UserInfoDTO> CheckLogin(string userName, string password);
        Result<UserInfoDTO> CheckUser(string passport);
        Result<UserInfoDTO> GetUserObj(int userID);
        Result<int> Register(RegisterDTO registerInfo);
    }
}
