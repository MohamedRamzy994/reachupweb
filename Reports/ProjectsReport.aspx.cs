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
    public partial class ProjectsReport : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            using (AppletSoftwareEntities Context=new AppletSoftwareEntities ())
            {


                IEnumerable<AspNetProject> Projects = Context.AspNetProjects.ToList();

                foreach (var item in Projects)
                {

                    item.Project_Photo = Path.Combine(Server.MapPath("~/Images/resizedprojects/"), item.Project_Photo);
                    item.PCat_Id = Context.AspNetProjectsCategories.Find(item.PCat_Id).PCat_Name_En;
                    string Fname= Context.AspNetUsersInfoPlus.Where(m=>m.Id==item.Id).SingleOrDefault().UInfoPlus_Fname_En;
                    string Lname = Context.AspNetUsersInfoPlus.Where(m => m.Id == item.Id).SingleOrDefault().UInfo_Lname_En;
                    item.Id = Fname + " " + Lname;
                   




                }

                App_Reports.ProjectsReport Report = new App_Reports.ProjectsReport();
                Report.Load(Path.Combine(Server.MapPath("~/App_Reports"), "ProjectsReport.rpt"));
                Report.SetDataSource(Projects);

                CrystalReportViewer1.ReportSource = Report;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();



            }



        }
    }
}