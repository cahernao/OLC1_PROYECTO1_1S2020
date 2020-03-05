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



        /*public analizador1(string aa)
        {
            token mio = new token(aa, aa);
            miListaToken.Add(mio);
            mio = new token(aa, aa);
            miListaToken.Add(mio);


            miListaError.Add(mio);
            mio = new token("error", aa);
            miListaError.Add(mio);
            GeneraReporteTokens();
        }*/


        




        public void analizame(string contenido)
        {
            int fila = 0, columna = 0, EstadoPrincipal=0, EstadoComentarios=0, EstadoTemporalPrincial=0;
            char actual, siguiente, anterior;
            for (int i = 0; i < contenido.Length; i++)
            {
                Console.WriteLine("Princiapl: " + EstadoPrincipal + " Tempo: " + EstadoTemporalPrincial+ "  Y el char es: "+contenido[i]);
                if (contenido[i] == '\n') 
                { 
                    fila++; 
                    columna = 0;
                    //SI ESTAMOS EN ELE ESTAOD DE COMENTARIOS, PODREMOS RETORNAR AL ESTADO EN EL QUE ESTABAMOS
                    if (EstadoPrincipal == 4) { 
                        EstadoPrincipal = EstadoTemporalPrincial;
                        EstadoTemporalPrincial = 0;
                    }

                }
                else
                {
                    //AQUI VA EL PRIMER ANALISIS
                    //MANEJAREMOS UNA MAQUINA DE ESTADOS QUE PODEMOS IR DE UNO A OTRO CREANDO TOKENS
                    //AQUI ABAAJO DEBE DEFINIRSE EL TIPO DE TOKENS

                    //DE PRIMERA MANO IGNORAMOS EL ENTER PARA EVITAR PROBLEMAS
                    //SOLO LO USAREMOS PARA EL ESTADOCOMENTARIO TIPO 1

                    //VAMOS A EMPEZAR CON LOS ESTADOS DE COMENTARIOS Y LOS VAMOS A IGNORAR

                    columna = i;
                    if (i - 1 >= 0 && i + 1 < contenido.Length)
                    {
                        anterior = contenido[i - 1];
                        actual = contenido[i];
                        siguiente = contenido[i + 1];
                    }
                    else
                    {
                        actual = contenido[i];
                        siguiente = anterior = (char)32;
                    }

                    switch (EstadoPrincipal)
                    {
                        //AQUI VAMOS A DESGLOSAR LOS QUE SON LOS TIPOS DE GRUPOS DE CARACTERES A ANALIZAR, EN NUESTRO CASO SERAN 4
                        //ESTADO DE CONJUNTOS
                        //ESTADO DE PATRONES
                        //ESTADO DE LEXEMAS
                        //ESTADO DE COMENTARIOS UNA LINEA
                        //ESTADO DE COMENTARIOS DOS LINEAS


                        //CASO CONJUNTOS
                        case 0:
                            //AQUI ESPERAMOS 2 COSAS
                            //LA DECLARACION DE CONJUNTOS Y/O COMENTARIOS
                            //DEBEMOS HACER LA MANERA DE INTENTAR RECUPERARNOS DE ESOS ERRORES
                            
                            
                            
                            
                            if (estadoComentario(actual, siguiente)==4)
                            {
                                //EN ESTA CONDICION VERIFICAREMOS EL ESTADO DE SI ENTRAMOS A COMENTARIOS
                                //DE SER ASI CAMBIAREMOS EL ESTADO PRINCIPAL AL NORMAL
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 4;
                            }
                            else if (estadoComentario(actual, siguiente) == 5)
                            {
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 5;
                            }
                            else
                            {
                                //AQUI DEBEMOS BUSCAR CONJUNTOS
                                if(actual=='#')EstadoPrincipal=1;

                            }

                            break;

                        
                        //CASO PATRONES
                        case 1:
                            if (estadoComentario(actual, siguiente) == 4)
                            {
                                //EN ESTA CONDICION VERIFICAREMOS EL ESTADO DE SI ENTRAMOS A COMENTARIOS
                                //DE SER ASI CAMBIAREMOS EL ESTADO PRINCIPAL AL NORMAL
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 4;
                            }
                            else if (estadoComentario(actual, siguiente) == 5)
                            {
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 5;
                            }
                            else
                            {
                                //AQUI DEBEMOS BUSCAR PATRONES
                                if (actual == '(') EstadoPrincipal = 2;

                            }
                            break;






                        //LEXEMAS
                        case 2:
                            if (estadoComentario(actual, siguiente) == 4)
                            {
                                //EN ESTA CONDICION VERIFICAREMOS EL ESTADO DE SI ENTRAMOS A COMENTARIOS
                                //DE SER ASI CAMBIAREMOS EL ESTADO PRINCIPAL AL NORMAL
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 4;
                            }
                            else if (estadoComentario(actual, siguiente) == 5)
                            {
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 5;
                            }
                            else
                            {
                                //AQUI DEBEMOS BUSCAR LEXEMAS

                            }

                            break;
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        //CASO COMENTARIOS MULTILINEA
                        case 5:
                            //DEBIDO A LA CONDICION INICIAL, DONDE IGNORAMOS EL ENTER, YA CUANDO ESTE SE RECONOCE
                            //CAMBIAMOS AL ESTADO EN EL QUE ESTABA

                            //Console.WriteLine("Toy caso 5 " + actual);
                            if (anterior == '!' && actual == '>')
                            {
                                EstadoPrincipal = EstadoTemporalPrincial;
                                EstadoTemporalPrincial = 0;
                            }
                            break;




                        default:
                            break;
                    }

                }


                
            }
        }




        private int estadoComentario(char actual, char siguiente)
        {

            //VAMOS A INTENTAR DEFINIR NUESTRO METODO
            //POR AHORA NECESITAMOS 3 ESTADOS
            /*
             
             4 DONDE ENTRAMOS CON DOS BARRAS 
             5 CUANDO ESTAMOS CON AMBAS LINEAS
             0 CUANDO NO SEA NINGUNO
             * 
             */
            if (actual == '/' && siguiente == '/') return 4;
            else if (actual == '<' && siguiente == '!') return 5;
            else return 0;
        }



        private bool EntroEnComentario(char actual, char siguiente)
        {
            if ((actual == '/' && siguiente == '/') || (actual == '<' && siguiente == '!')) return true;
            else return false;
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
