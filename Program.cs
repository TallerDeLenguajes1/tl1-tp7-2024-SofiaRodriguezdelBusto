// See https://aka.ms/new-console-template for more information
using EspacioCalculadora;

Calculadora miCalculadora = new Calculadora();

int control;
do
{
    Console.WriteLine("\n--------Calculadora--------\n");
    Console.WriteLine("\n1.SUMA");
    Console.WriteLine("\n2.RESTA");
    Console.WriteLine("\n3.MULTIPLICACION");
    Console.WriteLine("\n4.DIVISION");
    Console.WriteLine("\n5.LIMPIAR");
    Console.WriteLine("\nElija la operacion que desea realizar: ");
    string operacion = Console.ReadLine(); 
    int op;
    double numero = 0;
    if(int.TryParse(operacion, out op))
    {
        if (op != 5)
        {
            string n;
            do{
                Console.WriteLine("\nIngrese el numero: ");
                n = Console.ReadLine(); 
            }while (!double.TryParse(n, out numero));
            
        }
        switch (op)
        {
            case 1:
                    miCalculadora.Sumar(numero);
                    Console.WriteLine("\nLa suma de los numeros es " + miCalculadora.Resultado);
                    break;
            case 2:
                    miCalculadora.Restar(numero);
                    Console.WriteLine("\nLa diferencia de los numeros es " + miCalculadora.Resultado);
                    break;

            case 3:
                    miCalculadora.Multiplicar(numero);
                    Console.WriteLine("\nEl producto de los numeros es " + miCalculadora.Resultado);
                    break;
            case 4:
                    miCalculadora.Dividir(numero);
                    Console.WriteLine("\nEl cociente de los numeros es " + miCalculadora.Resultado);
                    break;
            case 5:
                    miCalculadora.Limpiar();
                    Console.WriteLine("\nEl dato vacio es: ", miCalculadora.Resultado);
                    break;

         }
    }
    Console.WriteLine("\nIngrese 1 si desea continuar operando. Caso contrario ingrese 0");
    string controla = Console.ReadLine();
    if(!int.TryParse(controla, out control))
    {
      control = 1;
    }
    
} while (control != 0);
