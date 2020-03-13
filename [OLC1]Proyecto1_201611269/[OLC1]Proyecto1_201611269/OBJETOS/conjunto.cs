using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_Proyecto1_201611269.OBJETOS
{
    class conjunto
    {
        public string nombre;
        public string contenido;
        private List<string> listaElementos;

        public conjunto(string n, string c)
        {
            nombre = n.Replace(" ", "");
            contenido = c;
            listaElementos = new List<string>();
            AgregarINFO(contenido); 
        }

        public void AgregarINFO(string a){
            int index = a.IndexOf('~');
            if(index!=-1){
                string[] cad = a.Split('~');
                foreach(string  elemento in cad){
                    listaElementos.Add(elemento);
                }
            }
            else{
                foreach(string  elemento in a.Split(',')){
                    listaElementos.Add(elemento);
                }
            }
        }//void agregarinfor


        public string dameContenido(){
        
            //AQUI VAMOS A DAR LOS ELEMENTOS DE UN CONJUNTO, ESTO SERVIRA PARA LA EXPRESION REGULAR, LO CUAL NOS PIDE ESOS DATOS
            string contenido="[";
            try {
                if(listaElementos.Count>2){
                //EN EL CASO DE QUE LA LISTA SEA MAYOR A 2 VAMOS ENVIAR TODA LA INFO ASI A LO LOCO
                for(int i=0;i<listaElementos.Count;i++){
                    if(i==listaElementos.Count-1) contenido+=listaElementos[i];
                    else contenido+=listaElementos[i]+",";
                }
            }else{
            
                //SI EL TAMA;O ES IGUAL A 2 ENTONCES DEBEMOS AGREGAR ELEMENTO POR ELEMENTO
                string primero=listaElementos[0];
                string ultimo=listaElementos[1];
            
                //EN EL CASO DE QUE SEA UN GRUPO DE CARACTERES, LOS AGRUPAREMOS
            
                //EN ESTE CASO CUANDO SON DE TAMA;O MAYOR O IGUAL A 2 QUIERE DECIR QUE SON NUMEROS. ENTONCES AGREGAMOS UNA LISTA DE ESTSO NUMEROS A LA CADENA
                if(primero.Length>=2 && ultimo.Length>=2){
                    int primI=int.Parse(primero);
                    int ultI=int.Parse(ultimo);
                
                    for(int i=primI;i<=ultI;i++){
                        if(i==ultI)contenido+=i;
                        else contenido+=i+",";
                    }
                }else
                {
                    //EN EL CASO DE QUE NO SEAN NUMERO, PUES AGREGAMOS EL RANGO DE DATOS SELECCIONADOS
                    //DIGAMOS QUE DE A-Z DEBEMOS CONVERTIRLOS A CHAR, LUEGO A INT
                    //POR ULTIMO HACEMOS UN FOR DE TAL A TAL CARACTER, ENTONCES LUEGO LOS VOLVEMOS A CONVERTIR A CHAR Y LO AGREGAMOS
                
                    char ini=primero[0];
                    char fini=ultimo[0];
                    int primm=ini-0;
                    int finan=fini-0;
                
                    for(int i=ini;i<=fini;i++){
                        if(i==fini)contenido+=(char)i;
                        else contenido+=(char)i+",";
                    }
                }
            
            }
            }//try
            catch (Exception e) {
                MessageBox.Show(e.Message, "Error conjuntos ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            contenido+="]";
            return contenido;
        }
    }
}
