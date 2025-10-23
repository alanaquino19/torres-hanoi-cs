using System;
using System.Collections.Generic;

namespace TorresHanoi
{
    public static class Program
    {
        static Stack<int> torreA = new Stack<int>();
        static Stack<int> torreB = new Stack<int>();
        static Stack<int> torreC = new Stack<int>();
        static string jugador1, jugador2;
        static int turno = 1;
        static int movimientos = 0;
        static int discos = 3;

        public static void Main()
        {
            Console.Title = "Torres de Hanói para dos Jugadores";

            Console.WriteLine("TORRES DE HANÓI\n");

            Console.Write("Nombre del Jugador 1: ");
            jugador1 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(jugador1)) jugador1 = "Jugador 1";

            Console.Write("Nombre del Jugador 2: ");
            jugador2 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(jugador2)) jugador2 = "Jugador 2";

            InicializarTorres();

            Console.Clear();
            MostrarTorres();

            while (true)
            {
                Console.WriteLine($"\nTurno de {(turno == 1 ? jugador1 : jugador2)}");
                Console.Write("Mover de torre (A, B, C): ");
                string desde = Console.ReadLine()?.ToUpper();

                Console.Write("Mover a torre (A, B, C): ");
                string hacia = Console.ReadLine()?.ToUpper();

                if (ValidarEntrada(desde, hacia) && Mover(desde, hacia))
                {
                    movimientos++;
                    Console.Clear();
                    MostrarTorres();

                    if (torreC.Count == discos)
                    {
                        Console.WriteLine($"\n¡{(turno == 1 ? jugador1 : jugador2)} ha ganado en {movimientos} movimientos!");
                        break;
                    }

                    turno = turno == 1 ? 2 : 1;
                }
                else
                {
                    Console.WriteLine("\nMovimiento inválido. Intenta de nuevo.");
                    Console.WriteLine("Reglas: Solo puedes mover el disco superior, y no puedes colocar un disco sobre uno más pequeño.");
                }
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void InicializarTorres()
        {
            torreA.Clear();
            torreB.Clear();
            torreC.Clear();

            for (int i = discos; i >= 1; i--)
            {
                torreA.Push(i);
            }
        }

        static void MostrarTorres()
        {
            Console.WriteLine("ESTADO ACTUAL\n");
            Console.WriteLine($"Movimientos realizados: {movimientos}");
            Console.WriteLine($"Turno actual: {(turno == 1 ? jugador1 : jugador2)}\n");

            MostrarTorresHorizontalmente();
        }

        static void MostrarTorresHorizontalmente()
        {
            // Convertir stacks a listas para poder acceder a todos los elementos.
            List<int> listaA = new List<int>(torreA);
            List<int> listaB = new List<int>(torreB);
            List<int> listaC = new List<int>(torreC);

            // Invertir para tener la base primero.
            listaA.Reverse();
            listaB.Reverse();
            listaC.Reverse();

            Console.WriteLine("  A         B         C");
            Console.WriteLine("-----     -----     -----");

            // Encontrar la altura máxima para mostrar.
            int maxAltura = Math.Max(Math.Max(listaA.Count, listaB.Count), listaC.Count);

            for (int i = maxAltura - 1; i >= 0; i--)
            {
                string linea = " ";

                // Torre A.
                if (i < listaA.Count)
                    linea += CentrarDisco(listaA[i]) + "     ";
                else
                    linea += "  |  " + "     ";

                // Torre B.
                if (i < listaB.Count)
                    linea += CentrarDisco(listaB[i]) + "     ";
                else
                    linea += "  |  " + "     ";

                // Torre C.
                if (i < listaC.Count)
                    linea += CentrarDisco(listaC[i]);
                else
                    linea += "  |  ";

                Console.WriteLine(linea);
            }

            Console.WriteLine("-----     -----     -----\n");
        }

        static string CentrarDisco(int tamaño)
        {
            string disco = new string('█', tamaño * 2 - 1);
            return disco.PadLeft(tamaño + 1).PadRight(5);
        }

        static bool ValidarEntrada(string desde, string hacia)
        {
            if (string.IsNullOrEmpty(desde) || string.IsNullOrEmpty(hacia))
                return false;

            if (desde != "A" && desde != "B" && desde != "C")
                return false;

            if (hacia != "A" && hacia != "B" && hacia != "C")
                return false;

            return desde != hacia;
        }

        static bool Mover(string desde, string hacia)
        {
            Stack<int> origen = ObtenerTorre(desde);
            Stack<int> destino = ObtenerTorre(hacia);

            if (origen == null || destino == null)
                return false;

            if (origen.Count == 0)
                return false;

            int discoOrigen = origen.Peek();

            // Regla fundamental de Hanói: No se puede colocar un disco sobre uno más pequeño.
            if (destino.Count > 0 && destino.Peek() < discoOrigen)
                return false;

            // Realizar movimiento válido.
            origen.Pop();
            destino.Push(discoOrigen);
            return true;
        }

        static Stack<int> ObtenerTorre(string nombre)
        {
            switch (nombre)
            {
                case "A": return torreA;
                case "B": return torreB;
                case "C": return torreC;
                default: return null;
            }
        }
    }
}