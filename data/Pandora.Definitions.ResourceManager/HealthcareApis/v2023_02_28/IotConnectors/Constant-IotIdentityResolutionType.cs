using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_02_28.IotConnectors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IotIdentityResolutionTypeConstant
{
    [Description("Create")]
    Create,

    [Description("Lookup")]
    Lookup,
}
