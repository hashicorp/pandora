using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.ContentKeyPolicies;

internal class ContentKeyPoliciesGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ContentKeyPolicyId();

    public override Type? ResponseObject() => typeof(ContentKeyPolicyModel);


}
