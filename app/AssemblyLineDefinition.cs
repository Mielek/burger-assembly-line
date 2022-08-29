
using Mielek.Experiments.AssemblyLine;
using Mielek.Experiments.AssemblyLine.Builder;
using Mielek.Experiments.AssemblyLine.Builder.Definitions;
using Mielek.Experiments.AssemblyLine.Steps;

public class AssemblyLineDefinition : IAssemblyLineDefinition
{
    private List<IAssemblyLineStep> prepSteps = new List<IAssemblyLineStep>();
    private List<IAssemblyLineStep> steps = new List<IAssemblyLineStep>();
    private List<IAssemblyLineStep> postSteps = new List<IAssemblyLineStep>();
    private List<IAssemblyLineStep> afterErrorSteps = new List<IAssemblyLineStep>();

    public IAssemblyLineDefinition AddStep<T>(T step) where T : IAssemblyLineStepDefinition
    {
        switch(step) {
            case AddBunStepDefinition bun: 
                    this.prepSteps.Add(new SliceBunStep(bun));
                    this.steps.Add(new AddBottomBunSliceStep(bun));
                    this.postSteps.Add(new AddTopBunSliceStep(bun));
                break;
            case AddMeatStepDefinition meat: 
                    this.steps.Add(new Mielek.Experiments.AssemblyLine.Steps.AddMeatStep(meat));
            break;
            default:
                throw new NotImplementedException($"Not implemented {step.Name} step");
        }
        return this;
    }

    public IAssemblyLineDefinition AddAfterErrorStep<T>(T step) where T : IAssemblyLineStepDefinition
    {
        switch(step) {
            case DisposeBurgerDefinition dispose: 
                    this.afterErrorSteps.Add(new DisposeBurgerStep(dispose));
                break;
            default:
                throw new NotImplementedException($"Not implemented {step.Name} step for after error");
        }
        return this;
    }

    public AssemblyLine BuildAssemblyLine() {
        var steps = new List<IAssemblyLineStep>();
        steps.AddRange(this.prepSteps);
        steps.AddRange(this.steps);
        steps.AddRange(this.postSteps);
        return new AssemblyLine(steps, this.afterErrorSteps);
    }
}