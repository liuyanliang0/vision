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
            this.txtName.Text = objPersen.F_Name;
            this.txtAge.Text = (objPersen.F_Age).ToString();
            this.txtAddress.Text = objPersen.F_Address;
            this.txtGender.Text = objPersen.F_Sex.ToString();
            this.txtEducation.Text = objPersen.F_Education;
            this.txtTelephone.Text = objPersen.F_Phone;
            this.txtTime.Text = objPersen.F_Date.ToShortDateString();
            this.txtLeader.Text = objPersen.F_Leader;
            this.txtLeaderPhone.Text = objPersen.F_LeaderPhone;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //数据验证

            //封装要修改的对象
            Persen objPersen = new Persen()
            {
                F_Name = this.txtName.Text.Trim(),
                F_Age = Convert.ToInt32(this.txtAge.Text.Trim()),
                F_Sex = (Gender)(Enum.Parse(typeof(Gender), this.txtGender.Text.Trim())),
                F_Address = this.txtAddress.Text.Trim(),
                F_Education = this.txtEducation.Text.Trim(),
                F_Date = Convert.ToDateTime(this.txtTime.Text.Trim()),
                F_Phone = this.txtTelephone.Text.Trim(),
                F_Leader = this.txtLeader.Text.Trim(),
            };
            //从数据库或数据源中修改对象。。

            //保存当前已经修改的对象
            this.Tag = objPersen;
            this.DialogResult = DialogResult.OK;//设置窗体返回值
            this.Close();
        }
    }
}
