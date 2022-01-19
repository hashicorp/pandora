using System.Collections.Generic;

namespace Pandora.Data.Models;

public class ApiDefinition
{
    public string Name { get; set; }
    public List<ConstantDefinition> Constants { get; set; }
    public List<ModelDefinition> Models { get; set; }
    public List<OperationDefinition> Operations { get; set; }
    public List<ResourceIdDefinition> ResourceIds { get; set; }
}