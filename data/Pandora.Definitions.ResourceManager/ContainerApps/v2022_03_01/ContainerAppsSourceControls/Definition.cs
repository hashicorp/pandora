using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsSourceControls;

internal class Definition : ResourceDefinition
{
    public string Name => "ContainerAppsSourceControls";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByContainerAppOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SourceControlOperationStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureCredentialsModel),
        typeof(GithubActionConfigurationModel),
        typeof(RegistryInfoModel),
        typeof(SourceControlModel),
        typeof(SourceControlPropertiesModel),
    };
}
