using cn.bmob.io;
using cn.bmob.json;
using System;
using WebApplicationBRXT.Model;

namespace WebApplicationBRXT.Controller
{
    public class BmobMyUser : BmobBase
    {
        //对应要操作的数据表
        public const String TABLE_NAME = "_User";
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
            if (username == "")
                return "Exception: username is illegal.(201)";
            //注册用户
            MyUserObject user = new MyUserObject();
            user.username = username;
            user.password = password;
            initMyUserObject(user);
            var future = Bmob.CreateTaskAsync<MyUserObject>(user);
            String regTestResult;
            try
            {
                regTestResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);
            }
            catch
            {
                return (future.Exception.InnerException.ToString());
            }
            return regTestResult;
        }

        //初始化某个MyUserObject
        private void initMyUserObject(MyUserObject myUserObject)
        {
            //初始化信息 period = 0, grade = "研三", avatarurl = "http://bmob-cdn-16020.b0.upaiyun.com/2018/01/04/33f7ddc24082f0d780a7e97e618d039a.jpg"
            myUserObject.period = 0;
            myUserObject.grade = "研三";
            myUserObject.avatar = new BmobFile()
            {
                filename = myUserObject.username + "Avatar.jpg",
                url = "http://bmob-cdn-16020.b0.upaiyun.com/2018/01/04/33f7ddc24082f0d780a7e97e618d039a.jpg"
            };
        }

        //通过用户名获取个人额外信息
        public String GetPersonalInfoByName(String username)
        {
            MyUserObject user = new MyUserObject();
            var query = new BmobQuery();
            query.WhereContainedIn<string>("username", username);
            var future = Bmob.FindTaskAsync<MyUserObject>(TABLE_NAME, query);
            String queryResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);

            return queryResult;
        }
        //通过用户ID获取个人信息
        public String GetPersonalInfoById(String objectId)
        {
            var query = new BmobQuery();
            query.WhereContainedIn<String>("objectId", objectId);
            var future = Bmob.FindTaskAsync<MyUserObject>(TABLE_NAME, query);
            String queryResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);

            return queryResult;
        }

        //通过用户ID修改个人额外信息
        public String UpdatePersonalInfo(String objectId, BmobInt period, String grade, String avatarurl)
        {
            MyUserObject myUserObject = new MyUserObject();
            //更新内容
            myUserObject.period = period;
            myUserObject.grade = grade;
            //处理avatar
            BmobFile avatar = new BmobFile();
            avatar.filename = myUserObject.username + "Avatar";
            avatar.url = avatarurl;
            myUserObject.avatar = avatar;
            Bmob.Update(TABLE_NAME, objectId, myUserObject, (resp, exception) =>
            {
                if (exception != null)
                {
                   return;
                }
                return;
            });
            var result = JsonAdapter.JSON.ToDebugJsonString(myUserObject);
            return result;
        }
        //通过用户ID修改某个特定的个人额外信息
        public String UpdatePersonalSpecificInfo(String objectId, String infoname, String newinfo)
        {
            //新建对象准备修改
            MyUserObject myUserObject = new MyUserObject();
            String result = "";
            //搜索原有结果
            var query = new BmobQuery();
            query.WhereContainedIn<String>("objectId", objectId);
            var future = Bmob.FindTaskAsync<MyUserObject>(TABLE_NAME, query);
            //将原有参数赋值
            //myUserObject = future.Result;

            switch (infoname)
            {
                case "period":
                    int period = int.Parse(newinfo);
                    myUserObject.period = period;
                    break;
                case "grade":
                    myUserObject.grade = newinfo;
                    break;
                case "avatar":
                    //处理avatar
                    BmobFile avatar = new BmobFile();
                    avatar.filename = myUserObject.username + "Avatar";
                    avatar.url = newinfo;
                    myUserObject.avatar = avatar;
                    break;
                default:
                    result = "Wrong infoname";
                    break;
            }
            //将新的对象更新到数据库
            Bmob.Update(TABLE_NAME, objectId, myUserObject, (resp, exception) =>
            {
                if (exception != null)
                {
                    return;
                }
                return;
            });
            result = JsonAdapter.JSON.ToDebugJsonString(myUserObject);
            return result;
        }
    }
}