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
using static 柜员机.Persen;

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
                Name = this.txtName.Text.Trim(),
                Age = Convert.ToInt32(this.txtAge.Text.Trim()),
                Sex = (Gender)(Enum.Parse(typeof(Gender), this.txtGender.Text.Trim())),
                Address = this.txtAddress.Text.Trim(),
                Education = this.txtEducation.Text.Trim(),
                Time = Convert.ToDateTime(this.txtTime.Text.Trim()),
                Telephone = this.txtTelephone.Text.Trim(),
                Leader = this.txtLeader.Text.Trim(),
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
            string name = this.dgvPersenList.CurrentRow.Cells["name"].Value.ToString();
            Persen objPersen = (from b in this.persenList where b.Name.ToString().Equals(name) select b).First<Persen>();
            //显示要修改的窗体（把人员信息显示在修改窗体上）
            FrmEditPersen objEdit = new FrmEditPersen(objPersen);
            DialogResult result = objEdit.ShowDialog();
            //根据修改是否成功来决定是否同步显示
            if (result == DialogResult.OK)
            {
                //获取修改后的对象
                objPersen = (Persen)objEdit.Tag;
                //重新找到要修改的人员对象并修改属性值
                Persen editPersen = (from b in this.persenList where b.Name.ToString().Equals(name) select b).First<Persen>();
                editPersen.Name = objPersen.Name;
                editPersen.Age = objPersen.Age;
                editPersen.Address = objPersen.Address;
                editPersen.Education = objPersen.Education;
                editPersen.Sex = objPersen.Sex;
                editPersen.Time = objPersen.Time;
                editPersen.Telephone = objPersen.Telephone;
                editPersen.Leader = objPersen.Leader;
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
            Persen objPersen = (from b in this.persenList where b.Name.ToString().Equals(name) select b).First<Persen>();

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
    }
}
