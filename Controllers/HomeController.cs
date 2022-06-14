using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AppletSoftware.Models;
using Microsoft.Win32;
using PagedList;

namespace AppletSoftware.Controllers
{
    public class HomeController : Controller
    {
        private AppletSoftwareEntities Context = new AppletSoftwareEntities();

      //GET: Home/Index
        [HttpGet]
        public ActionResult Index(string language)
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


                ViewData["LatestPlans"] = Context.AspNetPlans.ToList().OrderByDescending(m=>m.Plan_DateTime).Take(3);
                ViewData["LatestProjects"] = Context.AspNetProjects.ToList().OrderByDescending(m => m.Project_DateTime).Take(6);
                ViewData["LatestCategories"] = Context.AspNetProjectsCategories.OrderByDescending(m => m.PCat_DateTime).Take(9);
                ViewData["ProjectsCount"] = Context.AspNetProjects.ToList().Count;
                ViewData["PlansCount"] = Context.AspNetPlans.ToList().Count;
                ViewData["ClientsCount"] = Context.AspNetClients.ToList().Count;
                ViewData["TestmonialsCount"] = Context.AspNetTestmonials.ToList().Count;

                ViewData["LatestTeams"] = Context.AspNetTeams.ToList().OrderByDescending(m=>m.Team_DateTime).Take(6);

                ViewData["LatestTestmonials"] = Context.AspNetTestmonials.ToList().OrderByDescending(m => m.Testmonial_DateTime).Take(6);

