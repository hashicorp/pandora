using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.BlobContainers;

internal class Definition : ResourceDefinition
{
    public string Name => "BlobContainers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ClearLegalHoldOperation(),
        new CreateOperation(),
        new CreateOrUpdateImmutabilityPolicyOperation(),
        new DeleteOperation(),
        new DeleteImmutabilityPolicyOperation(),
        new ExtendImmutabilityPolicyOperation(),
        new GetOperation(),
        new GetImmutabilityPolicyOperation(),
        new LeaseOperation(),
        new ListOperation(),
        new LockImmutabilityPolicyOperation(),
        new ObjectLevelWormOperation(),
        new SetLegalHoldOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ImmutabilityPolicyStateConstant),
        typeof(ImmutabilityPolicyUpdateTypeConstant),
        typeof(LeaseContainerRequestActionConstant),
        typeof(LeaseDurationConstant),
        typeof(LeaseStateConstant),
        typeof(LeaseStatusConstant),
        typeof(ListContainersIncludeConstant),
        typeof(MigrationStateConstant),
        typeof(PublicAccessConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BlobContainerModel),
        typeof(ContainerPropertiesModel),
        typeof(ImmutabilityPolicyModel),
        typeof(ImmutabilityPolicyPropertiesModel),
        typeof(ImmutabilityPolicyPropertyModel),
        typeof(ImmutableStorageWithVersioningModel),
        typeof(LeaseContainerRequestModel),
        typeof(LeaseContainerResponseModel),
        typeof(LegalHoldModel),
        typeof(LegalHoldPropertiesModel),
        typeof(ListContainerItemModel),
        typeof(ProtectedAppendWritesHistoryModel),
        typeof(TagPropertyModel),
        typeof(UpdateHistoryPropertyModel),
    };
}
