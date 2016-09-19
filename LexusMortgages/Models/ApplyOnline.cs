using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LexusMortgages.Models
{
    public class ApplyOnline
    {
        [Key]
        [Required, Display(Name = "Firstname")]
        public string fname { get; set; }
        [Required, Display(Name = "Surname")]
        public string sname { get; set; }
        [Required, Display(Name = "Location")]
        public string address { get; set; }
        [Required, Display(Name = "Telephone")]
        public int telephone { get; set; }
        [Required, Display(Name = "Email")]
        public string email { get; set; }        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required, Display(Name = "DOB")]
        public DateTime dob { get; set; }
        [Display(Name = "Martial")]
        public string martial { get; set; }
        [Required, Display(Name = "Occupation")]
        public string occupation { get; set; }
        [Required, Display(Name = "Employer")]
        public string employer { get; set; }
        [Required, Display(Name = "Net Monthly Income")]
        public int netMonthlyIncome { get; set; }
        [Required, Display(Name = "Other Income")]
        public int otherIncome { get; set; }
        [Display(Name = "Mortgage Type")]
        public string mortgageType { get; set; }
        [Display(Name = "Property Type")]
        public string propertyType { get; set; }
        [Display(Name = "Mortgage Term")]
        public string mortgageTerm { get; set; }
        [Required, Display(Name = "Purchase Price")]
        public int purchasePrice { get; set; }
        [Required, Display(Name = "Amount Required")]
        public int amountReq { get; set; }
    }
}