                ViewData["LatestNews"] = Context.AspNetNews.ToList().OrderByDescending(m => m.News_DateTime).Take(4);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendMessage(FormCollection Form)
        {
            try
            {
                ContactusViewModel Model = new ContactusViewModel();

                Model.Message_Subject = Request.Form["MessageSubject"].ToString();
                Model.Message_Response = false;
                Model.Message_Active = true;
                Model.Message_Email = Request.Form["SenderEmail"].ToString();
                Model.Message_DateTime = DateTime.Now;
                Model.Message_Content = Request.Form["MessageContent"].ToString();
                Model.Message_Id = Guid.NewGuid().ToString();


                AspNetMessage Entity = new AspNetMessage();
                Entity.Message_Subject = Model.Message_Subject;
                Entity.Message_Response = Model.Message_Response;
                Entity.Message_Id = Model.Message_Id;
                Entity.Message_Email = Model.Message_Email;
                Entity.Message_DateTime = Model.Message_DateTime;
                Entity.Message_Content = Model.Message_Content;
                Entity.Message_Active = Model.Message_Active;

                Context.AspNetMessages.Add(Entity);
                Context.SaveChanges();
                if (Context.GetValidationErrors().Count()==0)
                {


                    return RedirectToActionPermanent("Index", "Home");

                }
                else
                {
                  

                        return RedirectToActionPermanent("Index", "Home");

                   
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

            return RedirectToActionPermanent("Index", "Home");
        }

        //Post: Home/Index
          [HttpPost]
          [ValidateAntiForgeryToken]
        public ActionResult NewsLetters(FormCollection Form)
        {

            try
            {
                NewsLettersViewModel Model = new NewsLettersViewModel();

                Model.Letter_Id = Guid.NewGuid().ToString();
                Model.Letter_Email = Request.Form["Letter_Email"].ToString();
                Model.Letter_Active = true;
                Model.Letter_Response = false;
                Model.Letter_DateTime = DateTime.Now;


                AspNetNewsLetter Entity = new AspNetNewsLetter();

                Entity.Letter_Active = Model.Letter_Active;
                Entity.Letter_DateTime = Model.Letter_DateTime;
                Entity.Letter_Email = Model.Letter_Email;
                Entity.Letter_Id = Model.Letter_Id;
                Entity.Letter_Response = Model.Letter_Response;


                Context.AspNetNewsLetters.Add(entity: Entity);
                Context.SaveChanges();


                return RedirectToActionPermanent("Index", "Home");


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

        // GET: /Home/Plans
        public ActionResult Plans(int? page,string language)
        {

            int pageNumber = page ?? 1;
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);



                return View(Context.AspNetPlans.OrderByDescending(m => m.Plan_DateTime).ToPagedList(pageNumber, 12));



            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetPlans.OrderByDescending(m => m.Plan_DateTime).ToPagedList(pageNumber, 12));



        }


        // GET: /Home/OrderNow
        public ActionResult OrderNow(string Plan_Id,string language)
        {

           
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
                if (!string.IsNullOrEmpty(Plan_Id))
                {


                    AspNetPlan Entity = Context.AspNetPlans.Find(Plan_Id);

                    if (Entity!=null)
                    {

                        PlanOrderViewModel Model = new PlanOrderViewModel();

                        Model.Order_Plan = Entity.Plan_Name_En;
                        if (TempData.ContainsKey("Success"))
                        {
                            ViewBag.Success = TempData["Success"].ToString();
                        }
                        else
                        {
                            ViewBag.Success = string.Empty;

                        }



                        return View(Model);
                    }




                }
                else
                {
                    PlanOrderViewModel Model = new PlanOrderViewModel();
                 
                    if (TempData.Keys.Contains("Success"))
                    {
                        ViewBag.Success = TempData["Success"].ToString();

                    }
                    else
                    {
                        ViewBag.Success = string.Empty;

                    }
                    return View(Model);
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


        // POST: /Home/OrderNow
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderNow(PlanOrderViewModel Model,string language)
        {


            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (ModelState.IsValid)
                {


                    AspNetPlanOrder Entity = new AspNetPlanOrder();

                    Entity.Order_Id = Guid.NewGuid().ToString();
                    Entity.Order_Plan = Model.Order_Plan;
                    Entity.Order_Phone = Model.Order_Phone;
                    Entity.Order_Message = Model.Order_Message;
                    Entity.Order_Lname = Model.Order_Lname;
                    Entity.Order_Fname = Model.Order_Fname;
                    Entity.Order_Email = Model.Order_Email;
                    Entity.Order_Response = false;
                    Entity.Order_DateTime = DateTime.Now;

                    Context.AspNetPlanOrders.Add(Entity);
                    Context.SaveChanges();

                    if (Context.GetValidationErrors().Count()==0)
                    {

                        TempData["Success"] = "success";

                        return RedirectToActionPermanent("OrderNow", "Home",new { Plan_Id=string.Empty });
                    }
                    else
                    {
                        TempData["Success"] = string.Empty;

                        return RedirectToActionPermanent("OrderNow", "Home", new { Plan_Id = string.Empty });
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




        // GET: /Home/Projects
        public ActionResult Projects(int? page,string language)
        {

            int pageNumber = page ?? 1;
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                ViewData["LatestCategories"] = Context.AspNetProjectsCategories.OrderByDescending(m => m.PCat_DateTime).Take(9);

                return View(Context.AspNetProjects.OrderByDescending(m => m.Project_DateTime).ToPagedList(pageNumber, 12));



            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetProjects.OrderByDescending(m => m.Project_DateTime).ToPagedList(pageNumber, 12));



        }

        // GET: /Home/Teams
        public ActionResult News(int? page,string language)
        {

            int pageNumber = page ?? 1;
            try
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);



                return View(Context.AspNetNews.OrderByDescending(m => m.News_DateTime).ToPagedList(pageNumber, 12));
            


            }
            catch
            {

                //EnableLogging(true, true, true);
                //SetInteropLogging(true);
                //SetLoaderLogging(true);
                //SetNetworkLogging(true);
                //SetNetworkLogging(true);
            }

            return View(Context.AspNetNews.OrderByDescending(m => m.News_DateTime).ToPagedList(pageNumber, 12));



        }
        // GET: /Home/News
        public ActionResult Teams(int? page,string language)
        {

            int pageNumber = page ?? 1;
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                ViewData["TeamsDescending"] = Context.AspNetTeams.OrderByDescending(m => m.Team_DateTime).ToPagedList(pageNumber, 12);
                ViewData["TeamsAscending"] = Context.AspNetTeams.OrderBy(m => m.Team_DateTime).ToPagedList(pageNumber, 12);



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

        public ActionResult NewsDetails(string News_Id,string language)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

                if (!string.IsNullOrEmpty(News_Id))
                {
                    AspNetNew Entity = Context.AspNetNews.Find(News_Id);

                    if (Entity!=null)
                    {



                        return View(Entity);



                    }
                    else
                    {
                        return RedirectToActionPermanent("News", "Home");
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

        // GET: /Home/About

        public ActionResult About(string language)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);



            return View();
        }


        // GET: /Home/Contact

        public ActionResult Contact(string language)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);




            return View();
        }

  

        #region APPLETSoft Logging EXception


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






        #endregion



    }
}