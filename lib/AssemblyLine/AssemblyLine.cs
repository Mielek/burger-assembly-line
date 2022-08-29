using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mielek.Experiments.AssemblyLine;

public sealed class AssemblyLine
{
    private IEnumerable<IAssemblyLineStep> assemblySteps;
    private IEnumerable<IAssemblyLineStep> afterErrorSteps;

    public AssemblyLine(
        IEnumerable<IAssemblyLineStep> assemblySteps,
        IEnumerable<IAssemblyLineStep> afterErrorSteps)
    {
        this.assemblySteps = assemblySteps;
        this.afterErrorSteps = afterErrorSteps;
    }

    public AssemblyLine(IEnumerable<IAssemblyLineStep> assemblySteps)
        : this(assemblySteps, Enumerable.Empty<IAssemblyLineStep>())
    {
    }

    public async Task ProcessAsync(AssemblyLineContext context)
    {
        try {
            await this.ProcessAsync(this.assemblySteps, context);
        } catch(Exception e) {
            context.ReportError(e);
            await this.ProcessAsync(this.afterErrorSteps, context);
        }
    }

    private async Task ProcessAsync(IEnumerable<IAssemblyLineStep> steps, AssemblyLineContext context) {
        foreach (var step in steps)
        {
            await step.ProcessAsync(context);
        }
    }
}
