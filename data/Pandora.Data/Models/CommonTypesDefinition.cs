using System.Collections.Generic;

namespace Pandora.Data.Models;

public class CommonTypesDefinition
{
    public ServiceDefinitionType ServiceDefinitionType { get; set; }
    public IEnumerable<ConstantDefinition> Constants { get; set; }
    public IEnumerable<ModelDefinition> Models { get; set; }
}
