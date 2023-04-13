using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.AssignmentOperations;

internal class Definition : ResourceDefinition
{
    public string Name => "AssignmentOperations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssignmentDeploymentJobModel),
        typeof(AssignmentDeploymentJobResultModel),
        typeof(AssignmentJobCreatedResourceModel),
        typeof(AssignmentOperationModel),
        typeof(AssignmentOperationPropertiesModel),
        typeof(AzureResourceManagerErrorModel),
    };
}
