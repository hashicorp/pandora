using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SiteRuntimeStateConstant
{
    [Description("READY")]
    READY,

    [Description("STOPPED")]
    STOPPED,

    [Description("UNKNOWN")]
    UNKNOWN,
}
