using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.DeploymentInfo;

internal class Definition : ResourceDefinition
{
    public string Name => "DeploymentInfo";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExternalUserCreateOrUpdateOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ElasticDeploymentStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DeploymentInfoResponseModel),
        typeof(ExternalUserCreationResponseModel),
        typeof(ExternalUserInfoModel),
        typeof(MarketplaceSaaSInfoModel),
        typeof(MarketplaceSaaSInfoMarketplaceSubscriptionModel),
    };
}
