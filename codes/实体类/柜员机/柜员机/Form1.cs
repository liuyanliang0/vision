using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//引用空间
using System.IO;
using 柜员机;

namespace 柜员机
{
    
    
    public partial class Form1 : Form
    {
        //定义一个保存人员的容器
        private List<Persen> persenList = new List<Persen>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //数据验证

            //对象封装
            Persen objPersen = new Persen()
            {
                Name = this.txtName.Text.Trim(),
                Age = Convert.ToInt32( this.txtAge.Text.Trim()),
                Gender = this.txtGender.Text.Trim(),
                Address = this.txtAddress.Text.Trim(),
                Education = this.txtAddress.Text.Trim(),
                Time = Convert.ToDateTime(this.txtTime.Text.Trim()),
                Telephone = this.txtTelephone.Text.Trim(),
                Leader = this.txtLeader.Text.Trim(),
            };
            //将数据保存到数据源
            this.persenList.Add(objPersen);
            this.dgvPersenList.DataSource = null;
            this.dgvPersenList.DataSource = this.persenList;
        }
    }
}
