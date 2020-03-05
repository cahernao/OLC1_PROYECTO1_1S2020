using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201611269.ANALISIS
{

    class token
    {

        string nombre;
        string contenido;
        public int fila, columna;

        public token(string Nombre, string cont, int F, int Co){
            this.nombre=Nombre;
            this.contenido=cont;
            this.fila = F;
            this.columna = Co;
        }

        public token(string Nom, string Cont)
        {
            this.nombre = Nom;
            this.contenido = Cont;
            fila = columna = 0;
        }

        public token()
        {
            fila = columna = 0;
        }

        public void setNombre(string n)
        {
            this.nombre = n;
        }
        public void setContenido(string n)
        {
            this.contenido = n;
        }

        public string dameNombre()
        {
            return this.nombre;
        }
        public string dameContenido()
        {
            return this.contenido;
        }


    }
}
