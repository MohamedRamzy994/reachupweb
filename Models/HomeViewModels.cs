using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppletSoftware.Models
{
    public class HomeViewModels
    {



    }

    public class NewsLettersViewModel
    {

        [Display(Name = "LetterId")]
        [DataType(DataType.Text)]
        public string Letter_Id { get; set; }
        [Display(Name = "LetterEmail")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Letter_Email { get; set; }

        [Display(Name = "LetterActive")]
        [DataType(DataType.Custom)]

        public bool Letter_Active { get; set; }

        [Display(Name = "LetterResponse")]
        [DataType(DataType.Custom)]

        public bool Letter_Response { get; set; }


        [Display(Name = "LetterDateTime")]
        [DataType(DataType.DateTime)]

        public System.DateTime Letter_DateTime { get; set; }

    }
    public class ContactusViewModel
    {

        public string Message_Id { get; set; }
        public string Message_Email { get; set; }
        public string Message_Subject { get; set; }
        public string Message_Content { get; set; }
        public bool Message_Active { get; set; }
        public bool Message_Response { get; set; }
        public System.DateTime Message_DateTime { get; set; }


    }

    public class PlanOrderViewModel
    {
        public string Order_Id { get; set; }

        [Display(Name ="Email")]
        [Required]
        [DataType(DataType.Text)]
        public string Order_Email { get; set; }


        [Display(Name = "Phone")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Order_Phone { get; set; }



        [Display(Name = "Plan")]
        [Required]
        [DataType(DataType.Text)]
        public string Order_Plan { get; set; }



        [Display(Name = "Message")]
        [DataType(DataType.Text)]
        public string Order_Message { get; set; }



        [Display(Name = "First Name")]
        [Required]
        [DataType(DataType.Text)]
        public string Order_Fname { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [DataType(DataType.Text)]
        public string Order_Lname { get; set; }

        [Display(Name = "Response")]
      
        public bool Order_Response { get; set; }

        public System.DateTime Order_DateTime { get; set; }

    }



}