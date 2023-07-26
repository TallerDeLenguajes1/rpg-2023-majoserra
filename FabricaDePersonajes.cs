using Personajes;
using System.Collections.Generic;

//* 1) Genere una clase para poder crear personajes aleatorios que se llame FabricaDePersonajes 
namespace FabricaPersonajes
{
    public class FabricaDePersonajes
    {
        //Creamos la lista de nombres
        List<string> nombres = new List<string>{
            "Italo",
            "Jan",
            "Arthur",
            "Tokio",
            "Seul",
            "Berlin",
            "Rio",
            "Nairobi",
            "Lisboa",
            "Capullo"
        };
        //Creamos la lista de Apodos
        List<string> apodos = new List<string>{
            "cuchi",
            "pichi",
            "negro",
            "capu",
            "cuchi",
            "pichi",
            "negro",
            "capu",
            "capu",
            "hachi"
        };
        //Creamos al personaje
        public Personaje crearPersonaje()
        {
            //creamos una instancia para un nuevo Personaje
            var nuevo = new Personaje();
            //Creamos una instancia para Random
            var random = new Random();
            //asignamos apodo y nombre
            int numeroAleatorio = random.Next(nombres.Count);
            nuevo.Nombre = nombres[numeroAleatorio];
            nuevo.Apodo = apodos[numeroAleatorio];
            //asignamos tipo de personaje
            //como estamos trabajando con una enum primero obtendrenos el total de elementos de la enum
            int totalTipos = Enum.GetValues(typeof(tipoP)).Length;
            nuevo.Tipo = (tipoP)random.Next(0, totalTipos);
            nuevo.Salud = 100;
            //dividimos segun el tipo de personaje (para equilibrar los personajes)
            switch (nuevo.Tipo)
            {
                case tipoP.artimago:
                    nuevo.Velocidad = random.Next(4, 7);
                    nuevo.Destreza = random.Next(1, 3);
                    nuevo.Fuerza = random.Next(6, 11);
                    nuevo.Nivel = random.Next(5, 7);
                    nuevo.Armadura = random.Next(3, 10);
                    nuevo.Edad = random.Next(0, 300);
                    break;
                case tipoP.valkiria:
                    nuevo.Velocidad = random.Next(4, 7);
                    nuevo.Destreza = random.Next(1, 3);
                    nuevo.Fuerza = random.Next(6, 11);
                    nuevo.Nivel = random.Next(5, 7);
                    nuevo.Armadura = random.Next(3, 10);
                    nuevo.Edad = random.Next(0, 300);
                    break;
                case tipoP.samurai:
                    nuevo.Velocidad = random.Next(4, 7);
                    nuevo.Destreza = random.Next(1, 3);
                    nuevo.Fuerza = random.Next(6, 11);
                    nuevo.Nivel = random.Next(5, 7);
                    nuevo.Armadura = random.Next(3, 10);
                    nuevo.Edad = random.Next(0, 300);
                    break;
                case tipoP.gladiador:
                    nuevo.Velocidad = random.Next(4, 7);
                    nuevo.Destreza = random.Next(1, 3);
                    nuevo.Fuerza = random.Next(6, 11);
                    nuevo.Nivel = random.Next(5, 7);
                    nuevo.Armadura = random.Next(3, 10);
                    nuevo.Edad = random.Next(0, 300);
                    break;
                case tipoP.mercenario:
                    nuevo.Velocidad = random.Next(4, 7);
                    nuevo.Destreza = random.Next(1, 3);
                    nuevo.Fuerza = random.Next(6, 11);
                    nuevo.Nivel = random.Next(5, 7);
                    nuevo.Armadura = random.Next(3, 10);
                    nuevo.Edad = random.Next(0, 300);
                    break;

            }
            return nuevo;
        }

        //creamos lista de Personajes
        public List<Personaje> ListaPersonaje(int cantPersonaje)
        {
            var lista = new List<Personaje>();
            int cant = 0;
            while (cant < cantPersonaje)
            {
                //creamos personaje
                var personaje = crearPersonaje();
                //controlamos que los nombres no se repitan 
                if (personaje.Nombre != null)
                {
                    nombres.Remove(personaje.Nombre); //quitamos el nombre de la lista
                }
                cant = cant + 1;
                //agregamos personaje a la lista
                lista.Add(personaje);
            }
            return lista;
        }
    }
}