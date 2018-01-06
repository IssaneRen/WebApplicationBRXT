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

        //1.MyUser部分
        //1.1. 用户注册
        [WebMethod]
        public string Register(String username, String password)
        {
            BmobMyUser testBmob = new BmobMyUser();
            String testString = testBmob.RegFun(username, password);
            return testString;
        }
        //1.2. 用户登录
        [WebMethod]
        public string Login(String username, String password)
        {
            BmobMyUser testBmob = new BmobMyUser();
            String testString = testBmob.LoginFun(username, password);
            return testString;
        }
        //1.3. 用户信息获取（通过objectId)
        [WebMethod]
        public string GetUserInfoById(String objectId)
        {
            BmobMyUser bmobMyUser = new BmobMyUser();
            String resultString = bmobMyUser.GetPersonalInfoById(objectId);
            return resultString;
        }
        //1.4. 用户信息获取（通过username)
        [WebMethod]
        public string GetUserInfoByName(String name)
        {
            BmobMyUser bmobMyUser = new BmobMyUser();
            String resultString = bmobMyUser.GetPersonalInfoByName(name);
            return resultString;
        }
        //1.5. 用户信息修改（全部参数）
        [WebMethod]
        public string UpdateUserInfo(String objectId, int period, String grade, String avatarurl)
        {
            BmobMyUser bmobMyUser = new BmobMyUser();
            String resultString = bmobMyUser.UpdatePersonalInfo(objectId, period, grade, avatarurl);
            return resultString;
        }
        //1.6. 用户信息修改（单独参数）
        [WebMethod]
        public string UpdateUserSpecificInfo(String objectId, String infoname, String newinfo)
        {
            BmobMyUser bmobMyUser = new BmobMyUser();
            String resultString = bmobMyUser.UpdatePersonalSpecificInfo(objectId,infoname, newinfo);
            return resultString;
        }

        //2.News部分
        //2.1. 增加新闻
        [WebMethod]
        public string InsertNews(String newstitle, String newssummary, String coverurl)
        {
            BmobNews bmobNews = new BmobNews();
            String resultString = bmobNews.InsertNews(newstitle, newssummary, coverurl);
            return resultString;
        }
        //2.2. 删除新闻
        [WebMethod]
        public string DeleteNews(String objectId)
        {
            BmobNews bmobNews = new BmobNews();
            String resultString = bmobNews.DeleteNews(objectId);
            return resultString;
        }
        //2.3. 修改新闻
        [WebMethod]
        public string UpdateNews(String objectId, String infoname, String newinfo)
        {
            BmobNews bmobNews = new BmobNews();
            String resultString = bmobNews.UpdateNews(objectId, infoname, newinfo);
            return resultString;
        }
        //2.4. 查询新闻
        [WebMethod]
        public string SearchNews(String newstitle)
        {
            BmobNews bmobNews = new BmobNews();
            String resultString = bmobNews.SearchNews(newstitle);
            return resultString;
        }

        //3.QuestionBank部分
        //3.1. 增加新题目
        //3.2. 删除旧题目
        //3.3. 修改某题目
        //3.4. 查询某个题目内容
        //4.LiveClass部分
        //4.1. 增加自习教室
        //4.2. 删除自习教室
        //4.3. 修改自习教室信息
        //4.4. 查询自习教室信息


        //[WebMethod]
        //public string UploadExamAndAnswer(String examurl, String answerurl)
        //{
        //    BmobQuestionBank bmobQuestionBank = new BmobQuestionBank();
        //    String resultString = "";//bmobQuestionBank.Upload(examurl, answerurl);
        //    return resultString;
        //}

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