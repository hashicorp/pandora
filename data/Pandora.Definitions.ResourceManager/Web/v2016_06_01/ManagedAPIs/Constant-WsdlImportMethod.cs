using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ManagedAPIs;

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
