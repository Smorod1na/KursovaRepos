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
        public int Id { get; set; }
        public string ManagerId { get; set; }
        [Required(ErrorMessage = "No pfoto")]
        public string  Pfoto { get; set; }
        [Required(ErrorMessage = "No name")]
        public string Name { get; set; }
        public DateTime PostDate { get; set; }
        [Required(ErrorMessage = "No name")]

        public string Description { get; set; }

        public string Categorie { get; set; }
        public virtual Category NewsCategory { get; set; }
    }
}