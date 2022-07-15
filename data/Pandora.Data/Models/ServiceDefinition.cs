using System.Collections.Generic;

namespace Pandora.Data.Models;

public class ServiceDefinition
{
    public bool Generate { get; set; }
    public bool ResourceManager { get; set; }
    public string? ResourceProvider { get; set; }
    public string? TerraformPackageName { get; set; }
    public string Name { get; set; }
    public IEnumerable<VersionDefinition> Versions { get; set; }
}