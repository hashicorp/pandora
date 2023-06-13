using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.ManagedDatabaseSecurityAlertPolicies;

internal class CreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(ManagedDatabaseSecurityAlertPolicyModel);

    public override ResourceID? ResourceId() => new ManagedInstanceDatabaseId();

    public override Type? ResponseObject() => typeof(ManagedDatabaseSecurityAlertPolicyModel);

    public override string? UriSuffix() => "/securityAlertPolicies/default";


}
