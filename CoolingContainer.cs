using System.Runtime.InteropServices.JavaScript;

namespace Containers;

public class CoolingContainer : Container
{
    public string Product { get; private set; }
    public double Temperature { get; private set; }

    public CoolingContainer(double maxLoad, double height, double depth, double weight) : base("C", maxLoad, height, depth, weight)
    {
        Product = string.Empty;
        Temperature = 0;
    }

    private double GetTemperature(string product)
    {
        return product switch
        {
            "Bananas" => 13.3,
            "Chocolate" => 18,
            "Fish" => 2,
            "Meat" => -15,
            "Ice cream" => -18,
            "Frozen pizza" => -30,
            "Cheese" => 7.2,
            "Sausages" => 5,
            "Butter" => 20.5,
            "Eggs" => 19,
            _ => throw new ArgumentException($"Nieobsługiwany typ: {product}")
        };
    }

    public void LoadCargo(double mass, string product, double temperature)
    {
        if (!string.IsNullOrEmpty(product) && Product != product)
            throw new ArgumentException($"Kontener {SerialNumber} przechowuje już inne produkty");
        
        double reqTemp = GetTemperature(product);

        if (temperature < reqTemp)
            throw new ArgumentException($"Temperatura dla {product} jest za niska");

        if (CargoMass + mass > MaxLoad)
            throw new OverfillException($"Ladownosc kontenera {SerialNumber} przekroczona");
        
        Product = product;
        Temperature = temperature;

        base.LoadCargo(mass);
    }
}