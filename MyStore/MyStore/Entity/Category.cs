using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyStore.Entity
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Not text")]
        public string Name { get; set; }
        public  ICollection<News> CategoryNews { get; set; }
        public Category()
        {
        }
    }
}