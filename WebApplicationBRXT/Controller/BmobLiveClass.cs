using cn.bmob.http;
using cn.bmob.io;
using cn.bmob.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationBRXT.Model;

namespace WebApplicationBRXT.Controller
{
    public class BmobLiveClass : BmobBase
    {
        //对应要操作的数据表
        public const String TABLE_NAME = "Live_Class";
        public BmobLiveClass() :
            base()
        {

        }
        
        //插入数据 包括全部需要的属性
        public String InsertLiveClass(String url, BmobDate startTime, String profName, String profIntro)
        {
            LiveClassObject liveClassObject = new LiveClassObject(TABLE_NAME)
            {
                url = url,
                startTime = startTime,
                profName = profName,
                profIntro = profIntro
            };

            var future = Bmob.CreateTaskAsync(liveClassObject);

            // ！！！ 直接获取异步对象结果会阻塞主线程！ 建议使用async + await/callback的形式， 可以参考文件上传功能的实现。
            //获取创建记录的objectId
            liveClassObject.objectId = future.Result.objectId;

            //结果反馈，作为返回值
            String insertResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);

            return insertResult;
        }
        //插入数据 包括在线课堂的 url 老师名字 和老师的信息
        public String InsertLiveClass(String url, String profName, String profIntro)
        {
            LiveClassObject liveClassObject = new LiveClassObject(TABLE_NAME)
            {
                url = url,
                profName = profName,
                profIntro = profIntro
            };

            var future = Bmob.CreateTaskAsync(liveClassObject);

            // ！！！ 直接获取异步对象结果会阻塞主线程！ 建议使用async + await/callback的形式， 可以参考文件上传功能的实现。
            //获取创建记录的objectId
            liveClassObject.objectId = future.Result.objectId;

            //结果反馈，作为返回值
            String insertResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);

            return insertResult;
        }

        //删除数据 给定objectId删除相对应的LiveClass
        public String DeleteLiveClass(String objectId)
        {
            //删除一条记录
            var future = Bmob.DeleteTaskAsync(TABLE_NAME, objectId);
            String queryResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);

            return queryResult;
        }

        //修改数据 输入objectId获取对应的一行数据，并且输入新的url, startTime, profName以及profIntro
        public String UpdateLiveClass(String objectId, String url, BmobDate startTime, String profName, String profIntro)
        {
            LiveClassObject liveClassObject = new LiveClassObject();
            liveClassObject.objectId = objectId;
            liveClassObject.url = url;
            liveClassObject.startTime = startTime;
            liveClassObject.profName = profName;
            liveClassObject.profIntro = profIntro;

            //更新记录
            //var future = Bmob.UpdateTaskAsync<LiveClassObject>(liveClassObject);
            String result = "";
            Bmob.Update(TABLE_NAME, objectId, liveClassObject, (resp, exception) =>
            {
                if (exception != null)
                {
                    result = ("修改失败, 失败原因为： " + exception.Message);
                }
            });
            result = JsonAdapter.JSON.ToDebugJsonString(liveClassObject);
            return result;
        }

        //查询数据 输入老师名字查询老师的全部课程
        public String SearchLiveClass(String profName)
        {
            //查找表中的全部数据（默认最多返回10条数据）
            var query = new BmobQuery();
            query.WhereContainedIn<string>("profName", profName);
            var future = Bmob.FindTaskAsync<LiveClassObject>(TABLE_NAME, query);
            String queryResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);

            return queryResult;
        }
    }
}