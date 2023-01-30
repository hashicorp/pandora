using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Shares;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureContainerDataFormatConstant
{
    [Description("AzureFile")]
    AzureFile,

    [Description("BlockBlob")]
    BlockBlob,

    [Description("PageBlob")]
    PageBlob,
}
