using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.SoftDeletedContainers;

internal class DeletedProtectionContainersListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new VaultId();

    public override Type NestedItemType() => typeof(ProtectionContainerResourceModel);

    public override Type? OptionsObject() => typeof(DeletedProtectionContainersListOperation.DeletedProtectionContainersListOptions);

    public override string? UriSuffix() => "/backupDeletedProtectionContainers";

    internal class DeletedProtectionContainersListOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
