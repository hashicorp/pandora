using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_05_01.SnapshotPolicy;

internal class SnapshotPoliciesCreateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(SnapshotPolicyModel);

    public override ResourceID? ResourceId() => new SnapshotPolicyId();

    public override Type? ResponseObject() => typeof(SnapshotPolicyModel);


}
