using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ServerAdvisors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdvisorStatusConstant
{
    [Description("GA")]
    GA,

    [Description("LimitedPublicPreview")]
    LimitedPublicPreview,

    [Description("PrivatePreview")]
    PrivatePreview,

    [Description("PublicPreview")]
    PublicPreview,
}
