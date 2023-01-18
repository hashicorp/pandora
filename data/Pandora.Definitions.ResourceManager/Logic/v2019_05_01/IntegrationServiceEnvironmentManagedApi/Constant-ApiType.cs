using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApi;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApiTypeConstant
{
    [Description("NotSpecified")]
    NotSpecified,

    [Description("Rest")]
    Rest,

    [Description("Soap")]
    Soap,
}
