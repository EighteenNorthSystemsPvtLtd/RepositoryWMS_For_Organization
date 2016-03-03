using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BussinessLayer;
public partial class Form_ShifarasPatra : System.Web.UI.Page
{
    BussinessLayer.BusinessLayerclass bl = new BusinessLayerclass();
    BussinessLayer.BusinessLayerclass obj = new BusinessLayerclass();
    protected void Page_Load(object sender, EventArgs e)
    { try
            {
                System.Threading.Thread.Sleep(5000);//remove it after testing 
        if (Session["Group_Id"] == null)
            Response.Redirect("~/Form/login.aspx");
        if (!IsPostBack)
        {
            ddl_publishtype_master();
            Panel_DenikBoard.Visible = false;
            Panel_NewsPaper.Visible = false;
            Panel_Tender.Visible = false;
                RadioButtonList1.Focus();
                filltaluka();             
                RadioButtonList1.Focus();
                fillRecord();
                Checkstagestatus();
                txt_workname.Text = Session["Workname"].ToString();


                List<string> list = new List<string>();
                list.Add(Session["Work_ID"].ToString());//Session["WorkId"].ToString();
                DataSet ds1 = new DataSet();
                ds1 = obj.FillGridWithParameter(list, "sp_select_info_work_forShifaras");
                if (ds1.Tables.Count != 0)
                {
                    if (ds1.Tables[0].Rows.Count != 0)
                    {
                        Label23.Text = ds1.Tables[0].Rows[0][1].ToString() + ".00";

                        Label27.Text = ds1.Tables[0].Rows[0][2].ToString() + ".00";
                        Label30.Text = ds1.Tables[0].Rows[0][3].ToString() + ".00";

                        Label32.Text = ds1.Tables[0].Rows[0][0].ToString() + ".00";

                    }
                }





            }

        lblTalukatext.Text = "कामाचे नाव : " + Session["Workname"].ToString();
        //lblTalukatext.Text = "तालुका : " + Session["Talukaname"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "गाव : " + Session["Gavname"].ToString()
        //         + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "कामाचे नाव : " + Session["Workname"].ToString();
        ddlNewsPaper.Enabled = false;


        


        }
            catch(Exception ex)
            {
            
            }
       
    }
    protected void AddRecord()
    {

        List<string> para = new List<string>();
        DataSet ds = new DataSet();
        para.Add("1");
        para.Add(Session["Work_ID"].ToString());
        //if (RadioButtonList1.SelectedValue.ToString() == "O")
        //{
            para.Add(ddl_publishtype.SelectedValue.ToString());//thekedar id used as publish type for open tender           
            para.Add(ddl_ntype.SelectedValue.ToString());
            para.Add(DropDownList2.SelectedValue.ToString());
            para.Add(bl.convertDate(txt_salefinal_dale.Text));//send as txt_salefinal_dale
            para.Add(bl.convertDate(txt_addDate.Text));
            para.Add(txt_adNo.Text);
            para.Add(bl.convertDate(txt_sellDate.Text));
            para.Add(bl.convertDate(txt_lastDate.Text));
            para.Add(bl.convertDate(txt_openDate.Text));
           
        //}
        //else if (RadioButtonList1.SelectedValue.ToString() == "G")
        //{
        //    para.Add(DropDownList1.SelectedValue.ToString());
        //    para.Add(TextBox1.Text);
        //    para.Add(TextBox2.Text);
        //    string date = bl.convertDate(TextBox4.Text);
        //    para.Add(date);
        //    para.Add(bl.convertDate(TextBox6.Text));//shifaras date
        //    para.Add(TextBox3.Text);
        //    para.Add("1900/1/1");
        //    para.Add("1900/1/1");
        //    para.Add("1900/1/1");

        //}
        //else
        //{
        //    para.Add(ddlthekedar.SelectedValue.ToString());
        //    para.Add(txtshifarasKramank.Text);
        //    para.Add("1");//magno Patra no
        //    string date = bl.convertDate(fd.Text);
        //    para.Add(date);
        //    para.Add("1900/1/1");
        //    para.Add("0");
        //    para.Add("1900/1/1");
        //    para.Add("1900/1/1");
        //    para.Add("1900/1/1");
        //}
        para.Add(Session["officeid"].ToString());
       // para.Add(RadioButtonList1.SelectedValue.ToString());
           
        para.Add("O");
        if (RadioButtonList1.SelectedValue.ToString() == "G")
        {
            para.Add(TextBox5.Text);
        }
        else
        {
            para.Add("1.00");
        }

        if (ddl_publishtype.SelectedItem.Text.ToString() == "नोटीस बोर्ड")
        {
            para.Add("-");
            para.Add(txtNoticeBoard.Text);
            para.Add("-");
        }
        else if (ddl_publishtype.SelectedItem.Text.ToString() == "वर्तंमान पत्र")
        {

            para.Add(txtNewsPaperName.Text);
            para.Add("-");
            para.Add("-");
        }
        else
        {
            para.Add("-");
            para.Add("-");
            para.Add(txt_Tender.Text);
        }

       
       // para.Add(ddlNewsPaper.SelectedValue.ToString());
        para.Add("a");
        ds = bl.ExecuteStoredFunctionWithParameters(para, "sp_ShifarasPatra");
        lnk_Next.Visible = true;
        if (ds.Tables.Count != 0)
        {
            if (ds.Tables[0].Rows.Count != 0)

                ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "checkRecord();", true);
                lblmsg.Text = "Record Already Exists";
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "add();", true);
            lblmsg.Text = "Record Inserted";
            
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    { 
        try
        {
            setzero1();
            AddRecord();
            stagetrack();
            //lblmsg.Text = "Record Inserted ";         
            btn_nxt.Focus();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "disable_first();", true);
            txtNewsPaperName.Text = "";
            txtNoticeBoard.Text = "";
        }
        catch (Exception ex)
        {

        }
    }
    public void setzero1()
    {
        List<TextBox> plist = new List<TextBox>();
        plist.Add(txtworkname);
        plist.Add(txtshifarasKramank);
        bl.TextboxNull(plist);
    }
    public void setzero2()
    {
        List<TextBox> plist = new List<TextBox>();
        plist.Add(txt_adNo);
        obj.TextboxNull(plist);
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            setzero1();
            List<string> para = new List<string>();
            DataSet ds = new DataSet();
            para.Add("1");
            para.Add(Session["Work_ID"].ToString());  
            para.Add(ddlthekedar.SelectedValue.ToString());
            para.Add(txtshifarasKramank.Text);
            string date = bl.convertDate(fd.Text);
            para.Add(date);
            para.Add("1900/1/1");
            para.Add("0");
            para.Add("1900/1/1");
            para.Add("1900/1/1");
            para.Add("1900/1/1");        
            para.Add(Session["officeid"].ToString());
            //para.Add(RadioButtonList1.SelectedValue.ToString());
            para.Add("O");
            para.Add("1.0");
            para.Add("00");
           
            para.Add("u");
            bl.ExecuteStoredFunctionWithParameters(para, "sp_update_shifarasPatra");
            lblmsg.Text = "Record Updated ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "update();", true);
            btnupdate.Enabled = true;
            fillRecord();
            stagetrack();
            btn_nxt.Focus();
            txtNewsPaperName.Text = "";
            txtNoticeBoard.Text = "";
        }
        catch (Exception ex)
        {

        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (RadioButtonList1.SelectedValue == "E")
        //{
        //    DataSet dsamountcheck = new DataSet();
        //    List<string> para = new List<string>();
        //    para.Add(Session["Work_ID"].ToString());
        //    dsamountcheck = bl.FillGridWithParameter(para, "sp_fill_shifarasPatra_record");
        //    if (dsamountcheck.Tables.Count != 0)
        //    {
        //        if (dsamountcheck.Tables[1].Rows.Count != 0)
        //        {
        //            if (Convert.ToInt32(dsamountcheck.Tables[1].Rows[0][0].ToString()) <= 300000)
        //            {
        //                MultiView1.ActiveViewIndex = 0;
        //                ddlthekedar.Focus();
        //                ClearAll();
        //                fillddl1();
        //                Panel1.Visible = true;
        //                Panel2.Visible = false;
        //                Panel3.Visible = false;
        //                btn_delete.Visible = false;
        //                GridView1.Visible = false;
        //                btnsave.Enabled = true;
        //                btnupdate.Enabled = false;
        //            }
        //            else
        //            {

        //                ClearAll();
        //                Panel2.Visible = false;
        //                Panel3.Visible = false;
        //                btn_delete.Visible = false;
        //                GridView1.Visible = false;
        //                btnupdate.Enabled = false;
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "shifaras_amount_validation();", true);
        //                //lblmsg.Text = "Amount Greater than 300000";



        //            }
        //        }
        //    }

        //}
        //else if (RadioButtonList1.SelectedValue == "S")
        //{

        //     DataSet dsamountcheck = new DataSet();
        //    List<string> para = new List<string>();
        //    para.Add(Session["Work_ID"].ToString());
        //    dsamountcheck = bl.FillGridWithParameter(para, "sp_fill_shifarasPatra_record");
        //    if (dsamountcheck.Tables.Count != 0)
        //    {
        //        if (dsamountcheck.Tables[1].Rows.Count != 0)
        //        {
        //            if (Convert.ToInt32(dsamountcheck.Tables[1].Rows[0][0].ToString()) <= 300000)
        //            {
        //    MultiView1.ActiveViewIndex = 0;
        //    ddlthekedar.Focus();
        //    ClearAll();
        //    fillddl1();
        //    Panel1.Visible = true;
        //    Panel2.Visible = false;
        //    Panel3.Visible = false;
        //    btn_delete.Visible = false;
        //    GridView1.Visible = false;
        //    btnsave.Enabled = true;
        //    btnupdate.Enabled = false;
        //            }
        //            else
        //            {
        //                Panel2.Visible = false;
        //                Panel3.Visible = false;
        //                btn_delete.Visible = false;
        //                GridView1.Visible = false;
                     
        //                btnupdate.Enabled = false;
        //                //lblmsg.Text = "Amount Greater than 300000";
        //                // ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "add();", true);
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "shifaras_amount_validation();", true);
        //            }
        //        }
        //    }
        //}
        //else if (RadioButtonList1.SelectedValue == "O")
        //{
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            MultiView1.ActiveViewIndex =1;
            ddl_ntype.Focus();
            clearall();
            fillddl1();
            ddl_publishtype_master();
          
            btn_delete.Visible = true;
            GridView1.Visible = true;
            fillnewsddl();
            fillddlNewstype();
        //}
        //else if (RadioButtonList1.SelectedValue == "G")
        //{
        //    Panel1.Visible = false;
        //    Panel2.Visible = false;
        //    Panel3.Visible = true;
        //    MultiView1.ActiveViewIndex =2;
        //    DropDownList1.Focus();
        //    ClearAll();
        //    fillddlgram();
          
        //    btn_delete.Visible = false;
        //    GridView1.Visible = false;
        //    btnsave.Enabled = true;
        //    btnupdate.Enabled = false;
        //}
    }
    protected void filltaluka()
    { 
         
        DataSet ds = new DataSet();
        List<string> list = new List<string>();
        list.Add(Session["Work_ID"].ToString());
        ds = obj.FillGridWithParameter(list, "sp_TalukaName");
        if (ds.Tables.Count != 0)
        {
            Session["talukaId"] = ds.Tables[0].Rows[0][1].ToString();
        }
    }
    public void fillgrid()
    {
        try
        {
            DataSet ds = new DataSet();
            List<string> list = new List<string>();
            list.Add(Session["Work_ID"].ToString());
            ds = obj.FillGridWithParameter(list, "fill_advertisment");            
        }
        catch (Exception ex)
        { }
    }
    public void fillddl1()
    {
        DataSet ds2 = new DataSet();
        List<string> plist = new List<string>();
       // plist.Add(RadioButtonList1.SelectedValue.ToString());
        plist.Add("O");       
        ddlthekedar.DataValueField = "ThekedarId";
        ddlthekedar.DataTextField = "ThekedarName";
        ds2 = bl.FillGridWithParameter(plist,"Sp_FillThekedar");
        ddlthekedar.DataSource = ds2;
        ddlthekedar.DataBind();
        ddlthekedar.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    public void fillddlgram()
    {
        DataSet ds2 = new DataSet();
        List<string> plist = new List<string>();
        plist.Add(Session["talukaId"].ToString());
        DropDownList1.DataValueField = "gp_id";
        DropDownList1.DataTextField = "g_name";
        ds2 = bl.FillGridWithParameter(plist, "sp_fillGram");
        DropDownList1.DataSource = ds2;
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    public void ClearAll()
    {
        txtworkname.Text = "";
        txtshifarasKramank.Text = "";
        fd.Text = "";
    }   
    public void fillRecord()
    {
        try
        {
            DataSet ds3 = new DataSet();
            List<string> para = new List<string>();
            para.Add(Session["Work_ID"].ToString());
            ds3 = bl.FillGridWithParameter(para, "sp_fill_shifarasPatra_record");
            if (ds3.Tables.Count != 0)
            {
                if (ds3.Tables[0].Rows.Count != 0)
                {
                    //RadioButtonList1.ClearSelection();
                    //RadioButtonList1.Items.FindByValue(ds3.Tables[0].Rows[0][5].ToString()).Selected = true;
                     if (ds3.Tables[0].Rows[0][5].ToString() != "O")
                    {
                        //Panel1.Visible = true;
                        Panel2.Visible = false;
                        Panel3.Visible = false;
                        GridView1.Visible = false;                    
                        if (ds3.Tables[0].Rows[0][5].ToString() == "G")
                        {
                            MultiView1.ActiveViewIndex = 2;
                            Panel1.Visible = false;
                            Panel2.Visible = false;
                            Panel3.Visible = true;
                            fillddlgram();
                            //DropDownList1.ClearSelection();
                            DropDownList1.Items.FindByValue(ds3.Tables[0].Rows[0][1].ToString()).Selected = true;
                            TextBox2.Text = ds3.Tables[0].Rows[0][8].ToString();
                            TextBox4.Text = ds3.Tables[0].Rows[0][3].ToString();
                            TextBox3.Text = ds3.Tables[0].Rows[0][6].ToString();
                            TextBox5.Text = ds3.Tables[0].Rows[0][7].ToString()+".00";
                            TextBox1.Text = ds3.Tables[0].Rows[0][2].ToString();
                            TextBox6.Text = ds3.Tables[0].Rows[0][9].ToString();
                            Button2.Enabled = false;
                            Button3.Enabled = true;
                        }
                        else
                        {
                            MultiView1.ActiveViewIndex = 0;
                            fillddl1();
                            ddlthekedar.ClearSelection();
                            ddlthekedar.Items.FindByValue(ds3.Tables[0].Rows[0][1].ToString()).Selected = true;
                            // ddlthekedar.Text = ds3.Tables[0].Rows[0][4].ToString();
                            // txtworkname.Text = ds3.Tables[0].Rows[0][0].ToString();
                            txtshifarasKramank.Text = ds3.Tables[0].Rows[0][2].ToString();
                            fd.Text = ds3.Tables[0].Rows[0][3].ToString();
                            btnsave.Enabled = false;
                            btnupdate.Enabled = true;
                        }                                             
                    }
                    else
                    {
                        MultiView1.ActiveViewIndex = 1;
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                        Panel3.Visible = false;
                        GridView1.Visible = true;
                        btn_delete.Visible = true;
                        fillnewsddl();
                        fillddlNewstype();
                        ddl_publishtype_master();
                        int id = (ds3.Tables[0].Rows.Count) % 10;
                        if (id == 0)
                        {
                            if (GridView1.CurrentPageIndex > 0)
                            {
                                GridView1.DataSource = ds3;
                                GridView1.CurrentPageIndex--;
                                GridView1.DataBind();
                            }
                            else
                            {
                                GridView1.DataSource = ds3;
                                GridView1.DataBind();
                            }
                        }
                        else
                        {
                            GridView1.DataSource = ds3;
                            GridView1.DataBind();
                        }
                    }
                }
                else {
                    GridView1.Visible = false;
                }
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                GridView1.Visible = false;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void fillnewsddl()
    {
        DataSet ds = new DataSet();
        ds = obj.FillGrid("sp_fillNews_shifaras");
        ddl_ntype.DataTextField = "news_name";
        ddl_ntype.DataValueField = "newspaper_id";
        ddl_ntype.DataSource = ds;
        ddl_ntype.DataBind();
        ddl_ntype.Items.Insert(0, new ListItem("---select---", "0"));
    }
    protected void fillddlNewstype()
    {
        DataSet ds = new DataSet();
        ds = obj.FillGrid("sp_fillddlnewstype_shifa");
        DropDownList2.DataTextField = "nname";
        DropDownList2.DataValueField = "newstype_id";
        DropDownList2.DataSource = ds;
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("---select---", "0"));
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Form/HomePage.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Dispose();
        Response.Redirect("~/Form/login.aspx");
    }
    protected void btn_Add_Click(object sender, EventArgs e)
    {
        try
        {
            setzero2();
            AddRecord();
            GridView1.Visible = true;
            fillRecord();
            stagetrack();
            btn_Add.Enabled = true;
            btn_update.Enabled = false;
          clearall();
            lblmsg.Visible = true;
            btn_nxt.Focus();
        }
        catch (Exception ex)
        { }
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        try
        {
            setzero2();
            DataSet ds = new DataSet();
            List<string> para = new List<string>();
            para.Add(HiddenField2.Value.ToString());
            para.Add(Session["Work_ID"].ToString());
            para.Add("0");
            para.Add(ddl_ntype.SelectedValue.ToString());
            para.Add("1900/1/1");
            para.Add(bl.convertDate(txt_addDate.Text));
            para.Add(txt_adNo.Text);
            para.Add(bl.convertDate(txt_sellDate.Text));
            para.Add(bl.convertDate(txt_lastDate.Text));
            para.Add(bl.convertDate(txt_openDate.Text));
            para.Add(Session["officeid"].ToString());
           // para.Add(RadioButtonList1.SelectedValue.ToString());
           
            para.Add("O");
            para.Add("00");
            para.Add(DropDownList2.SelectedValue.ToString());
            //para.Add(txtNewsPaperName.Text);
            //para.Add(txtNoticeBoard.Text);
            //para.Add(txt_Tender.Text);




            if (ddl_publishtype.SelectedItem.Text.ToString() == "नोटीस बोर्ड")
            {
                para.Add("-");
                para.Add(txtNoticeBoard.Text);
                para.Add("-");
            }
            else if (ddl_publishtype.SelectedItem.Text.ToString() == "वर्तंमान पत्र")
            {

                para.Add(txtNewsPaperName.Text);
                para.Add("-");
                para.Add("-");
            }
            else
            {
                para.Add("-");
                para.Add("-");
                para.Add(txt_Tender.Text);
            }




            para.Add("u");
            bl.ExecuteStoredFunctionWithParameters(para, "sp_update_shifarasPatra");
            lblmsg.Text = "Record Updated";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "update();", true);
            clearall();
            fillRecord();
            btn_Add.Enabled = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = true;
            stagetrack();
            btn_nxt.Focus();
        }
        catch (Exception ex)
        {
        }
    }



    protected void btn_delete_Click(object sender, EventArgs e)
    {
        try
        {  
            int select=0;
            for (int i = 0; i < GridView1.Items.Count; i++)
            {
                CheckBox cb = (CheckBox)GridView1.Items[i].FindControl("CheckBox1");
                DataSet ds = new DataSet();
                if (cb.Checked)
                {
                    select=1;
                    List<string> para = new List<string>();
                    para.Add(GridView1.Items[i].Cells[2].Text.ToString());
                    ds = obj.FillGridWithParameter(para, "Delete_Advertisment");
                    
                }
            }
             fillRecord();
            if(select==1)
            {
                lblmsg.Text = "Record Deleted";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "delet();", true);
            }
                else
                {
                    lblmsg.Text = "Select Record To Delete";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "confirmtodel();", true);
                    lblmsg.Visible = true;
                }
            }
           
        
        catch (Exception ex)
        { }
    }

    //protected void btn_delete_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        for (int i = 0; i < GridView1.Items.Count; i++)
    //        {
    //            CheckBox cb = (CheckBox)GridView1.Items[i].FindControl("CheckBox1");
    //            DataSet ds = new DataSet();
    //            if (cb.Checked)
    //            {
    //                List<string> para = new List<string>();
    //                para.Add(GridView1.Items[i].Cells[2].Text.ToString());
    //                ds = obj.FillGridWithParameter(para, "Delete_Advertisment");
    //                lblmsg.Text = "Record Deleted";
    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "delete();", true);
    //            }
    //            else
    //            {
    //            lblmsg.Text = "Select Record To Delete";
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "confirmtodel();", true);
    //                lblmsg.Visible = true;
    //            }
    //        }
    //        fillRecord();
    //    }
    //    catch (Exception ex)
    //    { }
    //}

    public void clearall()
    {
        txt_Tender.Text = "";
        txtNewsPaperName.Text = "";
        txtNoticeBoard.Text = "";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "show_control();", true); 
    }  
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        btn_Add.Enabled = false;
        btn_update.Enabled = true;
        btn_delete.Enabled = false;
        HiddenField2.Value = GridView1.SelectedItem.Cells[2].Text.ToString();
        txt_addDate.Text = GridView1.SelectedItem.Cells[3].Text.ToString();
        txt_adNo.Text = GridView1.SelectedItem.Cells[4].Text.ToString();
        txt_sellDate.Text = GridView1.SelectedItem.Cells[5].Text.ToString();
        txt_salefinal_dale.Text = GridView1.SelectedItem.Cells[6].Text.ToString();
        txt_lastDate.Text = GridView1.SelectedItem.Cells[7].Text.ToString();
        txt_openDate.Text = GridView1.SelectedItem.Cells[8].Text.ToString();
        ddl_publishtype.ClearSelection();
        ddl_publishtype.Items.FindByText(GridView1.SelectedItem.Cells[10].Text.ToString()).Selected = true;

        if (GridView1.SelectedItem.Cells[10].Text.ToString() == "वर्तंमान पत्र")
        {
            Panel_NewsPaper.Visible = true;
            txtNewsPaperName.Text=GridView1.SelectedItem.Cells[11].Text .ToString();
        }
        else if (GridView1.SelectedItem.Cells[10].Text.ToString()== "नोटीस बोर्ड")
        {
            Panel_DenikBoard.Visible = true;
            txtNoticeBoard.Text=GridView1.SelectedItem.Cells[12].Text .ToString();
        }
        else
        {
            Panel_NewsPaper.Visible = false;
            Panel_DenikBoard.Visible = false;
            txt_Tender.Text = GridView1.SelectedItem.Cells[13].Text.ToString();
            Panel_Tender.Visible = true;
        }
        ddlNewsPaper.ClearSelection();
        //ddlNewsPaper.Items.FindByText(GridView1.SelectedItem.Cells[11].Text.ToString()).Selected = true;
        
        //ddl_ntype.ClearSelection();
        //ddl_ntype.Items.FindByText(GridView1.SelectedItem.Cells[4].Text.ToString()).Selected = true;
        //DropDownList2.ClearSelection();
        //DropDownList2.Items.FindByText(GridView1.SelectedItem.Cells[5].Text.ToString()).Selected = true;
      
    }
    protected void GridView1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        fillRecord();
        GridView1.CurrentPageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Form/HomePage.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Report/shifarspatra.aspx");
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedItem.ToString() != "0")
                AddRecord();
            else
            {
                lblmsg.Text = "Select Grampanchayat";
            }
            Button2.Enabled = false;
            Button3.Enabled = true;
            stagetrack();
            btn_nxt.Focus();


            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "disable_control();", true);    
            }
        catch (Exception ex)
        { }
    }
    protected void stagetrack()
    {
        List<string> list = new List<string>();
        list.Add(Session["Work_ID"].ToString());
        list.Add("5");
        list.Add(Session["User_Id"].ToString());
        list.Add(Session["officeid"].ToString());
        obj.FillGridWithParameter(list, "sp_Stage_Tracking_insert");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        List<string> para = new List<string>();
        DataSet ds = new DataSet();
        if (DropDownList1.SelectedItem.ToString() != "0")
        {
            para.Add("1");
            para.Add(Session["Work_ID"].ToString());
            para.Add(DropDownList1.SelectedValue.ToString());
            para.Add(TextBox2.Text);
            string date = bl.convertDate(TextBox4.Text);
            para.Add(date);
            para.Add(bl.convertDate(TextBox6.Text));
            para.Add(TextBox3.Text);
            para.Add("1900/1/1");
            para.Add("1900/1/1");
            para.Add("1900/1/1");
            para.Add(Session["officeid"].ToString());
            //para.Add(RadioButtonList1.SelectedValue.ToString());
           
            para.Add("O");
            para.Add(TextBox5.Text);
            para.Add(TextBox1.Text);//magnipatra No.
           // para.Add(ddlNewsPaper.SelectedValue.ToString());
            para.Add("u");
            bl.ExecuteStoredFunctionWithParameters(para, "sp_update_shifarasPatra");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "isActive", "update();", true);
            lblmsg.Text = "Record Updated ";
            fillRecord();
            stagetrack();
            btn_nxt.Focus();
        }
        else 
        {
            lblmsg.Text = "Select Grampanchayat";
        }     
    }
    public void cllall()
    {
        DropDownList1.ClearSelection();
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox1.Text = "";
        TextBox6.Text = "";
        lblmsg.Text = "";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        DropDownList1.Focus();
        cllall();
        Button2.Enabled = true;
        Button3.Enabled = false;

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        ddl_ntype.Focus();
        cleeral();
        btn_Add.Enabled = true;
        btn_update.Enabled = false;
    }
    public void cleeral()
    {
        txt_addDate.Text = "";
        txt_adNo.Text = "";
        txt_sellDate.Text="";
        txt_lastDate.Text="";
        txt_openDate.Text="";
        txtNewsPaperName.Text = "";
        txtNoticeBoard.Text = "";
        ddl_ntype.ClearSelection();
        DropDownList2.ClearSelection();
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        ddlthekedar.ClearSelection();
        txtshifarasKramank.Text = "";
        fd.Text="";
        ddlthekedar.Focus();

    }
    protected void LinkButton2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Form/Thekedar Master.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Form/NewsPaperMaster.aspx");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Form/GramPanchayatMaster.aspx");
    }
    protected void btn_nxt_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Form/Nivida_Karar.aspx");
    }
    private void ddl_publishtype_master()
    {
        DataSet ds2 = new DataSet();
        List<string> plist = new List<string>();
        plist.Add(Session["officeid"].ToString());
        ddl_publishtype.DataValueField = "p_type";
        ddl_publishtype.DataTextField = "ptype";
        ds2 = bl.FillGridWithParameter(plist, "sp_fillgridPublish");
        ddl_publishtype.DataSource = ds2;
        ddl_publishtype.DataBind();
        ddl_publishtype.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void fillddlnewspaper()
    {
        DataSet ds = new DataSet();
        ds = obj.FillGrid("sp_fillNews_shifaras");
        ddlNewsPaper.DataTextField = "news_name";
        ddlNewsPaper.DataValueField = "newspaper_id";
        ddlNewsPaper.DataSource = ds;
        ddlNewsPaper.DataBind();
        ddlNewsPaper.Items.Insert(0, new ListItem("---select---", "0"));
    }
    //protected void ddl_publishtype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddl_publishtype.SelectedItem.Text.ToString() == "वर्तंमान पत्र")
    //    {
    //        fillddl1();
    //        fillnewsddl();
    //        fillddlnewspaper();
    //        //ddl_ntype.Visible = true;
    //        //DropDownList2.Visible = true;
    //        //LinkButton3.Visible = true;
    //        //Label19.Visible = true;
    //        //Label20.Visible = true;
    //    }
    //    else
    //    {
    //        ddl_ntype.Visible = false;
    //        DropDownList2.Visible = false;
    //        LinkButton3.Visible = false;
    //        Label19.Visible = false;
    //        Label20.Visible = false;

    //    }
    //}





    //For disable next stage button 17/8/2015
    protected void Checkstagestatus()
    {
        DataSet ds = new DataSet();
        List<string> list = new List<string>();
        list.Add(Session["Work_ID"].ToString());
        list.Add("5");
        ds = obj.FillGridWithParameter(list, "sp_Check_Stage_Status");
        if (ds.Tables[0].Rows.Count != 0)
        {
            lnk_Next.Visible = true;
        }
        else
        {
            lnk_Next.Visible = false;
        }
    }



    //protected void ddl_publishtype_SelectedIndexChanged(object sender, EventArgs e)
    //{
        
    //    if (ddl_publishtype.SelectedItem.Text.ToString() == "वर्तंमान पत्र")
    //    {
    //        ddlNewsPaper.Enabled = true;
    //        fillddl1();
    //        fillnewsddl();
    //       // fillddlnewspaper();
    //        //ddl_ntype.Visible = true;
    //        //DropDownList2.Visible = true;
    //        //LinkButton3.Visible = true;
    //        //Label19.Visible = true;
    //        //Label20.Visible = true;
    //    }
    //    else
    //    {
    //        ddl_ntype.Visible = false;
    //        DropDownList2.Visible = false;
    //        LinkButton3.Visible = false;
    //        Label19.Visible = false;
    //        Label20.Visible = false;
    //        ddlNewsPaper.Enabled = false;
    //    }
    //}

    protected void ddl_publishtype_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddl_publishtype.SelectedItem.Text.ToString() == "वर्तंमान पत्र")
        {
            ddlNewsPaper.Enabled = true;
            fillddl1();
            fillnewsddl();
            // fillddlnewspaper();
            //ddl_ntype.Visible = true;
            //DropDownList2.Visible = true;
            //LinkButton3.Visible = true;
            //Label19.Visible = true;
            //Label20.Visible = true;
            Panel_NewsPaper.Visible = true;
            Panel_DenikBoard.Visible = false;
        }
        else if (ddl_publishtype.SelectedItem.Text.ToString() == "नोटीस बोर्ड")
        {
            ddl_ntype.Visible = false;
            DropDownList2.Visible = false;
            LinkButton3.Visible = false;
            Label19.Visible = false;
            Label20.Visible = false;
            ddlNewsPaper.Enabled = false;
            Panel_DenikBoard.Visible = true;
            Panel_NewsPaper.Visible = false;
        }
        else
        {
            Panel_Tender.Visible = true;
            Panel_DenikBoard.Visible = false;
            Panel_NewsPaper.Visible = false;

        }
    }

}
