using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ExtendedLocation.v2021_08_15.CustomLocations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HostTypeConstant
{
    [Description("Kubernetes")]
    Kubernetes,
}
