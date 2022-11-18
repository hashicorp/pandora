using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2022_01_31_preview.ManagedIdentities;

internal class FederatedIdentityCredentialsListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new UserAssignedIdentityId();

\t\tpublic override Type NestedItemType() => typeof(FederatedIdentityCredentialModel);

\t\tpublic override Type? OptionsObject() => typeof(FederatedIdentityCredentialsListOperation.FederatedIdentityCredentialsListOptions);

\t\tpublic override string? UriSuffix() => "/federatedIdentityCredentials";

    internal class FederatedIdentityCredentialsListOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
