using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Client.ServiceReference;

namespace Client
{
    public partial class MainForm : System.Web.UI.Page
    {
        StudentClient proxy = new StudentClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            Student[] listData = proxy.GetInfo("");
            this.GridView1.DataSource = listData.ToList();
            this.GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Student model = new Student();
            model.ID =Convert.ToInt32(this.txt_id.Text);
            model.Name = this.txt_name.Text;
            model.Age = Convert.ToInt32(this.txt_age.Text);
            model.Grade = this.txt_grade.Text;
            model.Address = this.txt_address.Text;
            if (proxy.Exist(model.ID))
            {
                proxy.Update(model);
            }
            else
            {
                proxy.Add(model);
            }

            BindData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int id = Convert.ToInt16(((GridView1.Rows[e.RowIndex].FindControl("lbl_id") as Label).Text));  
            bool flag = proxy.Delete(id);
            if (flag)
            {
                Response.Write("<Script>alert(' 删除成功！')</Script> ");
                BindData();
            }
            else
            {
                Response.Write("<Script>alert(' 删除失败！')</Script> ");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {              
                e.Row.Attributes.Add("onclick", e.Row.ClientID.ToString() + ".checked=true;selectx(this)");//点击行变色

           }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lbtn")
　　　　　　　 {
　　　　　　　　　  GridViewRow gvrow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer); //获取被点击的linkButton所在的GridViewRow
　　　　　　　　　　int index = gvrow.RowIndex; //获取到行索引 RowIndex

                this.txt_id.Text = (GridView1.Rows[index].Cells[0].FindControl("lbl_id") as Label).Text.Trim();
　　　　　　　　　　this.txt_name.Text=GridView1.Rows[index].Cells[1].Text.Trim();
                this.txt_age.Text = GridView1.Rows[index].Cells[2].Text.Trim();
                this.txt_grade.Text = GridView1.Rows[index].Cells[3].Text.Trim();
                this.txt_address.Text = GridView1.Rows[index].Cells[4].Text.Trim();

　　　　　　　 }　　　　　 
        }



    }
}