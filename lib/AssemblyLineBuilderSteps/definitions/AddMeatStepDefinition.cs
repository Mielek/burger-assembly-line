using Mielek.Experiments.AssemblyLine.Builder;

namespace Mielek.Experiments.AssemblyLine.Builder.Definitions;

public class AddMeatStepDefinition : IAssemblyLineStepDefinition
{

    public AddMeatStepDefinition(string meatType) {
        this.MeatType = meatType;
    }

    public string Name => $"Add {this.MeatType} meat";

    public string MeatType { get; init; }

    public override string? ToString()
    {
        return this.Name;
    }
}