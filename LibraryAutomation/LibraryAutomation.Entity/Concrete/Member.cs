using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.Entity.Abstract;

namespace LibraryAutomation.Entity.Concrete
{
    public class Member : IEntity
    {
        [Key]
        public int UyeNo { get; set; }
        public string UyeAd { get; set; }
        public string UyeSoyad { get; set; }
        public string UyeTelefon { get; set; }
        public string UyeEposta { get; set; }
        public string UyeAdres { get; set; }
    }
}
