using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.BackupResourceStorageConfigsNonCRR;

internal class UpdateOperation : Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(BackupResourceConfigResourceModel);

    public override ResourceID? ResourceId() => new VaultId();

    public override Type? ResponseObject() => typeof(BackupResourceConfigResourceModel);

    public override string? UriSuffix() => "/backupStorageConfig/vaultStorageConfig";


}
