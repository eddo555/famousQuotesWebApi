using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamousQuotesApi.Models
{
    public class SubMenu
    {
        public int SubMenuId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Quote { get; set; }
        public int Menu_MenuId { get; set; }
    }
}