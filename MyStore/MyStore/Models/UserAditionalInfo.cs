using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyStore.Models
{
    [Table("tblUserAditional")]
    public class UserAditionalInfo
    {
        [Key]
        public string Id { get; set; }
        //[Required]
        public string FullName { get; set; }
        //[Required]
        public string Image { get; set; }
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}