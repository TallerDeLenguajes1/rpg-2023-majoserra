namespace EspacioMensajes;
using FabricaPersonajes;
using Personajes;
public class Mensajes
{
    public void bienvenida()
    {
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║              BIENVENIDOS             ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Thread.Sleep(1000);

    }
    public void ElegirPersonaje()
    {
        Console.WriteLine("╔═════════════════════╗");
        Console.WriteLine("║  Elije un Personaje ║");
        Console.WriteLine("╚═════════════════════╝");
        Thread.Sleep(1000);
    }

    public void inicioBatalla()
    {
        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine("║            COMIENZA EL             ║");
        Console.WriteLine("║           ENFRETAMIENTO            ║");
        Console.WriteLine("╚════════════════════════════════════╝");

    }
    public void Nombre(string jugador, string enemigo)
    {
        Console.WriteLine("╔══════════════════╗    ╔══════════════════╗");
        Console.WriteLine(@$"        {jugador}               {enemigo}           ");
        Console.WriteLine("╚══════════════════╝    ╚══════════════════╝");
        Thread.Sleep(1000);
    }
    public void MostrarPersonaje(List<Personaje> Lista)
    {
        for (int i = 0; i < Lista.Count; i++)
        {
            Console.WriteLine("╔═           ═╗");
            Console.WriteLine($"   {Lista[i].Nombre}  ");
            Console.WriteLine("╚═           ═╝");

        }
    }
    public void Ganaste()
    {
        Console.WriteLine("╔═════════════════════╗");
        Console.WriteLine("║       GANASTE :)    ║");
        Console.WriteLine("╚═════════════════════╝");
        Thread.Sleep(1000);
    }
    public void Perdiste()
    {
        Console.WriteLine("╔═════════════════════╗");
        Console.WriteLine("║      PERDISTE :(    ║");
        Console.WriteLine("╚═════════════════════╝");
        Thread.Sleep(1000);
    }

    public void MensajeGanador(Personaje winner)
    {
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("       Luego de una Gran Batalla        ");
        Console.WriteLine("          podemos decir que el          ");
        Console.WriteLine("              Ganador es                ");
        Console.WriteLine("                                        ");
        Console.WriteLine($"             {winner.Nombre}                   ");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Thread.Sleep(1000);

        Console.WriteLine("");
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("  Su Caracteristicas son:               ");
        Console.WriteLine($"   Apodo:              ");
        Console.WriteLine($"   Velocidad: {winner.Velocidad}     ");
        Console.WriteLine($"   Destreza:  {winner.Destreza}     ");
        Console.WriteLine($"   Fuerza: {winner.Fuerza}         ");
        Console.WriteLine($"   Armadura: {winner.Armadura}               ");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Thread.Sleep(1000);


    }

}
