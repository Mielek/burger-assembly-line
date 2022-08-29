using Mielek.Experiments.AssemblyLine;
using Mielek.Experiments.AssemblyLine.Builder.Definitions;

namespace Mielek.Experiments.AssemblyLine.Steps;

public class AddTopBunSliceStep : BaseBunStep
{

    public AddTopBunSliceStep(AddBunStepDefinition definition) : base(definition) { }

    public override string Name => $"Add top {this.definition.Bun} slice";

    public override Task ProcessAsync(AssemblyLineContext data)
    {
        if(data.TryPopParameter("TopBunSlice", out var bun)) {
            data.AddBurgerLayer($"Top {bun} slice");
        } else {
            throw new Exception("TopBunSlice");
        }

        return Task.CompletedTask;
    }
}