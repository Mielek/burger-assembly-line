using Mielek.Experiments.AssemblyLine;
using Mielek.Experiments.AssemblyLine.Builder.Definitions;

namespace Mielek.Experiments.AssemblyLine.Steps;

public abstract class BaseBunStep : IAssemblyLineStep
{

    protected AddBunStepDefinition definition;

    protected BaseBunStep(AddBunStepDefinition definition) {
        this.definition = definition;
    }

    public abstract string Name { get; }

    public abstract Task ProcessAsync(AssemblyLineContext data);
}