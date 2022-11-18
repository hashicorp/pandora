using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01.Deployments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PropertyChangeTypeConstant
{
    [Description("Array")]
    Array,

    [Description("Create")]
    Create,

    [Description("Delete")]
    Delete,

    [Description("Modify")]
    Modify,

    [Description("NoEffect")]
    NoEffect,
}
