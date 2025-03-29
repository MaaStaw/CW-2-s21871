namespace Containers;

public class ContainerShip
{
    public string Name { get; }
    public int MaxContainers { get; }
    public double MaxWeight { get; }
    private List<Container> containers = new List<Container>();

    public ContainerShip(string name, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (containers.Count > MaxContainers)
            throw new ArgumentException("Za dużo kontenerów na statku");
        if (containers.Sum(c => c.Weight + c.CargoMass) > MaxWeight)
            throw new InvalidOperationException("Przekroczona dopuszczalna masa");
        containers.Add(container);
    }

    public void RemoveContainer(string serialNumber)
    {
        containers.RemoveAll(c => c.SerialNumber == serialNumber);
    }

    public void ReplaceContainer(string serialNumberReplace, string serialNumber)
    {
        var index = containers.FindIndex(c => c.SerialNumber == serialNumberReplace);
        if (index != -1)
        {
            var newContainer = containers.First(c => c.SerialNumber == serialNumber);
            if (newContainer != null)
            {
                containers[index] = newContainer;
                Console.WriteLine($"Kontener {serialNumberReplace} został zastąpiony kontenerem {serialNumber}");
            }
            else
            {
                Console.WriteLine($"Nie znaleziono kontenera {serialNumber}");
            }
        }
        else
        {
            Console.WriteLine($"Nie znaleziono kontenera {serialNumberReplace}");
        }
    }

    public void ShipInfo()
    {
        Console.WriteLine($"Statek {Name} - Max Containers: {MaxContainers} - Max Weight: {MaxWeight}");
        Console.WriteLine("Załadowane kontenery:");
        foreach (var container in containers)
        {
            Console.WriteLine(container);
        }
    }
}