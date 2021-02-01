using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousQuotesApi.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public ICollection<SubMenu> submenus { get; set; }
    }
}