using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.DefaultAccount
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
