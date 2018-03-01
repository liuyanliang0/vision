using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 柜员机
{
   public class Persen
    {
        
        //姓名
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //年龄
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 1 || value > 110)
                {
                    throw (new ArgumentOutOfRangeException("AgeIntProperty", value, "年龄必须在0和100之间"));
                }
                age = value;
            }
        }
        //性别
        //定义一个叫Gender的枚举类型
       public enum Gender
        {
            男, 女
        }
        public Gender Sex{ get; set; }

        //居住地
        public string Address { get; set; }

        //学历
        //public enum Education
        //{
        //    小学,
        //    初中,
        //    高中,
        //    大学,
        //    研究生,
        //    博士,
        //    博士前,

        
        public string Education { get; set; }

        //初到教会时间
        public DateTime Time { get; set; }

        //联系电话
        public string Telephone { get; set; }

        //代领人
        public string Leader { get; set; }

    }
}
