using System.Text;

using Mielek.Experiments.AssemblyLine.Builder;

namespace Mielek.Experiments.AssemblyLine.Builder.Definitions;

public class AddBunStepDefinition : IAssemblyLineStepDefinition
{

    public AddBunStepDefinition(string flour, string? additionalIngridient, string? topping)
    {
        this.Flour = flour;
        this.AdditionalIngridient = additionalIngridient;
        this.Topping = topping;
    }

    public string Name => $"Add {this.Bun}";

    public string Bun
    {
        get
        {
            var bun = $"{this.Flour} bun";
            if (this.AdditionalIngridient != null)
            {
                bun += $" with {this.AdditionalIngridient} inside";
            }

            if (this.Topping != null)
            {
                bun += $" with {this.Topping} topping";
            }

            return bun;
        }
    }

    public string Flour { get; init; }
    public string? AdditionalIngridient { get; init; }
    public string? Topping { get; init; }

    public override string? ToString()
    {
        return this.Name;
    }
}
