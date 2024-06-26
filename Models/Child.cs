using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Infant.Models
{
    public class Child
    {
    }
    public class Login
    {
        [Display(Name = "Mail Address")]
        public string us { get; set; }
        [Display(Name = "Password")]
        public string psd { get; set; }
    }
    public class Parent
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Fathers Name"), Required]
        public string FN { get; set; }

        [Display(Name = "Mail Address"), Required]
        public string MA { get; set; }

        [Display(Name = "Mothers Name"), Required]
        public string MN { get; set; }

        [Display(Name = "Child Name"), Required]
        public string CN { get; set; }

        [Display(Name = "Child Date Of Birth"), Required]
        public string DOB { get; set; }

        [Display(Name = "Place  Of Birth"), Required]
        public string POB { get; set; }

        [Display(Name = "Gender"), Required]
        public string Gender { get; set; }

        [Display(Name = "UserName"), Required]
        public string us { get; set; }

        [Display(Name = "Password"), Required]
        public string psd { get; set; }

        [Display(Name = "Mobile"), Required]
        public Int64 Mob { get; set; }

        [Display(Name = "City"), Required]
        public string City { get; set; }

        public string status { get; set; }
    }
    public class AddVaccine
    {
        [Key]
        public int id { get; set; }

        [Required, Display(Name = "Vaccination Schedule Date")]
        public string VacDt { get; set; }

        [Required, Display(Name = "In Time")]
        public string IT { get; set; }

        [Required, Display(Name = "Out Time")]
        public string OT { get; set; }

        [Required, Display(Name = "Location")]
        public string Loc { get; set; }

        [Required, Display(Name = "Incharge")]
        public string Inc { get; set; }

        [Required, Display(Name = "Mobile Number")]
        public string Mob { get; set; }

        [Required, Display(Name = "Baby Age")]
        public string BA { get; set; }
    }
    public class Children
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Children Name"), Required]
        public string CN { get; set; }

        [Display(Name = "Fathers Name"), Required]
        public string FN { get; set; }

        [Display(Name = "Mail Address"), Required]
        public string MA { get; set; }

        [Display(Name = "Mothers Name"), Required]
        public string MN { get; set; }

        [Display(Name = "Gender"), Required]
        public string Gender { get; set; }

        [Display(Name = "Child Date Of Birth"), Required]
        public string DOB { get; set; }

        [Display(Name = "Age"), Required]
        public string Age { get; set; }

        public string Image { get; set; }
    }
    public class vaccinedetail
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Vaccination Date")]
        public string VD { get; set; }

        [Display(Name = "Children Name"), Required]
        public string CN { get; set; }

        [Display(Name = "Gender"), Required]
        public string Gender { get; set; }

        [Display(Name = "Age"), Required]
        public string Age { get; set; }

        [Display(Name = "Vaccine Name")]
        public string VN { get; set; }
    }
    public class RebookVac
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Children Name"), Required]
        public string CN { get; set; }

        [Display(Name = "Gender"), Required]
        public string Gender { get; set; }

        [Display(Name = "Age"), Required]
        public string Age { get; set; }

        [Display(Name = "Mail Address"), Required]
        public string MA { get; set; }

        [Display(Name = "Rebooking Vaccination Date")]
        public string VD { get; set; }

        [Required, Display(Name = "Location")]
        public string Loc { get; set; }

        [Required, Display(Name = "Mobile Number")]
        public string Mob { get; set; }

        [Display(Name = "Fathers Name"), Required]
        public string FN { get; set; }

        public string Status { get; set; }

    }
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Parent Name")]
        public string PN { get; set; }

        [Display(Name = "Mail Address")]
        public string Mail { get; set; }

        [Display(Name = "Mobile Number")]
        public string Mob { get; set; }

        [Display(Name = "Feed Back")]
        public string FB { get; set; }
    }
    public enum Gender
    {
        Male, Female, Transgender
    }
    public class Vaccination : DbContext
    {
        public DbSet<Parent> Parents { get; set; }
        public DbSet<AddVaccine> AddVaccines { get; set; }
        public DbSet<Children> Childrens { get; set; }
        public DbSet<vaccinedetail> vaccinedetails { get; set; }
        public DbSet<RebookVac> RebookVacs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}