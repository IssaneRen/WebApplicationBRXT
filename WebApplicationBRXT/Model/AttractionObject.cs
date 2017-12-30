using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationTouringGo.Model
{
    class AttractionObject : BmobTable
    {

        private String fTable;
        //以下对应云端字段名称
        public String point { get; set; }
        public String name { get; set; }

        //构造函数
        public AttractionObject() { }

        //构造函数
        public AttractionObject(String tableName)
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

            this.point = input.getString("point");
            this.name = input.getString("name");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("point", this.point);
            output.Put("name", this.name);
        }
    }
}