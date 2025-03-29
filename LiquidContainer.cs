namespace Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool isHazardous;
    
    public LiquidContainer(double maxLoad, double height, double depth, double weight, bool isHazardous) : base("L", maxLoad, height,
        depth, weight)
    {
        this.isHazardous = isHazardous;
    }

    public override void LoadCargo(double mass)
    {
        double limit = isHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
        if (mass > limit)
        {
            Notification(SerialNumber, "Przekroczona dopuszczalna ladownosc!");
            throw new OverfillException($"Przeladowanie w kontenerze {SerialNumber}");
        }
        
        base.LoadCargo(mass);
    }

    public void Notification(string number, string mess)
    {
        Console.WriteLine($"{number}: {mess}");
    }
}