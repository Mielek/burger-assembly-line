
using Mielek.Experiments.AssemblyLine.Builder;

namespace Mielek.Experiments.AssemblyLine.Builder.Definitions;

public class AddBunStep
{
    public static AddBunStep WheatBun()
    {
        return new AddBunStep("Wheat");
    }
    public static AddBunStepDefinition WithWheatBun()
    {
        return AddBunStep.WheatBun().Build();
    }
    public static AddBunStep RyeBun()
    {
        return new AddBunStep("Rye");
    }
    public static AddBunStepDefinition WithRyeBun()
    {
        return AddBunStep.RyeBun().Build();
    }


    private string flour;
    private string? additionalIngridient;
    private string? topping;

    public AddBunStep(string flour)
    {
        this.flour = flour;
    }

    public AddBunStep WithAdditionalIngridient(string additionalIngridient)
    {
        this.additionalIngridient = additionalIngridient;
        return this;
    }

    public AddBunStep WithTopping(string topping)
    {
        this.topping = topping;
        return this;
    }

    public AddBunStepDefinition Build()
    {
        return new AddBunStepDefinition(this.flour, this.additionalIngridient, this.topping);
    }
}