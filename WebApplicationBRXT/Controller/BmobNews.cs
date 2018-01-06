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
        public String InsertNews(String newsTitle, String newsSummary, String coverurl)
        {
            //接下来要操作的数据的数据
            NewsObject newsObject = new NewsObject(TABLE_NAME);
            ///设置值    
            newsObject.title = newsTitle;
            newsObject.summary = newsSummary;
            BmobFile cover = new BmobFile();
            cover.filename = "cover";
            cover.url = coverurl;
            newsObject.cover = cover;

            //保存数据
            var future = Bmob.CreateTaskAsync(newsObject);

            // ！！！ 直接获取异步对象结果会阻塞主线程！ 建议使用async + await/callback的形式， 可以参考文件上传功能的实现。
            //获取创建记录的objectId
            newsObject.objectId = future.Result.objectId;

            //结果反馈，作为返回值
            String insertResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);

            return insertResult;
        }

        //删除某个新闻
        public String DeleteNews(String objectId)
        {
            //删除一条记录
            var future = Bmob.DeleteTaskAsync(TABLE_NAME, objectId);
            String queryResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);

            return queryResult;
        }

        //修改某个特定的新闻
        public String UpdateNews(String objectId, String infoname, String newinfo)
        {
            //新建对象准备修改
            NewsObject newsObject = new NewsObject();
            String result = "";
            //搜索原有结果
            var query = new BmobQuery();
            query.WhereContainedIn<String>("objectId", objectId);
            var future = Bmob.FindTaskAsync<NewsObject>(TABLE_NAME, query);

            //修改参数
            switch (infoname)
            {
                case "title":
                    newsObject.title = newinfo;
                    break;
                case "summary":
                    newsObject.summary = newinfo;
                    break;
                case "cover":
                    //处理avatar
                    BmobFile cover = new BmobFile();
                    cover.filename = "cover";
                    cover.url = newinfo;
                    newsObject.cover = cover;
                    break;
                default:
                    result = "Wrong infoname";
                    break;
            }
            //将新的对象更新到数据库
            Bmob.Update(TABLE_NAME, objectId, newsObject, (resp, exception) =>
            {
                if (exception != null)
                {
                    return;
                }
                return;
            });
            result = JsonAdapter.JSON.ToDebugJsonString(newsObject);
            return result;
        }
    }
}