using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HostNameTypeConstant
{
    [Description("Managed")]
    Managed,

    [Description("Verified")]
    Verified,
}
