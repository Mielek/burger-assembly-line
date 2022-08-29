using Mielek.Experiments.AssemblyLine;
using Mielek.Experiments.AssemblyLine.Builder.Definitions;

namespace Mielek.Experiments.AssemblyLine.Steps;

public class AddBottomBunSliceStep : BaseBunStep
{

    public AddBottomBunSliceStep(AddBunStepDefinition definition) : base(definition) { }

    public override string Name => $"Add bottom {this.definition.Bun} slice";

    public override Task ProcessAsync(AssemblyLineContext data)
    {
        if(data.TryPopParameter("BottomBunSlice", out var bun)) {
            data.AddBurgerLayer($"Bottom {bun} slice");
        } else {
            throw new Exception("BottomBunSlice");
        }

        return Task.CompletedTask;
    }
}