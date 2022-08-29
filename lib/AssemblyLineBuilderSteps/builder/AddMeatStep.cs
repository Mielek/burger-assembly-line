
using Mielek.Experiments.AssemblyLine.Builder;

namespace Mielek.Experiments.AssemblyLine.Builder.Definitions;

public static class AddMeatStep {
    public static AddMeatStepDefinition WithBeef() {
        return new AddMeatStepDefinition("Beef");
    }

    public static AddMeatStepDefinition WithPork() {
        return new AddMeatStepDefinition("Pork");
    }
    
    public static AddMeatStepDefinition WithChiken() {
        return new AddMeatStepDefinition("Chiken");
    }
}
