using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebApplicationBRXT.Controller;

namespace WebApplicationBRXT
{
    /// <summary>
    /// MainPage 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://brxteducation.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class MainPage : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string Login(String username, String password)
        {
            BmobMyUser testBmob = new BmobMyUser();
            String testString = testBmob.LoginFun(username, password);
            return testString;
        }

        [WebMethod]
        public string Register(String username, String password)
        {
            BmobMyUser testBmob = new BmobMyUser();
            String testString = testBmob.RegFun(username, password);
            return testString;
        }
    }
}