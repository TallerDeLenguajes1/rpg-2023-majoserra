using Personajes;
using FabricaPersonajes;
using System.Text.Json;
using EspacioMensajes;
using System.Collections.Generic;
internal class Program
{
    private static void Main(string[] args)
    {
        //creamos una instancia para Random
        Random rand = new Random();
        //creamos una instacia para lista personajes
        List<Personaje> Lista = new List<Personaje>();
        //creamos una instancia para fabrica de personajes
        FabricaDePersonajes Crear = new();
        //definimos la cantidad de personajes
        int cantPersonajes = 10;
        //cargamos la lista de los personajes
        Lista = Crear.ListaPersonaje(cantPersonajes);
        //guardamos los personajes en un archivo json
        GuardarPersonajes(Lista, "Personajes.json");
        //mostramos a los personajes

        // for (int i = 0; i < cantPersonajes; i++)
        // {
        //     Console.WriteLine("╔═════════════════ Personaje {0} ════════════════╗", i); Console.WriteLine(Lista[i].MostrarPersonaje());
        //     Console.WriteLine("╚══════════════════════════════════════════════╝");
        // }

        //Presentamos a los Jugadores
        //insetar mensaje de Bienvenida
        Mensajes msj = new Mensajes();
        msj.bienvenida();

        msj.MostrarPersonaje(Lista);

        int seleccionado;
        bool anda;
        do
        {
            msj.ElegirPersonaje();
            anda = int.TryParse(Console.ReadLine(), out seleccionado);
        } while (seleccionado >= Lista.Count); //Controlamos que no se ingrese un personaje inexistente

        Console.Clear();
        if (anda)
        {
            var jugador = Lista[seleccionado];
            //eliminamos al jugador de la lista
            Lista.Remove(jugador);
            var Enemigo = Lista[rand.Next(0, Lista.Count)];
            Lista.Remove(Enemigo);

            int band = 1;

            do
            {

                msj.inicioBatalla();

                //tenemos que elegir un Enemigo (Lo haremos de manera aleatoria)

                msj.Nombre(jugador.Nombre, Enemigo.Nombre);

                //SORTEAMOS QUIEN COMIENZA
                int inicio;

                inicio = rand.Next(2);
                //BATALLA

                do
                {
                    //constante de Ajuste
                    int constAjuste = 500;
                    if (inicio == 0)
                    {
                        int ataque = jugador.Destreza * jugador.Fuerza * jugador.Nivel;
                        int efectividad = rand.Next(1, 101);

                        int defensa = Enemigo.Armadura * Enemigo.Velocidad;

                        int danioprovocado = ((ataque * efectividad) - defensa) / constAjuste;

                        Enemigo.Salud -= danioprovocado;
                        inicio = 1;
                    }
                    else
                    {
                        int ataque = Enemigo.Destreza * Enemigo.Fuerza * Enemigo.Nivel;
                        int efectividad = rand.Next(1, 101);

                        int defensa = jugador.Armadura * jugador.Velocidad;

                        int danioprovocado = ((ataque * efectividad) - defensa) / constAjuste;

                        jugador.Salud -= danioprovocado;

                        inicio = 0;
                    }

                } while (jugador.Salud >= 0 && Enemigo.Salud >= 0);

                Console.WriteLine("Salud Jugador: " + jugador.Salud);
                Console.WriteLine("salud Enemigo: " + Enemigo.Salud);


                if (jugador.Salud > 0) //jugador gano
                {
                    msj.Ganaste();
                    jugador.Salud = 100; //recargamos vida
                    if (Lista.Count != 0)
                    {
                        Enemigo = Lista[rand.Next(0, Lista.Count)];
                        Lista.Remove(Enemigo);
                    }
                    else
                    {
                        band = 0;
                    }
                }
                else
                {
                    Enemigo.Salud = 100;
                    msj.Perdiste();

                    //Tenemos que elegir otro personaje 
                    if (Lista.Count != 0)
                    {
                        msj.MostrarPersonaje(Lista);

                        int cambio;
                        bool func;
                        do
                        {
                            msj.ElegirPersonaje();
                            func = int.TryParse(Console.ReadLine(), out cambio);
                        } while (cambio >= Lista.Count); //Controlamos que no se ingrese un personaje inexistente

                        if (func)
                        {
                            jugador = Lista[cambio];
                            Lista.Remove(jugador);
                        }
                    }
                    else
                    {
                        band = 0;
                    }

                }



            } while (Lista.Count >= 0 && band != 0);
            var Ganador = new Personaje();
            if (Enemigo.Salud == 100)
            {
                Ganador = Enemigo;

            }
            else
            {
                Ganador = jugador;
            }
            msj.MensajeGanador(Ganador);
        }





    }
    public static void GuardarPersonajes(List<Personaje> listaPersonajes, string nombreArchivo)
    {
        string personajesJson = JsonSerializer.Serialize(listaPersonajes);
        using (FileStream archivoAbierto = new(nombreArchivo, FileMode.OpenOrCreate))
        {
            using (StreamWriter archivoEscribir = new(archivoAbierto))
            {
                archivoEscribir.WriteLine(personajesJson);
                archivoEscribir.Close();
            }
        }
    }
    public List<Personaje>? LeerPersonajes(string nombreArchivo)
    {
        string documentoJson;
        using (FileStream archivoAbierto = new(nombreArchivo, FileMode.Open))
        {
            using (StreamReader archivoLeer = new(archivoAbierto))
            {
                documentoJson = archivoLeer.ReadToEnd();
                archivoLeer.Close();
            }
        }
        var listadoPersonajes = JsonSerializer.Deserialize<List<Personaje>>(documentoJson);
        return listadoPersonajes;
    }
    /*public bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                FileInfo fileInfo = new(nombreArchivo);
                return fileInfo.Length > 0;
            }
            return false;
        }*/
}

