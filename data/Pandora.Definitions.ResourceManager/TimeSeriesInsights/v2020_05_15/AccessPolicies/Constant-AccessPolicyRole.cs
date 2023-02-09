using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.AccessPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessPolicyRoleConstant
{
    [Description("Contributor")]
    Contributor,

    [Description("Reader")]
    Reader,
}
