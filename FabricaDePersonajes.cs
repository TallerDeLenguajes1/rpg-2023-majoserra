namespace FabricaPersonajes
{
    using Personajes;

    public class FabricaDePersonajes
    {

        //Creamos al personaje
        public Personaje nuevoP(string? nombre, tipoP tipo, string? apodo)
        {
            //creamos una instancia para un nuevo Personaje
            var nuevo = new Personaje();

            nuevo.Nombre = nombre;
            nuevo.Tipo = tipo;
            nuevo.Apodo = apodo;

            //Creamos una instancia para Random
            var random = new Random();

            if (nuevo.Tipo == tipoP.artimago)
            {

                nuevo.Velocidad = random.Next(4, 7);
                nuevo.Destreza = random.Next(1, 3);
                nuevo.Fuerza = random.Next(6, 11);
                nuevo.Nivel = random.Next(5, 7);
                nuevo.Armadura = random.Next(3, 10);
                nuevo.Edad = random.Next(0, 300);
            }

        }
    }
}