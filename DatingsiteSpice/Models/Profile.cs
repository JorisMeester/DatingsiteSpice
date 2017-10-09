using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingsiteSpice.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public ApplicationUser User { get; set; }
        public string Nickname { get; set; }
        public GenderEnum Gender { get; set; }
        public PreferenceEnum Preference { get; set; }
        public DateTime Birthdate { get; set; }
        public double Length { get; set; }
        public EtnicityEnum Etnicity { get; set; }
        public string City { get; set; }
        public EducationLevelEnum EducationLevel { get; set; }
        public Interest Interests { get; set; }
        public Picture Image { get; set; }
        public string PhotoAlbum { get; set; }
    }

    public enum GenderEnum
    {
        Man,
        Vrouw,
        Overige,
        Onbekend
    }

    public enum PreferenceEnum
    {
        Mannen,
        Vrouwen,
        Beide,
        Overig
    }

    public enum EtnicityEnum
    {
        Aziatisch,
    }

    public enum EducationLevelEnum
    {
        MBO,
        HBO,
        Universiteit
    }
}