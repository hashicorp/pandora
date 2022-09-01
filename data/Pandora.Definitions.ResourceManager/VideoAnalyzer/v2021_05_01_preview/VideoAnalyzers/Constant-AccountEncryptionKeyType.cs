using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccountEncryptionKeyTypeConstant
{
    [Description("CustomerKey")]
    CustomerKey,

    [Description("SystemKey")]
    SystemKey,
}
