using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.DataVersionRegistry;

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
        typeof(AutoDeleteConditionConstant),
        typeof(DataImportSourceTypeConstant),
        typeof(DataTypeConstant),
        typeof(ListViewTypeConstant),
        typeof(PendingUploadCredentialTypeConstant),
        typeof(PendingUploadTypeConstant),
        typeof(ProtectionLevelConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutoDeleteSettingModel),
        typeof(BlobReferenceForConsumptionDtoModel),
        typeof(DataImportModel),
        typeof(DataImportSourceModel),
        typeof(DataVersionBaseModel),
        typeof(DataVersionBaseResourceModel),
        typeof(DatabaseSourceModel),
        typeof(FileSystemSourceModel),
        typeof(IntellectualPropertyModel),
        typeof(MLTableDataModel),
        typeof(PendingUploadCredentialDtoModel),
        typeof(PendingUploadRequestDtoModel),
        typeof(PendingUploadResponseDtoModel),
        typeof(SASCredentialDtoModel),
        typeof(UriFileDataVersionModel),
        typeof(UriFolderDataVersionModel),
    };
}
