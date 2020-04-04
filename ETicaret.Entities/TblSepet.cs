using System;
using System.Collections.Generic;
using System.Text;

namespace ETicaret.Entities
{
    public class TblSepet
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<TblSepetUrunleri> SepetUrunleri { get; set; }
    }
}
