using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AppletSoftware.Models;
using Microsoft.Win32;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace AppletSoftware.Views.Reports
{
    public partial class NewsReport : System.Web.UI.Page
    {

      private new AppletSoftwareEntities Context = new AppletSoftwareEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
           

                IEnumerable<AspNetNew> News = Context.AspNetNews.ToList();

                foreach (var item in News)
                {
                item.NCat_Id = Context.AspNetNewsCategories.Find(item.NCat_Id).NCat_Name_En;

                string Fname = Context.AspNetUsersInfoPlus.Where(m => m.Id == item.Id).SingleOrDefault().UInfoPlus_Fname_En;
                string Lname = Context.AspNetUsersInfoPlus.Where(m => m.Id == item.Id).SingleOrDefault().UInfo_Lname_En;

                item.Id = Fname + " " + Lname;
                }

                App_Reports.NewsReport Report = new App_Reports.NewsReport();
                Report.Load(Path.Combine(Server.MapPath("~/App_Reports"), "NewsReport.rpt"));
                Report.SetDataSource(News);

                CrystalReportViewer1.ReportSource = Report;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();



            



        }
    }
}