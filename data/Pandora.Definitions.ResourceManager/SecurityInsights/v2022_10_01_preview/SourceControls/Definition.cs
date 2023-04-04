using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.SourceControls;

internal class Definition : ResourceDefinition
{
    public string Name => "SourceControls";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ContentTypeConstant),
        typeof(DeploymentFetchStatusConstant),
        typeof(DeploymentResultConstant),
        typeof(DeploymentStateConstant),
        typeof(RepoTypeConstant),
        typeof(VersionConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureDevOpsResourceInfoModel),
        typeof(ContentPathMapModel),
        typeof(DeploymentModel),
        typeof(DeploymentInfoModel),
        typeof(GitHubResourceInfoModel),
        typeof(RepositoryModel),
        typeof(RepositoryResourceInfoModel),
        typeof(SourceControlModel),
        typeof(SourceControlPropertiesModel),
        typeof(WebhookModel),
    };
}
