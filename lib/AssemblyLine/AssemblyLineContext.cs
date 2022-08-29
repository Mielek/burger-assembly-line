using System.Collections.Generic;

namespace Mielek.Experiments.AssemblyLine;

public class AssemblyLineContext
{

    private List<string> burger = new List<string>();

    private Dictionary<string, string> parameters = new Dictionary<string, string>();

    public AssemblyLineContext()
    {
    }

    public void AddBurgerLayer(string layer)
    {
        this.burger.Add(layer);
        Console.WriteLine($"{layer} layer added");
    }

    public void PushParameter(string name, string value)
    {
        this.parameters.Add(name, value);
    }

    public bool TryPopParameter(string name, out string? value)
    {
        if (this.parameters.ContainsKey(name))
        {
            value = this.parameters[name];
            this.parameters.Remove(name);
            return true;
        }
        value = default;
        return false;
    }

    public bool ContainsBurger() {
        return this.burger.Count > 0;
    }

    public void DisposeBurger() {
        this.burger.Clear();
        Console.WriteLine("Burger Disposed");
    }

    public void PrintBurger()
    {
        Console.WriteLine("Created burger");
        foreach (var layer in this.burger)
        {
            Console.WriteLine(layer);
        }
    }

    public void ReportError(Exception e) {
        Console.WriteLine(e.Message);
    }
}
