using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.ManagedCassandras;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionStateConstant
{
    [Description("DatacenterToDatacenterNetworkError")]
    DatacenterToDatacenterNetworkError,

    [Description("InternalError")]
    InternalError,

    [Description("InternalOperatorToDataCenterCertificateError")]
    InternalOperatorToDataCenterCertificateError,

    [Description("OK")]
    OK,

    [Description("OperatorToDataCenterNetworkError")]
    OperatorToDataCenterNetworkError,

    [Description("Unknown")]
    Unknown,
}
