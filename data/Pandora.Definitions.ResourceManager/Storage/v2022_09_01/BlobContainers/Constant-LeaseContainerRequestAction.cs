using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.BlobContainers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LeaseContainerRequestActionConstant
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
