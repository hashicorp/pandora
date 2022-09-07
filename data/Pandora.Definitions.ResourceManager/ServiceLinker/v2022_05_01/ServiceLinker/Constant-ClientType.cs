using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceLinker.v2022_05_01.ServiceLinker;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClientTypeConstant
{
    [Description("django")]
    Django,

    [Description("dotnet")]
    Dotnet,

    [Description("go")]
    Go,

    [Description("java")]
    Java,

    [Description("kafka-springBoot")]
    KafkaNegativespringBoot,

    [Description("nodejs")]
    Nodejs,

    [Description("none")]
    None,

    [Description("php")]
    Php,

    [Description("python")]
    Python,

    [Description("ruby")]
    Ruby,

    [Description("springBoot")]
    SpringBoot,
}
