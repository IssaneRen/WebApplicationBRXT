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
        public BmobFile examQuestion { set; get; }
        public BmobFile answer { set; get; }

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

            this.examQuestion = input.Get<BmobFile>("examQuestion");
            this.answer = input.Get<BmobFile>("answer");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("examQuestion", this.examQuestion);
            output.Put("answer", this.answer);
        }

    }
}