using Mielek.Experiments.AssemblyLine;
using Mielek.Experiments.AssemblyLine.Builder.Definitions;

namespace Mielek.Experiments.AssemblyLine.Steps;

public class SliceBunStep : BaseBunStep
{

    public SliceBunStep(AddBunStepDefinition definition) : base(definition) { }

    public override string Name => $"Slice {this.definition.Bun}";

    public override Task ProcessAsync(AssemblyLineContext data)
    {
        data.PushParameter("BottomBunSlice", this.definition.Bun);
        data.PushParameter("TopBunSlice", this.definition.Bun);
        Console.WriteLine("Burger sliced");
        return Task.CompletedTask;
    }
}