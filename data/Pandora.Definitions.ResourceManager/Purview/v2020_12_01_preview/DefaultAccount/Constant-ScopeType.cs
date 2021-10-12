using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.DefaultAccount
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ScopeTypeConstant
    {
        [Description("Subscription")]
        Subscription,

        [Description("Tenant")]
        Tenant,
    }
}
