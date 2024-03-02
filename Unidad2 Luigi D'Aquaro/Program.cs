using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Unidad2_Luigi_D_Aquaro
{
    class Program
    {
        static int saldo = 3200;
        static object lockObject = new object();

        static void Main(string[] args)
        {
            // Crear hilos para simular ingreso y retiro de dinero
            Thread ingresoThread = new Thread(IngresoDinero);
            Thread retiroThread = new Thread(RetiroDinero);

            // Iniciar los hilos
            ingresoThread.Start();
            retiroThread.Start();

            // Esperar a que ambos hilos terminen
            ingresoThread.Join();
            retiroThread.Join();

            // Mostrar el saldo final
            Console.WriteLine("Saldo final: $" + saldo);
        }

        static void IngresoDinero()
        {
            for (int i = 0; i < 5; i++)
            {
                lock (lockObject)
                {
                    int ingreso = 100;
                    saldo += ingreso;
                    Console.WriteLine("Ingreso de $" + ingreso + " - Saldo actual: $" + saldo);
                }

                // Simular un breve tiempo de espera
                Thread.Sleep(100);
            }
        }

        static void RetiroDinero()
        {
            for (int i = 0; i < 5; i++)
            {
                lock (lockObject)
                {
                    int retiro = 50;
                    if (saldo >= retiro)
                    {
                        saldo -= retiro;
                        Console.WriteLine("Retiro de $" + retiro + " - Saldo actual: $" + saldo);
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente para el retiro de $" + retiro);
                    }
                }

                // Simular un breve tiempo de espera
                Thread.Sleep(10000);
            }
        }
    }
}
