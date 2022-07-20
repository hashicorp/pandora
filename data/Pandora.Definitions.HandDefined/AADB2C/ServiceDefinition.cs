using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.HandDefined.AADB2C;

public class Service : ServiceDefinition
{
    public string Name => "AADB2C";
    public string? ResourceProvider => "Microsoft.AzureActiveDirectory";

    public string? TerraformPackageName => "aadb2c";
    public bool Generate => true;

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>();
}