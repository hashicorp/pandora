using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Media;

internal class Definition : ResourceDefinition
{
    public string Name => "Media";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AccountFiltersCreateOrUpdateOperation(),
        new AccountFiltersDeleteOperation(),
        new AccountFiltersGetOperation(),
        new AccountFiltersListOperation(),
        new AccountFiltersUpdateOperation(),
        new AssetFiltersCreateOrUpdateOperation(),
        new AssetFiltersDeleteOperation(),
        new AssetFiltersGetOperation(),
        new AssetFiltersListOperation(),
        new AssetFiltersUpdateOperation(),
        new AssetsCreateOrUpdateOperation(),
        new AssetsDeleteOperation(),
        new AssetsGetOperation(),
        new AssetsGetEncryptionKeyOperation(),
        new AssetsListOperation(),
        new AssetsListContainerSasOperation(),
        new AssetsListStreamingLocatorsOperation(),
        new AssetsUpdateOperation(),
        new ContentKeyPoliciesCreateOrUpdateOperation(),
        new ContentKeyPoliciesDeleteOperation(),
        new ContentKeyPoliciesGetOperation(),
        new ContentKeyPoliciesGetPolicyPropertiesWithSecretsOperation(),
        new ContentKeyPoliciesListOperation(),
        new ContentKeyPoliciesUpdateOperation(),
        new JobsCancelJobOperation(),
        new JobsCreateOperation(),
        new JobsDeleteOperation(),
        new JobsGetOperation(),
        new JobsListOperation(),
        new JobsUpdateOperation(),
        new LocationsCheckNameAvailabilityOperation(),
        new MediaservicesCreateOrUpdateOperation(),
        new MediaservicesDeleteOperation(),
        new MediaservicesGetOperation(),
        new MediaservicesGetBySubscriptionOperation(),
        new MediaservicesListOperation(),
        new MediaservicesListBySubscriptionOperation(),
        new MediaservicesListEdgePoliciesOperation(),
        new MediaservicesSyncStorageKeysOperation(),
        new MediaservicesUpdateOperation(),
        new PrivateEndpointConnectionsCreateOrUpdateOperation(),
        new PrivateEndpointConnectionsDeleteOperation(),
        new PrivateEndpointConnectionsGetOperation(),
        new PrivateEndpointConnectionsListOperation(),
        new PrivateLinkResourcesGetOperation(),
        new PrivateLinkResourcesListOperation(),
        new StreamingLocatorsCreateOperation(),
        new StreamingLocatorsDeleteOperation(),
        new StreamingLocatorsGetOperation(),
        new StreamingLocatorsListOperation(),
        new StreamingLocatorsListContentKeysOperation(),
        new StreamingLocatorsListPathsOperation(),
        new StreamingPoliciesCreateOperation(),
        new StreamingPoliciesDeleteOperation(),
        new StreamingPoliciesGetOperation(),
        new StreamingPoliciesListOperation(),
        new TransformsCreateOrUpdateOperation(),
        new TransformsDeleteOperation(),
        new TransformsGetOperation(),
        new TransformsListOperation(),
        new TransformsUpdateOperation(),
    };
}
