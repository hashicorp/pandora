using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.Certificate;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CertificateFormatConstant
{
    [Description("Cer")]
    Cer,

    [Description("Pfx")]
    Pfx,
}
