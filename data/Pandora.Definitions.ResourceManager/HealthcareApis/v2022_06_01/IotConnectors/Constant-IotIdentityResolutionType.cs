using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2022_06_01.IotConnectors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IotIdentityResolutionTypeConstant
{
    [Description("Create")]
    Create,

    [Description("Lookup")]
    Lookup,
}
