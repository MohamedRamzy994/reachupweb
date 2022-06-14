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
    public partial class ClientsReport : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            using (AppletSoftwareEntities Context=new AppletSoftwareEntities ())
            {


                IEnumerable<AspNetClient> Clients = Context.AspNetClients.ToList();

           

                App_Reports.ClientsReport Report = new App_Reports.ClientsReport();
                Report.Load(Path.Combine(Server.MapPath("~/App_Reports"), "ClientsReport.rpt"));
                Report.SetDataSource(Clients);

                CrystalReportViewer1.ReportSource = Report;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();



            }



        }
    }
}