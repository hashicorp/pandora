using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServicePlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SupportedTlsVersionsConstant
{
    [Description("1.1")]
    OnePointOne,

    [Description("1.2")]
    OnePointTwo,

    [Description("1.0")]
    OnePointZero,
}
