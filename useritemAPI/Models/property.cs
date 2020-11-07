using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthAPI.Models
{
    public class property
    {
        [Key]
        public int idProperty { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }

}