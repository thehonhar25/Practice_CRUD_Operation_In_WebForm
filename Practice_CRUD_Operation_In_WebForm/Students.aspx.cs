using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Xml.Linq;

namespace Practice_CRUD_Operation_In_WebForm
{
    public partial class Students : System.Web.UI.Page
    {
        SqlConnection _con = new SqlConnection("Data Source=RAHUl;Initial Catalog=Practice_CRUD_Operation;Integrated Security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Show();
                ShowGender();
                ShowCourse();
                ShowCountry();
               

            }
        }
        public void Show()
        {
            _con.Open();
            SqlCommand cmd = new SqlCommand("select * from Pratice_CRUD_In_WebForm join tblCourse on Student_Course=Course_id join tblGender on Student_Gender=Gender_id join tblCountry on Student_Country=country_id join tblState on Student_State=state_id", _con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            gvemployee.DataSource = dt;
            gvemployee.DataBind();


        }
        public void ShowGender()
        {
            _con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblGender", _con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            rblGender.DataTextField = "Gender_name";
            rblGender.DataValueField = "Gender_id";
            rblGender.DataSource = dt;
            rblGender.DataBind();

        }
        public void ShowCourse()
        {
            _con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblCourse", _con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            ddlCourse.DataTextField = "Course_name";
            ddlCourse.DataValueField = "Course_id";
            ddlCourse.DataSource = dt;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        public void ShowCountry()
        {
            _con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblCountry", _con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            ddlCountry.DataTextField = "country_name";
            ddlCountry.DataValueField = "country_id";
            ddlCountry.DataSource = dt;
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void ShowState()
        {
            _con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblState where country_id='"+ddlCountry.SelectedValue+"'", _con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            _con.Close();
            ddlState.DataTextField = "state_name";
            ddlState.DataValueField = "state_id";
            ddlState.DataSource = dt;
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--Select--", "0"));
        }




        public void Clear()
        {
            txtName.Text = "";
            txtEnrollmentNo.Text = "";
            rblGender.ClearSelection();
            txtAddress.Text = "";
            ddlCourse.SelectedValue = "0";
            ddlCountry.SelectedValue = "0";
            ddlState.SelectedValue = "0";
            btnSubmit.Text = "Submit";
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Submit")
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand("insert into Pratice_CRUD_In_WebForm(Student_Name,Student_Enrollment_No,Student_Gender,Student_Address,Student_Course,Student_Country,Student_State)values('" + txtName.Text + "','" + txtEnrollmentNo.Text + "','" + rblGender.SelectedValue + "','" + txtAddress.Text + "','" + ddlCourse.SelectedValue + "','"+ddlCountry.SelectedValue+"','"+ddlState.SelectedValue+"')", _con);
                cmd.ExecuteNonQuery();
                _con.Close();

            }
            else if (btnSubmit.Text == "Update")
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand("update Pratice_CRUD_In_WebForm set Student_Name='" + txtName.Text + "',Student_Enrollment_No='" + txtEnrollmentNo.Text + "',Student_Gender='" + rblGender.SelectedValue + "',Student_Address='" + txtAddress.Text + "',Student_Course='" + ddlCourse.SelectedValue + "',Student_Country='"+ddlCountry.SelectedValue+"',Student_State='"+ddlState.SelectedValue+"' where Student_Id='" + ViewState["IDD"] + "'  ", _con);
                cmd.ExecuteNonQuery();
                _con.Close();

            }
            Show();
            Clear();

        }

        protected void gvemployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "D")
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand("delete from Pratice_CRUD_In_WebForm where Student_Id='" + e.CommandArgument + "'", _con);
                cmd.ExecuteNonQuery();
                _con.Close();
                Show();

            }
            else if (e.CommandName == "E")
            {
                _con.Open();
                SqlCommand cmd = new SqlCommand("select * from Pratice_CRUD_In_WebForm where Student_Id='" + e.CommandArgument + "'", _con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                _con.Close();
                txtName.Text = dt.Rows[0]["Student_Name"].ToString();
                txtEnrollmentNo.Text = dt.Rows[0]["Student_Enrollment_No"].ToString();
                rblGender.SelectedValue = dt.Rows[0]["Student_Gender"].ToString();
                txtAddress.Text = dt.Rows[0]["Student_Address"].ToString();
                ddlCourse.SelectedValue = dt.Rows[0]["Student_Course"].ToString();
                ddlCountry.SelectedValue = dt.Rows[0]["Student_Country"].ToString() ;
                ddlState.SelectedValue = dt.Rows[0]["Student_State"].ToString();

                btnSubmit.Text = "Update";
                ViewState["IDD"] = e.CommandArgument;
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowState();
        }
    }
}