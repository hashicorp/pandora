using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.CodeVersion;

internal class Definition : ResourceDefinition
{
    public string Name => "CodeVersion";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrGetStartPendingUploadOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new PublishOperation(),
        new RegistryCodeVersionsCreateOrGetStartPendingUploadOperation(),
        new RegistryCodeVersionsCreateOrUpdateOperation(),
        new RegistryCodeVersionsDeleteOperation(),
        new RegistryCodeVersionsGetOperation(),
        new RegistryCodeVersionsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssetProvisioningStateConstant),
        typeof(PendingUploadCredentialTypeConstant),
        typeof(PendingUploadTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BlobReferenceForConsumptionDtoModel),
        typeof(CodeVersionModel),
        typeof(CodeVersionResourceModel),
        typeof(DestinationAssetModel),
        typeof(PendingUploadCredentialDtoModel),
        typeof(PendingUploadRequestDtoModel),
        typeof(PendingUploadResponseDtoModel),
        typeof(SASCredentialDtoModel),
    };
}
