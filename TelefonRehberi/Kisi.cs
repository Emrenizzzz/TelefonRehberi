using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    public class Kisi
    {
        public Kisi(string _isim,string _soyisim,string _numara)
        {
            this.Isim = _isim;
            this.Soyisim = _soyisim;
            this.Numara = _numara;
        }

        private string isim;

        public string Isim { get => isim; set => isim = value; }

        private string soyisim;
        public string Soyisim { get => soyisim; set => soyisim = value; }

        private string numara;
        public string Numara { get => numara; set => numara = value; }


    }
}
