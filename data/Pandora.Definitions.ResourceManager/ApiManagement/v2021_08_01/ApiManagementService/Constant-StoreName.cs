using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiManagementService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StoreNameConstant
{
    [Description("CertificateAuthority")]
    CertificateAuthority,

    [Description("Root")]
    Root,
}
