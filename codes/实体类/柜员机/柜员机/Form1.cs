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
using Vision;
using static Vision.Persen;

namespace 柜员机
{
    

    public partial class Form1 : Form
    {
        //定义一个保存人员的容器
        private List<Persen> persenList = new List<Persen>();
        public Form1()
        {
            InitializeComponent();
            //禁止dgv自动生成列
            this.dgvPersenList.AutoGenerateColumns = false;
           
        }

     

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //数据验证

            //对象封装
            try {
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
                    F_LeaderPhone = this.txtLeaderPhone.Text.Trim()
            };
            //将数据保存到数据源
            this.persenList.Add(objPersen);
            this.dgvPersenList.DataSource = null;
            this.dgvPersenList.DataSource = this.persenList;
            }
            catch
            {
                MessageBox.Show("请输入正确的信息","系统提示");
            }
          
                //添加完清楚用户
                this.txtName.Clear();
                this.txtAge.Clear();
                this.txtGender.Clear();
                this.txtAddress.Clear();
            this.txtEducation.Clear();
                this.txtTelephone.Clear();
                this.txtLeader.Clear();
                this.txtName.Focus();
           
        }
        //修改信息
        private void bntEdit_Click(object sender, EventArgs e)
        {
            //验证 如果当前没有信息 则不执行操作
            if (this.dgvPersenList.CurrentRow == null || this.dgvPersenList.RowCount == 0) return;

            //获取要修改的信息
            string name = this.dgvPersenList.CurrentRow.Cells["F_Name"].Value.ToString();
            Persen objPersen = (from b in this.persenList where b.F_Name.ToString().Equals(name) select b).First<Persen>();
            //显示要修改的窗体（把人员信息显示在修改窗体上）
            FrmEditPersen objEdit = new FrmEditPersen(objPersen);
            DialogResult result = objEdit.ShowDialog();
            //根据修改是否成功来决定是否同步显示
            if (result == DialogResult.OK)
            {
                //获取修改后的对象
                objPersen = (Persen)objEdit.Tag;
                //重新找到要修改的人员对象并修改属性值
                Persen editPersen = (from b in this.persenList where b.F_Name.ToString().Equals(name) select b).First<Persen>();
                editPersen.F_Name = objPersen.F_Name;
                editPersen.F_Age = objPersen.F_Age;
                editPersen.F_Address = objPersen.F_Address;
                editPersen.F_Education = objPersen.F_Education;
                editPersen.F_Sex = objPersen.F_Sex;
                editPersen.F_Date = objPersen.F_Date;
                editPersen.F_Phone = objPersen.F_Phone;
                editPersen.F_Leader = objPersen.F_Leader;
                editPersen.F_LeaderPhone = objPersen.F_LeaderPhone;
                //同步刷新
                this.dgvPersenList.Refresh();
            }
        }
        //删除
        private void btnDel_Click(object sender, EventArgs e)
        {
            //验证 如果当前没有信息 则不执行操作
            if (this.dgvPersenList.CurrentRow == null || this.dgvPersenList.RowCount == 0) return;

            //删除确定
            DialogResult result = MessageBox.Show("确定删除", "系统提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (result == DialogResult.Cancel) return;
            //获取要修改的信息
            string name = this.dgvPersenList.CurrentRow.Cells["name"].Value.ToString();
            Persen objPersen = (from b in this.persenList where b.F_Name.ToString().Equals(name) select b).First<Persen>();

            //从数据源中和集合中删除
            this.persenList.Remove(objPersen);

            //同步更新显示
            this.dgvPersenList.DataSource = null;
            this.dgvPersenList.DataSource = this.persenList;
            

        }
        //查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //从数据源获取全部查询的信息（返回List集合对象）

            this.dgvPersenList.DataSource = this.persenList;
        }
        //清楚显示
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.persenList.Clear();
            this.dgvPersenList.DataSource = null;
        }
        //显示小组窗体
        private void btnGroup_Click(object sender, EventArgs e)
        {
           
           
            T_GroupForm form = new T_GroupForm();
            form.ShowDialog();
            //释放资源
            form.Dispose();
            form = null;
        }
    }
}
