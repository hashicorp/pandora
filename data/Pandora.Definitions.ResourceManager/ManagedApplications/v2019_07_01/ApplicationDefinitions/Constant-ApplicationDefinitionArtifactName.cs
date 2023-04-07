using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2019_07_01.ApplicationDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationDefinitionArtifactNameConstant
{
    [Description("ApplicationResourceTemplate")]
    ApplicationResourceTemplate,

    [Description("CreateUiDefinition")]
    CreateUiDefinition,

    [Description("MainTemplateParameters")]
    MainTemplateParameters,

    [Description("NotSpecified")]
    NotSpecified,
}
