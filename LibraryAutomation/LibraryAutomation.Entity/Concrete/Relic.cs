using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAutomation.Entity.Abstract;

namespace LibraryAutomation.Entity.Concrete
{
    public class Relic : IEntity
    {
        [Key]
        public int EmanetNo { get; set; }
        public int UyeNo { get; set; }
        public int KitapNo { get; set; }
        public DateTime EmanetVermeTarih { get; set; }
        public DateTime EmanetGeriAlmaTarih { get; set; }
        public DateTime EmanetIslemTarih { get; set; }
        public string EmanetNot { get; set; }
        public string EmanetTeslimEdildi { get; set; }
    }
}
