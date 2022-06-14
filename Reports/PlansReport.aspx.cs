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
    public partial class PlansReport : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            using (AppletSoftwareEntities Context=new AppletSoftwareEntities ())
            {                             
                IEnumerable<AspNetPlan> Plans = Context.AspNetPlans.ToList();

                foreach (var item in Plans)
                {

                 
                    item.PlanCat_Id = Context.AspNetPlansCategories.Find(item.PlanCat_Id).PlanCat_Name_En;
                    string Fname = Context.AspNetUsersInfoPlus.Where(m => m.Id == item.Id).SingleOrDefault().UInfoPlus_Fname_En;
                    string Lname = Context.AspNetUsersInfoPlus.Where(m => m.Id == item.Id).SingleOrDefault().UInfo_Lname_En;
                    item.Id = Fname + " " + Lname;





                }



                App_Reports.PlansReport Report = new App_Reports.PlansReport();
                Report.Load(Path.Combine(Server.MapPath("~/App_Reports"), "PlansReport.rpt"));
                Report.SetDataSource(Plans);

                CrystalReportViewer1.ReportSource = Report;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();



            }



        }
    }
}