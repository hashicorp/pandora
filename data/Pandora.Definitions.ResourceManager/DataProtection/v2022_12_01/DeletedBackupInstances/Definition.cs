using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.DeletedBackupInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "DeletedBackupInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
        new UndeleteOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CurrentProtectionStateConstant),
        typeof(DataStoreTypesConstant),
        typeof(SecretStoreTypeConstant),
        typeof(StatusConstant),
        typeof(ValidationTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthCredentialsModel),
        typeof(AzureOperationalStoreParametersModel),
        typeof(DataStoreParametersModel),
        typeof(DatasourceModel),
        typeof(DatasourceSetModel),
        typeof(DeletedBackupInstanceModel),
        typeof(DeletedBackupInstanceResourceModel),
        typeof(DeletionInfoModel),
        typeof(InnerErrorModel),
        typeof(PolicyInfoModel),
        typeof(PolicyParametersModel),
        typeof(ProtectionStatusDetailsModel),
        typeof(SecretStoreBasedAuthCredentialsModel),
        typeof(SecretStoreResourceModel),
        typeof(UserFacingErrorModel),
    };
}
