using System.Threading.Tasks;

namespace Mielek.Experiments.AssemblyLine;

public interface IAssemblyLineStep {
    public string Name { get; }
    public Task ProcessAsync(AssemblyLineContext data);
}