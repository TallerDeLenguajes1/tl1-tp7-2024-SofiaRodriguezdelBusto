// See https://aka.ms/new-console-template for more information
using EspacioCalculadora;
using administracion;

Calculadora miCalculadora = new Calculadora();


Console.WriteLine("\n--------Ejercicio 1--------\n");
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


Console.WriteLine("\n--------Ejercicio 2--------\n");
Empleados[] empleados = new Empleados[3];
string nombre;
string apellido;
string ingresoUsuario;
DateTime fechaNacimiento;
char estadoCiv;
DateTime ingreso;
double sueldoBasic;
int cargoEmpleado;
for (int i = 0; i < 3; i++)
{
        empleados[i] = new Empleados();
        Console.WriteLine($"\n------Empleado {i+1}------\n");
        Console.WriteLine($"\nEmpleado {i}");
        Console.WriteLine($"\nIngrese el apellido del empleado");
        apellido =  Console.ReadLine();
        empleados[i].Apellido = apellido;
        Console.WriteLine($"\nIngrese el nombre del empleado");
        nombre =  Console.ReadLine();
        empleados[i].Nombre = nombre;
        Console.WriteLine($"\nIngrese la fecha de nacimiento");
        do
        {
            Console.WriteLine("\nUtilice el formato AAAA-MM-DD.");
            ingresoUsuario =  Console.ReadLine();
                
        } while (!DateTime.TryParse(ingresoUsuario, out fechaNacimiento));
        empleados[i].FechaNacimiento = fechaNacimiento;
        do
        {
            Console.WriteLine("Ingrese el caracter correspondiente al estado civil del empleado: \nC-Casado\nS-Soltero");
            ingresoUsuario = Console.ReadLine();
        } while (!char.TryParse(ingresoUsuario, out estadoCiv) || (estadoCiv != 'c' && estadoCiv != 's' && estadoCiv != 'C' && estadoCiv != 'S'));
        empleados[i].EstadoCivil = estadoCiv;
            Console.WriteLine("Ingrese la fecha de ingreso en la empresa del empleado.\n");
        do
        {
            Console.WriteLine("\nUtilice el formato AAAA-MM-DD.");
            ingresoUsuario = Console.ReadLine();
        } while (!DateTime.TryParse(ingresoUsuario, out ingreso));
        empleados[i].FechaIngreso = ingreso;
        do
        {
            Console.WriteLine("Ingrese el sueldo basico del empleado\n");
            ingresoUsuario = Console.ReadLine();
        } while (!double.TryParse(ingresoUsuario, out sueldoBasic) || sueldoBasic < 0);
        empleados[i].SueldoBasico = sueldoBasic;
        do
        {
             Console.WriteLine("Seleccione el cargo del empleado.\n");
             Console.WriteLine("[1]. Auxiliar\n");
             Console.WriteLine("[2]. Administrativo\n");
             Console.WriteLine("[3]. Ingeniero\n");
             Console.WriteLine("[4]. Especialista\n");
             Console.WriteLine("[5]. Investigador\n");
             ingresoUsuario = Console.ReadLine();
        } while (!int.TryParse(ingresoUsuario, out cargoEmpleado) || cargoEmpleado >= 6 || cargoEmpleado <= 0);
        switch (cargoEmpleado)
        {
                case 1:
                empleados[i].Cargo = Cargos.Auxiliar;
                break;
                case 2:
                empleados[i].Cargo = Cargos.Administrativo;
                break;
                case 3:
                empleados[i].Cargo = Cargos.Ingeniero;
                break;
                case 4:
                empleados[i].Cargo = Cargos.Especialista;
                break;
                case 5:
                empleados[i].Cargo = Cargos.Investigador;
                break;
        }
}

double totalSalarios = 0;

for (int i = 0; i < 3; i++)
{
        totalSalarios += empleados[i].CalculoSalario();
}
Console.WriteLine($"\nEl monto total pagado en concepto de salarios es {totalSalarios}");

int aniosParaJubilarse;
int menorCantidadAnios = 1000;
int empleadoAJubilar = 0;
for (int i = 0; i < 3; i++)
{
    aniosParaJubilarse = empleados[i].FaltaParaJubilacion();
    if(menorCantidadAnios>aniosParaJubilarse)
    {
        menorCantidadAnios = aniosParaJubilarse;
        empleadoAJubilar = i;
    }
}
double sueldoReal = empleados[empleadoAJubilar].CalculoSalario();
int antiguedad = empleados[empleadoAJubilar].CalculoAntiguedad();
int edad = empleados[empleadoAJubilar].CalculoEdad();

Console.WriteLine("\nEl empleado mas proximo a jubilarse es: ");
empleados[empleadoAJubilar].MostrarEmpleado(sueldoReal, antiguedad, edad, menorCantidadAnios);

