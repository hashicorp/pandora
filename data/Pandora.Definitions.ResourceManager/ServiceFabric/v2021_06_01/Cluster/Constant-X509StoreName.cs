using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum X509StoreNameConstant
{
    [Description("AddressBook")]
    AddressBook,

    [Description("AuthRoot")]
    AuthRoot,

    [Description("CertificateAuthority")]
    CertificateAuthority,

    [Description("Disallowed")]
    Disallowed,

    [Description("My")]
    My,

    [Description("Root")]
    Root,

    [Description("TrustedPeople")]
    TrustedPeople,

    [Description("TrustedPublisher")]
    TrustedPublisher,
}
