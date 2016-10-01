using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LexusMortgages.Models
{
    public class MortgageProcess
    {
        [Key]
        [Required, Display(Name = "Loan Amount(€)")]
        public double amount { get; set; }
        [Required, Display(Name = "Term in Years")]
        public int years { get; set; }
        [Required, Display(Name = "Interest Rate")]
        public double rate { get; set; }
        public double result { get; set; }
    }

}