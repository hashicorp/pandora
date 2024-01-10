using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Batch.v2023_11_01.BatchAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationModeConstant
{
    [Description("AAD")]
    AAD,

    [Description("SharedKey")]
    SharedKey,

    [Description("TaskAuthenticationToken")]
    TaskAuthenticationToken,
}
