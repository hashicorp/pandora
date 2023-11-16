using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Migrations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceTypeConstant
{
    [Description("AWS")]
    AWS,

    [Description("AzureVM")]
    AzureVM,

    [Description("GCP")]
    GCP,

    [Description("OnPremises")]
    OnPremises,

    [Description("PostgreSQLSingleServer")]
    PostgreSQLSingleServer,
}
