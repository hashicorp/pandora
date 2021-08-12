using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.AttestationProviders
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum AttestationServiceStatusConstant
    {
        [Description("Error")]
        Error,

        [Description("NotReady")]
        NotReady,

        [Description("Ready")]
        Ready,
    }
}
