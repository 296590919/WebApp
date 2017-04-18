using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DTO
{
    public class MenuItemDTO
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
    }
    public class MenuDTO
    {
        public int projectID { get; set; }
        public string projectName { get; set; }
        public List<MenuItemDTO> categoryList { get; set; }
    }
}
