using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationBRXT.Model
{
    public class QuestionBankObject : BmobTable
    {
        private String fTable;
        //一下对应云字段名称
        public BmobInt questionNum { set; get; }
        public String question { set; get; }
        public BmobFile graph { set; get; }
        public String bankName { set; get; }
        public String answer { set; get; }

        //constructor
        public QuestionBankObject() { }
        public QuestionBankObject(String tableName)
        {
            this.fTable = tableName;
        }

        public override string table
        {
            get
            {
                if (fTable != null)
                {
                    return fTable;
                }
                return base.table;
            }
        }

        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);

            this.questionNum = input.getInt("questionNum");
            this.question = input.getString("question");
            this.graph = input.Get<BmobFile>("graph");
            this.bankName = input.getString("bankName");
            this.answer = input.getString("answer");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("questionNum", this.questionNum);
            output.Put("question", this.question);
            output.Put("graph", this.graph);
            output.Put("bankName", this.bankName);
            output.Put("answer", this.answer);
        }

    }
}