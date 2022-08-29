using Mielek.Experiments.AssemblyLine;
using Mielek.Experiments.AssemblyLine.Builder.Definitions;

namespace Mielek.Experiments.AssemblyLine.Steps;

public class AddMeatStep : IAssemblyLineStep
{

    private AddMeatStepDefinition definition;

    public AddMeatStep(AddMeatStepDefinition definition) {
        this.definition = definition;
    }

    public string Name => this.definition.Name;

    public Task ProcessAsync(AssemblyLineContext data)
    {
        if(new Random().NextDouble() > 0.5d) {
            throw new Exception("Meat dropped on the floor");
        }
        data.AddBurgerLayer(this.definition.MeatType);

        return Task.CompletedTask;
    }

    public override string? ToString()
    {
        return this.Name;
    }
}