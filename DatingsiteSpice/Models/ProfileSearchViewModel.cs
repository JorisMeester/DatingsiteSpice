using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingsiteSpice.Models
{
    public class ProfileSearchViewModel
    {
        public GenderInterestEnum GenderPreference { get; set; }
       // public string AgeRange { get; set; }
        public int AgeMin { get; set; }
        //{
        //    get
        //    {
        //        return Convert.ToInt32(AgeRange.Split(',')[0]);
        //    }
        //}
        public int AgeMax { get; set; }
        //{
        //    get
        //    {
        //        return Convert.ToInt32(AgeRange.Split(',')[1]);
        //    }
        //}
        public int MyProperty { get; set; }
        public int HeightMin { get; set; }
        public int HeightMax { get; set; }
        public List<EthnicityEnum> EthnicityPreferences { get; set; }
        public List<EducationEnum> EducationPreferences { get; set; }
        public string City { get; set; }
        public int? Range { get; set; } // ? enables null value
    }
}