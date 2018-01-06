using cn.bmob.Extensions;
using cn.bmob.io;
using cn.bmob.json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplicationBRXT.Model;

namespace WebApplicationBRXT.Controller
{
    public class BmobQuestionBank : BmobBase
    {
        //对应要操作的数据表
        public const String TABLE_NAME = "Exam_Question_Bank";
        public BmobQuestionBank() :
            base()
        {

        }

        //增加题库中的题目
        //TODO: 添加题目

        //删除题库中题目
        //TODO

        //修改题库中题目
        //TODO

        //查询题库中题目
        //TODO

        /*
        //public String Upload(String examurl, String answerurl, String filename)
        //{
        //    //const String EXTENTION_NAME = ".png";

        //    //Byte[] dataExam = null;
        //    //Byte[] dataAnswer = null;
        //    //using (var stream = File.OpenRead(examurl))
        //    //{
        //    //    dataExam = stream.ReadAsBytes();
        //    //}
        //    //using (var stream = File.OpenRead(answerurl)) 
        //    //{
        //    //    dataAnswer = stream.ReadAsBytes();
        //    //}

        //    BmobFile bmobFileExam =  new BmobFile();
        //    BmobFile bmobFileAnswer = new BmobFile();

        //    bmobFileExam.filename = filename;
        //    bmobFileAnswer.filename = filename;
        //    bmobFileExam.url = examurl;
        //    bmobFileAnswer.url = answerurl;

        //    QuestionBankObject questionBank = new QuestionBankObject(TABLE_NAME);

        //    questionBank.examQuestion = bmobFileExam;
        //    questionBank.answer = bmobFileAnswer;

        //    var future = Bmob.CreateTaskAsync(questionBank);

        //    // ！！！ 直接获取异步对象结果会阻塞主线程！ 建议使用async + await/callback的形式， 可以参考文件上传功能的实现。
        //    //获取创建记录的objectId
        //    questionBank.objectId = future.Result.objectId;

        //    //结果反馈作为返回值
        //    String uploadResult = JsonAdapter.JSON.ToDebugJsonString(future.Result);

        //    return uploadResult;
        //}*/
    }
}