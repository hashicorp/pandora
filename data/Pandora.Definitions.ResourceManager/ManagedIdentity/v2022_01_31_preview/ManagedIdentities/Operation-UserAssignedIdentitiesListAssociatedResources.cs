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
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new UserAssignedIdentityId();

    public override Type NestedItemType() => typeof(AzureResourceModel);

    public override Type? OptionsObject() => typeof(UserAssignedIdentitiesListAssociatedResourcesOperation.UserAssignedIdentitiesListAssociatedResourcesOptions);

    public override string? UriSuffix() => "/listAssociatedResources";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;

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
