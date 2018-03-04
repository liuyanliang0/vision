using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision
{
    //定义一个小组类
   public class T_Group
    {
        //小组组长
        public string F_TeamLeader { get; set; }

        //组长电话
        public string F_Telephone { get; set; }

        //小组牧区
        public string F_MuDistrict { get; set; }

        //小组分区
        public string F_District { get; set; }


        //小组成立时间
        public DateTime F_Date { get; set; }

        //小组人数
        public int F_Number { get; set; }
        //聚会地点
        public string F_Address { get; set; }


    }
}
