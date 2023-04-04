using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.ContentKeyPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "ContentKeyPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ContentKeyPoliciesCreateOrUpdateOperation(),
        new ContentKeyPoliciesDeleteOperation(),
        new ContentKeyPoliciesGetOperation(),
        new ContentKeyPoliciesGetPolicyPropertiesWithSecretsOperation(),
        new ContentKeyPoliciesListOperation(),
        new ContentKeyPoliciesUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ContentKeyPolicyFairPlayRentalAndLeaseKeyTypeConstant),
        typeof(ContentKeyPolicyPlayReadyContentTypeConstant),
        typeof(ContentKeyPolicyPlayReadyLicenseTypeConstant),
        typeof(ContentKeyPolicyPlayReadyUnknownOutputPassingOptionConstant),
        typeof(ContentKeyPolicyRestrictionTokenTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ContentKeyPolicyModel),
        typeof(ContentKeyPolicyClearKeyConfigurationModel),
        typeof(ContentKeyPolicyConfigurationModel),
        typeof(ContentKeyPolicyFairPlayConfigurationModel),
        typeof(ContentKeyPolicyFairPlayOfflineRentalConfigurationModel),
        typeof(ContentKeyPolicyOpenRestrictionModel),
        typeof(ContentKeyPolicyOptionModel),
        typeof(ContentKeyPolicyPlayReadyConfigurationModel),
        typeof(ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeaderModel),
        typeof(ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifierModel),
        typeof(ContentKeyPolicyPlayReadyContentKeyLocationModel),
        typeof(ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestrictionModel),
        typeof(ContentKeyPolicyPlayReadyLicenseModel),
        typeof(ContentKeyPolicyPlayReadyPlayRightModel),
        typeof(ContentKeyPolicyPropertiesModel),
        typeof(ContentKeyPolicyRestrictionModel),
        typeof(ContentKeyPolicyRestrictionTokenKeyModel),
        typeof(ContentKeyPolicyRsaTokenKeyModel),
        typeof(ContentKeyPolicySymmetricTokenKeyModel),
        typeof(ContentKeyPolicyTokenClaimModel),
        typeof(ContentKeyPolicyTokenRestrictionModel),
        typeof(ContentKeyPolicyUnknownConfigurationModel),
        typeof(ContentKeyPolicyUnknownRestrictionModel),
        typeof(ContentKeyPolicyWidevineConfigurationModel),
        typeof(ContentKeyPolicyX509CertificateTokenKeyModel),
    };
}
