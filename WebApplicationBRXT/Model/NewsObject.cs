using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationBRXT.Model
{
    public class NewsObject : BmobTable
    {
        private String fTable;
        //一下对应云字段名称
        public String title { set; get; }
        public String summary { set; get; }
        public BmobFile cover { set; get; }

        //constructor
        public NewsObject() { }
        public NewsObject(String tableName)
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

            this.title = input.getString("title");
            this.summary = input.getString("summary");
            this.cover = input.getFile("cover");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("title", this.title);
            output.Put("summary", this.summary);
            output.Put("cover", this.cover);
        }
    }
}