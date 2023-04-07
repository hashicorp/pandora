using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DirectoryTypeConstant
{
    [Description("ActiveDirectory")]
    ActiveDirectory,
}
