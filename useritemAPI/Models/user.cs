using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthAPI.Models
{
    public class user
    {
        [Key]
        public int idUser { get; set; }
        public string username { get; set; }
        [ForeignKey("idUser")]
        public ICollection<item> items { get; set; }
    }

}