using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPracticeCheckProject.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
    }
}
