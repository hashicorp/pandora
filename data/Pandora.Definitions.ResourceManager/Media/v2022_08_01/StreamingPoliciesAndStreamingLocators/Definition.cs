using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.StreamingPoliciesAndStreamingLocators;

internal class Definition : ResourceDefinition
{
    public string Name => "StreamingPoliciesAndStreamingLocators";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
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
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EncryptionSchemeConstant),
        typeof(StreamingLocatorContentKeyTypeConstant),
        typeof(StreamingPolicyStreamingProtocolConstant),
        typeof(TrackPropertyCompareOperationConstant),
        typeof(TrackPropertyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CbcsDrmConfigurationModel),
        typeof(CencDrmConfigurationModel),
        typeof(ClearKeyEncryptionConfigurationModel),
        typeof(CommonEncryptionCbcsModel),
        typeof(CommonEncryptionCencModel),
        typeof(DefaultKeyModel),
        typeof(EnabledProtocolsModel),
        typeof(EnvelopeEncryptionModel),
        typeof(ListContentKeysResponseModel),
        typeof(ListPathsResponseModel),
        typeof(NoEncryptionModel),
        typeof(StreamingLocatorModel),
        typeof(StreamingLocatorContentKeyModel),
        typeof(StreamingLocatorPropertiesModel),
        typeof(StreamingPathModel),
        typeof(StreamingPolicyModel),
        typeof(StreamingPolicyContentKeyModel),
        typeof(StreamingPolicyContentKeysModel),
        typeof(StreamingPolicyFairPlayConfigurationModel),
        typeof(StreamingPolicyPlayReadyConfigurationModel),
        typeof(StreamingPolicyPropertiesModel),
        typeof(StreamingPolicyWidevineConfigurationModel),
        typeof(TrackPropertyConditionModel),
        typeof(TrackSelectionModel),
    };
}
