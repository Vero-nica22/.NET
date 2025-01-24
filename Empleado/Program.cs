using System;
using System.Collections.Generic;

//Clase Padre
public abstract class Empleado
{
    public required string nombre { get; set; }

    public abstract decimal calcularSalario();

    public override string ToString()
    {
        return $"Empledo {nombre} ";
    }
}

//Clase hija 1

public class EmpleadoTiempoCompleto : Empleado
{
    public decimal salarioAnual { get; set; }

    public override decimal calcularSalario()
    {
        decimal salarioMensual = salarioAnual / 12;
        return salarioMensual;

    }
}

//Clase hija 2

public class EmpleadoPorHoras : Empleado
{
    public decimal tarifaPorHora { get; set; }
    public int horasTrabajadas { get; set; }

    public override decimal calcularSalario()
    {
        decimal salarioMensual = tarifaPorHora * horasTrabajadas;
        return salarioMensual;
    }
}

//Programa principal

public class Program
{
    static void Main()
    {
        List<Empleado> empleados = new List<Empleado>
        {
            new EmpleadoTiempoCompleto { nombre = "Isabella", salarioAnual = 12000000 },
            new EmpleadoPorHoras { nombre = "Luis", tarifaPorHora = 100000, horasTrabajadas = 160 },
        };

        foreach (Empleado empleado in empleados)
        {
            Console.WriteLine($"{empleado} tiene un salario mensual de {empleado.calcularSalario()}");
        }



    }
}
