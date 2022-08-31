using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MinimumTlsVersionConstant
{
    [Description("TLS1_1")]
    TLSOneOne,

    [Description("TLS1_2")]
    TLSOneTwo,

    [Description("TLS1_0")]
    TLSOneZero,
}
