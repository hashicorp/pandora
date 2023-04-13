using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountPartners;

internal class ListContentCallbackUrlOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(GetCallbackUrlParametersModel);

    public override ResourceID? ResourceId() => new PartnerId();

    public override Type? ResponseObject() => typeof(WorkflowTriggerCallbackUrlModel);

    public override string? UriSuffix() => "/listContentCallbackUrl";


}
