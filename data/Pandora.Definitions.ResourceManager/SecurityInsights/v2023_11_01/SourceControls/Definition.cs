using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.SourceControls;

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
        typeof(RepositoryAccessKindConstant),
        typeof(StateConstant),
        typeof(VersionConstant),
        typeof(WarningCodeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureDevOpsResourceInfoModel),
        typeof(DeploymentModel),
        typeof(DeploymentInfoModel),
        typeof(GitHubResourceInfoModel),
        typeof(PullRequestModel),
        typeof(RepositoryModel),
        typeof(RepositoryAccessModel),
        typeof(RepositoryAccessObjectModel),
        typeof(RepositoryAccessPropertiesModel),
        typeof(RepositoryResourceInfoModel),
        typeof(ServicePrincipalModel),
        typeof(SourceControlModel),
        typeof(SourceControlPropertiesModel),
        typeof(WarningModel),
        typeof(WarningBodyModel),
        typeof(WebhookModel),
    };
}
