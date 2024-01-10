using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Domains;

internal class Definition : ResourceDefinition
{
    public string Name => "Domains";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdateOwnershipIdentifierOperation(),
        new DeleteOperation(),
        new DeleteOwnershipIdentifierOperation(),
        new GetOperation(),
        new GetControlCenterSsoRequestOperation(),
        new GetOwnershipIdentifierOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListOwnershipIdentifiersOperation(),
        new ListRecommendationsOperation(),
        new RenewOperation(),
        new TransferOutOperation(),
        new UpdateOperation(),
        new UpdateOwnershipIdentifierOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AzureResourceTypeConstant),
        typeof(CustomHostNameDnsRecordTypeConstant),
        typeof(DnsTypeConstant),
        typeof(DomainStatusConstant),
        typeof(DomainTypeConstant),
        typeof(HostNameTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(ResourceNotRenewableReasonConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddressModel),
        typeof(ContactModel),
        typeof(DomainModel),
        typeof(DomainAvailabilityCheckResultModel),
        typeof(DomainControlCenterSsoRequestModel),
        typeof(DomainOwnershipIdentifierModel),
        typeof(DomainOwnershipIdentifierPropertiesModel),
        typeof(DomainPatchResourceModel),
        typeof(DomainPatchResourcePropertiesModel),
        typeof(DomainPropertiesModel),
        typeof(DomainPurchaseConsentModel),
        typeof(DomainRecommendationSearchParametersModel),
        typeof(HostNameModel),
        typeof(NameIdentifierModel),
    };
}
