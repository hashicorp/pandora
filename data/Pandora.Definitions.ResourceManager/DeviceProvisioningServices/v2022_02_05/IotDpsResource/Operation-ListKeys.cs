using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.IotDpsResource;

internal class ListKeysOperation : Operations.ListOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override Type? RequestObject() => null;

\t\tpublic override ResourceID? ResourceId() => new ProvisioningServiceId();

\t\tpublic override Type NestedItemType() => typeof(SharedAccessSignatureAuthorizationRuleAccessRightsDescriptionModel);

\t\tpublic override string? UriSuffix() => "/listkeys";

\t\tpublic override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
