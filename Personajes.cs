using System;
namespace Personajes;

public enum tipoP
{
    valkiria,
    samurai,
    gladiador,
    mercenario,
    artimago
}
public class Personaje
{
    //Caracteristicas
    private int velocidad;
    private int destreza;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int salud;

    //Datos 
    private tipoP tipo;
    private string? nombre;
    private string? apodo;
    private DateTime fecnac;

    private int edad;

    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }
    public tipoP Tipo { get => tipo; set => tipo = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apodo { get => apodo; set => apodo = value; }
    public DateTime Fecnac { get => fecnac; set => fecnac = value; }
    public int Edad { get => edad; set => edad = value; }
}