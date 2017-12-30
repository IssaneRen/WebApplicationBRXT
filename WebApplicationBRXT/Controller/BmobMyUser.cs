using cn.bmob.io;
using cn.bmob.json;
using System;
using WebApplicationBRXT.Model;

namespace WebApplicationBRXT.Controller
{
    public class BmobMyUser : BmobBase
    {
        public BmobMyUser() : 
            base()
        {
            
        }

        public String LoginFun(String username, String password)
        {
            //登录用户
            var future = Bmob.LoginTaskAsync<BmobUser>(username,password);
            String loginTestResult;
            try
            {
                loginTestResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);
            }
            catch
            {
                return ("登录失败，原因：" + future.Exception.InnerException.ToString());
            }
            return loginTestResult;
        }

        public String RegFun(String username, String password)
        {

            //注册用户
            MyUserObject user = new MyUserObject();
            user.username = username;
            user.password = password;
            var future = Bmob.CreateTaskAsync<MyUserObject>(user);
            String regTestResult;
            try
            {
                regTestResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);
            }
            catch
            {
                return ("注册失败，原因：" + future.Exception.InnerException.ToString());
            }
            return regTestResult;
        }

        //TEST
        //public String loginTest()
        //{
        //    //登录用户
        //    var future = Bmob.LoginTaskAsync<BmobUser>("a", "a");
        //    String loginTestResult;
        //    try
        //    {
        //        loginTestResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);
        //    }
        //    catch
        //    {
        //        return ("登录失败，原因：" + future.Exception.InnerException.ToString());
        //    }
        //    return loginTestResult;
        //}

        //public String regTest()
        //{
        //    //注册用户
        //    MyUserObject user = new MyUserObject();
        //    user.username = "testUserReg1227";
        //    user.password = "test1227";
        //    //user.sex = new BmobBoolean(false);
        //    //user.age = 50;
        //    var future = Bmob.CreateTaskAsync<MyUserObject>(user);
        //    String regTestResult;
        //    try
        //    {
        //        regTestResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);
        //    }
        //    catch
        //    {
        //        return ("注册失败，原因：" + future.Exception.InnerException.ToString());
        //    }
        //    return regTestResult;
        //}
    }
}