using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 柜员机
{
    class Persen
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
                if (value < 1 || value > 100)
                {
                    throw (new ArgumentOutOfRangeException("AgeIntProperty", value, "年龄必须在0和100之间"));
                }
                age = value;
            }
        }
        //性别
        public string Gender { get; set; }

        //居住地
        public string Address { get; set; }

        //学历
        public string Education { get; set; }

        //初到教会时间
        public DateTime Time { get; set; }

        //联系电话
        public string Telephone { get; set; }

        //代领人
        public string Leader { get; set; }

    }
}
