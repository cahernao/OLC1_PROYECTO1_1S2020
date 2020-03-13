using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_Proyecto1_201611269.GRAFO
{
    class grafo
    {
        nodo inicial, final;
        int contador;

        public grafo()
        {
            contador=0;
            inicial = final =null;
        }

        public void agregarBasico(nodo n)
        {
            n.Num = contador;
            if (estaVacio()) {
                inicial = final = n;

            }
            else
            {
                final.primero = n;
                n.segundo = final;
                final = n;
            }
            contador++;

        }

        private bool estaVacio()
        {
            return (contador == 0);
        }


        public void generaGrafo(string nombre)
        {
            
            string exeFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string replacement = Regex.Replace(nombre, @"\t|\n|\r", "");
            string bodyGraph = "";
            System.IO.StreamWriter file = new System.IO.StreamWriter(exeFolder + "\\" + replacement + ".dot");
            try
            {
                
                int cont = 0;
                bodyGraph += "digraph G{\n"
                    + "rankdir=LR\n"
                    + "node[shape=box];\n";
                cont = contador;
                nodo n = inicial;
                while (cont != 0)
                {
                    cont--;
                    if (cont == 0) bodyGraph += "\" " + n.Num + " \";\n\n";
                    else bodyGraph += "\" " + n.Num + " \" ->";
                    n = n.primero;
                }
                bodyGraph += "\n\n}\n\n";
                
                
                file.WriteLine(bodyGraph);
                file.Close();

                ProcessStartInfo startInfo = new ProcessStartInfo("dot.exe");
                startInfo.Arguments = "-Tpng " + replacement + ".dot -o " + replacement + ".png";
                Process.Start(startInfo);

            }
            catch (Exception e)
            {
                MessageBox.Show("Error grafo: " + e.Message);
                file.Close();
                //throw;
            }
        }
    }
}
