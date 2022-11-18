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
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(ContactParametersModel);

\t\tpublic override ResourceID? ResourceId() => new SpacecraftId();

\t\tpublic override Type NestedItemType() => typeof(AvailableContactsModel);

\t\tpublic override string? UriSuffix() => "/listAvailableContacts";

\t\tpublic override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
