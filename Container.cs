namespace Containers;

public abstract class Container
{
    public double CargoMass { get; set; }
    public double Height { get; }
    public double Weight { get; }
    public double Depth { get; }
    public string SerialNumber { get; }
    public double MaxLoad { get; }
    private static int number = 1;

    protected Container(string type, double maxLoad, double height, double depth, double weight)
    {
        Height = height;
        Weight = weight;
        Depth = depth;
        SerialNumber = $"KON-{type}-{number++}";
        MaxLoad = maxLoad;
    }

    public virtual void LoadCargo(double mass)
    {
        if (CargoMass + mass > MaxLoad)
            throw new OverfillException($"Przeladowanie w kontenerze {SerialNumber}");
                
        CargoMass += mass;
    }

    public virtual void UnloadCargo()
    {
        CargoMass = 0;
    }

    public override string ToString()
    {
        return $"Cargo: {SerialNumber} - {CargoMass}/{MaxLoad} kg";
    }
}