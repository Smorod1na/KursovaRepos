using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyStore.Entity
{
    [Table("Comments")]
    public class Comments
    {
        public Comments()
        {

        }
        [Key]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Not text")]
        public string Text { get; set; }
        [ForeignKey("News")]
        public string NewsId { get; set; }
        public virtual News News { get; set; }
    }
}