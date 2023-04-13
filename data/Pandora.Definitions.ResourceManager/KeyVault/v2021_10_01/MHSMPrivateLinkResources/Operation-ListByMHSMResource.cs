using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.MHSMPrivateLinkResources;

internal class ListByMHSMResourceOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ManagedHSMId();

    public override Type? ResponseObject() => typeof(MHSMPrivateLinkResourceListResultModel);

    public override string? UriSuffix() => "/privateLinkResources";


}
