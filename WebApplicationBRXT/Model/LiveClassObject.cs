using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationBRXT.Model
{
    public class LiveClassObject :BmobTable
    {
        private String fTable;
        //一下对应云字段名称
        public String url { set; get; }
        public BmobDate startTime { set; get; }
        public String profName { set; get; }
        public String profIntro { set; get; }

        //constructor
        public LiveClassObject() { }
        public LiveClassObject(String tableName)
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

            this.url = input.getString("url");
            this.startTime = input.getDate("startTime");
            this.profName = input.getString("profName");
            this.profIntro = input.getString("profIntro");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            output.Put("url", this.url);
            output.Put("startTime", this.startTime);
            output.Put("profName", this.profName);
            output.Put("profIntro", this.profIntro);
        }
    }
}