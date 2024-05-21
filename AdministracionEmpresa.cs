namespace administracion
{
    class Empleados
    {
        string nombre;
        string apellido;
        DateTime fechaNacimiento;
        char estadoCivil;
        DateTime fechaIngreso;
        double SueldoBasico;

        Cargos Cargo;

        public int CalculoAntiguedad(DateTime fechaIngreso)
        {
            DateTime fechaActual = DateTime.Now;
            int antiguedad =  fechaActual.Year - fechaIngreso.Year;
            if(fechaActual.Month < fechaIngreso.Month || (fechaActual.Month == fechaIngreso.Month && fechaActual.Day<fechaIngreso.Day)){
                antiguedad--;
            }
            return antiguedad;
        }
        public int CalculoEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            int antiguedad =  fechaActual.Year - fechaNacimiento.Year;
            if(fechaActual.Month < fechaNacimiento.Month || (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day<fechaNacimiento.Day)){
                antiguedad--;
            }
            return antiguedad;
        }
        public int FaltaParaJubilacion(DateTime fechaNacimiento)
        {
            int edad = CalculoEdad(fechaNacimiento);
            int aniosRestantes = 65 - edad;
            return aniosRestantes; 
        }
        
        public double CalculoSalario(Empleados empleado)
        {
            double adicional;
            if(CalculoAntiguedad(empleado.fechaIngreso)< 20)
            {
                adicional = SueldoBasico * (CalculoAntiguedad(empleado.fechaIngreso)/100);
            }else
            {
                adicional = SueldoBasico * 0.25;
            }
            if (empleado.Cargo == Cargos.Especialista || empleado.Cargo == Cargos.Ingeniero)
            {
                adicional = adicional*1.50;
            }
            if(empleado.estadoCivil == 'C')
            {
                adicional += 150000;
            }
            return adicional;
        }
    }
    
}