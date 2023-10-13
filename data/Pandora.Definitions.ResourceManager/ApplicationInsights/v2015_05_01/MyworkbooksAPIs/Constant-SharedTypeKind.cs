using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.MyworkbooksAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SharedTypeKindConstant
{
    [Description("shared")]
    Shared,

    [Description("user")]
    User,
}
