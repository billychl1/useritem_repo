using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthAPI.Models
{
    public class item
    {
        [Key]
        public int idItem { get; set; }
        public string name { get; set; }
        public string game { get; set; }
        public DateTime expirationDate { get; set; }
        public int quantity { get; set; }
        [ForeignKey("idItem")]
        public ICollection<property> propertys { get; set; }

    }

}