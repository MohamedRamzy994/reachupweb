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
    public partial class ManagersReport : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            using (AppletSoftwareEntities Context=new AppletSoftwareEntities ())
            {


                IEnumerable<AspNetUsersInfoPlu> Managers = Context.AspNetUsersInfoPlus.ToList();

                foreach (var item in Managers)
                {

                   
                   
                    string Fname = Context.AspNetUsersInfoPlus.Where(m => m.Id == item.Id).SingleOrDefault().UInfoPlus_Fname_En;
                    string Lname = Context.AspNetUsersInfoPlus.Where(m => m.Id == item.Id).SingleOrDefault().UInfo_Lname_En;
                    item.UInfo_Publisher = Fname + " " + Lname;





                }


                App_Reports.ManagersReport Report = new App_Reports.ManagersReport();
                Report.Load(Path.Combine(Server.MapPath("~/App_Reports"), "ManagersReport.rpt"));
                Report.SetDataSource(Managers);

                CrystalReportViewer1.ReportSource = Report;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();



            }



        }
    }
}