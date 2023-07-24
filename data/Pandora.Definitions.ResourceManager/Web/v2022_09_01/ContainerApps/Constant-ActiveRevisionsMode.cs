using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ContainerApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActiveRevisionsModeConstant
{
    [Description("multiple")]
    Multiple,

    [Description("single")]
    Single,
}
