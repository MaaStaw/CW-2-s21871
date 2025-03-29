namespace Containers;

public class GasContainer : Container, IHazardNotifier
{
    private double Pressure { get; }

    public GasContainer(double maxLoad, double height, double depth, double weight, double pressure) : base("G", maxLoad, height, depth, weight)
    {
        Pressure = pressure;
    }

    public override void UnloadCargo()
    {
        CargoMass *= 0.05;
    }

    public void Notification(string number, string mess)
    {
        Console.WriteLine($"{number}: {mess}");
    }
}