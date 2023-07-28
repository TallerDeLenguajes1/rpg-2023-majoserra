using System;
using Personajes;
using FabricaPersonajes;
using EspacioMensajes;
using EspacioTrivia;
using System.Collections.Generic;
using EspacioJson;
internal class Program
{
    private static void Main(string[] args)
    {
        //creamos instancia para Mensajes
        Mensajes msj = new Mensajes();
        //creamos instancia para Preguntas
        var Preguntas = new Root();
        Preguntas = obtenerTrivia.Trivia();

        //creamos instancia para PersonajesJson
        PersonajesJson JsonArchivo = new(); //creamos una instanci

        //creamos una instancia para Random
        Random rand = new Random();

        //todo CREACION PERSONAJE

        List<Personaje> Lista = new List<Personaje>();//creamos una instacia para lista personajes

        int cantPersonajes = 10;//definimos la cantidad de personajes
        const string nombreArchivo = "Personajes.json"; //Nombre del Archivo

        // Verificar al comienzo del Juego si existe el archivo de personajes:

        if (JsonArchivo.Existe(nombreArchivo))
        {
            Lista = JsonArchivo.LeerPersonajes(nombreArchivo); //Si existe y tiene datos cargar los personajes desde el archivo existente. 
        }
        else
        {
            /* Si no existe generar 10 personajes utilizando la clase FabricaDePersonajes y
            guárdelos en el archivo de personajes usando la clase PersonajesJson.*/
            FabricaDePersonajes crear = new();
            Lista = crear.ListaPersonaje(cantPersonajes);
            JsonArchivo.GuardarPersonajes(Lista, nombreArchivo);
        }

        //Hacemos una copia de la lista 
        List<Personaje> ListaCopia = new List<Personaje>();//creamos una instacia para lista personajes
        ListaCopia = Lista.ToList();
        //todo JUEGO
        //insetar mensaje de Bienvenida
        int opcion = 1;
        int selec;
        bool anda1;
        while (opcion == 1)
        {
            Console.Clear();
            msj.bienvenida();
            msj.Menu();
            do
            {
                anda1 = int.TryParse(Console.ReadLine(), out selec);
            } while (selec > 2 || anda1 == false);

            switch (selec)
            {
                case 0:
                    //todo PRESENTACION
                    msj.PersonajesMensaje();
                    //Presentamos a los Jugadores, Muestre por pantalla los datos y características de los personajes cargados.
                    msj.Presentacion(ListaCopia);
                    break;
                case 1:
                    Console.WriteLine("juego");

                    msj.batalla();
                    msj.MostrarPersonaje(Lista);

                    int seleccionado;
                    bool anda;
                    do
                    {
                        msj.ElegirPersonaje();
                        anda = int.TryParse(Console.ReadLine(), out seleccionado);
                    } while (anda == false || seleccionado >= Lista.Count); //Controlamos que no se ingrese un personaje inexistente

                    Console.Clear();
                    if (anda)
                    {
                        //* 1) Elija 2 personajes para que compitan entre ellos.
                        var jugador = Lista[seleccionado];
                        //eliminamos al jugador de la lista
                        Lista.Remove(jugador);
                        //tenemos que elegir un Enemigo (Lo haremos de manera aleatoria)
                        var Enemigo = Lista[rand.Next(0, Lista.Count)];
                        Lista.Remove(Enemigo);

                        int band = 1;
                        int k = 0;

                        do
                        {
                            msj.Nombre(jugador.Nombre, Enemigo.Nombre);
                            Console.WriteLine("");
                            Console.WriteLine("Si Quieres comenzar deberas constestar una Pregunta con \"True o \"False\"");
                            Console.WriteLine("");
                            int inicio;

                            Console.WriteLine("¿ " + Preguntas.results[k].question + " ?");
                            Console.WriteLine("");
                            string? respuesta = Console.ReadLine();
                            if (Preguntas.results[k].correct_answer == respuesta) //* si contestamos bien, ademas de comenzar, recargamos vida
                            {
                                Console.WriteLine("╔═════════════════════════╗");
                                Console.WriteLine("║  Correcto, Comenzas vos ║");
                                Console.WriteLine("╚═════════════════════════╝");
                                jugador.Salud = jugador.Salud + 10;
                                inicio = 0;
                            }
                            else
                            {
                                Console.WriteLine("╔══════════════════════════════════╗");
                                Console.WriteLine("║  Incorrecto, Comienza el Enemigo ║");
                                Console.WriteLine("╚══════════════════════════════════╝");
                                inicio = 1;
                            }
                            k++;
                            //BATALLA

                            do
                            {
                                //* 2) El combate se realiza por turnos. Por cada turno un personaje ataca y el otro se defiende
                                //constante de Ajuste
                                if (inicio == 0)
                                {
                                    int danioprovocado = Batalla(jugador, Enemigo);
                                    Enemigo.Salud = Enemigo.Salud - danioprovocado;
                                    inicio = 1;
                                }
                                else
                                {
                                    int danioprovocado = Batalla(Enemigo, jugador);
                                    jugador.Salud -= danioprovocado;
                                    inicio = 0;
                                }
                            } while (jugador.Salud >= 0 && Enemigo.Salud >= 0); //*3) El combate se mantiene hasta que uno es vencido (salud <= 0)
                            Console.WriteLine("╔══════════════════════════════════╗");
                            Console.WriteLine("  Salud de " + jugador.Nombre + ":" + jugador.Salud);
                            Console.WriteLine("  Salud de " + Enemigo.Nombre + ":" + Enemigo.Salud);
                            Console.WriteLine("╚══════════════════════════════════╝");

                            if (jugador.Salud > 0) //jugador gano
                            {
                                msj.Ganaste();
                                //* 5) El que gane será beneficiado con una mejora en sus habilidades (En este caso recargamos vida)
                                jugador.Salud = 100; //recargamos vida
                                if (jugador.Fuerza < 10)
                                {
                                    jugador.Fuerza = jugador.Fuerza + 1; //Si nuestro jugador gana se vera beneficiado con  uno mas de fuerza
                                }
                                if (Lista.Count != 0)
                                {
                                    Enemigo = Lista[rand.Next(0, Lista.Count)]; //*Seleccionamos un Enemigo (Siguiente Ronda)
                                    Lista.Remove(Enemigo); //*Eliminamos de la Lista
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
                                        string? input = Console.ReadLine();
                                        func = int.TryParse(input, out cambio);
                                    } while (cambio >= Lista.Count || func == false); //Controlamos que no se ingrese un personaje inexistente

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
                            Thread.Sleep(2000);
                            Console.Clear();

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
                    else
                    {
                        Console.WriteLine("No se ingreso un numero corectamente, vuelve a intentarlo");
                    }
                    Thread.Sleep(2500);
                    Console.Clear();
                    msj.gameover();
                    Lista = JsonArchivo.LeerPersonajes(nombreArchivo); //Si existe y tiene datos cargar los personajes desde el archivo existente. 
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("  Desea volver al menu o salir? (menu = 1) (salir = 0) ");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            bool anda2;
            do
            {
                anda2 = int.TryParse(Console.ReadLine(), out opcion);
            } while (anda2 == false || opcion > 1);

            if (opcion == 0)
            {
                Environment.Exit(0);
            }
        }
    }

    public static int Batalla(Personaje jugador, Personaje Enemigo)
    {
        int constAjuste = 500;
        Random rand = new Random();
        int ataque = jugador.Destreza * jugador.Fuerza * jugador.Nivel;
        int efectividad = rand.Next(1, 101);

        int defensa = Enemigo.Armadura * Enemigo.Velocidad;

        int danioprovocado = ((ataque * efectividad) - defensa) / constAjuste;
        return danioprovocado;
    }

}
