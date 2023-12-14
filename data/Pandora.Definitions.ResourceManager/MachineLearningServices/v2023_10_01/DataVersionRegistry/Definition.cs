using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.DataVersionRegistry;

internal class Definition : ResourceDefinition
{
    public string Name => "DataVersionRegistry";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RegistryDataVersionsCreateOrGetStartPendingUploadOperation(),
        new RegistryDataVersionsCreateOrUpdateOperation(),
        new RegistryDataVersionsDeleteOperation(),
        new RegistryDataVersionsGetOperation(),
        new RegistryDataVersionsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataTypeConstant),
        typeof(ListViewTypeConstant),
        typeof(PendingUploadCredentialTypeConstant),
        typeof(PendingUploadTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BlobReferenceForConsumptionDtoModel),
        typeof(DataVersionBaseModel),
        typeof(DataVersionBaseResourceModel),
        typeof(MLTableDataModel),
        typeof(PendingUploadCredentialDtoModel),
        typeof(PendingUploadRequestDtoModel),
        typeof(PendingUploadResponseDtoModel),
        typeof(SASCredentialDtoModel),
        typeof(UriFileDataVersionModel),
        typeof(UriFolderDataVersionModel),
    };
}
