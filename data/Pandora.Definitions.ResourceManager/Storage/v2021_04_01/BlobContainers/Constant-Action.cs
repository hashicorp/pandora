using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobContainers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionConstant
{
    [Description("Acquire")]
    Acquire,

    [Description("Break")]
    Break,

    [Description("Change")]
    Change,

    [Description("Release")]
    Release,

    [Description("Renew")]
    Renew,
}
