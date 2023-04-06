using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.Blueprint;

internal class Definition : ResourceDefinition
{
    public string Name => "Blueprint";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BlueprintTargetScopeConstant),
        typeof(TemplateParameterTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BlueprintModel),
        typeof(BlueprintPropertiesModel),
        typeof(BlueprintResourceStatusBaseModel),
        typeof(ParameterDefinitionModel),
        typeof(ParameterDefinitionMetadataModel),
        typeof(ResourceGroupDefinitionModel),
    };
}
