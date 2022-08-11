using System.Collections.Generic;

namespace Pandora.Data.Models;

public class TerraformResourceTestDefinition
{
    public string BasicConfig { get; set; }
    public string RequiresImportConfig { get; set; }
    public string? CompleteConfig { get; set; }
    public string? TemplateConfig { get; set; }
    public Dictionary<string, List<string>> OtherTests { get; set; }
}