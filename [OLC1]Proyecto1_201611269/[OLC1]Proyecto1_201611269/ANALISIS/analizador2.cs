using _OLC1_Proyecto1_201611269.OBJETOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto1_201611269.ANALISIS
{
    class analizador2
    {
        public List<token> listaToken;
        public List<lexema> listaLexema;
        public List<conjunto> listaConj;
        public List<expresionRegular> listaER;
        public string error;

        public analizador2(List<token> lis)
        {
            listaToken = lis;
            listaLexema = new List<lexema>();
            listaConj = new List<conjunto>();
            listaER = new List<expresionRegular>();
            error="";
            ReunirInfo();

        }


        private void ReunirInfo()
        {

            //VAMOS A CREAR UN ANALIZADOR PARA REUNIR LA INFORMACION
            //CON ESTE METODO LO HAREMOS
            expresionRegular ex;
            int caso=0;
            string nombreaux = "";
            foreach (token t in listaToken)
            {
                switch (caso)
                {
                    case 0:
                        if (t.dameNombre().Contains("ID_CONJ")) { caso = 1; nombreaux = t.dameContenido(); }
                        if (t.dameNombre().Contains("ID_PATRON")) { caso = 2; nombreaux = t.dameContenido(); }
                        if (t.dameNombre().Contains("ID_LEXEMA")) { caso = 3; nombreaux = t.dameContenido(); }
                        break;


                    case 1:
                        if (t.dameNombre().Contains("CONTENIDO_CONJ")) { 
                            caso = 0;
                            listaConj.Add(new conjunto(nombreaux, t.dameContenido()));
                            nombreaux = "";
                        }
                        break;

                    case 2:
                        if (t.dameNombre().Contains("CONTENIDO_PATRON"))
                        {
                            caso = 0;
                            ex = new expresionRegular(nombreaux, t.dameContenido());
                            ex.agregarConjuntos(listaConj);
                            listaER.Add(ex);
                            nombreaux = "";
                        }
                        break;

                    case 3:
                        if (t.dameNombre().Contains("CONT_LEXEMA"))
                        {
                            caso = 0;
                            listaLexema.Add(new lexema(nombreaux, t.dameContenido()));
                            nombreaux = "";
                        }
                        break;

                }//switch
            }//for
        }//metodo reunir


        public string imprime()
        {
            string c="";
            c += "-------------------CONJUNTOS--------------\n\n" + System.Environment.NewLine;
            foreach (conjunto cn in listaConj)
            {
                c += cn.nombre + "  ->   " + cn.contenido + System.Environment.NewLine;
            }

            c += "-----------------------ER--------------\n\n" + System.Environment.NewLine;

            foreach (expresionRegular cn in listaER)
            {
                c += cn.nombre + "  ->   " + cn.contenido2 + System.Environment.NewLine;
            }
            c += "------------------LEXEMAS--------------\n\n" + System.Environment.NewLine;

            foreach (lexema cn in listaLexema)
            {
                c += cn.nombre + "  ->   " + cn.contenido + System.Environment.NewLine;
            }

            return c;
        }
    }
}
