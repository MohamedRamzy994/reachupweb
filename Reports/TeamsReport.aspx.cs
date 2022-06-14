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
    public partial class TeamsReport : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            AppletSoftwareEntities Context = new AppletSoftwareEntities();


                IEnumerable<AspNetTeam> Teams = Context.AspNetTeams.ToList();

                foreach (var item in Teams)
                {
                    item.TCat_Id = Context.AspNetTeamsCategories.Find(item.TCat_Id).TCat_Name_En;


                }

                App_Reports.TeamsReport Report = new App_Reports.TeamsReport();
                Report.Load(Path.Combine(Server.MapPath("~/App_Reports"), "TeamsReport.rpt"));
                Report.SetDataSource(Teams);

                CrystalReportViewer1.ReportSource = Report;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();



        



        }
    }
}