using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Domains;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CustomHostNameDnsRecordTypeConstant
{
    [Description("A")]
    A,

    [Description("CName")]
    CName,
}
