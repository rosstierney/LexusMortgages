﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LexusMortgages.Models
{
    public class Contact
    {
        [Key]
        [Required, Display(Name = "Full Name")]
        public string fullname { get; set; }
        [Required, Display(Name = "Email")]
        public string email { get; set; }
        [Required, Display(Name = "City")]
        public string city { get; set; }
        [Required, Display(Name = "Telephone")]
        public int telephone { get; set; }
        [Required, Display(Name = "Enquiry")]
        public string enquiry { get; set; }
    }
}