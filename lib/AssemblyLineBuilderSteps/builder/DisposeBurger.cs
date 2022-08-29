
using Mielek.Experiments.AssemblyLine.Builder;

namespace Mielek.Experiments.AssemblyLine.Builder.Definitions;

public static class DisposeBurger {
    public static DisposeBurgerDefinition WhenNotCoocked() {
        return new DisposeBurgerDefinition();
    }
}