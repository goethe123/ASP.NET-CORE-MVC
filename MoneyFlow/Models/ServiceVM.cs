using MoneyFlow.Entities;
using System.ComponentModel.DataAnnotations;

namespace MoneyFlow.Models
{
    public class ServiceVM
    {

        public int ServiceId { get; set; }
        public int UserId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Type { get; set; }

        

    }
}
