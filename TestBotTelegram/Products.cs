using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBotTelegram
{
   public class Products
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,MaxLength(50)]
        public string ProductName { get; set; }

        [Required,MaxLength(10)]
        public string Price { get; set; }

    }
}
