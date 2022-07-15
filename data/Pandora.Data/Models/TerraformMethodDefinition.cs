namespace Pandora.Data.Models;

public class TerraformMethodDefinition
{
    public bool Generate { get; set; }
    public string MethodName { get; set; }
    public int TimeoutInMinutes { get; set; }
}