using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobErrorCategoryConstant
{
    [Description("Configuration")]
    Configuration,

    [Description("Content")]
    Content,

    [Description("Download")]
    Download,

    [Description("Service")]
    Service,

    [Description("Upload")]
    Upload,
}
