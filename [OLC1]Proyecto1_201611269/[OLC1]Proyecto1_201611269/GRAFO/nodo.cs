using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201611269.GRAFO
{
    class nodo
    {
        public string transicion;
        public int Num;
        public nodo primero, segundo;

        public nodo(string tr, int nu)
        {
            Num = nu;
            transicion = tr;
            primero = segundo = null;
        }


        
    }
}
