using Examen1AllanT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Examen1AllanT
{
    internal class Menu
    {
        List<Empleado> empleados = new List<Empleado>();
        static int opcion = 0;
        public void desplegar()
        {
            do
            {             
                Console.WriteLine("SISTEMA DE RECURSOS HUMANOS");
                Console.WriteLine("1- Agregar empleados");
                Console.WriteLine("2- Consultar empleados");
                Console.WriteLine("3- Modificar empleados");
                Console.WriteLine("4- Borrar empleados");
                Console.WriteLine("5- Inicializar arreglos");
                Console.WriteLine("6- Submenú de reportes");
                Console.WriteLine("7- Salir");
                Console.WriteLine(" Seleccione una opción: ");
                int.TryParse(Console.ReadLine(), out opcion);
                switch (opcion)
                {
                    case 1: Agregar(); break;
                    case 2: Consultar(); break;
                    case 3: Modificar(); break;
                    case 4: Borrar(); break;
                    case 5: Inicializar(); break;
                    case 6:
                        Console.Clear();
                        bool salirReportes = false;
                        while (!salirReportes)
                        {
                           
                            Console.WriteLine("-------------------------------------------------------------------------------");
                            Console.WriteLine("Menú de Reportes:");
                            Console.WriteLine("1- Consultar empleados con número de cédula");
                            Console.WriteLine("2- Lista de empleados ordenados por nombre");
                            Console.WriteLine("3- Calcular y mostrar el promedio de los salarios");
                            Console.WriteLine("4- Calcular y mostrar el salario más alto y el más bajo de todos los empleados");
                            Console.WriteLine("5- Volver al Menú Principal");
                            Console.Write("Seleccione una opción: ");
                            int opcionReportes = int.Parse(Console.ReadLine());

                            switch (opcionReportes)
                            {
                                case 1:
                                    Consultar();
                                    break;
                                case 2:
                                    ListaEmpleados();
                                    break;
                                case 3:
                                    PromedioSalarios();
                                    break;
                                case 4:
                                    CalcularSalariosExtremos();
                                    break;
                                case 5:
                                    Console.Clear();
                                    salirReportes = true;

                                    break;
                                default:
                                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                                    break;
                            }
                        }
                        break;
                    default:                  
                        break;

                }
            } while (opcion != 7);
        }
        public void Agregar()
        {
            
            Console.Write("Ingrese la cédula del empleado: ");
            string cedula = Console.ReadLine();
            if (empleados.Any(e => e.CedulaEmpleado == cedula))
            {
                Console.WriteLine("Ya existe un empleado con esa cédula.");
                return; 
            }
            Console.Write("Ingrese el nombre del empleado: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la dirección del empleado: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingrese el teléfono del empleado: ");
            string telefono = Console.ReadLine();          
            double salario;
            while (true)
            {
                Console.Write("Ingrese el salario del empleado: ");
                string salarioInput = Console.ReadLine();

                if (double.TryParse(salarioInput, out salario))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Ingrese un monto válido para el salario.");
                }
            }
            Empleado.AgregarEmpleado(empleados, cedula, nombre, direccion, telefono, salario);
            Console.WriteLine("Empleado agregado");
            Console.WriteLine("-----------------");
        }
        public void Consultar()
        {
            Console.Clear();
            Console.Write("Ingrese la cédula del empleado: ");
            string cedula = Console.ReadLine();
            Empleado empleado = Empleado.ConsultarEmpleado(empleados, cedula);

            if (empleado != null)
            {
                empleado.MostrarInformacionEmpleado();
            }
            else
            {
                Console.WriteLine("Cédula de empleado no encontrada");
            }
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine(); 
            Console.Clear(); 
        }
        public void Modificar()
        {
            Console.Clear();    
            Console.Write("Ingrese el número de cédula del empleado que desea modificar: ");
            string cedula = Console.ReadLine();

            Empleado empleado = Empleado.ConsultarEmpleado(empleados, cedula);

            if (empleado != null)
            {
                Console.WriteLine("Modificar datos del empleado:");
                Console.Write("Nuevo nombre del empleado: ");
                string nombre = Console.ReadLine();
                Console.Write("Nueva dirección del empleado: ");
                string direccion = Console.ReadLine();
                Console.Write("Nuevo teléfono del empleado: ");
                string telefono = Console.ReadLine();
                double salario;
                while (true)
                {
                    Console.Write("Nuevo salario del empleado: ");
                    string salarioInput = Console.ReadLine();

                    if (double.TryParse(salarioInput, out salario))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un monto válido para el salario.");
                    }
                    Console.WriteLine("Presione Enter para continuar...");
                    Console.ReadLine();
                    Console.Clear();
                }


                Empleado.ModificarEmpleado(empleados, cedula, nombre, direccion, telefono, salario);
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }

        }
        public void Borrar()
        {
            Console.Clear();
            Console.Write("Ingrese el número de cédula del empleado que desea borrar: ");
            string cedula = Console.ReadLine();

            Empleado.BorrarEmpleado(empleados, cedula);
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        public void Inicializar()
        {
            empleados.Clear();
            Console.WriteLine("Arreglos de empleados inicializados.");
        }
        public void ListaEmpleados()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                var empleadosOrdenados = empleados.OrderBy(e => e.NombreEmpleado).ToList();

                Console.WriteLine("Listado de empleados ordenados por nombre:");
                foreach (var empleado in empleadosOrdenados)
                {
                    Console.WriteLine($"Cédula: {empleado.CedulaEmpleado}, Nombre: {empleado.NombreEmpleado}");
                }
            }
        }
        public void PromedioSalarios()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados para calcular el promedio de salarios.");
            }
            else
            {
                double promedioSalarios = empleados.Average(e => e.SalarioEmpleado);
                Console.WriteLine($"El promedio de los salarios es de $ {promedioSalarios}");
            }
        }
        public void CalcularSalariosExtremos()
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados para calcular los salarios máximos y mínimos.");
            }
            else
            {
                double salarioMaximo = empleados.Max(e => e.SalarioEmpleado);
                double salarioMinimo = empleados.Min(e => e.SalarioEmpleado);

                Console.WriteLine($"Salario más alto es de $ {salarioMaximo}");
                Console.WriteLine($"Salario más bajo es de $ {salarioMinimo}");
            }
        }
    }     
  }








