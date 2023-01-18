using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApis;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SwaggerSchemaTypeConstant
{
    [Description("Array")]
    Array,

    [Description("Boolean")]
    Boolean,

    [Description("File")]
    File,

    [Description("Integer")]
    Integer,

    [Description("Null")]
    Null,

    [Description("Number")]
    Number,

    [Description("Object")]
    Object,

    [Description("String")]
    String,
}
