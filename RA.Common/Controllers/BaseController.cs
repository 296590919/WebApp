using System.Web;
using System.Web.Mvc;
using Common.DTO;

namespace Common.Controllers
{
    public abstract class BaseController : Controller
    {
        protected UserInfoDTO UserObj => Serializer.Deserialize<UserInfoDTO>(HttpUtility.UrlDecode(Request.Cookies["userObj"].Value));
    }
}