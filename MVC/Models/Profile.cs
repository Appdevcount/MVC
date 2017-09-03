using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Profile
    {
        //Adding Dat annotations for the purpose of Server side Form validations --- not for EF Model-Entity Mappings
        public int ProfileId { get; set; }
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string InterestedDomainsBox { get; set; }
        [Required]
        public  string Skillsets { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public virtual ICollection<NewsTopics> NewsTopics { get; set; }
        public string Region { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string DocFile { get; set; }
        public string ImgFile { get; set; }
        [Required]
        public string RadioEditorBox { get; set; }
        [Required]
        public string CheckEditorBox { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime DateTime { get; set; }

    }
    public enum Gender { Male=1,Female=2}
    public class NewsTopics
    {
        public int Id { get; set; }
        public string NewsTopic { get; set; }

        public Profile Profile { get; set; }
    }

    public class AjaxModalContext:DbContext
    {
        public AjaxModalContext():base("name=MVC")
        {

        }
        public DbSet<Profile> Profile { get; set; }
    }

    
}