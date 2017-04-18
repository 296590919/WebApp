using Common;
using Cooperation.Service.Interface.api;

namespace Cooperation.Service.Impl.api
{
    public class ApiService : IApiService
    {
        public bool CheckKey(string key)
        {
            //C4CA4238A0B923820DCC509A6F75849B
            if (key == Security.GetMD5("1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
