namespace Pandora.Data.Models;

public class TerraformResourceDefinition
{
    public TerraformMethodDefinition DeleteMethod { get; set; }
    public string DisplayName { get; set; }
    public bool GenerateIDValidationFunction { get; set; }
    public bool GenerateSchema { get; set; }
    public string Resource { get; set; }
    public string ResourceIdName { get; set; }
    public string ResourceLabel { get; set; }
    public string ResourceName { get; set; }
}