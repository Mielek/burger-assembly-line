using Mielek.Experiments.AssemblyLine;
using Mielek.Experiments.AssemblyLine.Builder.Definitions;

namespace Mielek.Experiments.AssemblyLine.Steps;

public class DisposeBurgerStep : IAssemblyLineStep
{

    private DisposeBurgerDefinition definition;

    public DisposeBurgerStep(DisposeBurgerDefinition definition) {
        this.definition = definition;
    }

    public string Name => this.definition.Name;

    public Task ProcessAsync(AssemblyLineContext data)
    {
        data.DisposeBurger();
        
        return Task.CompletedTask;
    }

    public override string? ToString()
    {
        return this.Name;
    }
}