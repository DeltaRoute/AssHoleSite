using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssHoleSite.Models
{
    public class PhoneC
    {
        public int Id { get; set; }//Id элемента в бд
        public string Name { get; set; }//название элемента
        public string Company { get; set; }//компания-производитель
        public int Price { get; set; }//цена элемента
        public CategoryC Parent { get; set; }//Id категории/подкатегории, в которой наодится элемент
    }
}
