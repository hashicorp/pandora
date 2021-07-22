using System.ComponentModel;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ActionsRequired
    {
        [Description("None")]
        None,

        [Description("Recreate")]
        Recreate,
    }
}
