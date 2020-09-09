using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyStore.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="No text input for role")]
        public string Name { get; set; }
    }
}