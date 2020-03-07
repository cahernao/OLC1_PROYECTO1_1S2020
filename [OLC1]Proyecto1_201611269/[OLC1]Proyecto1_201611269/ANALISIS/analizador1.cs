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
        private token miToken;


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
            //OJO CUIDADO
            limpia();
            //OJO CUIDADO
            int fila = 0, columna = 0, EstadoPrincipal=0, EstadoComentarios=0, EstadoTemporalPrincial=0, estadoConjuntos=0, estadoPatron=0, estadoLex=0;
            char actual, siguiente, anterior;
            string cadenaTemporal1 = string.Empty, nombreCONJ="", contCONJ="";
            for (int i = 0; i < contenido.Length; i++)
            {
                //Console.WriteLine("Princiapl: " + EstadoPrincipal + " Tempo: " + EstadoTemporalPrincial+" CONJ: "+estadoConjuntos+ "  Y el char es: "+contenido[i]);
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




                            if (estadoComentario(actual, siguiente) == 4 || estadoComentario(anterior, actual) == 4)
                            {
                                //EN ESTA CONDICION VERIFICAREMOS EL ESTADO DE SI ENTRAMOS A COMENTARIOS
                                //DE SER ASI CAMBIAREMOS EL ESTADO PRINCIPAL AL NORMAL
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 4;
                            }
                            else if (estadoComentario(actual, siguiente) == 5 || estadoComentario(anterior, actual) == 5)
                            {
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 5;
                            }
                            else
                            {
                                cadenaTemporal1 += actual;
                                //AQUI DEBEMOS BUSCAR CONJUNTOS
                                switch (estadoConjuntos)
                                {
                                        //CADENATEMPORAL1 debe ser igual al caracter

                                    case 0:
                                        //CASO UNO DONDE ESPERAMOS 2 ESTADOS DE SALIDA
                                        //1 DONDE ESTEN LOS 2 PUNTOS Y LUEGO VAMOS A CREAR UN TOKEN RESERVADA Y SEGUIMOS EN ESTADO CONJUNTOS
                                        //2 DONDE RECONOCEMOS OTRO TOKEN DONDE ES -> Y QUIERE DECIR QUE VAMOS AL ESTADO PATRON
                                        if (actual == ':')
                                        {
                                            if (cadenaTemporal1.Contains("CONJ"))
                                            {
                                                estadoConjuntos++;
                                                //TOOOKEN
                                                miListaToken.Add(new token("RESERVADA", "CONJ", fila, columna-4));
                                                miToken = new token("PUNTOS", ":", fila, columna);
                                                miListaToken.Add(miToken);
                                                cadenaTemporal1 = "";
                                                
                                            }
                                            else estadoConjuntos = -1;
                                        }
                                        else if (actual == '-' && siguiente == '>')
                                        {
                                            //TOOOKEN
                                            EstadoPrincipal++;
                                            miListaToken.Add(new token("ID_PATRON", quitaTodo(cadenaTemporal1), fila, columna - 1));
                                            cadenaTemporal1 = string.Empty;
                                            //ESTADO ESPECIAL PARA IR AL NUEVO ESTADO
                                            estadoConjuntos = 10;
                                        }
                                        
                                        break;


                                    case 1:
                                        //SI ESTAMOS AQUI QUIERE DECIR QUE VAMOS A RECONOCER EL ID DE CONJ
                                        if (anterior == '-' && actual == '>')
                                        {
                                            estadoConjuntos++;
                                            //TOOOKEN
                                            miToken = new token("ID_CONJ", nombreCONJ.Replace("-", ""), fila, columna);
                                            miListaToken.Add(miToken);
                                            nombreCONJ = "";

                                        }
                                        else nombreCONJ += actual;
                                        break;

                                    case 2:
                                        //AQUI VAMOS A RECONCER EL CONTENIDO DEL CONJ
                                        if (actual == ';')
                                        {
                                            //TOOOKEN
                                            miToken = new token("CONTENIDO_CONJ",contCONJ.Replace(" ", ""), fila, columna);
                                            miListaToken.Add(miToken);
                                            contCONJ = "";
                                            estadoConjuntos = 0;
                                            cadenaTemporal1 = "";

                                            //AQUI ESTAMOS EN EL ESTADO FINAL BUSCANDO 
                                        }
                                        else { contCONJ += actual; }
                                        break;
                                    default:
                                        //AQUI DEBEMOS ENCONTRAR ALGUN ERROR;
                                        //DIGAMOS QUE OBTENEMOS UN -1
                                        //HAREMOS QUE ENTREMOS A ESTE ESTADO Y LA VARIABLE CADENATEMPORAL1 SERA ALMACENADA COMO UN ERROR
                                        //Y VOLVEREMOS A EL SIGUIENTE ESTADO, TAMBI[EN GUARDAREMOS EL TOKEN COMO ERROR
                                        EstadoPrincipal++;
                                        token miError = new token("Error", cadenaTemporal1, fila, columna);
                                        miListaError.Add(miError);
                                        cadenaTemporal1 = string.Empty;
                                        estadoConjuntos=0;
                                        break;

                                }//switch conjuntos

                            }//else case 0

                            break;//BREAK CASE0 CONJUNTO

                        



                        //CASO PATRONES
                        case 1:
                            if (estadoComentario(actual, siguiente) == 4 || estadoComentario(anterior, actual) == 4)
                            {
                                //EN ESTA CONDICION VERIFICAREMOS EL ESTADO DE SI ENTRAMOS A COMENTARIOS
                                //DE SER ASI CAMBIAREMOS EL ESTADO PRINCIPAL AL NORMAL
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 4;
                            }
                            else if (estadoComentario(actual, siguiente) == 5 || estadoComentario(anterior, actual) == 5)
                            {
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 5;
                            }
                            else
                            {
                                cadenaTemporal1+=actual;

                                switch(estadoPatron){
                                    case 0:
                                        //DEBERIAMOS ENTRAR A ESTE ESTADO PRINCIPALEMNTE
                                        //YA QUE LO LLAMAMOS CUANDO VENIMOS DE CONJUNTOS
                                        // Y LA PALABRA RESERVADA NO ES LA CORRECTA Y LOS TOQUENS SON IGUALES
                                        if (anterior == '-' && actual == '>' && estadoConjuntos == 10)
                                        {
                                            cadenaTemporal1 = "";
                                            estadoPatron++;
                                            //VOLVEMOS ESTADO CONJUNTOS A SU ESTADO NORMAL
                                            estadoConjuntos = 0;
                                        }
                                        else if(anterior=='-' && actual=='>' ){
                                            //TOOOKEN
                                            miListaToken.Add(new token("ID_PATRON",quitaTodo(cadenaTemporal1), fila, columna));
                                            cadenaTemporal1="";
                                            estadoPatron++;
                                        }else if(actual==':'){
                                            //TOOOKEN
                                            miListaToken.Add(new token("ID_LEXEMA",quitaTodo(cadenaTemporal1), fila, columna));
                                            cadenaTemporal1="";
                                            EstadoPrincipal++;
                                            estadoPatron=10;
                                            //ESTADO ESPECIAL
                                            
                                        }
                                        break;

                                    case 1:
                                        //SI LLEGAMOS A ESTE CASO QUIERE DECIR QUE DEBEMOS ALMACENAR TODO EL CONTENIDO EN ESTA INFORMACION Y LUEGO ESPERAR 
                                        //UN PUNTO Y COMA
                                        if(actual==';'){
                                            //TOOOKEN
                                            miListaToken.Add(new token("CONTENIDO_PATRON",quitatodoDos(cadenaTemporal1), fila, columna));
                                            cadenaTemporal1="";
                                            estadoPatron=0;
                                        }
                                        break;
                                    default:
                                        //TOOOKEN
                                            miListaToken.Add(new token("ERROR_PATRON",cadenaTemporal1, fila, columna));
                                            cadenaTemporal1="";
                                            EstadoPrincipal++;

                                        break;
                                }//switch patrones
                                //AQUI DEBEMOS BUSCAR PATRONES
                                //if (actual == '(') EstadoPrincipal = 2;
                                //DEBEMOS CONSIDERAR EL TOKEN ANTERIOR
                                //PUESTO QUE EL ACTUAL DEL CASO ANTERIOR, ES UN ERROR, PARA ESE, PERO NO PARA ESTE CASO
                                //EN FIN USAR EL CHAR ANTERIOR

                            }
                            break;






                        //LEXEMAS
                        case 2:
                            if (estadoComentario(actual, siguiente) == 4 || estadoComentario(anterior, actual) == 4)
                            {
                                //EN ESTA CONDICION VERIFICAREMOS EL ESTADO DE SI ENTRAMOS A COMENTARIOS
                                //DE SER ASI CAMBIAREMOS EL ESTADO PRINCIPAL AL NORMAL
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 4;
                            }
                            else if (estadoComentario(actual, siguiente) == 5 || estadoComentario(anterior, actual) == 5)
                            {
                                EstadoTemporalPrincial = EstadoPrincipal;
                                EstadoPrincipal = 5;
                            }
                            else
                            {
                                //AQUI DEBEMOS BUSCAR LEXEMAS
                                cadenaTemporal1+=actual;
                                switch(estadoLex){
                                    case 0:
                                        if( (actual=='"' || actual==':') && estadoPatron==10){
                                            estadoPatron=0;
                                            cadenaTemporal1="";
                                            estadoLex++;
                                        }
                                        else if(actual=='"' || actual==':'){
                                            //TOOOKEN
                                            miListaToken.Add(new token("ID_LEXEMA",quitaTodo(cadenaTemporal1), fila, columna));
                                            cadenaTemporal1="";
                                            estadoLex++;
                                        }
                                        break;


                                    case 1:
                                        if(actual==';'){
                                            //TOOOKEN
                                            miListaToken.Add(new token("CONT_LEXEMA",quitatodoDos(cadenaTemporal1), fila, columna));
                                            cadenaTemporal1="";
                                            estadoLex=0;
                                        }
                                        break;

                                    default:
                                        break;
                                }//switch lexema



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


                
            }//for contenido
            MessageBox.Show("analizadoo");
        }


        private string dameCorrecto(string cadena)
        {
            string cad = cadena;
            
            if (cadena.Contains("&")) cad = cadena.Replace("&", "&amp;");
            if (cadena.Contains(">")) cad = cadena.Replace(">", "&gt;");
            if (cadena.Contains("\"")) cad = cadena.Replace("\"", "&quot;");
            if (cadena.Contains("'")) cad = cadena.Replace("'", "&apos;");
            if (cadena.Contains("<")) cad = cadena.Replace("<", "&lt;");
            return cad;
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


        private void limpia()
        {
            miListaToken.Clear();
            miListaError.Clear();
        }


        private string quitaTodo(string cadena)
        {
            string cad = cadena;
            /*if(cadena.Contains(" "))cad = cadena.Replace(" ", "");
            if(cadena.Contains(">"))cad = cadena.Replace(">", "");
            if (cadena.Contains("-")) cad = cadena.Replace("-", "");
            if (cadena.Contains(":")) cad = cadena.Replace(":", "");
            if (cadena.Contains("\"")) cad = cadena.Replace("\"", "");*/
            return cad.Replace(" ", "").Replace(">", "").Replace("-", "").Replace(":", "")
                .Replace("\"", "").Replace(";", "");
        }

        private string quitatodoDos(string cadena)
        {
            string cad = cadena;
            return cad.Replace(">", "").Replace("-", "").Replace(":", "")
                .Replace("\"", "").Replace(";", "");
        }





        public string dameTokens()
        {
            string contenido=string.Empty;
            foreach (token mi in miListaToken)
            {
                contenido += mi.dameNombre() + "       " + mi.dameContenido() + "      " + mi.fila + "  " + mi.columna + System.Environment.NewLine;
            }
            contenido += "\n\n\n";
            foreach (token mi in miListaError)
            {
                contenido += mi.dameNombre() + "       " + mi.dameContenido() + "      " + mi.fila + "  " + mi.columna + System.Environment.NewLine;
            }
            return contenido;
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
                        sw.WriteLine("<Token>\n<Nombre>" + to.dameNombre() + "</Nombre>\n<Valor>" + dameCorrecto(to.dameContenido()) + "</Valor>\n<Fila>" + to.fila + "</Fila>\n<Columna>" + to.columna + "</Columna>\n</Token>");
                    }
                    

                    sw.WriteLine("<TokenError>\n");

                    //AQUI VA EL CICLO DE ERRORES
                    foreach (token to in miListaError)
                    {
                        sw.WriteLine("<Token>\n<Nombre>" + to.dameNombre() + "</Nombre>\n<Valor>" + dameCorrecto(to.dameContenido()) + "</Valor>\n<Fila>" + to.fila + "</Fila>\n<Columna>" + to.columna + "</Columna>\n</Token>");
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
