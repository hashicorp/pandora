using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.DscConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContentSourceTypeConstant
{
    [Description("embeddedContent")]
    EmbeddedContent,

    [Description("uri")]
    Uri,
}
