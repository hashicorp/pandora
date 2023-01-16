using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Labs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnvironmentPermissionConstant
{
    [Description("Contributor")]
    Contributor,

    [Description("Reader")]
    Reader,
}
