using System;
using System.IO;
namespace Aplicacion3_4to_Bim
{
        class Program
        {
            static void Main(string[] args)
            {
                string direccion = "";
                string Nombre = "";
                string Apellido = "";
                string Telefono = "";
                string linea = "";
                string direccionCt = "";
                int op = 0;
                string Referencia = "";
                while (op == 0)
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("---------------Cinta De Opciones--------------");
                    Console.WriteLine("\n1. Crear Agenda \n2. Añadir Contacto \n3. Buscar Contacto \n4. Borrar Contacto \n5 Borrar Agenda \n6. Salir");
                    Console.WriteLine("Digite el numero de opcion que desea");
                    Console.WriteLine("----------------------------------------------");
                    op = int.Parse(Console.ReadLine());
                    System.Threading.Thread.Sleep(3000);

                    Console.Clear();
                    if (op == 1)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Ingrese El Nombre De La Agenda");
                        String Agenda = Console.ReadLine() + ".txt";
                        StreamWriter ar;
                        ar = File.CreateText(Agenda);
                        ar.Close();
                        Console.WriteLine("----------------------------------------------");
                        System.Threading.Thread.Sleep(3000);
                    }
                    else if (op == 2)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Ingrese El Nombre De la Agenda:");
                        direccion = Console.ReadLine() + ".txt";

                        Console.WriteLine("Ingrese El Nombre Del Contacto:");
                        Nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese Apellido:");
                        Apellido = Console.ReadLine();

                        Console.WriteLine("Ingrese Telefono:");
                        Telefono = Console.ReadLine();

                        Console.WriteLine("Ingrese La Direccion del Contacto:");
                        direccionCt = Console.ReadLine();

                        linea = Nombre + ";" + Apellido + ";" + Telefono + ";" + direccionCt;
                        Escribir(direccion, linea);
                        Console.WriteLine("----------------------------------------------");
                        System.Threading.Thread.Sleep(3000);
                    }
                    else if (op == 3)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Ingrese El Nombre De la Agenda donde desea Buscar: ");
                        direccion = Console.ReadLine() + ".txt";
                        Console.WriteLine("Ingrese Una Referencia Del Contacto a Buscar: ");
                        Referencia = Console.ReadLine();
                        Buscar(direccion, Referencia);
                        Console.WriteLine("----------------------------------------------");
                        System.Threading.Thread.Sleep(3000);

                    }
                    else if (op == 4)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Ingrese El Nombre De la Agenda donde desea Eliminar ");
                        direccion = Console.ReadLine() + ".txt";
                        Console.WriteLine("Ingrese el Numero del Contacto que desea Eliminar");
                        Referencia = Console.ReadLine();
                        Eliminar(direccion, Referencia);
                        Console.WriteLine("El Contacto A Sido Eliminado");
                        Console.WriteLine("----------------------------------------------");
                        System.Threading.Thread.Sleep(3000);

                    }
                    else if (op == 5)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Ingrese El Nombre De La Agenda");
                        String Agenda = Console.ReadLine() + ".txt";
                        File.Delete(Agenda);
                        Console.WriteLine("La Agenda A sido Eliminada");
                        Console.WriteLine("----------------------------------------------");
                        System.Threading.Thread.Sleep(3000);



                    }
                    else if (op == 6)
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Aplicacion Creada Por Pedro Javier Serrano Ramírez");
                        Console.WriteLine("4to. Bachillerato BACO");
                        Console.WriteLine("----------------------------------------------");
                        break;

                    }
                    op = 0;
                }
            }
            static void Escribir(string ruta, string dato)
            {

                StreamWriter ar;
                ar = File.AppendText(ruta);
                ar.WriteLine(dato);
                ar.Close();
            }
            static void Buscar(string ruta, string buscar)
            {
                string lineaAr = "";
                StreamReader ar;
                ar = File.OpenText(ruta);

                lineaAr = ar.ReadLine();

                while (lineaAr != null)
                {
                    string[] vec = lineaAr.Split(';');
                    if (vec[0] == buscar || vec[1] == buscar || vec[2] == buscar || vec[3] == buscar)
                    {
                        Console.WriteLine("Contacto encontrado: " + vec[0] + " " + vec[1] + " " + vec[2] + " " + vec[3]);
                    }
                    lineaAr = ar.ReadLine();
                }
                ar.Close();

            }
            static void Eliminar(string ruta, string buscar)
            {
                string lineaAr = "";
                StreamReader ar;
                StreamWriter Br;
                Br = File.CreateText("Borrador.txt");
                ar = File.OpenText(ruta);

                lineaAr = ar.ReadLine();

                while (lineaAr != null)
                {
                    string[] vec = lineaAr.Split(';');
                    if (vec[2] != buscar)
                    {
                        Br.WriteLine(lineaAr);
                    }
                    lineaAr = ar.ReadLine();
                }
                ar.Close();
                Br.Close();
                StreamReader Br2;
                StreamWriter Ar2;
                Br2 = File.OpenText("Borrador.txt");
                Ar2 = File.CreateText(ruta);
                lineaAr = Br2.ReadToEnd();
                Ar2.WriteLine(lineaAr);
                Ar2.Close();
                Br2.Close();
            }
        }
    }
