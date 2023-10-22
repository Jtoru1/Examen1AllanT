using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1AllanT
{
    internal class Empleado
    {

        public string CedulaEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string DireccionEmpleado { get; set; }
        public string TelefonoEmpleado { get; set; }
        public double SalarioEmpleado { get; set; }

        public Empleado(string Cedula, string Nombre, string Direccion, string Telefono, double Salario)
        {
            CedulaEmpleado = Cedula;
            NombreEmpleado = Nombre;
            DireccionEmpleado = Direccion;
            TelefonoEmpleado = Telefono;
            SalarioEmpleado = Salario;
        }
        public void MostrarInformacionEmpleado ()
        {
            Console.WriteLine($"Cédula: {CedulaEmpleado}");
            Console.WriteLine($"Nombre: {NombreEmpleado}");
            Console.WriteLine($"Dirección: {DireccionEmpleado}");
            Console.WriteLine($"Teléfono: {TelefonoEmpleado}");
            Console.WriteLine($"Salario: {SalarioEmpleado}");
        }
        public static Empleado ConsultarEmpleado(List<Empleado> empleados, string cedula)
        {
            return empleados.Find(e => e.CedulaEmpleado == cedula);
        }
        public static void ModificarEmpleado(List<Empleado> empleados, string cedula, string nombre, string direccion, string telefono, double salario)
        {
            Empleado empleado = ConsultarEmpleado(empleados, cedula);
            if (empleado != null)
            {
                empleado.NombreEmpleado = nombre;
                empleado.DireccionEmpleado = direccion;
                empleado.TelefonoEmpleado = telefono;
                empleado.SalarioEmpleado = salario;
                Console.WriteLine("Empleado modificado.");
                Console.WriteLine("-----------------");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
                Console.WriteLine("-----------------");
            }
        }
        public static void AgregarEmpleado (List<Empleado> empleados, string cedula, string nombre, string direccion, string telefono, double salario)
        {
            Empleado empleado = new Empleado(cedula, nombre, direccion, telefono, salario);
            empleados.Add(empleado);
        }
        public static void BorrarEmpleado(List<Empleado> empleados, string cedula)
        {
            Empleado empleado = ConsultarEmpleado(empleados, cedula);
            if (empleado != null)
            {
                empleados.Remove(empleado);
                Console.WriteLine("Empleado eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }
    }
}