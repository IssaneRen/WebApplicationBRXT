using cn.bmob.io;
using cn.bmob.json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationBRXT.Model;

namespace WebApplicationBRXT.Controller
{
    public class BmobNews : BmobBase
    {
        //对应要操作的数据表
        public const String TABLE_NAME = "News";
        public BmobNews() :
            base()
        {

        }

        //以Title搜索News
        public String SearchNews(String newsTitle)
        {
            //查找表中的全部数据（默认最多返回10条数据）
            var query = new BmobQuery();
            query.WhereContainedIn<string>("title", newsTitle);
            var future = Bmob.FindTaskAsync<NewsObject>(TABLE_NAME, query);
            String queryResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);

            return queryResult;
        }

        //添加新闻到数据库中
        public String InsertNews(String newsTitle, String newsSummary)
        {
            //接下来要操作的数据的数据
            NewsObject newsObject = new NewsObject(TABLE_NAME);
            ///设置值    
            /////System.Random rnd = new System.Random();
            //NewsObject.point = "201712271401";
            newsObject.title = newsTitle;
            newsObject.summary = newsSummary;
            //NewsObject.cheatMode = false;

            //保存数据
            var future = Bmob.CreateTaskAsync(newsObject);

            // ！！！ 直接获取异步对象结果会阻塞主线程！ 建议使用async + await/callback的形式， 可以参考文件上传功能的实现。
            //获取创建记录的objectId
            newsObject.objectId = future.Result.objectId;

            //结果反馈，作为返回值
            String insertResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);

            return insertResult;
        }
    }
}