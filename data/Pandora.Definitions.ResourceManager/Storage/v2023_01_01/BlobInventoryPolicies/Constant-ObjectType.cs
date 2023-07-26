using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2023_01_01.BlobInventoryPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ObjectTypeConstant
{
    [Description("Blob")]
    Blob,

    [Description("Container")]
    Container,
}
