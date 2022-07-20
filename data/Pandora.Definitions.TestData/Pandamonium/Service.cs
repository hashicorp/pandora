using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.TestData.Pandamonium;

public class Service : ServiceDefinition
{
    /*
     * Pandamonium is a fake service exclusively for testing Pandora which is now disabled by default
     * 
     * This needs to be conditionally enabled in `data/Pandora.Data/ServiceDefinitions.cs` to be loaded
     */

    public string Name => "Pandamonium";
    public bool Generate => true;
    public string? ResourceProvider => "Microsoft.Blah";

    public string? TerraformPackageName => "pandamonium";
    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>();
}