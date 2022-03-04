using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.IotConnectors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedServiceIdentityTypeConstant
{
    [Description("None")]
    None,

    [Description("SystemAssigned")]
    SystemAssigned,
}
