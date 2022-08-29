using Mielek.Experiments.AssemblyLine.Builder;

namespace Mielek.Experiments.AssemblyLine.Builder.Definitions;

public class DisposeBurgerDefinition : IAssemblyLineStepDefinition
{

    public DisposeBurgerDefinition() {
    }

    public string Name => $"Throw burger to bin";

    public override string? ToString()
    {
        return this.Name;
    }
}
