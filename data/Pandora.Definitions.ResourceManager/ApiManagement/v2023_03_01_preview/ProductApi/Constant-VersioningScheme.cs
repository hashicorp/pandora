using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ProductApi;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VersioningSchemeConstant
{
    [Description("Header")]
    Header,

    [Description("Query")]
    Query,

    [Description("Segment")]
    Segment,
}
