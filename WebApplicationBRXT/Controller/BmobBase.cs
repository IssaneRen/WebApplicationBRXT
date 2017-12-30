using cn.bmob.api;
using cn.bmob.tools;
using System.Diagnostics;

namespace WebApplicationBRXT.Controller
{
    public class BmobBase
    {
        private BmobWindows bmob;

        public BmobWindows Bmob
        {
            get { return bmob; }
        }
        
        ////对应要操作的数据表[理论上Base中应该为空]
        //public const String TABLE_NAME = "Attraction";
        ////接下来要操作的数据的数据
        //private AttractionObject attractionObject = new AttractionObject(TABLE_NAME);

        //public String createDataTest()
        //{
        //    //设置值    
        //    //System.Random rnd = new System.Random();
        //    attractionObject.point = "1234567";
        //    attractionObject.name = "myOwnTest";
        //    attractionObject.createdAt = DateTime.Now;
        //    attractionObject.updatedAt = DateTime.Now;

        //    //保存数据
        //    var future = Bmob.CreateTaskAsync(attractionObject);
        //    //异步显示返回的数据
        //    String createResult;
        //    createResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);
        //    //FinishedCallback(future.Result, resultText);
        //    return createResult;
        //}

        public BmobBase()
        {
            bmob = new BmobWindows();

            //初始化，这个ApplicationId/RestKey需要更改为你自己的ApplicationId/RestKey（ http://www.bmob.cn 上注册登录之后，创建应用可获取到ApplicationId/RestKey）
            Bmob.initialize("cb514de4bc8f7e90521a9683862da28f", "4c7658cf792ea770e2bea6801151fc06");

            //注册调试工具
            BmobDebug.Register(msg => { Debug.WriteLine(msg); });

            //测试添加一行my own test
            //createDataTest();

        }

    }
}