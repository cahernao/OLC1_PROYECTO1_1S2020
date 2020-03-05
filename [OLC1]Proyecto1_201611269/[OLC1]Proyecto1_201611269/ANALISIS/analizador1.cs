using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_Proyecto1_201611269.ANALISIS
{
    class analizador1
    {
        public List<token> miListaToken = new List<token>();
        public List<token> miListaError = new List<token>();



        public analizador1(string aa)
        {
            token mio = new token(aa, aa);
            miListaToken.Add(mio);
            mio = new token(aa, aa);
            miListaToken.Add(mio);


            miListaError.Add(mio);
            mio = new token("error", aa);
            miListaError.Add(mio);
            GeneraReporteTokens();
        }


        
        
        
        
        
        
        
        
        public void GeneraReporteTokens()
        {
            //VAMOS A CREAR UN ARCHIVO DE REPORTE DE TOKENS
            string contenido = string.Empty;
            string nombre = System.Reflection.Assembly.GetEntryAssembly().Location.ToString().Replace("[OLC1]Proyecto1_201611269.exe", "") + "TokenR.xml";
            try
            {
                if (File.Exists(nombre))
                {
                    File.Delete(nombre);
                }

                using (StreamWriter sw = File.CreateText(nombre))
                {
                    sw.WriteLine("<ListaTokens>");
                    sw.WriteLine("<Generado>Carlos Hernandez 201611269 " + DateTime.Now.ToString() + " </Generado>");
                    
                    //contenido += "<ListaTokens>\n";
                    foreach (token to in miListaToken)
                    {
                        sw.WriteLine("<Token>\n<Nombre>" + to.dameNombre() + "</Nombre>\n<Valor>" + to.dameContenido() + "</Valor>\n<Fila>" + to.fila + "</Fila>\n<Columna>" + to.columna + "</Columna>\n</Token>");
                    }
                    

                    sw.WriteLine("<TokenError>\n");

                    //AQUI VA EL CICLO DE ERRORES
                    foreach (token to in miListaError)
                    {
                        sw.WriteLine("<Token>\n<Nombre>" + to.dameNombre() + "</Nombre>\n<Valor>" + to.dameContenido() + "</Valor>\n<Fila>" + to.fila + "</Fila>\n<Columna>" + to.columna + "</Columna>\n</Token>");
                    }

                    sw.WriteLine("</TokenError>\n");

                    sw.WriteLine("</ListaTokens>\n\n\n");
                }

                System.Diagnostics.Process.Start("TokenR.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }
    }
}
