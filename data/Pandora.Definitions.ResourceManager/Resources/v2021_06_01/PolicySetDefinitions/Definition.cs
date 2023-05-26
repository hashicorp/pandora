using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2021_06_01.PolicySetDefinitions;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicySetDefinitions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new CreateOrUpdateAtManagementGroupOperation(),
        new DeleteOperation(),
        new DeleteAtManagementGroupOperation(),
        new GetOperation(),
        new GetAtManagementGroupOperation(),
        new GetBuiltInOperation(),
        new ListOperation(),
        new ListBuiltInOperation(),
        new ListByManagementGroupOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ParameterTypeConstant),
        typeof(PolicyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ParameterDefinitionsValueModel),
        typeof(ParameterDefinitionsValueMetadataModel),
        typeof(ParameterValuesValueModel),
        typeof(PolicyDefinitionGroupModel),
        typeof(PolicyDefinitionReferenceModel),
        typeof(PolicySetDefinitionModel),
        typeof(PolicySetDefinitionPropertiesModel),
    };
}
