public abstract class Vehiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public abstract void Conducir();
    public virtual void Detener()
    {
        //base.Detener();
        Console.WriteLine("El cohe se detuvo de forma segura.");
    }
}

public class Coche : Vehiculo
{
    public override void Conducir() 
    {

        Console.WriteLine($"Estoy conduciendo un coche de marca: {Marca} y modelo: {Modelo}");
    }

    public override void Detener() 
    { 
        //base.Detener();
        Console.WriteLine("El coche se detuvo de forma segura.");
    }
}

public class Bicileta : Vehiculo
{
    public override void Conducir()
    {
        Console.WriteLine($"Pedaliendo la bicicle {Marca} {Modelo}");
    }
}
