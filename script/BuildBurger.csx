// For intelisense
// #r "C:\repos\experiments\c-sharp\csx-in-app\lib\AssemblyLineBuilder\bin\Debug\net6.0\AssemblyLineBuilder.dll"
// #r "C:\repos\experiments\c-sharp\csx-in-app\lib\AssemblyLineBuilderSteps\bin\Debug\net6.0\AssemblyLineBuilderSteps.dll"

using Mielek.Experiments.AssemblyLine.Builder;
using Mielek.Experiments.AssemblyLine.Builder.Definitions;

public class BuildBurger : IAssemblyLineBuilder
{
    public void Build(IAssemblyLineDefinition definition)
    {
        definition
            .AddStep(AddBunStep.WithRyeBun())
            .AddStep(AddMeatStep.WithBeef())
            .AddAfterErrorStep(DisposeBurger.WhenNotCoocked());
    }
}

return new BuildBurger();