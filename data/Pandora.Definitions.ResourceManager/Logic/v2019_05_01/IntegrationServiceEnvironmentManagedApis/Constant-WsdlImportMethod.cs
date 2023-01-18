using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApis;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WsdlImportMethodConstant
{
    [Description("NotSpecified")]
    NotSpecified,

    [Description("SoapPassThrough")]
    SoapPassThrough,

    [Description("SoapToRest")]
    SoapToRest,
}
