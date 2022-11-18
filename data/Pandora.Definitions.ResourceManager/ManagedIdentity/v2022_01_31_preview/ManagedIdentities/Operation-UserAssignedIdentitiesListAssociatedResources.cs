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

internal class UserAssignedIdentitiesListAssociatedResourcesOperation : Operations.ListOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override Type? RequestObject() => null;

\t\tpublic override ResourceID? ResourceId() => new UserAssignedIdentityId();

\t\tpublic override Type NestedItemType() => typeof(AzureResourceModel);

\t\tpublic override Type? OptionsObject() => typeof(UserAssignedIdentitiesListAssociatedResourcesOperation.UserAssignedIdentitiesListAssociatedResourcesOptions);

\t\tpublic override string? UriSuffix() => "/listAssociatedResources";

\t\tpublic override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;

    internal class UserAssignedIdentitiesListAssociatedResourcesOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$orderby")]
        [Optional]
        public string Orderby { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
