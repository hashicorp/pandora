using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01_preview.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MinimalTlsVersionEnumConstant
{
    [Description("TLSEnforcementDisabled")]
    TLSEnforcementDisabled,

    [Description("TLS1_1")]
    TLSOneOne,

    [Description("TLS1_2")]
    TLSOneTwo,

    [Description("TLS1_0")]
    TLSOneZero,
}
