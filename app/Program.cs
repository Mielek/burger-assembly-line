// See https://aka.ms/new-console-template for more information

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using System.Reflection;
using System.Collections.Immutable;
using Mielek.Experiments.AssemblyLine.Builder;
using Mielek.Experiments.AssemblyLine.Builder.Definitions;
using Mielek.Experiments.AssemblyLine;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // var loader = new InteractiveAssemblyLoader();
        // loader.RegisterDependency(Assembly.GetAssembly(typeof(IAssemblyLineBuilder)));
        // loader.RegisterDependency(Assembly.GetAssembly(typeof(AddBunStep)));

        // var res = new Resolver();

        var option = ScriptOptions.Default.WithReferences(new[] {
            MetadataReference.CreateFromFile(Assembly.GetAssembly(typeof(IAssemblyLineBuilder)).Location),
            MetadataReference.CreateFromFile(Assembly.GetAssembly(typeof(AddBunStep)).Location),
            });

        var script = CSharpScript.Create<IAssemblyLineBuilder>(File.ReadAllText("../script/BuildBurger.csx"), option);

        var state = await script.RunAsync();


        var obj = state.ReturnValue;

        var assemblyLineDefinition = new AssemblyLineDefinition();
        obj.Build(assemblyLineDefinition);

        var assemblyLine = assemblyLineDefinition.BuildAssemblyLine();

        var assemblyLineContext = new AssemblyLineContext();

        await assemblyLine.ProcessAsync(assemblyLineContext);

        if (assemblyLineContext.ContainsBurger())
        {
            assemblyLineContext.PrintBurger();
        }
        else
        {
            Console.WriteLine("No burger");
        }
    }
}

class Resolver : MetadataReferenceResolver
{
    public override bool Equals(object? other)
    {
        return Object.Equals(this, other);
    }

    public override int GetHashCode()
    {
        return 1;
    }

    public override ImmutableArray<PortableExecutableReference> ResolveReference(string reference, string? baseFilePath, MetadataReferenceProperties properties)
    {
        Console.WriteLine(reference);
        Console.WriteLine(properties.Aliases.IsEmpty);
        Console.WriteLine(properties.EmbedInteropTypes);
        Console.WriteLine(properties.Kind);
        Console.WriteLine();
        return ImmutableArray.Create<PortableExecutableReference>();
    }
}