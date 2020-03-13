using _OLC1_Proyecto1_201611269.GRAFO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_Proyecto1_201611269.OBJETOS
{
    class Thompson
    {
        string nombre;
        string cadenaPrincipal;
        public Stack<dobleString> conc;
        public Stack<dobleString> obj;
        public grafo miG;

        public Thompson(string no, string cad)
        {
            nombre = no;
            cadenaPrincipal = cad;
            conc = new Stack<dobleString>();
            obj = new Stack<dobleString>();
            miG = new grafo();
            agregarPilas(cadenaPrincipal);
            
        }


        private void agregarPilas(string cadena)
        {
            //VAMOS A AGRE
            try
            {
                int estado = 0;
                string cadenaTemporal = "";
                char actual, siguiente;
                for (int i = 0; i < cadena.Length; i++)
                {
                    actual = cadena[i];
                    if (i < cadena.Length-1) siguiente = cadena[i + 1];
                    else siguiente = (char)57;
                    switch (estado)
                    {
                        case 0:
                            switch (actual)
                            {
                                // ESTAMSO EN EL CASO 0 DONDE ESPERAMOS DE PRIMERA INSTANCIA UN SIGNO DE CONCATENACION
                                case '.':
                                    conc.Push(new dobleString("CONCATENACION", "."));
                                    miG.agregarBasico(new nodo(cadenaTemporal, i));
                                    break;
                                case '*':
                                    conc.Push(new dobleString("ASTER", "*"));
                                    miG.agregarBasico(new nodo(cadenaTemporal, i));
                                    break;
                                case '|':
                                    conc.Push(new dobleString("OR", "|"));
                                    miG.agregarBasico(new nodo(cadenaTemporal, i));
                                    break;
                                case '?':
                                    conc.Push(new dobleString("SIGNOPRE", "?"));
                                    miG.agregarBasico(new nodo(cadenaTemporal, i));
                                    break;
                                case '+':
                                    conc.Push(new dobleString("MAS", "+"));
                                    miG.agregarBasico(new nodo(cadenaTemporal, i));
                                    break;
                                //IGNORAMOS EL CASO DEL ESPACIO
                                case (char)32:
                                    break;
                                default:
                                    //SI NO ES NINGUNO DE LOS SIGNOS, QUIERE DECIR QUE ES UN CONTENIDO DE OTRA COSA
                                    //NOS VAMOS AL ESTADO 0
                                    cadenaTemporal += actual;
                                    estado = 1;
                                    break;

                            }//switch actual
                            break;


                        case 1:
                            if (actual == ']' || actual == '}' || actual=='"')
                            {
                                miG.agregarBasico(new nodo(cadenaTemporal, i));
                                obj.Push(new dobleString("OBJETO", cadenaTemporal.Replace("\"", "")));
                                cadenaTemporal = "";
                                estado = 0;
                            }
                            else cadenaTemporal += actual;
                            break;


                        default:
                            //POSIBLES ERRORES
                            break;

                    }//swithc estado
                }

            }
            catch (Exception e)
            {

                MessageBox.Show("Thompson error "+e.Message);
            }
        }//agregarPilas



        public string dameResultadoPilas()
        {
            string cn = "RESULTADO DE: " + nombre+System.Environment.NewLine;
            cn += "--------------------CONC--------------------" + System.Environment.NewLine;
            foreach (dobleString ds in conc)
            {
                cn += ds.nombre + System.Environment.NewLine;
            }
            cn += "---------------------OBJT---------------------" + System.Environment.NewLine;
            foreach (dobleString ds in obj)
            {
                cn += ds.nombre+"       "+ds.contenido+ System.Environment.NewLine;
            }
            cn += System.Environment.NewLine +System.Environment.NewLine +System.Environment.NewLine;
            
            //TEMP




            miG.generaGrafo(nombre);






            //TEMP
            return cn;
        }



        //METODO PARA SABER SI TIENE CONCATENACION
        private bool tieneConcatenacion(char c)
        {
            return (c == '.' || c == '*' || c == '|' || c == '?' || c == '+');
        }
        private bool esLetra(char c)
        {
            return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        }
    }





    class dobleString{
        public string nombre;
        public string contenido;
        public dobleString(string no, string con)
        {
            nombre = no;
            contenido = con;
        }

        //NOMENCLATURA
        // . CONCATENACION
        // * ASTER
        // | OR
        // ? SIGNOPRE
        // + MAS
    }
}
