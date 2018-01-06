using cn.bmob.io;
using System;

namespace WebApplicationBRXT.Model
{
    public class MyUserObject: BmobUser
    {

        //以下对应云端字段名称
        //public BmobBoolean sex { get; set; }
        //public BmobInt age { get; set; }
        public BmobInt period { get; set; }
        public String grade { get; set; }
        public BmobFile avatar { get; set; }

        //构造函数
        public MyUserObject() { }

        //读字段信息
        public override void readFields(BmobInput input)
        {
            base.readFields(input);

            //this.sex = input.getBoolean("sex");
            //this.age = input.getInt("age");
            this.period = input.getInt("period");
            this.grade = input.getString("grade");
            this.avatar = input.Get<BmobFile>("avatar");
        }

        //写字段信息
        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);

            //output.Put("sex", this.sex);
            //output.Put("age", this.age);
            output.Put("period", this.period);
            output.Put("grade", this.grade);
            output.Put("avatar", this.avatar);
        }
    }
}