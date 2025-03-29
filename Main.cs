using Containers;

class Program
{
    static void Main()
    {
        try
        {
            CoolingContainer container = new CoolingContainer(1000, 10, 10, 500);
            Console.WriteLine(container);

            container.LoadCargo(500, "Bananas", 13.3);
            Console.WriteLine(container);

            container.UnloadCargo();
            Console.WriteLine(container);
            
        }
        catch(Exception e)
        {
            Console.WriteLine($"Exception: {e}");
        }
    }
}