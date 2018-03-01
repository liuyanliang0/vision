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

using 柜员机;
using static 柜员机.Persen;

namespace 柜员机
{
    public partial class FrmEditPersen : Form
    {
        public FrmEditPersen()
        {
            InitializeComponent();
        }

        public FrmEditPersen(Persen objPersen)
        {
            InitializeComponent();
            //显示要修改的人员信息
            this.txtName.Text = objPersen.Name;
            this.txtAge.Text = (objPersen.Age).ToString();
            this.txtAddress.Text = objPersen.Address;
            this.txtGender.Text = objPersen.Sex.ToString();
            this.txtEducation.Text = objPersen.Education;
            this.txtTelephone.Text = objPersen.Telephone;
            this.txtTime.Text = objPersen.Time.ToShortDateString();
            this.txtLeader.Text = objPersen.Leader;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //数据验证

            //封装要修改的对象
            Persen objPersen = new Persen()
            {
                Name = this.txtName.Text.Trim(),
                Age = Convert.ToInt32(this.txtAge.Text.Trim()),
                Sex = (Gender)(Enum.Parse(typeof(Gender), this.txtGender.Text.Trim())),
                Address = this.txtAddress.Text.Trim(),
                Education = this.txtEducation.Text.Trim(),
                Time = Convert.ToDateTime(this.txtTime.Text.Trim()),
                Telephone = this.txtTelephone.Text.Trim(),
                Leader = this.txtLeader.Text.Trim(),
            };
            //从数据库或数据源中修改对象。。

            //保存当前已经修改的对象
            this.Tag = objPersen;
            this.DialogResult = DialogResult.OK;//设置窗体返回值
            this.Close();
        }
    }
}
