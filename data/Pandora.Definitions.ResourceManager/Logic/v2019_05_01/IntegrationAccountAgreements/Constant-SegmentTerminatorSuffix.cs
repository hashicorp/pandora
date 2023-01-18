using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SegmentTerminatorSuffixConstant
{
    [Description("CR")]
    CR,

    [Description("CRLF")]
    CRLF,

    [Description("LF")]
    LF,

    [Description("None")]
    None,

    [Description("NotSpecified")]
    NotSpecified,
}
