using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_03_10.PrivateLinkScopes;

internal class PrivateLinkScopesCreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(HybridComputePrivateLinkScopeModel);

\t\tpublic override ResourceID? ResourceId() => new ProviderPrivateLinkScopeId();

\t\tpublic override Type? ResponseObject() => typeof(HybridComputePrivateLinkScopeModel);


}
