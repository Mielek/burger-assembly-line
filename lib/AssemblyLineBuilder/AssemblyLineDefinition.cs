namespace Mielek.Experiments.AssemblyLine.Builder;

public partial interface IAssemblyLineDefinition {
    public IAssemblyLineDefinition AddStep<T>(T step) where T : IAssemblyLineStepDefinition;
    public IAssemblyLineDefinition AddAfterErrorStep<T>(T step) where T : IAssemblyLineStepDefinition;
}