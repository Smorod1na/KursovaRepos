using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyStore.Entity
{
    [Table("News")]
    public class News
    {
        [Key]
        public string Id { get; set; }
        public string ManagerId { get; set; }
        [Required(ErrorMessage = "No pfoto")]
        public string  Pfoto { get; set; }
        [Required(ErrorMessage = "No name")]
        public string Name { get; set; }
        public DateTime PostDate { get; set; }
        [Required(ErrorMessage = "No name")]

        public string Description { get; set; }

        //[ForeignKey("NewsCategory")]
        //public string CategoriesId { get; set; }
        public string Categories { get; set; }
        public virtual Category NewsCategory { get; set; }

        public virtual ICollection<Comments> NewsComments { get; set; }
        public News()
        {

        }
    }
}