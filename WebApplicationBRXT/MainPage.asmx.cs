using cn.bmob.io;
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

        [WebMethod]
        public string SearchNews(String newstitle)
        {
            BmobNews bmobNews = new BmobNews();
            String resultString = bmobNews.SearchNews(newstitle);
            return resultString;
        }

        [WebMethod]
        public string InsertNews(String newstitle, String newssummary)
        {
            BmobNews bmobNews = new BmobNews();
            String resultString = bmobNews.InsertNews(newstitle, newssummary);
            return resultString;
        }

        [WebMethod]
        public string UploadExamAndAnswer(String examurl, String answerurl)
        {
            BmobQuestionBank bmobQuestionBank = new BmobQuestionBank();
            String resultString = bmobQuestionBank.Upload(examurl, answerurl);
            return resultString;
        }

        [WebMethod]
        public string InsertLiveClass(String url, DateTime startTime, String profName, String profIntro)
        {
            BmobLiveClass bmobLiveClass = new BmobLiveClass();
            String resultString = bmobLiveClass.InsertLiveClass(url, startTime, profName, profIntro);
            return resultString;
        }
        [WebMethod]
        public String DeleteLiveClass(String objectId)
        {
            BmobLiveClass bmobLiveClass = new BmobLiveClass();
            String resultString = bmobLiveClass.DeleteLiveClass(objectId);
            return resultString;
        }
        [WebMethod]
        public String UpdateLiveClass(String objectId, String url, DateTime startTime, String profName, String profIntro)
        {
            BmobLiveClass bmobLiveClass = new BmobLiveClass();
            String resultString = bmobLiveClass.UpdateLiveClass(objectId, url, startTime, profName, profIntro);
            return resultString;
        }
        [WebMethod]
        public string SearchLiveClass(String profName)
        {
            BmobLiveClass bmobLiveClass = new BmobLiveClass();
            String resultString = bmobLiveClass.SearchLiveClass(profName);
            return resultString;
        }
    }
}