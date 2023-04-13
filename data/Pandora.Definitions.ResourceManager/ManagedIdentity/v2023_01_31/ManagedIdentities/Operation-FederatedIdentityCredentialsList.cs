using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2023_01_31.ManagedIdentities;

internal class FederatedIdentityCredentialsListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new UserAssignedIdentityId();

    public override Type NestedItemType() => typeof(FederatedIdentityCredentialModel);

    public override Type? OptionsObject() => typeof(FederatedIdentityCredentialsListOperation.FederatedIdentityCredentialsListOptions);

    public override string? UriSuffix() => "/federatedIdentityCredentials";

    internal class FederatedIdentityCredentialsListOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
