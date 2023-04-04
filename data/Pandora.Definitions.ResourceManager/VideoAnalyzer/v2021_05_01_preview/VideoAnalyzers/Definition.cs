using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzers;

internal class Definition : ResourceDefinition
{
    public string Name => "VideoAnalyzers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new LocationsCheckNameAvailabilityOperation(),
        new VideoAnalyzersCreateOrUpdateOperation(),
        new VideoAnalyzersDeleteOperation(),
        new VideoAnalyzersGetOperation(),
        new VideoAnalyzersListOperation(),
        new VideoAnalyzersListBySubscriptionOperation(),
        new VideoAnalyzersSyncStorageKeysOperation(),
        new VideoAnalyzersUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccountEncryptionKeyTypeConstant),
        typeof(CheckNameAvailabilityReasonConstant),
        typeof(VideoAnalyzerEndpointTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccountEncryptionModel),
        typeof(CheckNameAvailabilityRequestModel),
        typeof(CheckNameAvailabilityResponseModel),
        typeof(EndpointModel),
        typeof(KeyVaultPropertiesModel),
        typeof(ResourceIdentityModel),
        typeof(StorageAccountModel),
        typeof(SyncStorageKeysInputModel),
        typeof(UserAssignedManagedIdentityModel),
        typeof(VideoAnalyzerModel),
        typeof(VideoAnalyzerCollectionModel),
        typeof(VideoAnalyzerIdentityModel),
        typeof(VideoAnalyzerPropertiesUpdateModel),
        typeof(VideoAnalyzerUpdateModel),
    };
}
