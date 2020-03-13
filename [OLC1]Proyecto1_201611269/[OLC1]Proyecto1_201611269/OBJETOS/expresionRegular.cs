using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201611269.OBJETOS
{
    class expresionRegular
    {
        public string nombre;
        public string contenido;
        public string contenido2;
        public Thompson miTh;

        public expresionRegular(string no, string con)
        {
            nombre = no;
            contenido = contenido2 = con;
        }
        public void agregarConjuntos(List<conjunto> listaCon){
        
            int index=-1;
            foreach(conjunto cn in listaCon){
            
                //RECORRER CADA CONJUNTO ENVIADO Y VERIFICAR SI HAY ALGUNA COINCIDENCIA
                    index = contenido.IndexOf(cn.nombre);
                    if (index!=-1)
                    {
                        string contendioCN=cn.dameContenido();
                        contenido=contenido.Replace("{"+cn.nombre+"}", contendioCN);
                    }
            }
            miTh = new Thompson(nombre, contenido);

        }
    }
}
