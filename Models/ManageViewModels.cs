using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace AppletSoftware.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }


    //-----------------------------------------------------------APPLET Software Models--------------------
    public class ProjectsViewModel
    {
        [Display(Name ="Project_Id")]
        [DataType(DataType.Text)]
        public string Project_Id { get; set; }
        [Display(Name = "ProjectName")]
        [DataType(DataType.Text)]
        [Required]
        public string Project_Name_Ar { get; set; }
        [Display(Name = "ProjectName")]
        [DataType(DataType.Text)]
        [Required]
        public string Project_Name_En { get; set; }
        [Display(Name = "ProjectDateTime")]
        [DataType(DataType.DateTime)]
        public System.DateTime Project_DateTime { get; set; }
        [Display(Name = "ProjectPhoto")]
        [DataType(DataType.Text)]
        [Required]
        public string Project_Photo { get; set; }
        [Display(Name = "ProjectUrl")]
        [DataType(DataType.Url)]
        
        public string Project_Url { get; set; }
        [Display(Name = "ProjectDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string Project_Descrption_Ar { get; set; }
        [Display(Name = "ProjectDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string Project_Descrption_En { get; set; }
        [Display(Name = "ProjectCategory")]
        [DataType(DataType.Text)]
        [Required]
        public string PCat_Id { get; set; }
        [Display(Name = "ProjectPublisher")]
        [DataType(DataType.Text)]
        
        public string Id { get; set; }

        public string ProjectStatus { get; set; }

       public IEnumerable<SelectListItem> Categories { get; set; }

        public virtual AspNetProjectsCategory AspNetProjectsCategory { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }


    }
    public class ProjectsCategoriesViewModel
    {

        [Display(Name ="ProjectCategory")]
        [DataType(DataType.Text)]
        public string PCat_Id { get; set; }
        [Display(Name = "ProjectCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string PCat_Name_Ar { get; set; }
        [Display(Name = "ProjectCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string PCat_Name_En { get; set; }
        [Display(Name = "ProjectCategoryDateTime")]
        [DataType(DataType.DateTime)]
       
        public System.DateTime PCat_DateTime { get; set; }
        [Display(Name = "ProjectCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]

        public string PCat_Description_Ar { get; set; }
        [Display(Name = "ProjectCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string PCat_Description_En { get; set; }
        [Display(Name = "ProjectCategoryStatus")]
        [DataType(DataType.Text)]
     
        public string ProjectCategoryStatus { get; set; }
        [Display(Name = "ProjectCategoryPublisher")]
        [DataType(DataType.Text)]
       
        public string Id { get; set; }

      
        public virtual ICollection<AspNetProject> AspNetProjects { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
    public class NewsViewModel
    {
        [Display(Name ="NewsId")]
        [DataType(DataType.Text)]
        public string News_Id { get; set; }
        [Display(Name = "NewsTitle")]
        [DataType(DataType.Text)]
        [Required]
        public string News_Title_Ar { get; set; }
        [Display(Name = "NewsTitle")]
        [DataType(DataType.Text)]
        [Required]
        public string News_Title_En { get; set; }
        [Display(Name = "NewsShort")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string News_Short_Ar { get; set; }
        [Display(Name = "NewsShort")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string News_Short_En { get; set; }
        [Display(Name = "NewsLong")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string News_Long_Ar { get; set; }
        [Display(Name = "NewsLong")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string News_Long_En { get; set; }
        [Display(Name = "NewsDateTime")]
        [DataType(DataType.DateTime)]
       
        public System.DateTime News_DateTime { get; set; }
        [Display(Name = "NewsPhoto")]
        [DataType(DataType.Text)]
        [Required]
        public string News_Photo { get; set; }
        [Display(Name = "NewsCategory")]
        [DataType(DataType.Text)]
        
        public string NCat_Id { get; set; }

        [Display(Name = "NewsPublisher")]
        [DataType(DataType.Text)]
        
        public string Id { get; set; }
        public string NewsStatus { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public virtual AspNetNewsCategory AspNetNewsCategory { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }


    }
    public class NewsCategoriesViewModel
    {

        [Display(Name = "NewsCategory")]
        [DataType(DataType.Text)]
        public string NCat_Id { get; set; }
        [Display(Name = "NewsCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string NCat_Name_Ar { get; set; }
        [Display(Name = "NewsCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string NCat_Name_En { get; set; }
        [Display(Name = "NewsCategoryDateTime")]
        [DataType(DataType.DateTime)]

        public System.DateTime NCat_DateTime { get; set; }
        [Display(Name = "NewsCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string NCat_Description_Ar { get; set; }
        [Display(Name = "NewsCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string NCat_Description_En { get; set; }
        [Display(Name = "NewsCategoryPublisher")]
        [DataType(DataType.Text)]
        public string Id { get; set; }

        [Display(Name = "NewsCategoryStatus")]
        [DataType(DataType.Text)]
        public string NewsCategoriesStatus { get; set; }



        public virtual ICollection<AspNetProject> AspNetProjects { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
    public class TeamsViewModel
    {
        [Display(Name ="TeamId")]
        [DataType(DataType.Text)]
        public string Team_Id { get; set; }

        [Display(Name = "TeamFname")]
        [DataType(DataType.Text)]
        [Required]
        public string Team_Fname_Ar { get; set; }

        [Display(Name = "TeamFname")]
        [DataType(DataType.Text)]
        [Required]
        public string Team_Fname_En { get; set; }

        [Display(Name = "TeamLname")]
        [DataType(DataType.Text)]
        [Required]
        public string Team_Lname_Ar { get; set; }

        [Display(Name = "TeamLname")]
        [DataType(DataType.Text)]
        [Required]
        public string Team_Lname_En { get; set; }
        [Display(Name = "Team Email")]
        [DataType(DataType.EmailAddress)]
        [Required]

        public string Team_Email { get; set; }
        [Display(Name = "Team Phone")]
        [DataType(DataType.PhoneNumber)]
        [Required]

        public string Team_Phone { get; set; }

        [Display(Name = "Team Photo")]
        [DataType(DataType.Text)]
        [Required]

        public string Team_Photo { get; set; }

        [Display(Name = "Team DateTime")]
        [DataType(DataType.DateTime)]
        public System.DateTime Team_DateTime { get; set; }

        [Display(Name = "Team Category")]
        [DataType(DataType.Text)]
        [Required]
        public string TCat_Id { get; set; }

        [Display(Name = "TeamPublisher")]
        [DataType(DataType.Text)]
        
        public string Id { get; set; }

        [Display(Name = "TeamSalary")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Team_Salary { get; set; }

        [Display(Name = "TeamJobTitle")]
        [DataType(DataType.Text)]
        [Required]
        public string Team_JobTitle_Ar { get; set; }

        [Display(Name = "TeamJobTitle")]
        [DataType(DataType.Text)]
        [Required]
        public string Team_JobTitle_En { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public string TeamsStatus { get; set; }
        
        public virtual AspNetTeamsCategory AspNetTeamsCategory { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }

    }
    public class TeamsCategoriesViewModel
    {
      

        [Display(Name = "TeamsCategory")]
        [DataType(DataType.Text)]
        public string TCat_Id { get; set; }
        [Display(Name = "TeamsCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string TCat_Name_Ar { get; set; }
        [Display(Name = "TeamsCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string TCat_Name_En { get; set; }
        [Display(Name = "TeamsCategoryDateTime")]
        [DataType(DataType.DateTime)]

        public System.DateTime TCat_DateTime { get; set; }
        [Display(Name = "TeamsCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]

        public string TCat_Description_Ar { get; set; }
        [Display(Name = "TeamsCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string TCat_Description_En { get; set; }
        [Display(Name = "TeamsCategoryPublisher")]
        [DataType(DataType.Text)]
        public string Id { get; set; }

        public string TeamsCategoriesStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetTeam> AspNetTeams { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
    public class TestmonialsViewModel
    {

        [Display(Name ="TestmonialId")]
        [DataType(DataType.Text)]
        public string Testmonial_Id { get; set; }
        [Display(Name = "TestmonialQuestion")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string Testmonial_Question_Ar { get; set; }
        [Display(Name = "TestmonialQuestion")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string Testmonial_Question_En { get; set; }
        [Display(Name = "TestmonialAnswer")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string Testmonial_Answer_Ar { get; set; }
        [Display(Name = "TestmonialAnswer")]
        [DataType(DataType.Text)]
        [Required]
         [AllowHtml]

        public string Testmonial_Answer_En { get; set; }
        [Display(Name = "TestmonialDateTime")]
        [DataType(DataType.DateTime)]     
        public System.DateTime Testmonial_DateTime { get; set; }
        [Display(Name = "TestmonialClientName")]
        [DataType(DataType.Text)]
        [Required]

        public string Testmonial_ClientName_Ar { get; set; }
        [Display(Name = "TestmonialClientName")]
        [DataType(DataType.Text)]
        [Required]

        public string Testmonial_ClientName_En { get; set; }
        [Display(Name = "TestmonialJobTitle")]
        [DataType(DataType.Text)]
        [Required]

        public string Testmonial_ClientJobTitle_Ar { get; set; }
        [Display(Name = "TestmonialJobTitle")]
        [DataType(DataType.Text)]
        [Required]
        public string Testmonial_ClientJobTitle_En { get; set; }
        [Display(Name = "TestmonialPhoto")]
        [DataType(DataType.Text)]
        [Required]
        public string Testmonial_ClientPhoto { get; set; }
        [Display(Name = "TestmonialCategory")]
        [DataType(DataType.Text)]
        [Required]
        public string TsCat_Id { get; set; }
        [Display(Name = "TestmonialPublisher")]
        [DataType(DataType.Text)]
        
        public string Id { get; set; }

        public string Testmonialstatus { get; set; }

         public IEnumerable<SelectListItem> Categories { get; set; }
        public virtual AspNetTestmonialsCategory AspNetTestmonialsCategory { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }

    }
    public class TestmonialsCategoriesViewModel
    {


        [Display(Name = "TestmonialsCategory")]
        [DataType(DataType.Text)]
        public string TsCat_Id { get; set; }
        [Display(Name = "TestmonialsCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string TsCat_Name_Ar { get; set; }
        [Display(Name = "TestmonialsCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string TsCat_Name_En { get; set; }
        [Display(Name = "TestmonialsCategoryDateTime")]
        [DataType(DataType.DateTime)]

        public System.DateTime TsCat_DateTime { get; set; }
        [Display(Name = "TestmonialsCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]

        public string TsCat_Description_Ar { get; set; }
        [Display(Name = "TestmonialsCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string TsCat_Description_En { get; set; }
        [Display(Name = "TestmonialsCategoryPublisher")]
        [DataType(DataType.Text)]
        public string Id { get; set; }

        public string TestmonialsCategoriesStatus { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetTestmonial> AspNetTestmonials { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }

    public class PlansViewModel
    {
         [Display(Name ="PlanId")]
         [DataType(DataType.Text)]
        public string Plan_Id { get; set; }
        [Display(Name = "PlanName")]
        [DataType(DataType.Text)]
        [Required]
        public string Plan_Name_Ar { get; set; }
        [Display(Name = "PlanName")]
        [DataType(DataType.Text)]
        [Required]
        public string Plan_Name_En { get; set; }

        [Display(Name = "PlanPrice")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Plan_Price { get; set; }
        [Display(Name = "PlanDateTime")]
        [DataType(DataType.DateTime)]
       
        public System.DateTime Plan_DateTime { get; set; }
        [Display(Name = "PlanDescription")]
        [DataType(DataType.Text)]
        [Required]      
        [AllowHtml]
        public string Plan_Description_Ar { get; set; }

        [Display(Name = "PlanDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string Plan_Description_En { get; set; }
        [Display(Name = "PlanCategory")]
        [DataType(DataType.Text)]
        [Required]
        public string PlanCat_Id { get; set; }
        [Display(Name = "PlanPublisher")]
        [DataType(DataType.Text)]
        
        public string Id { get; set; }

        public string PlanStatus { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public virtual AspNetPlansCategory AspNetPlansCategory { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }


    }
    public class PlansCategoriesViewModel
    {


        [Display(Name = "PlansCategory")]
        [DataType(DataType.Text)]
        public string PlanCat_Id { get; set; }
        [Display(Name = "PlansCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string PlanCat_Name_Ar { get; set; }
        [Display(Name = "PlansCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string PlanCat_Name_En { get; set; }
        [Display(Name = "PlansCategoryDateTime")]
        [DataType(DataType.DateTime)]

        public System.DateTime PlanCat_DateTime { get; set; }
        [Display(Name = "PlansCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]

        public string PlanCat_Description_Ar { get; set; }
        [Display(Name = "PlansCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]
        public string PlanCat_Description_En { get; set; }
        [Display(Name = "PlansCategoryPublisher")]
        [DataType(DataType.Text)]
        public string Id { get; set; }
        public string PlansCategoriesStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetTestmonial> AspNetPlans { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
    
    public class ClientsViewModel
    {
        [Display(Name ="ClientId")]
        [DataType(DataType.Text)]
        public string Client_Id { get; set; }
        [Display(Name = "ClientFName")]
        [DataType(DataType.Text)]
        [Required]
        public string Client_Fname_Ar { get; set; }
        [Display(Name = "ClientFName")]
        [DataType(DataType.Text)]
        [Required]
        public string Client_Fname_En { get; set; }
        [Display(Name = "ClientLName")]
        [DataType(DataType.Text)]
        [Required]
        public string Client_Lname_Ar { get; set; }
        [Display(Name = "ClientLName")]
        [DataType(DataType.Text)]
        [Required]
        public string Client_Lname_En { get; set; }
        [Display(Name = "ClientEmail")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Client_Email { get; set; }
        [Display(Name = "ClientPhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Client_PhoneNumber { get; set; }
        [Display(Name = "CompanyName")]
        [DataType(DataType.Text)]
        [Required]
        public string Client_CompanyName_Ar { get; set; }
        [Display(Name = "CompanyName")]
        [DataType(DataType.Text)]
        [Required]
        public string Client_CompanyName_En { get; set; }
        [Display(Name = "ClientAddress")]
        [DataType(DataType.Text)]
        [Required]
        public string Client_Address_Ar { get; set; }
        [Display(Name = "ClientAddress")]
        [DataType(DataType.Text)]
        [Required]
        public string Client_Address_En { get; set; }
        [Display(Name = "ClientDateTime")]
        [DataType(DataType.DateTime)]
        
        public System.DateTime Client_DateTime { get; set; }
        [Display(Name = "ClientCategory")]
        [DataType(DataType.Text)]
        [Required]
        public string ClCat_Id { get; set; }
        [Display(Name = "ClientPublisher")]
        [DataType(DataType.Text)]
        public string Id { get; set; }

        [Display(Name = "ClientPhoto")]
        [DataType(DataType.Text)]
        public string Client_Photo { get; set; }


        public string ClientStatus { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        
        public virtual AspNetClientsCategory AspNetClientsCategory { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }

    }
    public class ClientsCategoriesViewModel
    {


        [Display(Name = "ClientsCategory")]
        [DataType(DataType.Text)]
        public string ClCat_Id { get; set; }
        [Display(Name = "ClientsCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string ClCat_Name_Ar { get; set; }
        [Display(Name = "ClientsCategoryName")]
        [DataType(DataType.Text)]
        [Required]
        public string ClCat_Name_En { get; set; }
        [Display(Name = "ClientsCategoryDateTime")]
        [DataType(DataType.DateTime)]

        public System.DateTime ClCat_DateTime { get; set; }
        [Display(Name = "ClientsCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
         [AllowHtml]
        public string ClCat_Description_Ar { get; set; }
        [Display(Name = "ClientsCategoryDescription")]
        [DataType(DataType.Text)]
        [Required]
        [AllowHtml]

        public string ClCat_Description_En { get; set; }
        [Display(Name = "ClientsCategoryPublisher")]
        [DataType(DataType.Text)]
        public string Id { get; set; }
        public string ClientsCategoriesStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetTestmonial> AspNetClients { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }

    public class ManagersViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Display(Name ="UserInfoId")]
        [DataType(DataType.Text)]
        public string UInfoPlus_Id { get; set; }
        [Display(Name = "UserInfoFirstName")]
        [DataType(DataType.Text)]
        [Required]
        public string UInfoPlus_Fname_En { get; set; }
        [Display(Name = "UserInfoLastName")]
        [DataType(DataType.Text)]
        [Required]
        public string UInfoPlus_Fname_Ar { get; set; }
        [Display(Name = "UserInfoLastName")]
        [DataType(DataType.Text)]
        [Required]
        public string UInfo_Lname_En { get; set; }
        [Display(Name = "UserInfoLastName")]
        [DataType(DataType.Text)]
        [Required]
        public string UInfo_Lname_Ar { get; set; }
        [Display(Name = "UserInfoPhoto")]
        [DataType(DataType.Text)]
      
        public string UInfo_Photo { get; set; }
        [Display(Name = "UserId")]
        [DataType(DataType.Text)]

        public string ManagersStatus { get; set; }

        public string Id { get; set; }


        [Display(Name = "UserInfoDateTime")]
        [DataType(DataType.DateTime)]

        public System.DateTime UInfoPlus_DateTime { get; set; }


        [Display(Name = "UserEmail")]
        [DataType(DataType.EmailAddress)]
       

        public bool EmailConfirmed { get; set; }

        [Display(Name = "UserPassword")]
        [DataType(DataType.Password)]

        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        [Display(Name = "UserPhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "UserPhoneNumberConfirmd")]
        [DataType(DataType.Text)]
        
        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }
        public System.Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        [Display(Name = "UserUserName")]
        [DataType(DataType.Text)]
    
        public string UserName { get; set; }

        public virtual ICollection<AspNetClient> AspNetClients { get; set; }

        public virtual ICollection<AspNetClientsCategory> AspNetClientsCategories { get; set; }

        public virtual ICollection<AspNetNew> AspNetNews { get; set; }

        public virtual ICollection<AspNetNewsCategory> AspNetNewsCategories { get; set; }

        public virtual ICollection<AspNetPlan> AspNetPlans { get; set; }

        public virtual ICollection<AspNetProject> AspNetProjects { get; set; }

        public virtual ICollection<AspNetProjectsCategory> AspNetProjectsCategories { get; set; }

        public virtual ICollection<AspNetTeam> AspNetTeams { get; set; }

        public virtual ICollection<AspNetTeamsCategory> AspNetTeamsCategories { get; set; }

        public virtual ICollection<AspNetTestmonial> AspNetTestmonials { get; set; }

        public virtual ICollection<AspNetTestmonialsCategory> AspNetTestmonialsCategories { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }

        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }

        public virtual ICollection<AspNetUsersInfoPlu> AspNetUsersInfoPlus { get; set; }

        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }

    public class ManagersShowViewModel
    {

        public AspNetUser Users { get; set; }
        public AspNetUsersInfoPlu UsersPlusInfo { get; set; }

        public string ManagerStatus { get; set; }


    }

    public class MessagesInboxViewModel
    {
        [Display(Name ="MessageId")]
        [DataType(DataType.Text)]
        public string Message_Id { get; set; }
        [Display(Name = "MessageEmail")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Message_Email { get; set; }

        [Display(Name = "MessageSubject")]
        [DataType(DataType.Text)]
        [Required]
        public string Message_Subject { get; set; }

        [AllowHtml]
        [Display(Name = "MessageContent")]
        [DataType(DataType.Text)]
        [Required]
        public string Message_Content { get; set; }

        public bool Message_Active { get; set; }
        public bool Message_Response { get; set; }
        public System.DateTime Message_DateTime { get; set; }



    }
}
