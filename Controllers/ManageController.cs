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
using System.Collections.Generic;
using PagedList.Mvc;
using PagedList;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Net;
using System.Threading;
using System.Globalization;

namespace AppletSoftware.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private AppletSoftwareEntities Context = new AppletSoftwareEntities();


        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }





        #region  OrdersArea

         [HttpGet]
        public ActionResult ClientsOrders(int? page, string language)
        {

            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();

                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;

                    }

                    IPagedList<AspNetPlanOrder> Model = Context.AspNetPlanOrders.OrderByDescending(m => m.Order_DateTime).ToPagedList(pageNumber, 10);





                    return View(Model);
                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SeenClientsOrders(string Order_Id,string language)
        {


            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {


                    AspNetPlanOrder Order = Context.AspNetPlanOrders.Find(Order_Id);
                    if (Order != null)
                    {

                        Order.Order_Response = true;


                        Context.SaveChanges();

                        if (Context.GetValidationErrors().Count() == 0)
                        {

                            TempData["alertMessage"] = "Success";

                            return RedirectToActionPermanent("ClientsOrders", "Manage");


                        }
                        else
                        {
                            TempData["alertMessage"] = "Error";

                            return RedirectToActionPermanent("ClientsOrders", "Manage");
                        }

                    }







                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }


            }
            catch
            {

                ////EnableLogging(true, true, true);
                //SetInteropLogging(true);
                ////SetLoaderLogging(true);
                ////SetNetworkLogging(true);
                ////SetNetworkLogging(true);
            }

            return View();
        }



       
        #endregion



        #region IndexArea

        //
        // GET: /Manage/Index
        public ActionResult Dashboard(string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    ViewData["Projects"] = Context.AspNetProjects.Count();
                    ViewData["Clients"] = Context.AspNetClients.Count();
                    ViewData["Plans"] = Context.AspNetPlans.Count();
                    ViewData["Teams"] = Context.AspNetTeams.Count();
                    ViewData["Managers"] = Context.AspNetUsers.Count();
                    ViewData["Testmonials"] = Context.AspNetTestmonials.Count();
                    ViewData["News"] = Context.AspNetNews.Count();
                    ViewData["NewsLetters"] = Context.AspNetNewsLetters.Count();
                    ViewData["Orders"] = Context.AspNetPlanOrders.Count();
                    ViewData["Messages"] = Context.AspNetMessages.Count();


                    ViewData["RecentClients"] = Context.AspNetClients.ToList();


                    return View();
                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }
            }
            catch (Exception)
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }




            return View();
        }

        public ActionResult ActiveNewsLetters(int? page,string language)
        {

            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                      
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                        
                    }

                    IPagedList<AspNetNewsLetter> Model = Context.AspNetNewsLetters.OrderByDescending(m=>m.Letter_DateTime).ToPagedList(pageNumber, 10);





                    return View(Model);
                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SeenNewsLetters(string Letter_Id,string language)
        {

           
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                 
                    AspNetNewsLetter Letter = Context.AspNetNewsLetters.Find(Letter_Id);
                    if (Letter!=null)
                    {

                        Letter.Letter_Active = false;


                        Context.SaveChanges();

                        if (Context.GetValidationErrors().Count()==0)
                        {

                            TempData["alertMessage"] = "Success";
                     
                            return RedirectToActionPermanent("ActiveNewsLetters", "Manage");


                        }
                        else
                        {
                            TempData["alertMessage"] = "Error";
                         
                            return RedirectToActionPermanent("ActiveNewsLetters", "Manage");
                        }

                    }

                   




                   
                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }


            }
            catch
            {

                ////EnableLogging(true, true, true);
                //SetInteropLogging(true);
                ////SetLoaderLogging(true);
                ////SetNetworkLogging(true);
                ////SetNetworkLogging(true);
            }

            return View();
        }

        public ActionResult ActiveMessages(int? page,string language)
        {



            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();

                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;

                    }

                    IPagedList<AspNetMessage> Model = Context.AspNetMessages.OrderByDescending(m => m.Message_DateTime).ToPagedList(pageNumber, 10);





                    return View(Model);
                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View();


        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SeenMessages(string Message_Id,string language)
        {


            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {
                    

                    AspNetMessage Message = Context.AspNetMessages.Find(Message_Id);
                    if (Message != null)
                    {

                        Message.Message_Active = false;


                        Context.SaveChanges();

                        if (Context.GetValidationErrors().Count() == 0)
                        {

                            TempData["alertMessage"] = "Success";

                            return RedirectToActionPermanent("ActiveMessages", "Manage");


                        }
                        else
                        {
                            TempData["alertMessage"] = "Error";

                            return RedirectToActionPermanent("ActiveMessages", "Manage");
                        }

                    }







                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }


            }
            catch
            {

                ////EnableLogging(true, true, true);
                //SetInteropLogging(true);
                ////SetLoaderLogging(true);
                ////SetNetworkLogging(true);
                ////SetNetworkLogging(true);
            }

            return View();
        }

        public ActionResult MessagesInbox(string Message_Id,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();

                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;

                    }

                    AspNetMessage Message = Context.AspNetMessages.Find(Message_Id);

                    if (Message!=null)
                    {
                        MessagesInboxViewModel Model = new MessagesInboxViewModel();

                        Model.Message_Email = Message.Message_Email;
                        Model.Message_Subject = Message.Message_Subject;
                        Model.Message_Content = Message.Message_Content;



                        return View(Model);


                    }





                }
                else
                {
                    return RedirectToActionPermanent("MessagesInbox", "Manage");
                }
            }
            catch (Exception)
            {


                ////EnableLogging(true, true, true);
                //SetInteropLogging(true);
                ////SetLoaderLogging(true);
                ////SetNetworkLogging(true);
                ////SetNetworkLogging(true); 
            }




            return View();


        }

         [HttpPost]
         [ValidateAntiForgeryToken]
        public ActionResult ComposeMessage(MessagesInboxViewModel Model,string language)
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated&&User.IsInRole("Manager"))
                {

                    //created object of SmtpClient details and provides server details
                    SmtpClient MyServer = new SmtpClient();
                    MyServer.Host = "smtp.gmail.com";
                    MyServer.Port = 587;
                    MyServer.EnableSsl = true;

                    //Server Credentials
                    NetworkCredential NC = new NetworkCredential();
                    NC.UserName = "ramzymohamed790@gmail.com";
                    NC.Password = "Ruzell7777";
                    //assigned credetial details to server
                    MyServer.Credentials = NC;

                    //create sender address
                    MailAddress from = new MailAddress("ramzymohamed790@gmail.com", "APPLET Software");

                    //create receiver address
                    MailAddress receiver = new MailAddress(Model.Message_Email, "APPLET Client");

                    MailMessage Mymessage = new MailMessage(from, receiver);
                    Mymessage.Subject = Model.Message_Subject;
                    Mymessage.Body = Model.Message_Content;
                    Mymessage.IsBodyHtml = true;
                    //sends the email
                    MyServer.Send(Mymessage);

                    AspNetMessage Message = Context.AspNetMessages.Find(Model.Message_Id);
                    Message.Message_Response = true;
                    Context.SaveChanges();
                    if (Context.GetValidationErrors().Count()==0)
                    {

                        TempData["alertMessage"] = "Success";
                        return RedirectToActionPermanent("ActiveMessages", "Manage");

                    }
                    else
                    {
                        TempData["alertMessage"] = "Success";
                        return RedirectToActionPermanent("ActiveMessages", "Manage");
                    }



                   
                }


            
                else
                {
                    return RedirectToActionPermanent("Login", "Manage");
                }

            }
            catch (Exception ex)
            {
                ////EnableLogging(true, true, true);
                //SetInteropLogging(true);
                ////SetLoaderLogging(true);
                ////SetNetworkLogging(true);
                ////SetNetworkLogging(true);

            }


            return View();

        }

        public ActionResult ActiveNotifications(int? page,string language)
        {


            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();

                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;

                    }

                    IPagedList<AspNetNotification> Model = Context.AspNetNotifications.OrderByDescending(m => m.Notify_DateTime).ToPagedList(pageNumber, 10);





                    return View(Model);
                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }





            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SeenNotifications(string Notify_Id,string language)
        {


            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {


                    AspNetNotification Notify = Context.AspNetNotifications.Find(Notify_Id);
                    if (Notify != null)
                    {

                        Notify.Notify_Active = false;


                        Context.SaveChanges();

                        if (Context.GetValidationErrors().Count() == 0)
                        {

                            TempData["alertMessage"] = "Success";

                            return RedirectToActionPermanent("ActiveNotifications", "Manage");


                        }
                        else
                        {
                            TempData["alertMessage"] = "Error";

                            return RedirectToActionPermanent("ActiveNotifications", "Manage");
                        }

                    }







                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }


            }
            catch
            {

                ////EnableLogging(true, true, true);
                //SetInteropLogging(true);
                ////SetLoaderLogging(true);
                ////SetNetworkLogging(true);
                ////SetNetworkLogging(true);
            }

            return View();
        }

        [HttpGet]
       
        public ActionResult ManagerProfile(string Id,string language)
        {

            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated&&User.IsInRole("Manager"))
                {

                    ManagersShowViewModel Entity = Context.AspNetUsers.Join(Context.AspNetUsersInfoPlus, m => m.Id, n => n.Id, (m, n) => new { AspNetUser = m, AspNetUsersInfoPlu = n }).OrderByDescending(m => m.AspNetUsersInfoPlu.UInfo_DateTime).Select(m => new ManagersShowViewModel { Users = m.AspNetUser, UsersPlusInfo = m.AspNetUsersInfoPlu }).Where(m => m.Users.Id == Id && m.UsersPlusInfo.Id == m.Users.Id).SingleOrDefault();
                    if (Entity != null)
                    {

                        ManagersViewModel Model = new ManagersViewModel();

                        Model.Id = Entity.Users.Id;
                        Model.Email = Entity.Users.Email;
                        Model.PhoneNumber = Entity.Users.PhoneNumber;
                        Model.UserName = Entity.Users.UserName;
                        Model.UInfo_Lname_En = Entity.UsersPlusInfo.UInfo_Lname_En;
                        Model.UInfo_Lname_Ar = Entity.UsersPlusInfo.UInfo_Lname_Ar;
                        Model.UInfoPlus_Fname_En = Entity.UsersPlusInfo.UInfoPlus_Fname_En;
                        Model.UInfoPlus_Fname_Ar = Entity.UsersPlusInfo.UInfoPlus_Fname_Ar;
                        Model.UInfoPlus_DateTime = DateTime.Now;
                        Model.UInfo_Photo = Entity.UsersPlusInfo.UInfo_Photo;
                        Model.Password = Entity.Users.PasswordHash;
                        Model.ConfirmPassword = Entity.Users.PasswordHash;



                        if (TempData.ContainsKey("alertMessage"))
                        {
                            Model.ManagersStatus = TempData["alertMessage"].ToString();
                        }
                        else
                        {
                            Model.ManagersStatus = string.Empty;
                        }




                        return View(Model);
                    }
                  

                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }



            }
            catch (Exception)
            {

                throw;
            }



            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: /Manage/EditManagers
        public ActionResult ManagerProfileSettings(ManagersViewModel model, HttpPostedFileBase UInfo_Photo,string language)
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {
                    if (ModelState.IsValid)
                    {
                        if (UInfo_Photo != null && UInfo_Photo.ContentLength > 0)
                        {
                            var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                            var fileextention = Path.GetExtension(UInfo_Photo.FileName);

                            //.........check file Extention

                            if (!supportedTypes.Contains(fileextention))
                            {

                                model.ManagersStatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                TempData["alertMessage"] = model.ManagersStatus;
                                return RedirectToActionPermanent("ManagerProfile", "Manage");


                            }
                            else
                            {

                                string fileName = Guid.NewGuid() + Path.GetExtension(UInfo_Photo.FileName);
                                string pathoriginal = Path.Combine(Server.MapPath("~/Images/managers"), fileName).ToString();

                                string pathresized = Path.Combine(Server.MapPath("~/Images/resizedmanagers"), fileName).ToString();
                                UInfo_Photo.SaveAs(pathoriginal);
                                ResizeImage(350, pathoriginal, pathresized);
                                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber, PasswordHash = model.Password };

                                using (AppletSoftwareEntities Context = new AppletSoftwareEntities())
                                {
                                    //System.IO.File.Delete(Server.MapPath("~/Images/resizedmanagers/" + UsersPlusInfo.UInfo_Photo));
                                    //System.IO.File.Delete(Server.MapPath("~/Images/managers/" + UsersPlusInfo.UInfo_Photo));
                                    //ManagersShowViewModel Entity = Context.AspNetUsers.Join(Context.AspNetUsersInfoPlus, m => m.Id, n => n.Id, (m, n) => new { AspNetUser = m, AspNetUsersInfoPlu = n })
                                    //    .OrderByDescending(m => m.AspNetUsersInfoPlu.UInfo_DateTime).Select(m => new ManagersShowViewModel { Users = m.AspNetUser, UsersPlusInfo = m.AspNetUsersInfoPlu })
                                    //    .Where(m => m.Users.Id == model.Id && m.UsersPlusInfo.Id == m.Users.Id).SingleOrDefault();

                                    AspNetUser Users = Context.AspNetUsers.Find(model.Id);
                                    AspNetUsersInfoPlu UsersPlusInfo = Context.AspNetUsersInfoPlus.Where(m => m.Id == model.Id).SingleOrDefault();

                                    Users.Email = user.Email;
                                    Users.UserName = model.Email;
                                    Users.PhoneNumber = user.PhoneNumber;
                                    UsersPlusInfo.UInfo_Photo = fileName;




                                    Context.SaveChanges();
                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        TempData["alertMessage"] = "Success";

                                        AspNetNotification Notify = new AspNetNotification();
                                        Notify.Notify_Id = Guid.NewGuid().ToString();
                                        Notify.Notify_Title = "Edit his Profile";
                                        Notify.Notify_Action = "Managers";
                                        Notify.Notify_Active = true;
                                        Notify.Notify_DateTime = DateTime.Now;
                                        Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                        string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                        string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                        string Manager_Name = FName + " " + LName;

                                        Notify.Notify_Manager_Name = Manager_Name;

                                        Notify.Notify_Manager_Photo = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                        Context.AspNetNotifications.Add(Notify);
                                        Context.SaveChanges();
                                        return RedirectToActionPermanent("ManagerProfile", "Manage", new { Id = model.Id });


                                    }
                                    else
                                    {
                                        TempData["alertMessage"] = "Error";
                                        return RedirectToActionPermanent("ManagerProfile", "Manage", new { Id = model.Id });
                                    }




                                }




                            }
                        }



                    }
                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }




            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }



            return View();
        }



        #endregion




        #region ReportsArea

        // GET: /Manage/Reports
        public ActionResult Reports(string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


            return View();
        }
        // GET: /Manage/Reports
        public ActionResult ReportProjects(string language)
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    //IEnumerable<AspNetProject> Projects= Context.AspNetProjects.ToList();

                    // App_Reports.ProjectsReport Report = new App_Reports.ProjectsReport();
                    // Report.Load(Path.Combine(Server.MapPath("~/App_Reports"), "ProjectsReport.rpt"));
                    // Report.SetDataSource(Projects);


                    // Response.Buffer = false;
                    // Response.ClearContent();
                    // Response.ClearHeaders();

                    // Stream stream = Report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    // stream.Seek(0, SeekOrigin.Begin);
                    // return File(stream, "application/pdf", "EverestList.pdf");


                    //return Redirect("~/Reports/ProjectsReport.aspx");

                    return View();
                                                   

                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }
            }
            catch
            {
                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }


            return View();
        }
        // GET: /Manage/ReportClients
        public ActionResult ReportClients(string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    //IEnumerable<AspNetProject> Projects= Context.AspNetProjects.ToList();

                    // App_Reports.ProjectsReport Report = new App_Reports.ProjectsReport();
                    // Report.Load(Path.Combine(Server.MapPath("~/App_Reports"), "ProjectsReport.rpt"));
                    // Report.SetDataSource(Projects);


                    // Response.Buffer = false;
                    // Response.ClearContent();
                    // Response.ClearHeaders();

                    // Stream stream = Report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    // stream.Seek(0, SeekOrigin.Begin);
                    // return File(stream, "application/pdf", "EverestList.pdf");


                    //return Redirect("~/Reports/ProjectsReport.aspx");

                    return View();


                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }
            }
            catch
            {
                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }



            return View();
        }
        // GET: /Manage/ReportTeams
        public ActionResult ReportTeams(string language)
        {

            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    //IEnumerable<AspNetProject> Projects= Context.AspNetProjects.ToList();

                    // App_Reports.ProjectsReport Report = new App_Reports.ProjectsReport();
                    // Report.Load(Path.Combine(Server.MapPath("~/App_Reports"), "ProjectsReport.rpt"));
                    // Report.SetDataSource(Projects);


                    // Response.Buffer = false;
                    // Response.ClearContent();
                    // Response.ClearHeaders();

                    // Stream stream = Report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    // stream.Seek(0, SeekOrigin.Begin);
                    // return File(stream, "application/pdf", "EverestList.pdf");


                    //return Redirect("~/Reports/ProjectsReport.aspx");

                    return View();


                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }
            }
            catch
            {
                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }


            return View();
        }
        // GET: /Manage/ReportNews
        public ActionResult ReportNews(string language)
        {

            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    //IEnumerable<AspNetProject> Projects= Context.AspNetProjects.ToList();

                    // App_Reports.ProjectsReport Report = new App_Reports.ProjectsReport();
                    // Report.Load(Path.Combine(Server.MapPath("~/App_Reports"), "ProjectsReport.rpt"));
                    // Report.SetDataSource(Projects);


                    // Response.Buffer = false;
                    // Response.ClearContent();
                    // Response.ClearHeaders();

                    // Stream stream = Report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    // stream.Seek(0, SeekOrigin.Begin);
                    // return File(stream, "application/pdf", "EverestList.pdf");


                    //return Redirect("~/Reports/ProjectsReport.aspx");

                    return View();


                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }
            }
            catch
            {
                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }



            return View();
        }
        // GET: /Manage/ReportPlans
        public ActionResult ReportPlans(string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


            return View();
        }
        // GET: /Manage/ReportManagers
        public ActionResult ReportManagers(string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


            return View();
        }
        #endregion

        #region ManagersArea

        // GET: /Manage/Managers
        public ActionResult Managers(int? page,string language)
        {


            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }

                   IPagedList<ManagersShowViewModel> Model = Context.AspNetUsers.Join(Context.AspNetUsersInfoPlus, m => m.Id, n => n.Id, (m, n) => new { AspNetUser = m, AspNetUsersInfoPlu = n }).OrderByDescending(m=>m.AspNetUsersInfoPlu.UInfo_DateTime).Select(m=>new ManagersShowViewModel {Users=m.AspNetUser,UsersPlusInfo=m.AspNetUsersInfoPlu }).ToPagedList(pageNumber, 10);




                    return View(Model);
                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }


            }
            catch
            {

                ////EnableLogging(true, true, true);
                //SetInteropLogging(true);
                ////SetLoaderLogging(true);
                ////SetNetworkLogging(true);
                ////SetNetworkLogging(true);
            }

            return View();



        }

        // Post: /Manage/Managers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteManagers(string Manager_Id,string language)
        {
             try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    ApplicationUser user = UserManager.FindById(Manager_Id);

                    if (HttpContext.GetOwinContext().Request.User.Identity.GetUserId() == user.Id)
                    {
                        bool locked = UserManager.GetLockoutEnabled(user.Id);

                        if (locked == true)
                        {

                            IdentityResult result = UserManager.SetLockoutEnabled(user.Id, false);
                            if (result.Succeeded)
                            {

                                UserManager.SetLockoutEndDate(user.Id, DateTimeOffset.UtcNow);
                                UserManager.ResetAccessFailedCountAsync(user.Id);
                                AspNetNotification Notify = new AspNetNotification();
                                Notify.Notify_Id = Guid.NewGuid().ToString();
                                Notify.Notify_Title = "Unlock Manager";
                                Notify.Notify_Action = "Managers";
                                Notify.Notify_Active = true;
                                Notify.Notify_DateTime = DateTime.Now;
                                Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                 string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                string Manager_Name = FName + " " + LName;

                                Notify.Notify_Manager_Name = Manager_Name;

                                 Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                Context.AspNetNotifications.Add(Notify);
                                Context.SaveChanges();

                                return RedirectToActionPermanent("Managers", "Manage");
                            }



                        }
                        else if (locked == false)
                        {

                            IdentityResult result = UserManager.SetLockoutEnabled(user.Id, true);

                            if (result.Succeeded)
                            {


                                UserManager.SetLockoutEndDate(user.Id, DateTimeOffset.UtcNow.AddDays(30));
                                AspNetNotification Notify = new AspNetNotification();
                                Notify.Notify_Id = Guid.NewGuid().ToString();
                                Notify.Notify_Title = "Lock Manager";
                                Notify.Notify_Action = "Managers";
                                Notify.Notify_Active = true;
                                Notify.Notify_DateTime = DateTime.Now;
                                Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                 string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                string Manager_Name = FName + " " + LName;

                                Notify.Notify_Manager_Name = Manager_Name;

                                 Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                Context.AspNetNotifications.Add(Notify);
                                Context.SaveChanges();

                                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

                                return RedirectToActionPermanent("Login", "Account");
                            }




                        }






                    }

                    else
                    {


                        bool locked = UserManager.GetLockoutEnabled(user.Id);

                        if (locked == true)
                        {

                            IdentityResult result = UserManager.SetLockoutEnabled(user.Id, false);
                            if (result.Succeeded)
                            {

                                UserManager.SetLockoutEndDate(user.Id, DateTimeOffset.UtcNow);
                                UserManager.ResetAccessFailedCount(user.Id);
                                AspNetNotification Notify = new AspNetNotification();
                                Notify.Notify_Id = Guid.NewGuid().ToString();
                                Notify.Notify_Title = "Unlock Manager";
                                Notify.Notify_Action = "Managers";
                                Notify.Notify_Active = true;
                                Notify.Notify_DateTime = DateTime.Now;
                                Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                 string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                string Manager_Name = FName + " " + LName;

                                Notify.Notify_Manager_Name = Manager_Name;

                                 Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                Context.AspNetNotifications.Add(Notify);
                                Context.SaveChanges();
                                return RedirectToActionPermanent("Managers", "Manage");
                            }



                        }
                        else if (locked == false)
                        {

                            IdentityResult result = UserManager.SetLockoutEnabled(user.Id, true);

                            if (result.Succeeded)
                            {


                                UserManager.SetLockoutEndDate(user.Id, DateTimeOffset.UtcNow.AddDays(30));

                                AspNetNotification Notify = new AspNetNotification();
                                Notify.Notify_Id = Guid.NewGuid().ToString();
                                Notify.Notify_Title = "Lock Manager";
                                Notify.Notify_Action = "Managers";
                                Notify.Notify_Active = true;
                                Notify.Notify_DateTime = DateTime.Now;
                                Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                 string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                string Manager_Name = FName + " " + LName;

                                Notify.Notify_Manager_Name = Manager_Name;

                                 Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                Context.AspNetNotifications.Add(Notify);
                                Context.SaveChanges();



                                return RedirectToActionPermanent("Managers", "Manage");
                            }




                        }


                    }




                }

                else
                {

                    return RedirectToActionPermanent("Login", "Account");
                }


            }
            catch
            {

                ////EnableLogging(true, true, true);
                //SetInteropLogging(true);
                ////SetLoaderLogging(true);
                ////SetNetworkLogging(true);
                ////SetNetworkLogging(true);
            }

            return View();



        }

        // GET: /Manage/EditManagers
        public ActionResult EditManagers(string Manager_Id,string language)
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {

                        ManagersShowViewModel Entity = Context.AspNetUsers.Join(Context.AspNetUsersInfoPlus, m => m.Id, n => n.Id, (m, n) => new { AspNetUser = m, AspNetUsersInfoPlu = n }).OrderByDescending(m => m.AspNetUsersInfoPlu.UInfo_DateTime).Select(m=>new ManagersShowViewModel { Users = m.AspNetUser, UsersPlusInfo = m.AspNetUsersInfoPlu }).Where(m=>m.Users.Id==Manager_Id&&m.UsersPlusInfo.Id==m.Users.Id).SingleOrDefault();
                        if (Entity != null)
                        {

                            ManagersViewModel Model = new ManagersViewModel();

                            Model.Id = Entity.Users.Id;
                            Model.Email = Entity.Users.Email;
                            Model.PhoneNumber = Entity.Users.PhoneNumber;
                            Model.UserName = Entity.Users.UserName;
                            Model.UInfo_Lname_En = Entity.UsersPlusInfo.UInfo_Lname_En;
                            Model.UInfo_Lname_Ar = Entity.UsersPlusInfo.UInfo_Lname_Ar;
                            Model.UInfoPlus_Fname_En = Entity.UsersPlusInfo.UInfoPlus_Fname_En;
                            Model.UInfoPlus_Fname_Ar = Entity.UsersPlusInfo.UInfoPlus_Fname_Ar;
                            Model.UInfoPlus_DateTime = DateTime.Now;
                            Model.UInfo_Photo = Entity.UsersPlusInfo.UInfo_Photo;
                            Model.Password = Entity.Users.PasswordHash;
                            Model.ConfirmPassword = Entity.Users.PasswordHash;
                          
   

                            if (TempData.ContainsKey("alertMessage"))
                            {
                                Model.ManagersStatus = TempData["alertMessage"].ToString();
                            }
                            else
                            {
                                Model.ManagersStatus = string.Empty;
                            }

                         


                            return View(Model);
                        }
                        else
                        {
                            return RedirectToActionPermanent("Managers", "Manage");
                        }

                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: /Manage/EditManagers
        public ActionResult EditManagers(ManagersViewModel model, HttpPostedFileBase UInfo_Photo,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {
                    if (ModelState.IsValid)
                    {
                        if (UInfo_Photo != null && UInfo_Photo.ContentLength > 0)
                        {
                            var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                            var fileextention = Path.GetExtension(UInfo_Photo.FileName);

                            //.........check file Extention

                            if (!supportedTypes.Contains(fileextention))
                            {

                                model.ManagersStatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                TempData["alertMessage"] = model.ManagersStatus;
                                return RedirectToActionPermanent("EditManagers", "Manage");


                            }
                            else
                            {

                                string fileName = Guid.NewGuid() + Path.GetExtension(UInfo_Photo.FileName);
                                string pathoriginal = Path.Combine(Server.MapPath("~/Images/managers"), fileName).ToString();

                                string pathresized = Path.Combine(Server.MapPath("~/Images/resizedmanagers"), fileName).ToString();
                                UInfo_Photo.SaveAs(pathoriginal);
                                ResizeImage(350, pathoriginal, pathresized);
                                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber, PasswordHash = model.Password };

                                using (AppletSoftwareEntities Context = new AppletSoftwareEntities())
                                {

                                    //ManagersShowViewModel Entity = Context.AspNetUsers.Join(Context.AspNetUsersInfoPlus, m => m.Id, n => n.Id, (m, n) => new { AspNetUser = m, AspNetUsersInfoPlu = n })
                                    //    .OrderByDescending(m => m.AspNetUsersInfoPlu.UInfo_DateTime).Select(m => new ManagersShowViewModel { Users = m.AspNetUser, UsersPlusInfo = m.AspNetUsersInfoPlu })
                                    //    .Where(m => m.Users.Id == model.Id && m.UsersPlusInfo.Id == m.Users.Id).SingleOrDefault();

                                    AspNetUser Users = Context.AspNetUsers.Find(model.Id);
                                    AspNetUsersInfoPlu UsersPlusInfo = Context.AspNetUsersInfoPlus.Where(m => m.Id == model.Id).SingleOrDefault();

                                    Users.Email = user.Email;
                                    Users.UserName = model.Email;
                                    Users.PasswordHash = user.PasswordHash;
                                    Users.PhoneNumber = user.PhoneNumber;
                                    UsersPlusInfo.UInfoPlus_Fname_En = model.UInfoPlus_Fname_En;
                                    UsersPlusInfo.UInfo_Lname_Ar = model.UInfo_Lname_Ar;
                                    UsersPlusInfo.UInfo_Lname_En = model.UInfo_Lname_En;
                                    UsersPlusInfo.UInfo_DateTime = DateTime.Now;
                                    UsersPlusInfo.UInfoPlus_Fname_Ar = model.UInfoPlus_Fname_Ar;
                                    UsersPlusInfo.UInfo_Photo = fileName;
                                    UsersPlusInfo.UInfo_Publisher = User.Identity.GetUserId();

                                    //System.IO.File.Delete(Server.MapPath("~/Images/resizedmanagers/" + UsersPlusInfo.UInfo_Photo));
                                    //System.IO.File.Delete(Server.MapPath("~/Images/managers/" + UsersPlusInfo.UInfo_Photo));

                                    Context.SaveChanges();
                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        TempData["alertMessage"] = "Success";

                                        AspNetNotification Notify = new AspNetNotification();
                                        Notify.Notify_Id = Guid.NewGuid().ToString();
                                        Notify.Notify_Title = "Edit Manager";
                                        Notify.Notify_Action = "Managers";
                                        Notify.Notify_Active = true;
                                        Notify.Notify_DateTime = DateTime.Now;
                                        Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                         string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                        string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                        string Manager_Name = FName + " " + LName;

                                        Notify.Notify_Manager_Name = Manager_Name;

                                         Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                        Context.AspNetNotifications.Add(Notify);
                                        Context.SaveChanges();
                                        return RedirectToActionPermanent("EditManagers", "Manage", new { Managers_Id = model.Id });


                                    }
                                    else
                                    {
                                        TempData["alertMessage"] = "Error";
                                        return RedirectToActionPermanent("EditManagers", "Manage", new { Managers_Id = model.Id });
                                    }



                                   
                                }

                              
                               

                            }
                        }



                    }
                }
                else
                {
                    return RedirectToActionPermanent("Login", "Account");
                }


         
                 
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }



            return View();
        }

        #endregion


        #region ProjectsArea

        // GET: /Manage/Projects
        public ActionResult Projects(int? page,string language)
        {


            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }
                  
                  
                    ViewData["Categories"] = new SelectList(Context.AspNetProjectsCategories.ToList(), "PCat_Name_En", "PCat_Name_En");


                    return View(Context.AspNetProjects.OrderByDescending(m => m.Project_DateTime).ToPagedList(pageNumber, 10));
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetProjectsCategories.OrderByDescending(m => m.PCat_DateTime).ToPagedList(pageNumber, 10));


           
        }

        // GET: /Manage/ProjectsCategories
        public ActionResult ProjectsCategories(int?page,string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            int pageNumber = page ?? 1;  
            try
            {

                  
                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                       ViewBag.alertMessage=TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }
                    
                    return View(Context.AspNetProjectsCategories.OrderByDescending(m=>m.PCat_DateTime).ToPagedList(pageNumber, 10));
                }

                
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetProjectsCategories.OrderByDescending(m => m.PCat_DateTime).ToPagedList(pageNumber, 10));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeleteProjectsCategories
        public ActionResult DeleteProjectsCategories(string PCat_Id,string language)
        {
            using (Context)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                    if (!string.IsNullOrEmpty(PCat_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetProjectsCategory Entity = Context.AspNetProjectsCategories.Find(PCat_Id);

                            
                            if (Entity != null)
                            {

                                Context.AspNetProjectsCategories.Remove(Entity);
                                                                               
                                    Context.SaveChanges();

                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                       
                                        TempData["alertMessage"] = "Success";

                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete Projects Category";
                                    Notify.Notify_Action = "Projects Categories";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();
                                    return RedirectToActionPermanent("ProjectsCategories", "Manage");

                                    }
                                    else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("ProjectsCategories", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("ProjectsCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/EditProjectsCategories
        public ActionResult EditProjectsCategories(string PCat_Id,string language)
        {
              try
                {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                if (!string.IsNullOrEmpty(PCat_Id))
                {


                    using (Context)
                    {
                       
                            if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                            {

                            AspNetProjectsCategory Entity = Context.AspNetProjectsCategories.Find(PCat_Id);
                            if (Entity!=null)
                            {

                                ProjectsCategoriesViewModel Model = new ProjectsCategoriesViewModel();

                                Model.Id = Entity.Id;
                                Model.PCat_DateTime = Entity.PCat_DateTime;
                                Model.PCat_Description_Ar = Entity.PCat_Description_Ar;
                                Model.PCat_Description_En = Entity.PCat_Description_En;
                                Model.PCat_Id = Entity.PCat_Id;
                                Model.PCat_Name_Ar = Entity.PCat_Name_Ar;
                                Model.PCat_Name_En = Entity.PCat_Name_En;
                                if (TempData.ContainsKey("alertMessage"))
                                {
                                    Model.ProjectCategoryStatus = TempData["alertMessage"].ToString();
                                }
                                else
                                {
                                    Model.ProjectCategoryStatus = string.Empty;
                                }

                              

                                return View(Model);


                            }
                          



                            }
                            else
                            {
                                return RedirectToActionPermanent("Login", "Account");
                            }



                    }

                }
                else
                {
                    RedirectToActionPermanent("ProjectsCategories", "Manage");
                }

                }
            
                catch
                {
                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }
                

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/EditProjectsCategories
        public ActionResult EditProjectsCategories(ProjectsCategoriesViewModel Model,string language)
        {
            using (Context) { 
                try
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                    if (!string.IsNullOrEmpty(Model.PCat_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetProjectsCategory Entity = Context.AspNetProjectsCategories.Find(Model.PCat_Id);
                            if (Entity != null)
                            {


                                if (ModelState.IsValid)
                                {



                                    //Entity.PCat_DateTime = DateTime.Now;
                                    Entity.PCat_Description_Ar = Model.PCat_Description_Ar;
                                    Entity.PCat_Description_En = Model.PCat_Description_En;
                                    Entity.PCat_Name_Ar = Model.PCat_Name_Ar;
                                    Entity.PCat_Name_En = Model.PCat_Name_En;
                                    Entity.Id = User.Identity.GetUserId();


                                    Context.SaveChanges();

                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        Model.ProjectCategoryStatus = "Success";
                                        TempData["alertMessage"] = Model.ProjectCategoryStatus;

                                        AspNetNotification Notify = new AspNetNotification();
                                        Notify.Notify_Id = Guid.NewGuid().ToString();
                                        Notify.Notify_Title = "Edit Projects Category";
                                        Notify.Notify_Action = "Projects Categories";
                                        Notify.Notify_Active = true;
                                        Notify.Notify_DateTime = DateTime.Now;
                                        Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                         string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                        string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                        string Manager_Name = FName + " " + LName;

                                        Notify.Notify_Manager_Name = Manager_Name;

                                         Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                        Context.AspNetNotifications.Add(Notify);
                                        Context.SaveChanges();

                                        return RedirectToAction("EditProjectsCategories", "Manage", new { PCat_Id= Model.PCat_Id });

                                    }
                                    else
                                    {
                                        Model.ProjectCategoryStatus = "Error";
                                        TempData["alertMessage"] = Model.ProjectCategoryStatus;
                                        return RedirectToAction("EditProjectsCategories", "Manage", new { PCat_Id= Model.PCat_Id });
                                    }




                                }

                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("ProjectsCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/NewProjectsCategories
        public ActionResult NewProjectsCategories(string language)
        {

            ProjectsCategoriesViewModel Model = new ProjectsCategoriesViewModel();
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {

                      
                        if (TempData.ContainsKey("alertMessage"))
                        {


                            Model.ProjectCategoryStatus = TempData["alertMessage"].ToString();


                        }
                        else
                        {

                            Model.ProjectCategoryStatus = string.Empty;

                        }

                   
                    }
            }
            catch
            {


                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);



            }


            return View(Model);
        }

        // POST: /Manage/NewProjectsCategories
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult NewProjectsCategories(ProjectsCategoriesViewModel Model,string language)
        {
            using (Context)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                    if (ModelState.IsValid)
                    {

                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetProjectsCategory Entity = new AspNetProjectsCategory();
                            Entity.PCat_Id = Guid.NewGuid().ToString();
                            Entity.PCat_Name_En = Model.PCat_Name_En;
                            Entity.PCat_Name_Ar = Model.PCat_Name_Ar;
                            Entity.PCat_Description_Ar = Model.PCat_Description_Ar;
                            Entity.PCat_Description_En = Model.PCat_Description_En;
                            Entity.PCat_DateTime = DateTime.Now;
                            Entity.Id = User.Identity.GetUserId();

                            Context.AspNetProjectsCategories.Add(entity: Entity);
                            Context.SaveChanges();


                            if (Context.GetValidationErrors().Count() == 0)
                            {

                                Model.ProjectCategoryStatus = "Success";
                                AspNetNotification Notify = new AspNetNotification();
                                Notify.Notify_Id = Guid.NewGuid().ToString();
                                Notify.Notify_Title = "Add New Projects Category";
                                Notify.Notify_Action = "Projects Categories";
                                Notify.Notify_Active = true;
                                Notify.Notify_DateTime = DateTime.Now;
                                Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                 string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                string Manager_Name = FName + " " + LName;

                                Notify.Notify_Manager_Name = Manager_Name;

                                 Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                Context.AspNetNotifications.Add(Notify);
                                Context.SaveChanges();
                                TempData["alertMessage"]= Model.ProjectCategoryStatus;
                           
                               

                                return RedirectToActionPermanent("NewProjectsCategories");
                            }
                            else
                            {


                                Model.ProjectCategoryStatus = "Error";
                                TempData["alertMessage"] = Model.ProjectCategoryStatus;
                                return RedirectToActionPermanent("NewProjectsCategories");
                            }


                        }







                    }




                }
                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }





            }


            return View(Model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeleteProjects
        public ActionResult DeleteProjects(string Project_Id,string language)
        {
            using (Context)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                    if (!string.IsNullOrEmpty(Project_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetProject Entity = Context.AspNetProjects.Find(Project_Id);


                            if (Entity != null)
                            {
                                System.IO.File.Delete(Server.MapPath("~/Images/resizedprojects/" + Entity.Project_Photo));
                                System.IO.File.Delete(Server.MapPath("~/Images/projects/" + Entity.Project_Photo));

                                Context.AspNetProjects.Remove(Entity);

                                Context.SaveChanges();

                                if (Context.GetValidationErrors().Count() == 0)
                                {


                                    TempData["alertMessage"] = "Success";
                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete Projects";
                                    Notify.Notify_Action = "Projects";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();
                                    return RedirectToActionPermanent("Projects", "Manage");

                                }
                                else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("Projects", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("Projects", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/EditProject
        public ActionResult EditProjects(string Project_Id,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {

                        AspNetProject Entity = Context.AspNetProjects.Find(Project_Id);
                        if (Entity != null)
                        {

                            ProjectsViewModel Model = new ProjectsViewModel();

                            Model.Id = Entity.Id;
                            Model.Project_DateTime = Entity.Project_DateTime;
                            Model.Project_Descrption_Ar = Entity.Project_Descrption_Ar;
                            Model.Project_Descrption_En = Entity.Project_Descrption_En;
                            Model.PCat_Id = Entity.PCat_Id;
                            Model.Project_Name_Ar = Entity.Project_Name_Ar;
                            Model.Project_Name_En = Entity.Project_Name_En;
                            Model.Project_Photo = Entity.Project_Photo;
                            Model.Project_Url = Entity.Project_Url;
                            if (TempData.ContainsKey("alertMessage"))
                            {
                                Model.ProjectStatus = TempData["alertMessage"].ToString();
                            }
                            else
                            {
                                Model.ProjectStatus = string.Empty;
                            }

                            Model.Categories = new SelectList(Context.AspNetProjectsCategories.ToList(), "PCat_Id", "PCat_Name_En");


                            return View(Model);
                        }
                        else
                        {
                            return RedirectToActionPermanent("Projects", "Manage");
                        }

                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }


        // Post: /Manage/EditProject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProjects(ProjectsViewModel Model,HttpPostedFileBase Project_Photo,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        
                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        if (ModelState.IsValid)
                        {
                            if (Project_Photo != null && Project_Photo.ContentLength > 0)
                            {
                           
                            var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                                var fileextention = Path.GetExtension(Project_Photo.FileName);

                                //.........check file Extention

                                if (!supportedTypes.Contains(fileextention))
                                {

                                    Model.ProjectStatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                    TempData["alertMessage"] = Model.ProjectStatus;
                               
                                return RedirectToActionPermanent("Projects", "Manage");


                                }
                                else
                                {
                               
                                string fileName = Guid.NewGuid() + Path.GetExtension(Project_Photo.FileName);
                                    string pathoriginal = Path.Combine(Server.MapPath("~/Images/projects"), fileName).ToString();

                                    string pathresized = Path.Combine(Server.MapPath("~/Images/resizedprojects"), fileName).ToString();
                                    Project_Photo.SaveAs(pathoriginal);
                                    ResizeImage(350, pathoriginal, pathresized);

                                    AspNetProject Entity = Context.AspNetProjects.Find(Model.Project_Id);
                                    if (Entity != null)
                                    {

                                        //Entity.Project_DateTime = DateTime.Now;
                                        Entity.Project_Name_En = Model.Project_Name_En;
                                        Entity.Project_Name_Ar = Model.Project_Name_Ar;
                                        Entity.Project_Descrption_Ar = Model.Project_Descrption_Ar;
                                        Entity.Project_Descrption_En = Model.Project_Descrption_En;
                                        Entity.Id = User.Identity.GetUserId();
                                        Entity.PCat_Id = Model.PCat_Id;

                                        System.IO.File.Delete(Server.MapPath("~/Images/resizedprojects/" + Entity.Project_Photo));
                                        System.IO.File.Delete(Server.MapPath("~/Images/projects/" + Entity.Project_Photo));

                                        Entity.Project_Photo = fileName;
                                        Context.SaveChanges();
                                        if (Context.GetValidationErrors().Count() == 0)
                                        {

                                            TempData["alertMessage"] = "Success";
                                            AspNetNotification Notify = new AspNetNotification();
                                            Notify.Notify_Id = Guid.NewGuid().ToString();
                                            Notify.Notify_Title = "Edit Projects";
                                            Notify.Notify_Action = "Projects";
                                            Notify.Notify_Active = true;
                                            Notify.Notify_DateTime = DateTime.Now;
                                            Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                             string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                            string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                            string Manager_Name = FName + " " + LName;

                                            Notify.Notify_Manager_Name = Manager_Name;

                                             Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                            Context.AspNetNotifications.Add(Notify);
                                            Context.SaveChanges();

                                            return RedirectToActionPermanent("EditProjects", "Manage",new { Project_Id=Model.Project_Id });


                                        }
                                        else
                                        {
                                            TempData["alertMessage"] = "Error";
                                            return RedirectToActionPermanent("EditProjects", "Manage", new { Project_Id = Model.Project_Id });
                                        }

                                    }
                                    else
                                    {
                                        return RedirectToActionPermanent("Projects", "Manage");
                                    }

                                }
                            }



                        }

                    Model.Categories = new SelectList(Context.AspNetProjectsCategories.ToList(), "PCat_Id", "PCat_Name_En");
                }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                  
               
            }
            catch
            {



                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }

        // GET: /Manage/NewProject
        public ActionResult NewProjects(string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        ProjectsViewModel Model = new ProjectsViewModel();

                        Model.Categories= new SelectList(Context.AspNetProjectsCategories.ToList(), "PCat_Id", "PCat_Name_En");

                        if (TempData.ContainsKey("alertMessage"))
                        {

                            Model.ProjectStatus = TempData["alertMessage"].ToString();

                        }
                        else
                        {
                            Model.ProjectStatus = string.Empty;
                        }

                        return View(Model);

                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }



                           

            return View();
        }

        // Post: /Manage/NewProject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewProjects(ProjectsViewModel Model, HttpPostedFileBase Project_Photo,string language)
        {
            using (Context)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {



                        if (ModelState.IsValid)
                        {
                            if (Project_Photo != null && Project_Photo.ContentLength > 0)
                            {
                                var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                                var fileextention = Path.GetExtension(Project_Photo.FileName);

                                //.........check file Extention

                                if (!supportedTypes.Contains(fileextention))
                                {

                                    Model.ProjectStatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                    TempData["alertMessage"] = Model.ProjectStatus;
                                    return RedirectToActionPermanent("NewProjects", "Manage");

                                   
                                }
                                else
                                {

                                    string fileName = Guid.NewGuid() + Path.GetExtension(Project_Photo.FileName);
                                    string pathoriginal = Path.Combine(Server.MapPath("~/Images/projects"), fileName).ToString();

                                    string pathresized = Path.Combine(Server.MapPath("~/Images/resizedprojects"), fileName).ToString();
                                    Project_Photo.SaveAs(pathoriginal);
                                    ResizeImage(350, pathoriginal, pathresized);


                                    AspNetProject Entity = new AspNetProject();
                                    Entity.Project_Id = Guid.NewGuid().ToString();
                                    Entity.Project_Name_Ar = Model.Project_Name_Ar;
                                    Entity.Project_Name_En = Model.Project_Name_En;
                                    Entity.Project_Descrption_Ar = Model.Project_Descrption_Ar;
                                    Entity.Project_Descrption_En = Model.Project_Descrption_En;
                                    Entity.Project_DateTime = System.DateTime.Now;
                                    Entity.Project_Photo = fileName;
                                    Entity.Project_Url = Model.Project_Url;
                                    Entity.PCat_Id = Model.PCat_Id;
                                    Entity.Id = User.Identity.GetUserId();


                                    Context.AspNetProjects.Add(Entity);
                                    Context.SaveChanges();

                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        TempData["alertMessage"] = "Success";
                                        AspNetNotification Notify = new AspNetNotification();
                                        Notify.Notify_Id = Guid.NewGuid().ToString();
                                        Notify.Notify_Title = "Add New Projects";
                                        Notify.Notify_Action = "Projects";
                                        Notify.Notify_Active = true;
                                        Notify.Notify_DateTime = DateTime.Now;
                                        Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                         string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                        string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                        string Manager_Name = FName + " " + LName;

                                        Notify.Notify_Manager_Name = Manager_Name;

                                         Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                        Context.AspNetNotifications.Add(Notify);
                                        Context.SaveChanges();
                                        return  RedirectToActionPermanent("NewProjects", "Manage");


                                    }
                                    else
                                    {
                                        TempData["alertMessage"] = "Error";
                                       return RedirectToActionPermanent("NewProjects", "Manage");
                                    }
                                }
                            }

                          

                        }
                      

                      

                        Model.Categories = new SelectList(Context.AspNetProjectsCategories.ToList(), "PCat_Id", "PCat_Name_En");
                    }
                    else
                    {

                        return RedirectToActionPermanent("Login", "Account");

                       
                    }




                }
                catch 
                {
                    ////EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    ////SetLoaderLogging(true);
                    ////SetNetworkLogging(true);
                    ////SetNetworkLogging(true);

                }





            }




            return View(Model);
        }
        #endregion

        #region NewsArea
        // GET: /Manage/News
        public ActionResult News(int? page,string language)
        {

            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }


                    ViewData["Categories"] = new SelectList(Context.AspNetNewsCategories.ToList(), "NCat_Name_En", "NCat_Name_En");


                    return View(Context.AspNetNews.OrderByDescending(m => m.News_DateTime).ToPagedList(pageNumber, 10));
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetProjectsCategories.OrderByDescending(m => m.PCat_DateTime).ToPagedList(pageNumber, 10));

       
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeleteNews
        public ActionResult DeleteNews(string News_Id,string language)
        {
            using (Context)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                    if (!string.IsNullOrEmpty(News_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetNew Entity = Context.AspNetNews.Find(News_Id);


                            if (Entity != null)
                            {
                                System.IO.File.Delete(Server.MapPath("~/Images/resizednews/" + Entity.News_Photo));
                                System.IO.File.Delete(Server.MapPath("~/Images/news/" + Entity.News_Photo));

                                Context.AspNetNews.Remove(Entity);

                                Context.SaveChanges();

                                if (Context.GetValidationErrors().Count() == 0)
                                {


                                    TempData["alertMessage"] = "Success";
                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete News";
                                    Notify.Notify_Action = "News";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();

                                    return RedirectToActionPermanent("News", "Manage");

                                }
                                else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("News", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("News", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        [HttpGet]
        // GET: /Manage/EditNews
        public ActionResult EditNews(string News_Id,string language)
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {

                        AspNetNew Entity = Context.AspNetNews.Find(News_Id);
                        if (Entity != null)
                        {

                            NewsViewModel Model = new NewsViewModel();

                            Model.Id = Entity.Id;
                            Model.News_DateTime = Entity.News_DateTime;

                            Model.News_Title_Ar = Entity.News_Title_Ar;
                            Model.News_Title_En = Entity.News_Title_En;
                            Model.News_Short_Ar = Entity.News_Short_Ar;
                            Model.News_Short_En = Entity.News_Short_En;
                            Model.NCat_Id = Entity.NCat_Id;
                            Model.News_Long_Ar = Entity.News_Long_Ar;
                            Model.News_Long_En = Entity.News_Long_En;
                            Model.News_Photo = Entity.News_Photo;
                            
                            if (TempData.ContainsKey("alertMessage"))
                            {
                                Model.NewsStatus = TempData["alertMessage"].ToString();
                            }
                            else
                            {
                                Model.NewsStatus = string.Empty;
                            }

                            Model.Categories = new SelectList(Context.AspNetNewsCategories.ToList(), "NCat_Id", "NCat_Name_En");


                            return View(Model);
                        }
                        else
                        {
                            return RedirectToActionPermanent("News", "Manage");
                        }

                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }

        // Post: /Manage/EditNews
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNews(NewsViewModel Model, HttpPostedFileBase News_Photo,string language)
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        if (ModelState.IsValid)
                        {
                            if (News_Photo != null && News_Photo.ContentLength > 0)
                            {
                                var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                                var fileextention = Path.GetExtension(News_Photo.FileName);

                                //.........check file Extention

                                if (!supportedTypes.Contains(fileextention))
                                {

                                    Model.NewsStatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                    TempData["alertMessage"] = Model.NewsStatus;
                                    return RedirectToActionPermanent("EditNews", "Manage");


                                }
                                else
                                {

                                    string fileName = Guid.NewGuid() + Path.GetExtension(News_Photo.FileName);
                                    string pathoriginal = Path.Combine(Server.MapPath("~/Images/news"), fileName).ToString();

                                    string pathresized = Path.Combine(Server.MapPath("~/Images/resizednews"), fileName).ToString();
                                    News_Photo.SaveAs(pathoriginal);
                                    ResizeImage(350, pathoriginal, pathresized);

                                    AspNetNew Entity = Context.AspNetNews.Find(Model.News_Id);
                                    if (Entity != null)
                                    {

                                        Entity.News_DateTime = DateTime.Now;
                                        Entity.News_Title_En = Model.News_Title_En;
                                        Entity.News_Title_Ar = Model.News_Title_Ar;
                                        Entity.News_Short_Ar = Model.News_Short_Ar;
                                        Entity.News_Short_En = Model.News_Short_En;
                                        Entity.News_Long_Ar = Model.News_Long_Ar;
                                        Entity.News_Long_En = Model.News_Long_En;
                                        Entity.Id = User.Identity.GetUserId();
                                        Entity.NCat_Id = Model.NCat_Id;

                                        System.IO.File.Delete(Server.MapPath("~/Images/resizednews/" + Entity.News_Photo));
                                        System.IO.File.Delete(Server.MapPath("~/Images/news/" + Entity.News_Photo));

                                        Entity.News_Photo = fileName;
                                        Context.SaveChanges();
                                        if (Context.GetValidationErrors().Count() == 0)
                                        {

                                            TempData["alertMessage"] = "Success";
                                          
                                            AspNetNotification Notify = new AspNetNotification();
                                            Notify.Notify_Id = Guid.NewGuid().ToString();
                                            Notify.Notify_Title = "Edit News";
                                            Notify.Notify_Action = "News";
                                            Notify.Notify_Active = true;
                                            Notify.Notify_DateTime = DateTime.Now;
                                            Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                             string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                            string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                            string Manager_Name = FName + " " + LName;

                                            Notify.Notify_Manager_Name = Manager_Name;

                                             Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                            Context.AspNetNotifications.Add(Notify);
                                            Context.SaveChanges();
                                            return RedirectToActionPermanent("EditNews", "Manage", new { News_Id = Model.News_Id });


                                        }
                                        else
                                        {
                                            TempData["alertMessage"] = "Error";
                                            return RedirectToActionPermanent("EditNews", "Manage", new { News_Id = Model.News_Id });
                                        }

                                    }
                                    else
                                    {
                                        return RedirectToActionPermanent("News", "Manage");
                                    }

                                }
                            }



                        }
                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                    Model.Categories = new SelectList(Context.AspNetNewsCategories.ToList(), "NCat_Id", "NCat_Name_En");
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }

        // GET: /Manage/NewNews
        public ActionResult NewNews(string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        NewsViewModel Model = new NewsViewModel();

                        Model.Categories = new SelectList(Context.AspNetNewsCategories.ToList(), "NCat_Id", "NCat_Name_En");

                        if (TempData.ContainsKey("alertMessage"))
                        {

                            Model.NewsStatus = TempData["alertMessage"].ToString();

                        }
                        else
                        {
                            Model.NewsStatus = string.Empty;
                        }

                        return View(Model);

                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewNews(NewsViewModel Model, HttpPostedFileBase News_Photo,string language)
        {
            using (Context)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {



                        if (ModelState.IsValid)
                        {
                            if (News_Photo != null && News_Photo.ContentLength > 0)
                            {
                                var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                                var fileextention = Path.GetExtension(News_Photo.FileName);

                                //.........check file Extention

                                if (!supportedTypes.Contains(fileextention))
                                {

                                    Model.NewsStatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                    TempData["alertMessage"] = Model.NewsStatus;
                                   
                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Add New News";
                                    Notify.Notify_Action = "News";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();
                                    return RedirectToActionPermanent("News", "Manage");


                                }
                                else
                                {

                                    string fileName = Guid.NewGuid() + Path.GetExtension(News_Photo.FileName);
                                    string pathoriginal = Path.Combine(Server.MapPath("~/Images/news"), fileName).ToString();

                                    string pathresized = Path.Combine(Server.MapPath("~/Images/resizednews"), fileName).ToString();
                                    News_Photo.SaveAs(pathoriginal);
                                    ResizeImage(350, pathoriginal, pathresized);


                                    AspNetNew Entity = new AspNetNew();
                                    Entity.News_Id = Guid.NewGuid().ToString();
                                    Entity.News_Title_Ar = Model.News_Title_Ar;
                                    Entity.News_Title_En = Model.News_Title_En;
                                    Entity.News_Short_Ar = Model.News_Short_Ar;
                                    Entity.News_Short_En = Model.News_Short_En;
                                    Entity.News_Long_Ar = Model.News_Long_Ar;
                                    Entity.News_Long_En = Model.News_Long_En;
                                    Entity.News_DateTime = System.DateTime.Now;
                                    Entity.News_Photo = fileName;
                                    
                                    Entity.NCat_Id = Model.NCat_Id;
                                    Entity.Id = User.Identity.GetUserId();


                                    Context.AspNetNews.Add(Entity);
                                    Context.SaveChanges();

                                    Console.WriteLine(Context.GetValidationErrors());

                                    return RedirectToActionPermanent("News", "Manage");
                                }
                            }


                          
                        }




                       
                    }
                    else
                    {

                        return RedirectToActionPermanent("Login", "Account");


                    }




                }
                catch (Exception ex)
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }





            }




            return RedirectToActionPermanent("News", "Manage");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeleteNewsCategories
        public ActionResult DeleteNewsCategories(string NCat_Id,string language)
        {
            using (Context)
            {
                try
                {
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                    if (!string.IsNullOrEmpty(NCat_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetNewsCategory Entity = Context.AspNetNewsCategories.Find(NCat_Id);


                            if (Entity != null)
                            {

                                Context.AspNetNewsCategories.Remove(Entity);
                                Context.SaveChanges();

                                if (Context.GetValidationErrors().Count() == 0)
                                {


                                    TempData["alertMessage"] = "Success";
                                    
                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete News Category";
                                    Notify.Notify_Action = "News Categories";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();
                                    return RedirectToActionPermanent("NewsCategories", "Manage");

                                }
                                else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("NewsCategories", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("NewsCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/NewsCategories
        public ActionResult NewsCategories(int? page,string language)

        {
            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }

                    return View(Context.AspNetNewsCategories.OrderByDescending(m => m.NCat_DateTime).ToPagedList(pageNumber, 10));
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetNewsCategories.OrderByDescending(m => m.NCat_DateTime).ToPagedList(pageNumber, 10));

        
        }

        // GET: /Manage/EditProjectsCategories
        public ActionResult EditNewsCategories(string NCat_Id,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                if (!string.IsNullOrEmpty(NCat_Id))
                {


                    using (Context)
                    {

                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetNewsCategory Entity = Context.AspNetNewsCategories.Find(NCat_Id);
                            if (Entity != null)
                            {

                                NewsCategoriesViewModel Model = new NewsCategoriesViewModel();

                                Model.Id = Entity.Id;
                                Model.NCat_DateTime = Entity.NCat_DateTime;
                                Model.NCat_Description_Ar = Entity.NCat_Description_Ar;
                                Model.NCat_Description_En = Entity.NCat_Description_En;
                                Model.NCat_Id = Entity.NCat_Id;
                                Model.NCat_Name_Ar = Entity.NCat_Name_Ar;
                                Model.NCat_Name_En = Entity.NCat_Name_En;
                                if (TempData.ContainsKey("alertMessage"))
                                {
                                    Model.NewsCategoriesStatus = TempData["alertMessage"].ToString();
                                }
                                else
                                {
                                    Model.NewsCategoriesStatus = string.Empty;
                                }



                                return View(Model);


                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }



                    }

                }
                else
                {
                    RedirectToActionPermanent("NewsCategories", "Manage");
                }

            }

            catch
            {
                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/EditNewsCategories
        public ActionResult EditNewsCategories(NewsCategoriesViewModel Model,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Model.NCat_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetNewsCategory Entity = Context.AspNetNewsCategories.Find(Model.NCat_Id);
                            if (Entity != null)
                            {


                                if (ModelState.IsValid)
                                {



                                    Entity.NCat_DateTime = DateTime.Now;
                                    Entity.NCat_Description_Ar = Model.NCat_Description_Ar;
                                    Entity.NCat_Description_En = Model.NCat_Description_En;
                                    Entity.NCat_Name_Ar = Model.NCat_Name_Ar;
                                    Entity.NCat_Name_En = Model.NCat_Name_En;
                                    Entity.Id = User.Identity.GetUserId();


                                    Context.SaveChanges();

                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        Model.NewsCategoriesStatus = "Success";
                                        TempData["alertMessage"] = Model.NewsCategoriesStatus;
                                        Model.NewsCategoriesStatus = "Success";
                                        AspNetNotification Notify = new AspNetNotification();
                                        Notify.Notify_Id = Guid.NewGuid().ToString();
                                        Notify.Notify_Title = "EditNews Category";
                                        Notify.Notify_Action = "News Categories";
                                        Notify.Notify_Active = true;
                                        Notify.Notify_DateTime = DateTime.Now;
                                        Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                         string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                        string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                        string Manager_Name = FName + " " + LName;

                                        Notify.Notify_Manager_Name = Manager_Name;

                                         Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                        Context.AspNetNotifications.Add(Notify);
                                        Context.SaveChanges();
                                        return RedirectToAction("EditNewsCategories", "Manage", new { NCat_Id = Model.NCat_Id });

                                    }
                                    else
                                    {
                                        Model.NewsCategoriesStatus = "Error";
                                        TempData["alertMessage"] = Model.NewsCategoriesStatus;
                                        return RedirectToAction("EditNewsCategories", "Manage", new { NCat_Id = Model.NCat_Id });
                                    }




                                }

                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("NewsCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }


        // GET: /Manage/NewNewsCategories
        public ActionResult NewNewsCategories(string language)
        {

            NewsCategoriesViewModel Model = new NewsCategoriesViewModel();
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {


                    if (TempData.ContainsKey("alertMessage"))
                    {


                        Model.NewsCategoriesStatus = TempData["alertMessage"].ToString();


                    }
                    else
                    {

                        Model.NewsCategoriesStatus = string.Empty;

                    }


                }
            }
            catch
            {


                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);



            }


            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/NewNewsCategories
        public ActionResult NewNewsCategories(NewsCategoriesViewModel Model,string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            using (Context)
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetNewsCategory Entity = new AspNetNewsCategory();
                            Entity.NCat_Id = Guid.NewGuid().ToString();
                            Entity.NCat_Name_En = Model.NCat_Name_En;
                            Entity.NCat_Name_Ar = Model.NCat_Name_Ar;
                            Entity.NCat_Description_Ar = Model.NCat_Description_Ar;
                            Entity.NCat_Description_En = Model.NCat_Description_En;
                            Entity.NCat_DateTime = DateTime.Now;
                            Entity.Id = User.Identity.GetUserId();

                            Context.AspNetNewsCategories.Add(entity: Entity);
                            Context.SaveChanges();


                            if (Context.GetValidationErrors().Count() == 0)
                            {

                                Model.NewsCategoriesStatus = "Success";
                                AspNetNotification Notify = new AspNetNotification();
                                Notify.Notify_Id = Guid.NewGuid().ToString();
                                Notify.Notify_Title = "Add New News Category";
                                Notify.Notify_Action = "News Categories";
                                Notify.Notify_Active = true;
                                Notify.Notify_DateTime = DateTime.Now;
                                Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                 string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                string Manager_Name = FName + " " + LName;

                                Notify.Notify_Manager_Name = Manager_Name;

                                 Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                Context.AspNetNotifications.Add(Notify);
                                Context.SaveChanges();

                                TempData["alertMessage"] = Model.NewsCategoriesStatus;



                                return RedirectToActionPermanent("NewNewsCategories");
                            }
                            else
                            {


                                Model.NewsCategoriesStatus = "Error";
                                TempData["alertMessage"] = Model.NewsCategoriesStatus;
                                return RedirectToActionPermanent("NewNewsCategories");
                            }


                        }







                    }




                }
                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }





            }


            return View(Model);
        }
        #endregion

        #region TeamsArea
        // GET: /Manage/Teams
        public ActionResult Teams(int? page,string language)
        {

            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }


                    ViewData["Categories"] = new SelectList(Context.AspNetTeamsCategories.ToList(), "TCat_Name_En", "TCat_Name_En");


                    return View(Context.AspNetTeams.OrderByDescending(m => m.Team_DateTime).ToPagedList(pageNumber, 10));
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetProjectsCategories.OrderByDescending(m => m.PCat_DateTime).ToPagedList(pageNumber, 10));



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeleteTeams
        public ActionResult DeleteTeams(string Team_Id,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Team_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetTeam Entity = Context.AspNetTeams.Find(Team_Id);


                            if (Entity != null)
                            {
                                System.IO.File.Delete(Server.MapPath("~/Images/resizedteams/" + Entity.Team_Photo));
                                System.IO.File.Delete(Server.MapPath("~/Images/teams/" + Entity.Team_Photo));

                                Context.AspNetTeams.Remove(Entity);

                                Context.SaveChanges();

                                if (Context.GetValidationErrors().Count() == 0)
                                {


                                    TempData["alertMessage"] = "Success";

                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete Team";
                                    Notify.Notify_Action = "Teams";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();
                                    return RedirectToActionPermanent("Teams", "Manage");

                                }
                                else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("Teams", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("Teams", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/EditTeams
        [HttpGet]
        public ActionResult EditTeams(string Teams_Id,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {

                        AspNetTeam Entity = Context.AspNetTeams.Find(Teams_Id);
                        if (Entity != null)
                        {

                            TeamsViewModel Model = new TeamsViewModel();

                            Model.Id = Entity.Id;
                            Model.Team_DateTime = Entity.Team_DateTime;
                            Model.Team_Id = Entity.Team_Id;
                            Model.Team_JobTitle_Ar = Entity.Team_JobTitle_Ar;
                            Model.Team_Email = Entity.Team_Email;
                            Model.Team_Fname_Ar = Entity.Team_Fname_Ar;
                            Model.Team_Fname_En = Entity.Team_Fname_En;
                            Model.TCat_Id = Entity.TCat_Id;
                            Model.Team_JobTitle_En = Entity.Team_JobTitle_En;
                            Model.Team_Lname_Ar = Entity.Team_Lname_Ar;
                            Model.Team_Lname_En = Entity.Team_Lname_En;

                            Model.Team_Phone = Entity.Team_Phone;
                            Model.Team_Salary = Entity.Team_Salary;
                            Model.Team_Photo = Entity.Team_Photo;

                            if (TempData.ContainsKey("alertMessage"))
                            {
                                Model.TeamsStatus = TempData["alertMessage"].ToString();
                            }
                            else
                            {
                                Model.TeamsStatus = string.Empty;
                            }

                            Model.Categories = new SelectList(Context.AspNetTeamsCategories.ToList(), "TCat_Id", "TCat_Name_En");


                            return View(Model);
                        }
                        else
                        {
                            return RedirectToActionPermanent("Teams", "Manage");
                        }

                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }

        // Post: /Manage/EditTeams
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTeams(TeamsViewModel Model, HttpPostedFileBase Team_Photo,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        if (ModelState.IsValid)
                        {
                            if (Team_Photo != null && Team_Photo.ContentLength > 0)
                            {
                                var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                                var fileextention = Path.GetExtension(Team_Photo.FileName);

                                //.........check file Extention

                                if (!supportedTypes.Contains(fileextention))
                                {

                                    Model.TeamsStatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                    TempData["alertMessage"] = Model.TeamsStatus;
                                    return RedirectToActionPermanent("EditTeams", "Manage");


                                }
                                else
                                {

                                    string fileName = Guid.NewGuid() + Path.GetExtension(Team_Photo.FileName);
                                    string pathoriginal = Path.Combine(Server.MapPath("~/Images/teams"), fileName).ToString();

                                    string pathresized = Path.Combine(Server.MapPath("~/Images/resizedteams"), fileName).ToString();
                                    Team_Photo.SaveAs(pathoriginal);
                                    ResizeImage(350, pathoriginal, pathresized);

                                    AspNetTeam Entity = Context.AspNetTeams.Find(Model.Team_Id);
                                    if (Entity != null)
                                    {

                                        Entity.Team_DateTime = DateTime.Now;
                                        Entity.Team_Fname_En = Model.Team_Fname_En;
                                        Entity.Team_Fname_Ar = Model.Team_Fname_Ar;
                                        Entity.Team_Lname_Ar = Model.Team_Lname_Ar;
                                        Entity.Team_Lname_En = Model.Team_Lname_En;
                                        Entity.Team_Email = Model.Team_Email;
                                        Entity.Team_Phone = Model.Team_Phone;
                                        Entity.Id = User.Identity.GetUserId();
                                        Entity.TCat_Id = Model.TCat_Id;
                                        Entity.Team_Salary = Model.Team_Salary;
                                        Entity.Team_JobTitle_En = Model.Team_JobTitle_En;
                                        Entity.Team_JobTitle_Ar = Model.Team_JobTitle_Ar;
                                        

                                        System.IO.File.Delete(Server.MapPath("~/Images/resizedteams/" + Entity.Team_Photo));
                                        System.IO.File.Delete(Server.MapPath("~/Images/teams/" + Entity.Team_Photo));

                                        Entity.Team_Photo = fileName;
                                        Context.SaveChanges();
                                        if (Context.GetValidationErrors().Count() == 0)
                                        {

                                            TempData["alertMessage"] = "Success";
                                            AspNetNotification Notify = new AspNetNotification();
                                            Notify.Notify_Id = Guid.NewGuid().ToString();
                                            Notify.Notify_Title = "Edit Team";
                                            Notify.Notify_Action = "Teams";
                                            Notify.Notify_Active = true;
                                            Notify.Notify_DateTime = DateTime.Now;
                                            Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                             string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                            string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                            string Manager_Name = FName + " " + LName;

                                            Notify.Notify_Manager_Name = Manager_Name;

                                             Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                            Context.AspNetNotifications.Add(Notify);
                                            Context.SaveChanges();

                                            return RedirectToActionPermanent("EditTeams", "Manage", new { Teams_Id = Model.Team_Id });


                                        }
                                        else
                                        {
                                            TempData["alertMessage"] = "Error";
                                            return RedirectToActionPermanent("EditTeams", "Manage", new { Teams_Id = Model.Team_Id });
                                        }

                                    }
                                    else
                                    {
                                        return RedirectToActionPermanent("Teams", "Manage");
                                    }

                                }
                            }



                        }
                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                    Model.Categories = new SelectList(Context.AspNetTeamsCategories.ToList(), "TCat_Id", "TCat_Name_En");
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }

        // GET: /Manage/NewTeams
        public ActionResult NewTeams(string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        TeamsViewModel Model = new TeamsViewModel();

                        Model.Categories = new SelectList(Context.AspNetTeamsCategories.ToList(), "TCat_Id", "TCat_Name_En");

                        if (TempData.ContainsKey("alertMessage"))
                        {

                            Model.TeamsStatus = TempData["alertMessage"].ToString();

                        }
                        else
                        {
                            Model.TeamsStatus = string.Empty;
                        }

                        return View(Model);

                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewTeams(TeamsViewModel Model, HttpPostedFileBase Team_Photo,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {
                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {



                        if (ModelState.IsValid)
                        {
                            Model.Categories = new SelectList(Context.AspNetTeamsCategories.ToList(), "TCat_Id", "TCat_Name_En");
                            if (Team_Photo != null && Team_Photo.ContentLength > 0)
                            {
                                var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                                var fileextention = Path.GetExtension(Team_Photo.FileName);

                                //.........check file Extention

                                if (!supportedTypes.Contains(fileextention))
                                {

                                    Model.TeamsStatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                    TempData["alertMessage"] = Model.TeamsStatus;


                                    return RedirectToActionPermanent("NewTeams", "Manage");


                                }
                                else
                                {

                                    string fileName = Guid.NewGuid() + Path.GetExtension(Team_Photo.FileName);
                                    string pathoriginal = Path.Combine(Server.MapPath("~/Images/teams"), fileName).ToString();

                                    string pathresized = Path.Combine(Server.MapPath("~/Images/resizedteams"), fileName).ToString();
                                    Team_Photo.SaveAs(pathoriginal);
                                    ResizeImage(350, pathoriginal, pathresized);


                                    AspNetTeam Entity = new AspNetTeam();
                                    Entity.Team_Id = Guid.NewGuid().ToString();
                                    Entity.Team_DateTime = DateTime.Now;
                                    Entity.Team_Fname_En = Model.Team_Fname_En;
                                    Entity.Team_Fname_Ar = Model.Team_Fname_Ar;
                                    Entity.Team_Lname_Ar = Model.Team_Lname_Ar;
                                    Entity.Team_Lname_En = Model.Team_Lname_En;
                                    Entity.Team_Email = Model.Team_Email;
                                    Entity.Team_Photo = fileName;
                                    Entity.Team_Phone = Model.Team_Phone;
                                    Entity.Id = User.Identity.GetUserId();
                                    Entity.TCat_Id = Model.TCat_Id;
                                    Entity.Team_Salary = Model.Team_Salary;
                                    Entity.Team_JobTitle_En = Model.Team_JobTitle_En;
                                    Entity.Team_JobTitle_Ar = Model.Team_JobTitle_Ar;



                                    Context.AspNetTeams.Add(Entity);
                                    Context.SaveChanges();
                                  

                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        TempData["alertMessage"] = "Success";

                                        AspNetNotification Notify = new AspNetNotification();
                                        Notify.Notify_Id = Guid.NewGuid().ToString();
                                        Notify.Notify_Title = "Add New Team";
                                        Notify.Notify_Action = "Teams";
                                        Notify.Notify_Active = true;
                                        Notify.Notify_DateTime = DateTime.Now;
                                        Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                         string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                        string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                        string Manager_Name = FName + " " + LName;

                                        Notify.Notify_Manager_Name = Manager_Name;

                                         Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                        Context.AspNetNotifications.Add(Notify);
                                        Context.SaveChanges();

                                        return RedirectToActionPermanent("NewTeams", "Manage");


                                    }
                                    else
                                    {
                                        TempData["alertMessage"] = "Error";
                                        return RedirectToActionPermanent("NewTeams", "Manage");
                                    }
                                }
                            }



                        }

                        Model.Categories = new SelectList(Context.AspNetTeamsCategories.ToList(), "TCat_Id", "TCat_Name_En");



                    }
                    else
                    {

                        return RedirectToActionPermanent("Login", "Account");


                    }




                }
                catch
                {
                    ////EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    ////SetLoaderLogging(true);
                    ////SetNetworkLogging(true);
                    ////SetNetworkLogging(true);

                }





            }




            return View(Model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeleteTeamsCategories
        public ActionResult DeleteTeamsCategories(string TCat_Id,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(TCat_Id ))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetTeamsCategory Entity = Context.AspNetTeamsCategories.Find(TCat_Id );


                            if (Entity != null)
                            {

                                Context.AspNetTeamsCategories.Remove(Entity);
                                Context.SaveChanges();

                                if (Context.GetValidationErrors().Count() == 0)
                                {


                                    TempData["alertMessage"] = "Success";

                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete Teams Category";
                                    Notify.Notify_Action = "Teams Categories";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();

                                    return RedirectToActionPermanent("TeamsCategories", "Manage");

                                }
                                else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("TeamsCategories", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("TeamsCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/TeamsCategories
        public ActionResult TeamsCategories(int? page,string language)

        {
            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }

                    return View(Context.AspNetTeamsCategories.OrderByDescending(m => m.TCat_DateTime).ToPagedList(pageNumber, 10));
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetTeamsCategories.OrderByDescending(m => m.TCat_DateTime).ToPagedList(pageNumber, 10));


        }

        // GET: /Manage/EditProjectsCategories
        public ActionResult EditTeamsCategories(string TCat_Id,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (!string.IsNullOrEmpty(TCat_Id))
                {


                    using (Context)
                    {

                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetTeamsCategory Entity = Context.AspNetTeamsCategories.Find(TCat_Id);
                            if (Entity != null)
                            {

                                TeamsCategoriesViewModel Model = new TeamsCategoriesViewModel();

                                Model.Id = Entity.Id;
                                Model.TCat_DateTime = Entity.TCat_DateTime;
                                Model.TCat_Description_Ar = Entity.TCat_Description_Ar;
                                Model.TCat_Description_En = Entity.TCat_Description_En;
                                Model.TCat_Id = Entity.TCat_Id;
                                Model.TCat_Name_Ar = Entity.TCat_Name_Ar;
                                Model.TCat_Name_En = Entity.TCat_Name_En;
                                if (TempData.ContainsKey("alertMessage"))
                                {
                                    Model.TeamsCategoriesStatus = TempData["alertMessage"].ToString();
                                }
                                else
                                {
                                    Model.TeamsCategoriesStatus = string.Empty;
                                }



                                return View(Model);


                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }



                    }

                }
                else
                {
                    RedirectToActionPermanent("TeamsCategories", "Manage");
                }

            }

            catch
            {
                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/EditTeamsCategories
        public ActionResult EditTeamsCategories(TeamsCategoriesViewModel Model,string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Model.TCat_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetTeamsCategory Entity = Context.AspNetTeamsCategories.Find(Model.TCat_Id);
                            if (Entity != null)
                            {


                                if (ModelState.IsValid)
                                {



                                    Entity.TCat_DateTime = DateTime.Now;
                                    Entity.TCat_Description_Ar = Model.TCat_Description_Ar;
                                    Entity.TCat_Description_En = Model.TCat_Description_En;
                                    Entity.TCat_Name_Ar = Model.TCat_Name_Ar;
                                    Entity.TCat_Name_En = Model.TCat_Name_En;
                                    Entity.Id = User.Identity.GetUserId();


                                    Context.SaveChanges();

                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        Model.TeamsCategoriesStatus = "Success";
                                        TempData["alertMessage"] = Model.TeamsCategoriesStatus;


                                        AspNetNotification Notify = new AspNetNotification();
                                        Notify.Notify_Id = Guid.NewGuid().ToString();
                                        Notify.Notify_Title = "Edit Teams Category";
                                        Notify.Notify_Action = "Teams Categories";
                                        Notify.Notify_Active = true;
                                        Notify.Notify_DateTime = DateTime.Now;
                                        Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                         string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                        string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                        string Manager_Name = FName + " " + LName;

                                        Notify.Notify_Manager_Name = Manager_Name;

                                         Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                        Context.AspNetNotifications.Add(Notify);
                                        Context.SaveChanges();
                                        return RedirectToAction("EditTeamsCategories", "Manage", new { TCat_Id = Model.TCat_Id });

                                    }
                                    else
                                    {
                                        Model.TeamsCategoriesStatus = "Error";
                                        TempData["alertMessage"] = Model.TeamsCategoriesStatus;
                                        return RedirectToAction("EditTeamsCategories", "Manage", new { TCat_Id = Model.TCat_Id });
                                    }




                                }

                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("TeamsCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }


        // GET: /Manage/NewTeamsCategories
        public ActionResult NewTeamsCategories(string language)
        {

            TeamsCategoriesViewModel Model = new TeamsCategoriesViewModel();
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {


                    if (TempData.ContainsKey("alertMessage"))
                    {


                        Model.TeamsCategoriesStatus = TempData["alertMessage"].ToString();


                    }
                    else
                    {

                        Model.TeamsCategoriesStatus = string.Empty;

                    }


                }
            }
            catch
            {


                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);



            }


            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/NewTeamsCategories
        public ActionResult NewTeamsCategories(TeamsCategoriesViewModel Model,string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            using (Context)
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetTeamsCategory Entity = new AspNetTeamsCategory();
                            Entity.TCat_Id = Guid.NewGuid().ToString();
                            Entity.TCat_Name_En = Model.TCat_Name_En;
                            Entity.TCat_Name_Ar = Model.TCat_Name_Ar;
                            Entity.TCat_Description_Ar = Model.TCat_Description_Ar;
                            Entity.TCat_Description_En = Model.TCat_Description_En;
                            Entity.TCat_DateTime = DateTime.Now;
                            Entity.Id = User.Identity.GetUserId();

                            Context.AspNetTeamsCategories.Add(entity: Entity);
                            Context.SaveChanges();


                            if (Context.GetValidationErrors().Count() == 0)
                            {

                                Model.TeamsCategoriesStatus = "Success";

                                AspNetNotification Notify = new AspNetNotification();
                                Notify.Notify_Id = Guid.NewGuid().ToString();
                                Notify.Notify_Title = "Add New Teams Category";
                                Notify.Notify_Action = "Teams Categories";
                                Notify.Notify_Active = true;
                                Notify.Notify_DateTime = DateTime.Now;
                                Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                 string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                string Manager_Name = FName + " " + LName;

                                Notify.Notify_Manager_Name = Manager_Name;

                                 Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                Context.AspNetNotifications.Add(Notify);
                                Context.SaveChanges();
                                TempData["alertMessage"] = Model.TeamsCategoriesStatus;



                                return RedirectToActionPermanent("NewTeamsCategories");
                            }
                            else
                            {


                                Model.TeamsCategoriesStatus = "Error";
                                TempData["alertMessage"] = Model.TeamsCategoriesStatus;
                                return RedirectToActionPermanent("NewTeamsCategories");
                            }


                        }







                    }




                }
                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }





            }


            return View(Model);
        }
        #endregion

        #region TestmonialsArea

        // GET: /Manage/Testmonials
        public ActionResult Testmonials(int? page,string language)
        {


            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }


                    ViewData["Categories"] = new SelectList(Context.AspNetTestmonialsCategories.ToList(), "TsCat_Name_En", "TsCat_Name_En");


                    return View(Context.AspNetTestmonials.OrderByDescending(m => m.Testmonial_DateTime).ToPagedList(pageNumber, 10));
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetTestmonialsCategories.OrderByDescending(m => m.TsCat_DateTime).ToPagedList(pageNumber, 10));



        }

        // GET: /Manage/TestmonialsCategories
        public ActionResult TestmonialsCategories(int? page,string language)
        {


            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }

                    return View(Context.AspNetTestmonialsCategories.OrderByDescending(m => m.TsCat_DateTime).ToPagedList(pageNumber, 10));
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetTestmonialsCategories.OrderByDescending(m => m.TsCat_DateTime).ToPagedList(pageNumber, 10));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeleteTestmonialsCategories
        public ActionResult DeleteTestmonialsCategories(string TsCat_Id,string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(TsCat_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetTestmonialsCategory Entity = Context.AspNetTestmonialsCategories.Find(TsCat_Id);


                            if (Entity != null)
                            {

                                Context.AspNetTestmonialsCategories.Remove(Entity);

                                Context.SaveChanges();

                                if (Context.GetValidationErrors().Count() == 0)
                                {


                                    TempData["alertMessage"] = "Success";

                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete Testmonial Category";
                                    Notify.Notify_Action = "Testmonials Categories";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();

                                    return RedirectToActionPermanent("TestmonialsCategories", "Manage");

                                }
                                else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("TestmonialsCategories", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("TestmonialsCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/EditTestmonialsCategories
        public ActionResult EditTestmonialsCategories(string TsCat_Id,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (!string.IsNullOrEmpty(TsCat_Id))
                {


                    using (Context)
                    {

                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetTestmonialsCategory Entity = Context.AspNetTestmonialsCategories.Find(TsCat_Id);
                            if (Entity != null)
                            {

                                TestmonialsCategoriesViewModel Model = new TestmonialsCategoriesViewModel();

                                Model.Id = Entity.Id;
                                Model.TsCat_DateTime = Entity.TsCat_DateTime;
                                Model.TsCat_Description_Ar = Entity.TsCat_Description_Ar;
                                Model.TsCat_Description_En = Entity.TsCat_Description_En;
                                Model.TsCat_Id = Entity.TsCat_Id;
                                Model.TsCat_Name_Ar = Entity.TsCat_Name_Ar;
                                Model.TsCat_Name_En = Entity.TsCat_Name_En;
                                if (TempData.ContainsKey("alertMessage"))
                                {
                                    Model.TestmonialsCategoriesStatus = TempData["alertMessage"].ToString();
                                }
                                else
                                {
                                    Model.TestmonialsCategoriesStatus = string.Empty;
                                }



                                return View(Model);


                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }



                    }

                }
                else
                {
                    RedirectToActionPermanent("TestmonialsCategories", "Manage");
                }

            }

            catch
            {
                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/EditTestmonialsCategories
        public ActionResult EditTestmonialsCategories(TestmonialsCategoriesViewModel Model,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Model.TsCat_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetTestmonialsCategory Entity = Context.AspNetTestmonialsCategories.Find(Model.TsCat_Id);
                            if (Entity != null)
                            {


                                if (ModelState.IsValid)
                                {



                                    Entity.TsCat_DateTime = DateTime.Now;
                                    Entity.TsCat_Description_Ar = Model.TsCat_Description_Ar;
                                    Entity.TsCat_Description_En = Model.TsCat_Description_En;
                                    Entity.TsCat_Name_Ar = Model.TsCat_Name_Ar;
                                    Entity.TsCat_Name_En = Model.TsCat_Name_En;
                                    Entity.Id = User.Identity.GetUserId();


                                    Context.SaveChanges();

                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        Model.TestmonialsCategoriesStatus = "Success";
                                        TempData["alertMessage"] = Model.TestmonialsCategoriesStatus;
                                        AspNetNotification Notify = new AspNetNotification();
                                        Notify.Notify_Id = Guid.NewGuid().ToString();
                                        Notify.Notify_Title = "Edit Testmonial Category";
                                        Notify.Notify_Action = "Testmonials Categories";
                                        Notify.Notify_Active = true;
                                        Notify.Notify_DateTime = DateTime.Now;
                                        Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                         string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                        string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                        string Manager_Name = FName + " " + LName;

                                        Notify.Notify_Manager_Name = Manager_Name;

                                         Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                        Context.AspNetNotifications.Add(Notify);
                                        Context.SaveChanges();

                                        return RedirectToAction("EditTestmonialsCategories", "Manage", new { TsCat_Id = Model.TsCat_Id });

                                    }
                                    else
                                    {
                                        Model.TestmonialsCategoriesStatus = "Error";
                                        TempData["alertMessage"] = Model.TestmonialsCategoriesStatus;
                                        return RedirectToAction("EditTestmonialsCategories", "Manage", new { TsCat_Id = Model.TsCat_Id });
                                    }




                                }

                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("TestmonialsCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/NewTestmonialsCategories
        public ActionResult NewTestmonialsCategories(string language)
        {

            TestmonialsCategoriesViewModel Model = new TestmonialsCategoriesViewModel();
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {


                    if (TempData.ContainsKey("alertMessage"))
                    {


                        Model.TestmonialsCategoriesStatus = TempData["alertMessage"].ToString();


                    }
                    else
                    {

                        Model.TestmonialsCategoriesStatus = string.Empty;

                    }


                }
            }
            catch
            {


                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);



            }


            return View(Model);
        }

        // POST: /Manage/NewTestmonialsCategories
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult NewTestmonialsCategories(TestmonialsCategoriesViewModel Model,string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetTestmonialsCategory Entity = new AspNetTestmonialsCategory();
                            Entity.TsCat_Id = Guid.NewGuid().ToString();
                            Entity.TsCat_Name_En = Model.TsCat_Name_En;
                            Entity.TsCat_Name_Ar = Model.TsCat_Name_Ar;
                            Entity.TsCat_Description_Ar = Model.TsCat_Description_Ar;
                            Entity.TsCat_Description_En = Model.TsCat_Description_En;
                            Entity.TsCat_DateTime = DateTime.Now;
                            Entity.Id = User.Identity.GetUserId();

                            Context.AspNetTestmonialsCategories.Add(entity: Entity);
                            Context.SaveChanges();


                            if (Context.GetValidationErrors().Count() == 0)
                            {

                                Model.TestmonialsCategoriesStatus = "Success";

                                AspNetNotification Notify = new AspNetNotification();
                                Notify.Notify_Id = Guid.NewGuid().ToString();
                                Notify.Notify_Title = "Add New Testmonial Category";
                                Notify.Notify_Action = "Testmonials Categories";
                                Notify.Notify_Active = true;
                                Notify.Notify_DateTime = DateTime.Now;
                                Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                 string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                string Manager_Name = FName + " " + LName;

                                Notify.Notify_Manager_Name = Manager_Name;

                                 Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                Context.AspNetNotifications.Add(Notify);
                                Context.SaveChanges();

                                TempData["alertMessage"] = Model.TestmonialsCategoriesStatus;



                                return RedirectToActionPermanent("NewTestmonialsCategories");
                            }
                            else
                            {


                                Model.TestmonialsCategoriesStatus = "Error";
                                TempData["alertMessage"] = Model.TestmonialsCategoriesStatus;
                                return RedirectToActionPermanent("NewTestmonialsCategories");
                            }


                        }







                    }




                }
                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }





            }


            return View(Model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeleteTestmonials
        public ActionResult DeleteTestmonials(string Testmonial_Id,string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Testmonial_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetTestmonial Entity = Context.AspNetTestmonials.Find(Testmonial_Id);


                            if (Entity != null)
                            {
                                System.IO.File.Delete(Server.MapPath("~/Images/resizedtestmonials/" + Entity.Testmonial_ClientPhoto));
                                System.IO.File.Delete(Server.MapPath("~/Images/testmonials/" + Entity.Testmonial_ClientPhoto));

                                Context.AspNetTestmonials.Remove(Entity);

                                Context.SaveChanges();

                                if (Context.GetValidationErrors().Count() == 0)
                                {


                                    TempData["alertMessage"] = "Success";

                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete Testmonial";
                                    Notify.Notify_Action = "Testmonials";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();
                                    return RedirectToActionPermanent("Testmonials", "Manage");

                                }
                                else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("Testmonials", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("Testmonials", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/EditTestmonial
        public ActionResult EditTestmonials(string Testmonial_Id,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {

                        AspNetTestmonial Entity = Context.AspNetTestmonials.Find(Testmonial_Id);
                        if (Entity != null)
                        {

                            TestmonialsViewModel Model = new TestmonialsViewModel();

                            Model.Id = Entity.Id;
                            Model.Testmonial_DateTime = Entity.Testmonial_DateTime;
                            Model.Testmonial_Answer_Ar = Entity.Testmonial_Answer_Ar;
                            Model.Testmonial_Answer_En = Entity.Testmonial_Answer_En;
                            Model.Testmonial_Question_Ar = Entity.Testmonial_Question_Ar;
                            Model.Testmonial_Question_En = Entity.Testmonial_Question_En;
                            Model.TsCat_Id = Entity.TsCat_Id;
                            Model.Testmonial_ClientName_Ar = Entity.Testmonial_ClientName_Ar;
                            Model.Testmonial_ClientName_En = Entity.Testmonial_ClientName_En;
                            Model.Testmonial_ClientJobTitle_Ar = Entity.Testmonial_ClientJobTitle_Ar;
                            Model.Testmonial_ClientJobTitle_En = Entity.Testmonial_ClientJobTitle_En;
                            Model.Testmonial_ClientPhoto = Entity.Testmonial_ClientPhoto;
                           
                            if (TempData.ContainsKey("alertMessage"))
                            {
                                Model.Testmonialstatus = TempData["alertMessage"].ToString();
                            }
                            else
                            {
                                Model.Testmonialstatus = string.Empty;
                            }

                            Model.Categories = new SelectList(Context.AspNetTestmonialsCategories.ToList(), "TsCat_Id", "TsCat_Name_En");


                            return View(Model);
                        }
                        else
                        {
                            return RedirectToActionPermanent("Testmonials", "Manage");
                        }

                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }


        // Post: /Manage/EditTestmonial
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTestmonials(TestmonialsViewModel Model, HttpPostedFileBase Testmonial_ClientPhoto,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        if (ModelState.IsValid)
                        {
                            if (Testmonial_ClientPhoto != null && Testmonial_ClientPhoto.ContentLength > 0)
                            {
                                var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                                var fileextention = Path.GetExtension(Testmonial_ClientPhoto.FileName);

                                //.........check file Extention

                                if (!supportedTypes.Contains(fileextention))
                                {

                                    Model.Testmonialstatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                    TempData["alertMessage"] = Model.Testmonialstatus;

                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Edit Testmonial";
                                    Notify.Notify_Action = "Testmonials";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();

                                    return RedirectToActionPermanent("EditTestmonials", "Manage");


                                }
                                else
                                {

                                    string fileName = Guid.NewGuid() + Path.GetExtension(Testmonial_ClientPhoto.FileName);
                                    string pathoriginal = Path.Combine(Server.MapPath("~/Images/testmonials"), fileName).ToString();

                                    string pathresized = Path.Combine(Server.MapPath("~/Images/resizedtestmonials"), fileName).ToString();
                                    Testmonial_ClientPhoto.SaveAs(pathoriginal);
                                    ResizeImage(350, pathoriginal, pathresized);

                                    AspNetTestmonial Entity = Context.AspNetTestmonials.Find(Model.Testmonial_Id);
                                    if (Entity != null)
                                    {


                                        Entity.Id = User.Identity.GetUserId();
                                        Entity.Testmonial_DateTime = DateTime.Now;
                                        Entity.Testmonial_Answer_Ar = Model.Testmonial_Answer_Ar;
                                        Entity.Testmonial_Answer_En = Model.Testmonial_Answer_En;
                                        Entity.Testmonial_Question_Ar = Model.Testmonial_Question_Ar;
                                        Entity.Testmonial_Question_En = Model.Testmonial_Question_En;
                                        Entity.TsCat_Id = Model.TsCat_Id;
                                        Entity.Testmonial_ClientName_Ar = Model.Testmonial_ClientName_Ar;
                                        Entity.Testmonial_ClientName_En = Model.Testmonial_ClientName_En;
                                        Entity.Testmonial_ClientJobTitle_Ar = Model.Testmonial_ClientJobTitle_Ar;
                                        Entity.Testmonial_ClientJobTitle_En = Model.Testmonial_ClientJobTitle_En;
                                        System.IO.File.Delete(Server.MapPath("~/Images/resizedtestmonials/" + Entity.Testmonial_ClientPhoto));
                                        System.IO.File.Delete(Server.MapPath("~/Images/testmonials/" + Entity.Testmonial_ClientPhoto));

                                        Entity.Testmonial_ClientPhoto = fileName;


                                        Context.SaveChanges();
                                        if (Context.GetValidationErrors().Count() == 0)
                                        {

                                            TempData["alertMessage"] = "Success";
                                            return RedirectToActionPermanent("EditTestmonials", "Manage", new { Testmonial_Id = Model.Testmonial_Id });


                                        }
                                        else
                                        {
                                            TempData["alertMessage"] = "Error";
                                            return RedirectToActionPermanent("EditTestmonials", "Manage", new { Testmonial_Id = Model.Testmonial_Id });
                                        }

                                    }
                                    else
                                    {
                                        return RedirectToActionPermanent("Testmonials", "Manage");
                                    }

                                }
                            }



                        }
                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                    Model.Categories = new SelectList(Context.AspNetTestmonialsCategories.ToList(), "TsCat_Id", "TsCat_Name_En");
                }
            }
            catch
            {

                ////EnableLogging(true, true, true);
                //SetInteropLogging(true);
                ////SetLoaderLogging(true);
                ////SetNetworkLogging(true);
                ////SetNetworkLogging(true);

            }





            return View();
        }

        // GET: /Manage/NewTestmonial
        public ActionResult NewTestmonials(string language)
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        TestmonialsViewModel Model = new TestmonialsViewModel();

                        Model.Categories = new SelectList(Context.AspNetTestmonialsCategories.ToList(), "TsCat_Id", "TsCat_Name_En");

                        if (TempData.ContainsKey("alertMessage"))
                        {

                            Model.Testmonialstatus = TempData["alertMessage"].ToString();

                        }
                        else
                        {
                            Model.Testmonialstatus = string.Empty;
                        }

                        return View(Model);

                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }

        // Post: /Manage/NewTestmonial
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewTestmonials(TestmonialsViewModel Model, HttpPostedFileBase Testmonial_ClientPhoto,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {
                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {



                        if (ModelState.IsValid)
                        {
                            if (Testmonial_ClientPhoto != null && Testmonial_ClientPhoto.ContentLength > 0)
                            {
                                var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                                var fileextention = Path.GetExtension(Testmonial_ClientPhoto.FileName);

                                //.........check file Extention

                                if (!supportedTypes.Contains(fileextention))
                                {

                                    Model.Testmonialstatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                    TempData["alertMessage"] = Model.Testmonialstatus;


                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Add New Testmonial";
                                    Notify.Notify_Action = "Testmonials";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();

                                    return RedirectToActionPermanent("NewTestmonials", "Manage");


                                }
                                else
                                {

                                    string fileName = Guid.NewGuid() + Path.GetExtension(Testmonial_ClientPhoto.FileName);
                                    string pathoriginal = Path.Combine(Server.MapPath("~/Images/testmonials"), fileName).ToString();

                                    string pathresized = Path.Combine(Server.MapPath("~/Images/resizedtestmonials"), fileName).ToString();
                                    Testmonial_ClientPhoto.SaveAs(pathoriginal);
                                    ResizeImage(350, pathoriginal, pathresized);


                                    AspNetTestmonial Entity = new AspNetTestmonial();
                                    Entity.Testmonial_Id = Guid.NewGuid().ToString();

                                    Entity.Testmonial_DateTime = DateTime.Now;
                                    Entity.Testmonial_Answer_Ar = Model.Testmonial_Answer_Ar;
                                    Entity.Testmonial_Answer_En = Model.Testmonial_Answer_En;
                                    Entity.Testmonial_Question_Ar = Model.Testmonial_Question_Ar;
                                    Entity.Testmonial_Question_En = Model.Testmonial_Question_En;
                                    Entity.TsCat_Id = Model.TsCat_Id;
                                    Entity.Testmonial_ClientName_Ar = Model.Testmonial_ClientName_Ar;
                                    Entity.Testmonial_ClientName_En = Model.Testmonial_ClientName_En;
                                    Entity.Testmonial_ClientJobTitle_Ar = Model.Testmonial_ClientJobTitle_Ar;
                                    Entity.Testmonial_ClientJobTitle_En = Model.Testmonial_ClientJobTitle_En;
                                    Entity.Testmonial_ClientPhoto = fileName;





                                    Entity.Id = User.Identity.GetUserId();


                                    Context.AspNetTestmonials.Add(Entity);
                                    Context.SaveChanges();

                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        TempData["alertMessage"] = "Success";
                                        return RedirectToActionPermanent("NewTestmonials", "Manage");


                                    }
                                    else
                                    {
                                        TempData["alertMessage"] = "Error";
                                        return RedirectToActionPermanent("NewTestmonials", "Manage");
                                    }
                                }
                            }



                        }



                        Model.Categories = new SelectList(Context.AspNetTestmonialsCategories.ToList(), "TsCat_Id", "TsCat_Name_En");

                    }
                    else
                    {

                        return RedirectToActionPermanent("Login", "Account");


                    }




                }
                catch
                {
                    ////EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    ////SetLoaderLogging(true);
                    ////SetNetworkLogging(true);
                    ////SetNetworkLogging(true);

                }





            }

           


            return View(Model);
        }
        #endregion


        #region PlansArea

        // GET: /Manage/Plans
        public ActionResult Plans(int? page,string language)
        {


            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }


                    ViewData["Categories"] = new SelectList(Context.AspNetPlansCategories.ToList(), "PlanCat_Name_En", "PlanCat_Name_En");


                    return View(Context.AspNetPlans.OrderByDescending(m => m.Plan_DateTime).ToPagedList(pageNumber, 10));
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetPlansCategories.OrderByDescending(m => m.PlanCat_DateTime).ToPagedList(pageNumber, 10));



        }

        // GET: /Manage/PlansCategories
        public ActionResult PlansCategories(int? page,string language)
        {


            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }

                    return View(Context.AspNetPlansCategories.OrderByDescending(m => m.PlanCat_DateTime).ToPagedList(pageNumber, 10));
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetPlansCategories.OrderByDescending(m => m.PlanCat_DateTime).ToPagedList(pageNumber, 10));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeletePlansCategories
        public ActionResult DeletePlansCategories(string PlanCat_Id,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(PlanCat_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetPlansCategory Entity = Context.AspNetPlansCategories.Find(PlanCat_Id);


                            if (Entity != null)
                            {

                                Context.AspNetPlansCategories.Remove(Entity);

                                Context.SaveChanges();

                                if (Context.GetValidationErrors().Count() == 0)
                                {


                                    TempData["alertMessage"] = "Success";

                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete Plan Category";
                                    Notify.Notify_Action = "Plans Categories";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();
                                    return RedirectToActionPermanent("PlansCategories", "Manage");

                                }
                                else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("PlansCategories", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("PlansCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/EditPlansCategories
        public ActionResult EditPlansCategories(string PlanCat_Id,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                if (!string.IsNullOrEmpty(PlanCat_Id))
                {


                    using (Context)
                    {

                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetPlansCategory Entity = Context.AspNetPlansCategories.Find(PlanCat_Id);
                            if (Entity != null)
                            {

                                PlansCategoriesViewModel Model = new PlansCategoriesViewModel();

                                Model.Id = Entity.Id;
                                Model.PlanCat_DateTime = Entity.PlanCat_DateTime;
                                Model.PlanCat_Description_Ar = Entity.PlanCat_Description_Ar;
                                Model.PlanCat_Description_En = Entity.PlanCat_Description_En;
                                Model.PlanCat_Id = Entity.PlanCat_Id;
                                Model.PlanCat_Name_Ar = Entity.PlanCat_Name_Ar;
                                Model.PlanCat_Name_En = Entity.PlanCat_Name_En;
                                if (TempData.ContainsKey("alertMessage"))
                                {
                                    Model.PlansCategoriesStatus = TempData["alertMessage"].ToString();
                                }
                                else
                                {
                                    Model.PlansCategoriesStatus = string.Empty;
                                }



                                return View(Model);


                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }



                    }

                }
                else
                {
                    RedirectToActionPermanent("PlansCategories", "Manage");
                }

            }

            catch
            {
                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/EditPlansCategories
        public ActionResult EditPlansCategories(PlansCategoriesViewModel Model,string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Model.PlanCat_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetPlansCategory Entity = Context.AspNetPlansCategories.Find(Model.PlanCat_Id);
                            if (Entity != null)
                            {


                                if (ModelState.IsValid)
                                {



                                    Entity.PlanCat_DateTime = DateTime.Now;
                                    Entity.PlanCat_Description_Ar = Model.PlanCat_Description_Ar;
                                    Entity.PlanCat_Description_En = Model.PlanCat_Description_En;
                                    Entity.PlanCat_Name_Ar = Model.PlanCat_Name_Ar;
                                    Entity.PlanCat_Name_En = Model.PlanCat_Name_En;
                                    Entity.Id = User.Identity.GetUserId();


                                    Context.SaveChanges();

                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        Model.PlansCategoriesStatus = "Success";
                                        TempData["alertMessage"] = Model.PlansCategoriesStatus;

                                        AspNetNotification Notify = new AspNetNotification();
                                        Notify.Notify_Id = Guid.NewGuid().ToString();
                                        Notify.Notify_Title = "Edit Plan Category";
                                        Notify.Notify_Action = "Plans Categories";
                                        Notify.Notify_Active = true;
                                        Notify.Notify_DateTime = DateTime.Now;
                                        Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                         string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                        string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                        string Manager_Name = FName + " " + LName;

                                        Notify.Notify_Manager_Name = Manager_Name;

                                         Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                        Context.AspNetNotifications.Add(Notify);
                                        Context.SaveChanges();

                                        return RedirectToAction("EditPlansCategories", "Manage", new { PlanCat_Id = Model.PlanCat_Id });

                                    }
                                    else
                                    {
                                        Model.PlansCategoriesStatus = "Error";
                                        TempData["alertMessage"] = Model.PlansCategoriesStatus;
                                        return RedirectToAction("EditPlansCategories", "Manage", new { PlanCat_Id = Model.PlanCat_Id });
                                    }




                                }

                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("PlansCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/NewPlansCategories
        public ActionResult NewPlansCategories(string language)
        {

            PlansCategoriesViewModel Model = new PlansCategoriesViewModel();
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {


                    if (TempData.ContainsKey("alertMessage"))
                    {


                        Model.PlansCategoriesStatus = TempData["alertMessage"].ToString();


                    }
                    else
                    {

                        Model.PlansCategoriesStatus = string.Empty;

                    }


                }
            }
            catch
            {


                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);



            }


            return View(Model);
        }

        // POST: /Manage/NewPlansCategories
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult NewPlansCategories(PlansCategoriesViewModel Model,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetPlansCategory Entity = new AspNetPlansCategory();
                            Entity.PlanCat_Id = Guid.NewGuid().ToString();
                            Entity.PlanCat_Name_En = Model.PlanCat_Name_En;
                            Entity.PlanCat_Name_Ar = Model.PlanCat_Name_Ar;
                            Entity.PlanCat_Description_Ar = Model.PlanCat_Description_Ar;
                            Entity.PlanCat_Description_En = Model.PlanCat_Description_En;
                            Entity.PlanCat_DateTime = DateTime.Now;
                            Entity.Id = User.Identity.GetUserId();

                            Context.AspNetPlansCategories.Add(entity: Entity);
                            Context.SaveChanges();


                            if (Context.GetValidationErrors().Count() == 0)
                            {

                                Model.PlansCategoriesStatus = "Success";
                                AspNetNotification Notify = new AspNetNotification();
                                Notify.Notify_Id = Guid.NewGuid().ToString();
                                Notify.Notify_Title = "Add New Plan Category";
                                Notify.Notify_Action = "Plans Categories";
                                Notify.Notify_Active = true;
                                Notify.Notify_DateTime = DateTime.Now;
                                Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                 string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                string Manager_Name = FName + " " + LName;

                                Notify.Notify_Manager_Name = Manager_Name;

                                 Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                Context.AspNetNotifications.Add(Notify);
                                Context.SaveChanges();

                                TempData["alertMessage"] = Model.PlansCategoriesStatus;



                                return RedirectToActionPermanent("NewPlansCategories");
                            }
                            else
                            {


                                Model.PlansCategoriesStatus = "Error";
                                TempData["alertMessage"] = Model.PlansCategoriesStatus;
                                return RedirectToActionPermanent("NewPlansCategories");
                            }


                        }







                    }




                }
                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }





            }


            return View(Model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeletePlans
        public ActionResult DeletePlans(string Plan_Id,string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Plan_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetPlan Entity = Context.AspNetPlans.Find(Plan_Id);


                            if (Entity != null)
                            {
                              

                                Context.AspNetPlans.Remove(Entity);

                                Context.SaveChanges();

                                if (Context.GetValidationErrors().Count() == 0)
                                {


                                    TempData["alertMessage"] = "Success";
                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete Plan";
                                    Notify.Notify_Action = "Plans";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();

                                    return RedirectToActionPermanent("Plans", "Manage");

                                }
                                else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("Plans", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("Plans", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/EditPlan
        public ActionResult EditPlans(string Plan_Id,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {

                        AspNetPlan Entity = Context.AspNetPlans.Find(Plan_Id);
                        if (Entity != null)
                        {

                            PlansViewModel Model = new PlansViewModel();

                            Model.Id = Entity.Id;
                            Model.Plan_DateTime = Entity.Plan_DateTime;
                            Model.Plan_Description_En= Entity.Plan_Description_En;
                            Model.Plan_Description_Ar = Entity.Plan_Description_Ar;
                            Model.PlanCat_Id = Entity.PlanCat_Id;
                            Model.Id = User.Identity.GetUserId();
                            Model.Plan_Name_Ar = Entity.Plan_Name_Ar;
                            Model.Plan_Name_En = Entity.Plan_Name_En;
                            Model.Plan_Price = Entity.Plan_Price;

                            if (TempData.ContainsKey("alertMessage"))
                            {
                                Model.PlanStatus = TempData["alertMessage"].ToString();
                            }
                            else
                            {
                                Model.PlanStatus = string.Empty;
                            }

                            Model.Categories = new SelectList(Context.AspNetPlansCategories.ToList(), "PlanCat_Id", "PlanCat_Name_En");


                            return View(Model);
                        }
                        else
                        {
                            return RedirectToActionPermanent("Plans", "Manage");
                        }

                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }


        // Post: /Manage/EditPlan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPlans(PlansViewModel Model, HttpPostedFileBase Plan_ClientPhoto,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        if (ModelState.IsValid)
                        {
                            
                                    AspNetPlan Entity = Context.AspNetPlans.Find(Model.Plan_Id);
                                    if (Entity != null)
                                    {

                                     


                                        //Entity.Plan_DateTime = DateTime.Now;
                                        Entity.Plan_Description_En = Model.Plan_Description_En;
                                        Entity.Plan_Description_Ar = Model.Plan_Description_Ar;
                                        Entity.PlanCat_Id = Model.PlanCat_Id;
                                        Entity.Id = User.Identity.GetUserId();
                                        Entity.Plan_Name_Ar = Model.Plan_Name_Ar;
                                        Entity.Plan_Name_En = Model.Plan_Name_En;
                                        Entity.Plan_Price = Model.Plan_Price;

                                      




                                        Context.SaveChanges();
                                        if (Context.GetValidationErrors().Count() == 0)
                                        {

                                            TempData["alertMessage"] = "Success";

                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Edit Plan";
                                    Notify.Notify_Action = "Plans";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();
                                    return RedirectToActionPermanent("EditPlans", "Manage", new { Plan_Id = Model.Plan_Id });


                                        }
                                        else
                                        {
                                            TempData["alertMessage"] = "Error";
                                            return RedirectToActionPermanent("EditPlans", "Manage", new { Plan_Id = Model.Plan_Id });
                                        }

                                    }
                                    else
                                    {
                                        return RedirectToActionPermanent("Plans", "Manage");
                                    }

                               
                      
                        }
                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                    Model.Categories = new SelectList(Context.AspNetPlansCategories.ToList(), "PlanCat_Id", "PlanCat_Name_En");
                }
            }
            catch
            {

                ////EnableLogging(true, true, true);
                //SetInteropLogging(true);
                ////SetLoaderLogging(true);
                ////SetNetworkLogging(true);
                ////SetNetworkLogging(true);

            }





            return View();
        }

        // GET: /Manage/NewPlan
        public ActionResult NewPlans(string language)
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        PlansViewModel Model = new PlansViewModel();

                        Model.Categories = new SelectList(Context.AspNetPlansCategories.ToList(), "PlanCat_Id", "PlanCat_Name_En");

                        if (TempData.ContainsKey("alertMessage"))
                        {

                            Model.PlanStatus = TempData["alertMessage"].ToString();

                        }
                        else
                        {
                            Model.PlanStatus = string.Empty;
                        }

                        return View(Model);

                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }

        // Post: /Manage/NewPlan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPlans(PlansViewModel Model, HttpPostedFileBase Plan_ClientPhoto,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {
                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {



                        if (ModelState.IsValid)
                        {
                           
                                    AspNetPlan Entity = new AspNetPlan();
                                    Entity.Plan_Id = Guid.NewGuid().ToString();

                                
                                    Entity.Plan_DateTime = DateTime.Now;
                                    Entity.Plan_Description_En = Model.Plan_Description_En;
                                    Entity.Plan_Description_Ar = Model.Plan_Description_Ar;
                                    Entity.PlanCat_Id = Model.PlanCat_Id;
                                    Entity.Id = User.Identity.GetUserId();
                                    Entity.Plan_Name_Ar = Model.Plan_Name_Ar;
                                    Entity.Plan_Name_En = Model.Plan_Name_En;
                                    Entity.Plan_Price = Model.Plan_Price;

                                    Entity.Id = User.Identity.GetUserId();


                                    Context.AspNetPlans.Add(Entity);
                                    Context.SaveChanges();

                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        TempData["alertMessage"] = "Success";


                                AspNetNotification Notify = new AspNetNotification();
                                Notify.Notify_Id = Guid.NewGuid().ToString();
                                Notify.Notify_Title = "Add New Plan";
                                Notify.Notify_Action = "Plans";
                                Notify.Notify_Active = true;
                                Notify.Notify_DateTime = DateTime.Now;
                                Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                 string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                string Manager_Name = FName + " " + LName;

                                Notify.Notify_Manager_Name = Manager_Name;

                                 Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                Context.AspNetNotifications.Add(Notify);
                                Context.SaveChanges();
                                return RedirectToActionPermanent("NewPlans", "Manage");


                                    }
                                    else
                                    {
                                        TempData["alertMessage"] = "Error";
                                        return RedirectToActionPermanent("NewPlans", "Manage");
                                    }
                                
                            } 


                        Model.Categories = new SelectList(Context.AspNetPlansCategories.ToList(), "PlanCat_Id", "PlanCat_Name_En");

                    }
                    else
                    {

                        return RedirectToActionPermanent("Login", "Account");


                    }




                }
                catch
                {
                    ////EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    ////SetLoaderLogging(true);
                    ////SetNetworkLogging(true);
                    ////SetNetworkLogging(true);

                }





            }




            return View(Model);
        }
        #endregion


        #region ClientsArea
        // GET: /Manage/Clients
        public ActionResult Clients(int? page,string language)
        {

            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }


                    ViewData["Categories"] = new SelectList(Context.AspNetClientsCategories.ToList(), "ClCat_Name_En", "ClCat_Name_En");


                    return View(Context.AspNetClients.OrderByDescending(m => m.Client_DateTime).ToPagedList(pageNumber, 10));
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetProjectsCategories.OrderByDescending(m => m.PCat_DateTime).ToPagedList(pageNumber, 10));



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeleteClients
        public ActionResult DeleteClients(string Client_Id,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Client_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetClient Entity = Context.AspNetClients.Find(Client_Id);


                            if (Entity != null)
                            {
                                System.IO.File.Delete(Server.MapPath("~/Images/resizedclients/" + Entity.Client_Photo));
                                System.IO.File.Delete(Server.MapPath("~/Images/clients/" + Entity.Client_Photo));

                                Context.AspNetClients.Remove(Entity);

                                Context.SaveChanges();

                                if (Context.GetValidationErrors().Count() == 0)
                                {


                                    TempData["alertMessage"] = "Success";


                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete Client";
                                    Notify.Notify_Action = "Clients";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();

                                    return RedirectToActionPermanent("Clients", "Manage");

                                }
                                else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("Clients", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("Clients", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/EditClients
        [HttpGet]
        public ActionResult EditClients(string Clients_Id,string language)
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {

                        AspNetClient Entity = Context.AspNetClients.Find(Clients_Id);

                        if (Entity != null)
                        {

                            ClientsViewModel Model = new ClientsViewModel();

                            Model.Id = Entity.Id;
                            Model.Client_DateTime = Entity.Client_DateTime;
                            Model.Client_Id = Entity.Client_Id;
                            Model.Client_Fname_En = Entity.Client_Fname_En;
                            Model.Client_Fname_Ar = Entity.Client_Fname_Ar;
                            Model.Client_Lname_En = Entity.Client_Lname_En;
                            Model.Client_Lname_Ar = Entity.Client_Lname_Ar;
                            Model.Client_Email = Entity.Client_Email;
                            Model.Client_PhoneNumber = Entity.Client_PhoneNumber;
                            Model.Client_Fname_En = Entity.Client_Fname_En;
                            Model.ClCat_Id = Entity.ClCat_Id;
                            Model.Client_CompanyName_En = Entity.Client_CompanyName_En;
                            Model.Client_CompanyName_Ar = Entity.Client_CompanyName_Ar;
                            Model.Client_Address_En = Entity.Client_Address_En;
                            Model.Client_Address_Ar = Entity.Client_Address_Ar;
                          
                            Model.Client_Photo = Entity.Client_Photo;

                            if (TempData.ContainsKey("alertMessage"))
                            {
                                Model.ClientStatus = TempData["alertMessage"].ToString();
                            }
                            else
                            {
                                Model.ClientStatus = string.Empty;
                            }

                            Model.Categories = new SelectList(Context.AspNetClientsCategories.ToList(), "ClCat_Id", "ClCat_Name_En");


                            return View(Model);
                        }
                        else
                        {
                            return RedirectToActionPermanent("Clients", "Manage");
                        }

                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }

        // Post: /Manage/EditClients
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClients(ClientsViewModel Model, HttpPostedFileBase Client_Photo,string language)
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        if (ModelState.IsValid)
                        {
                            if (Client_Photo != null && Client_Photo.ContentLength > 0)
                            {
                                var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                                var fileextention = Path.GetExtension(Client_Photo.FileName);

                                //.........check file Extention

                                if (!supportedTypes.Contains(fileextention))
                                {

                                    Model.ClientStatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                    TempData["alertMessage"] = Model.ClientStatus;
                                    return RedirectToActionPermanent("EditClients", "Manage");


                                }
                                else
                                {

                                    string fileName = Guid.NewGuid() + Path.GetExtension(Client_Photo.FileName);
                                    string pathoriginal = Path.Combine(Server.MapPath("~/Images/clients"), fileName).ToString();

                                    string pathresized = Path.Combine(Server.MapPath("~/Images/resizedclients"), fileName).ToString();
                                    Client_Photo.SaveAs(pathoriginal);
                                    ResizeImage(350, pathoriginal, pathresized);

                                    AspNetClient Entity = Context.AspNetClients.Find(Model.Client_Id);
                                    if (Entity != null)
                                    {

                                        Entity.Client_DateTime = DateTime.Now;
                                        Entity.Client_Fname_En = Model.Client_Fname_En;
                                        Entity.Client_Fname_Ar = Model.Client_Fname_Ar;
                                        Entity.Client_Lname_Ar = Model.Client_Lname_Ar;
                                        Entity.Client_Lname_En = Model.Client_Lname_En;
                                        Entity.Client_Email = Model.Client_Email;
                                        Entity.Client_PhoneNumber = Model.Client_PhoneNumber;
                                        Entity.Id = User.Identity.GetUserId();
                                        Entity.ClCat_Id = Model.ClCat_Id;
                                        Entity.Client_CompanyName_En = Model.Client_CompanyName_En;
                                        Entity.Client_CompanyName_Ar = Model.Client_CompanyName_Ar;

                                        Entity.Client_Address_En = Model.Client_Address_En;
                                        Entity.Client_Address_Ar = Model.Client_Address_Ar;
                                       



                                        System.IO.File.Delete(Server.MapPath("~/Images/resizedclients/" + Entity.Client_Photo));
                                        System.IO.File.Delete(Server.MapPath("~/Images/clients/" + Entity.Client_Photo));

                                        Entity.Client_Photo = fileName;
                                        Context.SaveChanges();
                                        if (Context.GetValidationErrors().Count() == 0)
                                        {

                                            TempData["alertMessage"] = "Success";

                                            AspNetNotification Notify = new AspNetNotification();
                                            Notify.Notify_Id = Guid.NewGuid().ToString();
                                            Notify.Notify_Title = "Edit Client";
                                            Notify.Notify_Action = "Clients";
                                            Notify.Notify_Active = true;
                                            Notify.Notify_DateTime = DateTime.Now;
                                            Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                             string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                            string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                            string Manager_Name = FName + " " + LName;

                                            Notify.Notify_Manager_Name = Manager_Name;

                                             Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                            Context.AspNetNotifications.Add(Notify);
                                            Context.SaveChanges();

                                            return RedirectToActionPermanent("EditClients", "Manage", new { Clients_Id = Model.Client_Id });


                                        }
                                        else
                                        {
                                            TempData["alertMessage"] = "Error";
                                            return RedirectToActionPermanent("EditClients", "Manage", new { Clients_Id = Model.Client_Id });
                                        }

                                    }
                                    else
                                    {
                                        return RedirectToActionPermanent("Clients", "Manage");
                                    }

                                }
                            }



                        }
                    }
                    else
                    {
                        return RedirectToActionPermanent("Login", "Account");
                    }
                    Model.Categories = new SelectList(Context.AspNetClientsCategories.ToList(), "ClCat_Id", "ClCat_Name_En");
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }

        // GET: /Manage/NewClients
        public ActionResult NewClients(string language)
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                using (Context)
                {

                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {
                        ClientsViewModel Model = new ClientsViewModel();

                        Model.Categories = new SelectList(Context.AspNetClientsCategories.ToList(), "ClCat_Id", "ClCat_Name_En");

                        if (TempData.ContainsKey("alertMessage"))
                        {

                            Model.ClientStatus = TempData["alertMessage"].ToString();

                        }
                        else
                        {
                            Model.ClientStatus = string.Empty;
                        }

                        return View(Model);

                    }
                }
            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }





            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewClients(ClientsViewModel Model, HttpPostedFileBase Client_Photo,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


            using (Context)
            {
                try
                {
                    if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                    {



                        if (ModelState.IsValid)
                        {
                            Model.Categories = new SelectList(Context.AspNetClientsCategories.ToList(), "ClCat_Id", "ClCat_Name_En");
                            if (Client_Photo != null && Client_Photo.ContentLength > 0)
                            {
                                var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                                var fileextention = Path.GetExtension(Client_Photo.FileName);

                                //.........check file Extention

                                if (!supportedTypes.Contains(fileextention))
                                {

                                    Model.ClientStatus = "File Extension Is InValid - Only Upload (.jpg , .jpeg, .png)";
                                    TempData["alertMessage"] = Model.ClientStatus;
                                    return RedirectToActionPermanent("NewClients", "Manage");


                                }
                                else
                                {

                                    string fileName = Guid.NewGuid() + Path.GetExtension(Client_Photo.FileName);
                                    string pathoriginal = Path.Combine(Server.MapPath("~/Images/clients"), fileName).ToString();

                                    string pathresized = Path.Combine(Server.MapPath("~/Images/resizedclients"), fileName).ToString();
                                    Client_Photo.SaveAs(pathoriginal);
                                    ResizeImage(350, pathoriginal, pathresized);


                                    AspNetClient Entity = new AspNetClient();
                                    Entity.Client_Id = Guid.NewGuid().ToString();
                                    Entity.Client_DateTime = DateTime.Now;
                                    Entity.Client_Fname_En = Model.Client_Fname_En;
                                    Entity.Client_Fname_Ar = Model.Client_Fname_Ar;
                                    Entity.Client_Lname_Ar = Model.Client_Lname_Ar;
                                    Entity.Client_Lname_En = Model.Client_Lname_En;
                                    Entity.Client_Email = Model.Client_Email;
                                    Entity.Client_Photo = fileName;
                                    Entity.Client_PhoneNumber = Model.Client_PhoneNumber;
                                    Entity.Id = User.Identity.GetUserId();
                                    Entity.ClCat_Id = Model.ClCat_Id;
                                    Entity.Client_CompanyName_En = Model.Client_CompanyName_En;
                                    Entity.Client_CompanyName_Ar = Model.Client_CompanyName_Ar;

                                    Entity.Client_Address_En = Model.Client_Address_En;
                                    Entity.Client_Address_Ar = Model.Client_Address_Ar;




                                    Context.AspNetClients.Add(Entity);
                                    Context.SaveChanges();


                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        TempData["alertMessage"] = "Success";


                                        AspNetNotification Notify = new AspNetNotification();
                                        Notify.Notify_Id = Guid.NewGuid().ToString();
                                        Notify.Notify_Title = "Add New Client";
                                        Notify.Notify_Action = "Clients";
                                        Notify.Notify_Active = true;
                                        Notify.Notify_DateTime = DateTime.Now;
                                        Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                         string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                        string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                        string Manager_Name = FName + " " + LName;

                                        Notify.Notify_Manager_Name = Manager_Name;

                                         Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                        Context.AspNetNotifications.Add(Notify);
                                        Context.SaveChanges();
                                        return RedirectToActionPermanent("NewClients", "Manage");


                                    }
                                    else
                                    {
                                        TempData["alertMessage"] = "Error";
                                        return RedirectToActionPermanent("NewClients", "Manage");
                                    }
                                }
                            }



                        }

                        Model.Categories = new SelectList(Context.AspNetClientsCategories.ToList(), "ClCat_Id", "ClCat_Name_En");



                    }
                    else
                    {

                        return RedirectToActionPermanent("Login", "Account");


                    }




                }
                catch
                {
                    ////EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    ////SetLoaderLogging(true);
                    ////SetNetworkLogging(true);
                    ////SetNetworkLogging(true);

                }





            }




            return View(Model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/DeleteClientsCategories
        public ActionResult DeleteClientsCategories(string ClCat_Id,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(ClCat_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetClientsCategory Entity = Context.AspNetClientsCategories.Find(ClCat_Id);


                            if (Entity != null)
                            {

                                Context.AspNetClientsCategories.Remove(Entity);
                                Context.SaveChanges();

                                if (Context.GetValidationErrors().Count() == 0)
                                {


                                    TempData["alertMessage"] = "Success";


                                    AspNetNotification Notify = new AspNetNotification();
                                    Notify.Notify_Id = Guid.NewGuid().ToString();
                                    Notify.Notify_Title = "Delete Client Category";
                                    Notify.Notify_Action = "Clients Categories";
                                    Notify.Notify_Active = true;
                                    Notify.Notify_DateTime = DateTime.Now;
                                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                     string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                    string Manager_Name = FName + " " + LName;

                                    Notify.Notify_Manager_Name = Manager_Name;

                                     Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                    Context.AspNetNotifications.Add(Notify);
                                    Context.SaveChanges();
                                    return RedirectToActionPermanent("ClientsCategories", "Manage");

                                }
                                else
                                {
                                    TempData["alertMessage"] = "Error";
                                    return RedirectToActionPermanent("ClientsCategories", "Manage");

                                }






                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("ClientsCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }

        // GET: /Manage/ClientsCategories
        public ActionResult ClientsCategories(int? page,string language)

        {
            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {

                    if (TempData.ContainsKey("alertMessage"))
                    {
                        ViewBag.alertMessage = TempData["alertMessage"].ToString();
                    }
                    else
                    {
                        ViewBag.alertMessage = string.Empty;
                    }

                    return View(Context.AspNetClientsCategories.OrderByDescending(m => m.ClCat_DateTime).ToPagedList(pageNumber, 10));
                }


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetClientsCategories.OrderByDescending(m => m.ClCat_DateTime).ToPagedList(pageNumber, 10));


        }

        // GET: /Manage/EditProjectsCategories
        public ActionResult EditClientsCategories(string ClCat_Id,string language)
        {
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (!string.IsNullOrEmpty(ClCat_Id))
                {


                    using (Context)
                    {

                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetClientsCategory Entity = Context.AspNetClientsCategories.Find(ClCat_Id);
                            if (Entity != null)
                            {

                                ClientsCategoriesViewModel Model = new ClientsCategoriesViewModel();

                                Model.Id = Entity.Id;
                                Model.ClCat_DateTime = Entity.ClCat_DateTime;
                                Model.ClCat_Description_Ar = Entity.ClCat_Description_Ar;
                                Model.ClCat_Description_En = Entity.ClCat_Description_En;
                                Model.ClCat_Id = Entity.ClCat_Id;
                                Model.ClCat_Name_Ar = Entity.ClCat_Name_Ar;
                                Model.ClCat_Name_En = Entity.ClCat_Name_En;
                                if (TempData.ContainsKey("alertMessage"))
                                {
                                    Model.ClientsCategoriesStatus = TempData["alertMessage"].ToString();
                                }
                                else
                                {
                                    Model.ClientsCategoriesStatus = string.Empty;
                                }



                                return View(Model);


                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }



                    }

                }
                else
                {
                    RedirectToActionPermanent("ClientsCategories", "Manage");
                }

            }

            catch
            {
                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);

            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/EditClientsCategories
        public ActionResult EditClientsCategories(ClientsCategoriesViewModel Model,string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (Context)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Model.ClCat_Id))
                    {



                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetClientsCategory Entity = Context.AspNetClientsCategories.Find(Model.ClCat_Id);
                            if (Entity != null)
                            {


                                if (ModelState.IsValid)
                                {



                                    Entity.ClCat_DateTime = DateTime.Now;
                                    Entity.ClCat_Description_Ar = Model.ClCat_Description_Ar;
                                    Entity.ClCat_Description_En = Model.ClCat_Description_En;
                                    Entity.ClCat_Name_Ar = Model.ClCat_Name_Ar;
                                    Entity.ClCat_Name_En = Model.ClCat_Name_En;
                                    Entity.Id = User.Identity.GetUserId();


                                    Context.SaveChanges();

                                    if (Context.GetValidationErrors().Count() == 0)
                                    {

                                        Model.ClientsCategoriesStatus = "Success";
                                        TempData["alertMessage"] = Model.ClientsCategoriesStatus;


                                        AspNetNotification Notify = new AspNetNotification();
                                        Notify.Notify_Id = Guid.NewGuid().ToString();
                                        Notify.Notify_Title = "Edit Client Category";
                                        Notify.Notify_Action = "Clients Categories";
                                        Notify.Notify_Active = true;
                                        Notify.Notify_DateTime = DateTime.Now;
                                        Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                         string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                        string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                        string Manager_Name = FName + " " + LName;

                                        Notify.Notify_Manager_Name = Manager_Name;

                                         Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                        Context.AspNetNotifications.Add(Notify);
                                        Context.SaveChanges();

                                        return RedirectToAction("EditClientsCategories", "Manage", new { ClCat_Id = Model.ClCat_Id });

                                    }
                                    else
                                    {
                                        Model.ClientsCategoriesStatus = "Error";
                                        TempData["alertMessage"] = Model.ClientsCategoriesStatus;
                                        return RedirectToAction("EditClientsCategories", "Manage", new { ClCat_Id = Model.ClCat_Id });
                                    }




                                }

                            }




                        }
                        else
                        {
                            return RedirectToActionPermanent("Login", "Account");
                        }





                    }
                    else
                    {
                        RedirectToActionPermanent("ClientsCategories", "Manage");
                    }

                }

                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }

            }
            return View();
        }


        // GET: /Manage/NewClientsCategories
        public ActionResult NewClientsCategories(string language)
        {

            ClientsCategoriesViewModel Model = new ClientsCategoriesViewModel();
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                {


                    if (TempData.ContainsKey("alertMessage"))
                    {


                        Model.ClientsCategoriesStatus = TempData["alertMessage"].ToString();


                    }
                    else
                    {

                        Model.ClientsCategoriesStatus = string.Empty;

                    }


                }
            }
            catch
            {


                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);



            }


            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: /Manage/NewClientsCategories
        public ActionResult NewClientsCategories(ClientsCategoriesViewModel Model,string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            using (Context)
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        if (User.Identity.IsAuthenticated && User.IsInRole("Manager"))
                        {

                            AspNetClientsCategory Entity = new AspNetClientsCategory();
                            Entity.ClCat_Id = Guid.NewGuid().ToString();
                            Entity.ClCat_Name_En = Model.ClCat_Name_En;
                            Entity.ClCat_Name_Ar = Model.ClCat_Name_Ar;
                            Entity.ClCat_Description_Ar = Model.ClCat_Description_Ar;
                            Entity.ClCat_Description_En = Model.ClCat_Description_En;
                            Entity.ClCat_DateTime = DateTime.Now;
                            Entity.Id = User.Identity.GetUserId();

                            Context.AspNetClientsCategories.Add(entity: Entity);
                            Context.SaveChanges();


                            if (Context.GetValidationErrors().Count() == 0)
                            {

                                Model.ClientsCategoriesStatus = "Success";
                                TempData["alertMessage"] = Model.ClientsCategoriesStatus;

                                AspNetNotification Notify = new AspNetNotification();
                                Notify.Notify_Id = Guid.NewGuid().ToString();
                                Notify.Notify_Title = "Add New Client Category";
                                Notify.Notify_Action = "Clients Categories";
                                Notify.Notify_Active = true;
                                Notify.Notify_DateTime = DateTime.Now;
                                Notify.Notify_Manager_Id = User.Identity.GetUserId();
                                
                                string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id ==Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                                string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                                string Manager_Name = FName + " " + LName;

                                Notify.Notify_Manager_Name = Manager_Name;

                                Notify.Notify_Manager_Photo= Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                                Context.AspNetNotifications.Add(Notify);
                                Context.SaveChanges();


                                return RedirectToActionPermanent("NewClientsCategories");
                            }
                            else
                            {


                                Model.ClientsCategoriesStatus = "Error";
                                TempData["alertMessage"] = Model.ClientsCategoriesStatus;
                                return RedirectToActionPermanent("NewClientsCategories");
                            }


                        }







                    }




                }
                catch
                {
                    //EnableLogging(true, true, true);
                    //SetInteropLogging(true);
                    //SetLoaderLogging(true);
                    //SetNetworkLogging(true);
                    //SetNetworkLogging(true);

                }





            }


            return View(Model);
        }
        #endregion


        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Generate the token and send it
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "Your security code is: " + code
                };
                await UserManager.SmsService.SendAsync(message);
            }
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            // Send an SMS through the SMS provider to verify the phone number
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePhoneNumberAsync(User.Identity.GetUserId(), model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Failed to verify phone");
            return View(model);
        }

        //
        // POST: /Manage/RemovePhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);


                    AspNetNotification Notify = new AspNetNotification();
                    Notify.Notify_Id = Guid.NewGuid().ToString();
                    Notify.Notify_Title = "Change Password";
                    Notify.Notify_Action = "Managers";
                    Notify.Notify_Active = true;
                    Notify.Notify_DateTime = DateTime.Now;
                    Notify.Notify_Manager_Id = User.Identity.GetUserId();
                    string FName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfoPlus_Fname_En;
                    string LName = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Lname_En;

                    string Manager_Name = FName + " " + LName;

                    Notify.Notify_Manager_Name = Manager_Name;

                    Notify.Notify_Manager_Photo = Context.AspNetUsersInfoPlus.Where(m => m.Id == Notify.Notify_Manager_Id).SingleOrDefault().UInfo_Photo;


                    Context.AspNetNotifications.Add(Notify);
                    Context.SaveChanges();

                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

#region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }




     //---------------------------------------------Log files for appletsoftware-------------------------------------


        // This method enables general logging and contains parameters
        // to specify a path, and boolean values where true includes
        // the application name, process id, and events to the log.
        private void EnableLogging(bool useApp, bool usePid, bool useFlush)
        {
            // Specify values for setting the registry.
            string userRoot = "HKEY_LOCAL_MACHINE";
            string subkey = "SOFTWARE\\Microsoft\\.NETCompactFramework\\Diagnostics\\Logging";
            string keyName = userRoot + "\\" + subkey;

            // Set the the Enabled registry value.
            Registry.SetValue(keyName, "Enabled", 1);

            if (useApp == true)
                Registry.SetValue(keyName, "UseApp", 1);
            else
                Registry.SetValue(keyName, "UseApp", 0);

            if (usePid == true)
                Registry.SetValue(keyName, "UsePid", 1);
            else
                Registry.SetValue(keyName, "UsePid", 0);

            if (useFlush == true)
                Registry.SetValue(keyName, "UseFlush", 1);
            else
                Registry.SetValue(keyName, "UseFlush", 0);
        }

        // This method set the Enabled key value to 1,
        // so that logging for Interoperability is enabled.
        private void SetInteropLogging(bool logOn)
        {
            // Specify values for setting the registry.
            string userRoot = "HKEY_LOCAL_MACHINE";
            string subkey = "Software\\Microsoft\\.NETCompactFramework\\Diagnostics\\Logging\\Interop";
            string keyName = userRoot + "\\" + subkey;

            int logSet;
            if (logOn == true)
                logSet = 1;
            else
                logSet = 0;

            // Set the the registry value.
            try
            {
                Registry.SetValue(keyName, "Enabled", logSet);
                //if (logOn == true)
                    //MessageBox.Show("Interop Logging On");
                //else
                    //MessageBox.Show("Interop Loggin Off");
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        // This set the Enabled key value to 1,
        // so that logging for class loading is enabled.
        private void SetLoaderLogging(bool logOn)
        {
            // Specify values for setting the registry.
            string userRoot = "HKEY_LOCAL_MACHINE";
            string subkey = "Software\\Microsoft\\.NETCompactFramework\\Diagnostics\\Logging\\Loader";
            string keyName = userRoot + "\\" + subkey;

            int logSet;
            if (logOn == true)
                logSet = 1;
            else
                logSet = 0;

            // Set the the registry value.
            try
            {
                Registry.SetValue(keyName, "Enabled", logSet);
                //if (logOn == true)
                    //MessageBox.Show("Loader Logging On");
                //else
                    //MessageBox.Show("Loader Loggin Off");
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        // This method set the Enabled key value to 1,
        // so that logging for networking is enabled.
        private void SetNetworkLogging(bool logOn)
        {
            // Specify values for setting the registry.
            string userRoot = "HKEY_LOCAL_MACHINE";
            string subkey = "Software\\Microsoft\\.NETCompactFramework\\Diagnostics\\Logging\\Networking";
            string keyName = userRoot + "\\" + subkey;

            int logSet;
            if (logOn == true)
                logSet = 1;
            else
                logSet = 0;

            // Set the the registry value.
            try
            {
                Registry.SetValue(keyName, "Enabled", logSet);
                //if (logOn == true)
                    //MessageBox.Show("Networking Logging On");
                //else
                    //MessageBox.Show("Networking Loggin Off");
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        // This method disables all logging.
        private void DisableLogging()
        {
            // Specify values for setting the registry.
            string userRoot = "HKEY_LOCAL_MACHINE";
            string subkey = "SOFTWARE\\Microsoft\\.NETCompactFramework\\Diagnostics\\Logging";
            string keyName = userRoot + "\\" + subkey;

            // Set the the Enabled registry value.
            Registry.SetValue(keyName, "Enabled", 0);
            //MessageBox.Show("Logging Disabled");
        }

        // This method recursively examines the keys
        // under the Logging sub key and writes their
        // key names and values to a log file. It saves
        // to "logsettings.txt" in the directory
        // containing this example application.
        private void WriteLoggingSettings()
        {
            StreamWriter sw = new StreamWriter(Server.MapPath("/logsettings.txt"), false);
            sw.WriteLine("General Logging Settings:");
            RegistryKey rkLogging = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETCompactFramework\\Diagnostics\\Logging");
            string[] valNames = rkLogging.GetValueNames();
            for (int x = 0; x < valNames.Length; x++)
            {
                sw.WriteLine(valNames[x].ToString() + ": " + rkLogging.GetValue(valNames[x]).ToString());
            }

            sw.WriteLine();
            sw.WriteLine("Interop Logging:");
            RegistryKey rkInterop = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETCompactFramework\\Diagnostics\\Logging\\Interop");
            string[] interopNames = rkInterop.GetValueNames();
            for (int x = 0; x < interopNames.Length; x++)
            {
                sw.WriteLine(interopNames[x].ToString() + ": " + rkInterop.GetValue(interopNames[x]).ToString());
            }

            sw.WriteLine();
            sw.WriteLine("Loader Logging:");
            RegistryKey rkLoader = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETCompactFramework\\Diagnostics\\Logging\\Loader");
            string[] loaderNames = rkLoader.GetValueNames();
            for (int x = 0; x < loaderNames.Length; x++)
            {
                sw.WriteLine(loaderNames[x].ToString() + ": " + rkLoader.GetValue(loaderNames[x]).ToString());
            }

            sw.WriteLine();
            sw.WriteLine("Networking Logging:");
            RegistryKey rkNetworking = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETCompactFramework\\Diagnostics\\Logging\\Networking");
            string[] netNames = rkNetworking.GetValueNames();
            for (int x = 0; x < netNames.Length; x++)
            {
                sw.WriteLine(netNames[x].ToString() + ": " + rkNetworking.GetValue(netNames[x]).ToString());
            }
            sw.Close();
        }



        private static void ResizeImage(int size, string filePath, string saveFilePath)
        {
            //variables for image dimension/scale

            double newHeight = 0;
            double newWidth = 0;
            double scale = 0;

            //create new image object
            Bitmap curImage = new Bitmap(filePath);

            //Determine image scaling
            if (curImage.Height > curImage.Width)
            {
                scale = Convert.ToSingle(size) / curImage.Height;
            }
            else
            {
                scale = Convert.ToSingle(size) / curImage.Width;
            }
            if (scale < 0 || scale > 1) { scale = 1; }

            //New image dimension
            newHeight = Math.Floor(Convert.ToSingle(curImage.Height) * scale);
            newWidth = Math.Floor(Convert.ToSingle(curImage.Width) * scale);

            //Create new object image
            Bitmap newImage = new Bitmap(curImage, Convert.ToInt32(newWidth), Convert.ToInt32(newHeight));
            Graphics imgDest = Graphics.FromImage(newImage);
            imgDest.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            imgDest.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            imgDest.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            imgDest.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
            EncoderParameters param = new EncoderParameters(1);
            param.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);

            //Draw the object image
            imgDest.DrawImage(curImage, 0, 0, newImage.Width, newImage.Height);

            //Save image file
            newImage.Save(saveFilePath, info[1], param);

            //Dispose the image objects
            curImage.Dispose();
            newImage.Dispose();
            imgDest.Dispose();


        }



        #endregion
    }
}