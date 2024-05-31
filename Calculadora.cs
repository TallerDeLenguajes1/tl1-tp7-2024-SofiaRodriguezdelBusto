namespace EspacioCalculadora
{   
    public class Calculadora
    {
        double dato;
        public double Resultado{get=>dato;}
        public void Sumar(double termino)
        {
           dato += termino; 
        }
        public void Restar(double termino)
        {
            dato -= termino;
        }
        public void Multiplicar(double termino)
        {
            dato *= termino;
        }
        public void Dividir(double termino)
        {
            if(termino != 0)
            {
                dato /= termino;
            }else
            {
                Console.WriteLine("Error! Division en 0");
            }
        }
        public void Limpiar()
        {
            dato = 0;
        }
    }
    
}