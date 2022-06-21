using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.Contact;

internal class SpacecraftsListAvailableContactsOperation : Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(ContactParametersModel);

    public override ResourceID? ResourceId() => new SpacecraftId();

    public override Type NestedItemType() => typeof(AvailableContactsModel);

    public override string? UriSuffix() => "/listAvailableContacts";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
