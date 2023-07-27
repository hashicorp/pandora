using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Api;

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
