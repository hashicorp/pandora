using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.Videos;

internal class AccessPoliciesGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new AccessPoliciesId();

    public override Type? ResponseObject() => typeof(AccessPolicyEntityModel);


}
