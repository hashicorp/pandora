using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.SnapshotPolicy;

internal class SnapshotPoliciesCreateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(SnapshotPolicyModel);

\t\tpublic override ResourceID? ResourceId() => new SnapshotPolicyId();

\t\tpublic override Type? ResponseObject() => typeof(SnapshotPolicyModel);


}
