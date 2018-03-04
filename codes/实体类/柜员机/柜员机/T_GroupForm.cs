using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using 柜员机;

namespace Vision
{
    public partial class T_GroupForm : Form
    {
        //定义一个保存小组的集合
        private List<T_Group> groupList = new List<T_Group>();
        public T_GroupForm()
        {
            InitializeComponent();
        }

       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //验证信息
            if(this.txtTeamLeader.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入信息", "系统提示");
                this.txtTeamLeader.Focus();
                return;
            }

            //封装对象
            T_Group objGroup = new T_Group()
            {
                F_TeamLeader = this.txtTeamLeader.Text.Trim(),
                F_Telephone = this.txtTelephone.Text.Trim(),
                F_MuDistrict = this.txtMuDistrict.Text.Trim(),
                F_District = this.txtDistrict.Text.Trim(),
                F_Number = int.Parse (this.txtNumber.Text.Trim()),
                F_Date = Convert.ToDateTime (this.txtDate.Text.Trim()),
                F_Address = this.txtAddress.Text.Trim(),
            };
            //将对象添加到数据源

            //同步添加显示
            this.groupList.Add(objGroup);
            this.dgvGroupList.DataSource = null;
            this.dgvGroupList.DataSource = this.groupList;

            //清空用户输入
            this.txtTeamLeader.Clear();
            this.txtTelephone.Clear();
            this.txtMuDistrict.Clear();
            this.txtDistrict.Clear();
           
            this.txtAddress.Clear();
            this.txtNumber.Clear();
            this.txtTeamLeader.Focus();
        }

        //修改小组信息
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //如果当前没有任何数据，则不执行任何操作
            if (this.dgvGroupList.CurrentRow == null || this.dgvGroupList.RowCount == 0) return;
            //获取要修改的内容
            string f_teamLeader = this.dgvGroupList.CurrentRow.Cells["F_TeamLeader"].Value.ToString();
            T_Group objGroup = (from b in this.groupList where b.F_TeamLeader.ToString().Equals(f_teamLeader) select b).First<T_Group>();
            //显示要修改的窗体（把图书信息传递到窗体上）
            EditGroup objEdit = new EditGroup(objGroup);
            DialogResult result = objEdit.ShowDialog();
            //根据修改是否成功来决定是否同步显示
            if (result == DialogResult.OK)
            {
                //首先获取修改后的对象
                objGroup = (T_Group)objEdit.Tag;
                //重新找到要修改的图书并修改属性值
                T_Group editGroup = (from b in this.groupList where b.F_TeamLeader.ToString().Equals(f_teamLeader) select b).First<T_Group>();
                editGroup.F_TeamLeader = objGroup.F_TeamLeader;
                editGroup.F_Telephone = objGroup.F_Telephone;
                editGroup.F_Number = objGroup.F_Number;
                editGroup.F_MuDistrict = objGroup.F_MuDistrict;
                editGroup.F_District = objGroup.F_District;
                editGroup.F_Date = objGroup.F_Date;
                editGroup.F_Address = objGroup.F_Address;
                //同步刷新
                this.dgvGroupList.Refresh();
            }
        }
        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //验证 如果没有如何信息 则不执行操作
            if (this.dgvGroupList.CurrentRow == null || this.dgvGroupList.RowCount == 0) return;

            //删除确定
            DialogResult result = MessageBox.Show("确定要删除的内容", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel) return;

            //获取要修改的内容(对象)
            string f_teamLeader = this.dgvGroupList.CurrentRow.Cells["F_TeamLeader"].Value.ToString();
            T_Group objGroup = (from b in this.groupList where b.F_TeamLeader.ToString().Equals(f_teamLeader) select b).First<T_Group>();

            //从数据库和集合中删除对象

            this.groupList.Remove(objGroup);

            //同步更新显示
            this.dgvGroupList.DataSource = null;
            this.dgvGroupList.DataSource = this.dgvGroupList;
        }
    }
}
