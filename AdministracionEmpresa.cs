namespace administracion
{
    class Empleados
    {
        string nombre;
        string apellido;
        DateTime fechaNacimiento;
        char estadoCivil;
        DateTime fechaIngreso;
        double sueldoBasico;

        Cargos cargo;
        public string Nombre {get => nombre; set => nombre = value; }

        public string Apellido { get => apellido; set => apellido = value; }

        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }

        public char EstadoCivil { get => estadoCivil; set => estadoCivil = value; }

        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }

        public double SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }

        public Cargos Cargo { get => cargo; set => cargo = value; }

        public void MostrarEmpleado(double sueldoReal, int antiguedad, int edad, int aniosParaJubilacion)
        {
            Console.WriteLine($"\nNombre: {Nombre}");
            Console.WriteLine($"\nApellido: {Apellido}");
            Console.WriteLine($"\nFecha de Nacimiento: {FechaNacimiento.ToShortDateString()}");
            Console.WriteLine($"Edad: {edad}");
            Console.Write("Estado civil: ");
            if (EstadoCivil == 'c' || EstadoCivil == 'C')
            {
                Console.Write("Casado\n");
            } else
            {
                Console.Write("Soltero\n");
            }
            Console.WriteLine($"\nFecha de ingreso a la empresa {FechaIngreso.ToShortDateString()}");
            Console.WriteLine($"\nAntiguedad {antiguedad}");
            Console.WriteLine($"\nAnios restantes para jubilarse {aniosParaJubilacion}");
            Console.WriteLine($"\nSueldo basico $ {SueldoBasico}");
            Console.WriteLine($"\nSueldo Real $ {sueldoReal}");
            Console.WriteLine($"\nCargo {Cargo}");1
        }
        public int CalculoAntiguedad()
        {
            DateTime fechaActual = DateTime.Now;
            int antiguedad =  fechaActual.Year - fechaIngreso.Year;
            if(fechaActual.Month < fechaIngreso.Month || (fechaActual.Month == fechaIngreso.Month && fechaActual.Day<fechaIngreso.Day)){
                antiguedad--;
            }
            return antiguedad;
        }
        public int CalculoEdad()
        {
            DateTime fechaActual = DateTime.Now;
            int antiguedad =  fechaActual.Year - fechaNacimiento.Year;
            if(fechaActual.Month < fechaNacimiento.Month || (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day<fechaNacimiento.Day)){
                antiguedad--;
            }
            return antiguedad;
        }
        public int FaltaParaJubilacion()
        {
            int edad = CalculoEdad();
            int aniosRestantes = 65 - edad;
            return aniosRestantes; 
        }
        
        public double CalculoSalario()
        {
            double adicional;
            if(CalculoAntiguedad()< 20)
            {
                adicional = SueldoBasico * (CalculoAntiguedad()/100);
            }else
            {
                adicional = SueldoBasico * 0.25;
            }
            if (cargo == Cargos.Especialista || cargo == Cargos.Ingeniero)
            {
                adicional *= 1.50;
            }
            if(estadoCivil == 'C' || estadoCivil == 'c')
            {
                adicional += 150000;
            }
            return SueldoBasico+adicional;
        }
    }
    
}