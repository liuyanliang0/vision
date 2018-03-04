using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Vision;
using static Vision.T_Group;

namespace 柜员机
{
    public partial class EditGroup : Form
    {
        public EditGroup()
        {
            InitializeComponent();
        }
        public EditGroup(T_Group objGroup)
        {
            InitializeComponent();
            //显示要修改的小组信息
            this.txtTeamLeader.Text = objGroup.F_TeamLeader;
            this.txtTelephone.Text = objGroup.F_Telephone;
            this.txtNumber.Text = objGroup.F_Number.ToString();
            this.txtDate.Text = objGroup.F_Date.ToShortDateString();
            this.txtAddress.Text = objGroup.F_Address;
            this.txtMuDistrict.Text = objGroup.F_MuDistrict;
            this.txtDistrict.Text = objGroup.F_District;
        }

        //提交修改后的信息
        private void btnYes_Click(object sender, EventArgs e)
        {
            //验证信息
            if (this.txtTeamLeader.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入正确信息", "系统提示");
                this.txtTeamLeader.Focus();
            };
            //封装要修改的对象
            T_Group objGroup = new T_Group()
            {
                F_TeamLeader = this.txtTeamLeader.Text.Trim(),
                F_Telephone = this.txtTelephone.Text.Trim(),
                F_Number = int.Parse(this.txtNumber.Text.Trim()),
                F_MuDistrict = this.txtMuDistrict.Text.Trim(),
                F_Address = this.txtAddress.Text.Trim(),
                F_Date = Convert.ToDateTime(this.txtDate.Text),
                F_District = this.txtDistrict.Text.Trim()
            };
            //从数据库或数据源中修改
     
            //保存当前以修改的对象
            this.Tag = objGroup ;
            this.DialogResult = DialogResult.OK;//返回修改值
            this.Close();
        }
    }
}
