using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.DedicatedHosts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InstanceViewTypesConstant
{
    [Description("instanceView")]
    InstanceView,

    [Description("userData")]
    UserData,
}
