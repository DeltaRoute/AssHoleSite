using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssHoleSite.Models
{
    public class CategoryC
    {
        public int Id { get; set; }//Id категории/подкатегории
        public string Name { get; set; }//Название категории/подкатегории
        public CategoryC Parent { get; set; }//Id родительской категории/подкатегории
    }
}
