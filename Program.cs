using Personajes;
using FabricaPersonajes;
using System.Text.Json;
using System.Collections.Generic;
internal class Program
{
    private static void Main(string[] args)
    {
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
        for (int i = 0; i < cantPersonajes; i++)
            {
                Console.WriteLine("╔═════════════════ Personaje {0} ════════════════╗", i);
                Console.WriteLine(Lista[i].MostrarPersonaje());
                Console.WriteLine("╚══════════════════════════════════════════════╝");     
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

        