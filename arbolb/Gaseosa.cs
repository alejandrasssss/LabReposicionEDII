using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETD2LAB1
{
    public class Gaseosa: IComparable
    {
        public string Nombre { get; set; }

        public string Sabor { get; set; }

        public string Volumen { get; set; }

        public string Precio { get; set; }
        public string CasaProductora { get; set; }


        public int CompareTo(object obj)
        {
            var temp = obj as Gaseosa;

            if (String.Compare(this.Nombre, temp.Nombre) == 0)
            {
                return 0;
            }
            else if (String.Compare(this.Nombre, temp.Nombre) == 1)
            {
                return 1;
            }
            else if (string.Compare(this.Nombre, temp.Nombre) == -1)
            {
                return -1;
            }
            return 2;

        }
    }
}

