using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Communication.v2023_04_01.Domains;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VerificationStatusConstant
{
    [Description("CancellationRequested")]
    CancellationRequested,

    [Description("NotStarted")]
    NotStarted,

    [Description("VerificationFailed")]
    VerificationFailed,

    [Description("VerificationInProgress")]
    VerificationInProgress,

    [Description("VerificationRequested")]
    VerificationRequested,

    [Description("Verified")]
    Verified,
}
