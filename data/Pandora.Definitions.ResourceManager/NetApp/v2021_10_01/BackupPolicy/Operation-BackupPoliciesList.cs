using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.BackupPolicy;

internal class BackupPoliciesListOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new NetAppAccountId();

    public override Type? ResponseObject() => typeof(BackupPoliciesListModel);

    public override string? UriSuffix() => "/backupPolicies";


}
