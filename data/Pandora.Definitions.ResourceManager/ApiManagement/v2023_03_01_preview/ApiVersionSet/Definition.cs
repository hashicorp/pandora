using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiVersionSet;

internal class Definition : ResourceDefinition
{
    public string Name => "ApiVersionSet";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new GetOperation(),
        new GetEntityTagOperation(),
        new ListByServiceOperation(),
        new UpdateOperation(),
        new WorkspaceApiVersionSetCreateOrUpdateOperation(),
        new WorkspaceApiVersionSetGetOperation(),
        new WorkspaceApiVersionSetGetEntityTagOperation(),
        new WorkspaceApiVersionSetListByServiceOperation(),
        new WorkspaceApiVersionSetUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(VersioningSchemeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiVersionSetContractModel),
        typeof(ApiVersionSetContractPropertiesModel),
        typeof(ApiVersionSetUpdateParametersModel),
        typeof(ApiVersionSetUpdateParametersPropertiesModel),
    };
}
