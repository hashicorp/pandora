using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.QumuloStorage.v2022_10_12.FileSystems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageSkuConstant
{
    [Description("Performance")]
    Performance,

    [Description("Standard")]
    Standard,
}
