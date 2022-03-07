namespace Pandora.Data.Models;

public class OptionDefinition
{
    public string? HeaderName { get; set; }

    public string? QueryStringName { get; set; }

    public string Name { get; set; }

    public ObjectDefinition ObjectDefinition { get; set; }

    // NOTE: whilst in properties it makes sense to differentiate between Required and Optional
    // (since they can be read-only) in Settings these are binary - so these can be represented
    // as a single field. 
    public bool Required { get; set; }
}