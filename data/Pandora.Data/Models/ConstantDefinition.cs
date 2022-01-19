using System.Collections.Generic;

namespace Pandora.Data.Models;

public class ConstantDefinition
{
    // NOTE: these intentionally map to String Enum's - other types of Enums are explictly unsupported
    // (since the ARM API doesn't contain any, and integer enum's can instead be an integer with validation)

    public bool CaseInsensitive { get; set; }
    public ConstantType Type { get; set; }
    public string Name { get; set; }
    public Dictionary<string, string> Values { get; set; }
}