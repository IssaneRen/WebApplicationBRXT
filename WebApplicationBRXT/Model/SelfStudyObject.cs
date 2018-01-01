using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationBRXT.Model
{
    public class SelfStudyObject : BmobTable
    {
        private String fTable;
        //一下对应云字段名称
        public String teacher { set; get; }
        public String subject { set; get; }
        public BmobDate startTime { set; get; }
        public BmobDate expiredTime { get; set; }

        //constructor
        public SelfStudyObject() { }
        public SelfStudyObject(String tableName)
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

            this.teacher = input.getString("teacher");
            this.subject = input.getString("subject");
            this.startTime = input.getDate("startTime");
            this.expiredTime = input.getDate("expiredTime");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("title", this.teacher);
            output.Put("summary", this.subject);
            output.Put("startTime", this.startTime);
            output.Put("expiredTime", this.expiredTime);
        }
    }
}