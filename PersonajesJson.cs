namespace EspacioJson;
using System.Text.Json;
using Personajes;
//todo 1) Armar una clase llamada PersonajesJson para guardar y leer desde un archivo Json

public class PersonajesJson
{
    // todo 2) Crear un método llamado GuardarPersonajes que reciba una lista de personajes, el nombre del archivo y lo guarde en formato Json. 
    public void GuardarPersonajes(List<Personaje> listaPersonajes, string nombreArchivo)
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
    //todo 3) Crear un método llamado LeerPersonajes que reciba un nombre de archivo y retorne la lista de personajes incluidos en el Json. 
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
    //todo 4) Crear un método llamado Existe que reciba un nombre de archivo y que retorne un True si existe y tiene datos o False en caso contrario
    public bool Existe(string nombreArchivo)
    {
        if (File.Exists(nombreArchivo))
        {
            FileInfo fileInfo = new(nombreArchivo);
            return fileInfo.Length > 0;
        }
        return false;
    }

}