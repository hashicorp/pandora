using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TypeConstant
{
    [Description("BinarySignature")]
    BinarySignature,

    [Description("File")]
    File,

    [Description("FileHash")]
    FileHash,

    [Description("ProductSignature")]
    ProductSignature,

    [Description("PublisherSignature")]
    PublisherSignature,

    [Description("VersionAndAboveSignature")]
    VersionAndAboveSignature,
}
