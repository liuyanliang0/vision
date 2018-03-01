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
        private string f_name
;
        public string F_Name
        {
            get { return f_name; }
            set { f_name = value; }
        }
        //年龄
        private int f_age;
        public int F_Age
        {
            get { return f_age; }
            set
            {
                if (value < 1 || value > 110)
                {
                    throw (new ArgumentOutOfRangeException("AgeIntProperty", value, "年龄必须在0和100之间"));
                }
                f_age = value;
            }
        }
        //性别
        //定义一个叫Gender的枚举类型
       public enum Gender
        {
            男 = 0,
            女 = 1
        }
        public Gender F_Sex
        { get; set; }

        //居住地
        public string F_Address { get; set; }

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

        
        public string F_Education{ get; set; }

        //初到教会时间
        public DateTime F_Date { get; set; }

        //联系电话
        public string F_Phone { get; set; }

        //代领人
        public string F_Leader { get; set; }

        //代领人电话
        public string F_LeaderPhone{ get; set; }

    }
}
