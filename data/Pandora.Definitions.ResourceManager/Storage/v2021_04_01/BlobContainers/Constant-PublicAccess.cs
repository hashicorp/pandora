using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobContainers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PublicAccessConstant
{
    [Description("Blob")]
    Blob,

    [Description("Container")]
    Container,

    [Description("None")]
    None,
}
