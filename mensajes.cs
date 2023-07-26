namespace EspacioMensajes;
using FabricaPersonajes;
using Personajes;
public class Mensajes
{
    public void bienvenida()
    {
        Console.WriteLine(@"
██████╗░██╗███████╗███╗░░██╗██╗░░░██╗███████╗███╗░░██╗██╗██████╗░░█████╗░░██████╗
██╔══██╗██║██╔════╝████╗░██║██║░░░██║██╔════╝████╗░██║██║██╔══██╗██╔══██╗██╔════╝
██████╦╝██║█████╗░░██╔██╗██║╚██╗░██╔╝█████╗░░██╔██╗██║██║██║░░██║██║░░██║╚█████╗░
██╔══██╗██║██╔══╝░░██║╚████║░╚████╔╝░██╔══╝░░██║╚████║██║██║░░██║██║░░██║░╚═══██╗
██████╦╝██║███████╗██║░╚███║░░╚██╔╝░░███████╗██║░╚███║██║██████╔╝╚█████╔╝██████╔╝
╚═════╝░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝╚═╝░░╚══╝╚═╝╚═════╝░░╚════╝░╚═════╝░");
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
            Console.WriteLine(" ╔═           ═╗");
            Console.WriteLine("     " + i + "-" + $"{Lista[i].Nombre}  ");
            Console.WriteLine(" ╚═           ═╝");

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
        Console.WriteLine($"   Apodo: {winner.Apodo}             ");
        Console.WriteLine($"   Nombre: {winner.Nombre}            ");
        Console.WriteLine($"   Edad: {winner.Edad}              ");
        Console.WriteLine($"   Salud: {winner.Salud}             ");
        Console.WriteLine($"   Nivel: {winner.Nivel}             ");
        Console.WriteLine($"   Tipi: {winner.Tipo}             ");
        Console.WriteLine($"   Velocidad: {winner.Velocidad}     ");
        Console.WriteLine($"   Destreza:  {winner.Destreza}      ");
        Console.WriteLine($"   Fuerza: {winner.Fuerza}           ");
        Console.WriteLine($"   Armadura: {winner.Armadura}       ");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Thread.Sleep(1000);
    }

    public void Presentacion(List<Personaje> Lista)
    {
        Console.WriteLine("");
        Console.WriteLine("╔══════════════════════════════════════╗");
        for (int i = 0; i < Lista.Count; i++)
        {
            Console.WriteLine("    ________________________________      ");
            Console.WriteLine($"   Apodo: {Lista[i].Apodo}             ");
            Console.WriteLine($"   Nombre: {Lista[i].Nombre}            ");
            Console.WriteLine($"   Edad: {Lista[i].Edad}              ");
            Console.WriteLine($"   Salud: {Lista[i].Salud}             ");
            Console.WriteLine($"   Nivel: {Lista[i].Nivel}             ");
            Console.WriteLine($"   Tipi: {Lista[i].Tipo}             ");
            Console.WriteLine($"   Velocidad: {Lista[i].Velocidad}     ");
            Console.WriteLine($"   Destreza:  {Lista[i].Destreza}      ");
            Console.WriteLine($"   Fuerza: {Lista[i].Fuerza}           ");
            Console.WriteLine($"   Armadura: {Lista[i].Armadura}       ");
            Console.WriteLine("    ________________________________      ");
        }
        Console.WriteLine("╚══════════════════════════════════════╝");
        Thread.Sleep(1000);

    }
    public void gameover()
    {
        Console.WriteLine(@"
░██████╗░░█████╗░███╗░░░███╗███████╗  ░█████╗░██╗░░░██╗███████╗██████╗░
██╔════╝░██╔══██╗████╗░████║██╔════╝  ██╔══██╗██║░░░██║██╔════╝██╔══██╗
██║░░██╗░███████║██╔████╔██║█████╗░░  ██║░░██║╚██╗░██╔╝█████╗░░██████╔╝
██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░  ██║░░██║░╚████╔╝░██╔══╝░░██╔══██╗
╚██████╔╝██║░░██║██║░╚═╝░██║███████╗  ╚█████╔╝░░╚██╔╝░░███████╗██║░░██║
░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝  ░╚════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝");
    }

}
