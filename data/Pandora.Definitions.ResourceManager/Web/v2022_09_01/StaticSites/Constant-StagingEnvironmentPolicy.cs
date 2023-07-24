using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.StaticSites;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StagingEnvironmentPolicyConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
