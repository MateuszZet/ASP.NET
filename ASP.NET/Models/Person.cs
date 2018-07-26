using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Models
{
    public class Person
    {
        [ScaffoldColumn(false)]
        [Key]
        public int id { get; set; }

        [Display(Name="Name: ")]
        [Required(ErrorMessage="Need to add name!")]
        [StringLength(10)]
        [RegularExpression("([a-zA-Z]+)")]
        public string name { get; set; }

        [Display(Name ="Surname: ")]
        [Required(ErrorMessage = "Need to add surname!")]
        [StringLength(15)]
        [RegularExpression("([a-zA-Z]+)")]
        public string surname { get; set; }

        [Display(Name = "Email: ")]
        [Required(ErrorMessage = "Need to add valid email!")]
        [EmailAddress]
        public string email { get; set; }

        [Display(Name = "Age: ")]
        [Required(ErrorMessage = "Need to add age (18-110)!")]
        [Range(18,110)]
        public int age { get; set; }
    }
}
