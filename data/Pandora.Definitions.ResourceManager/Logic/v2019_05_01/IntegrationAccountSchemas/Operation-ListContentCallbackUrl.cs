using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountSchemas;

internal class ListContentCallbackUrlOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(GetCallbackUrlParametersModel);

    public override ResourceID? ResourceId() => new SchemaId();

    public override Type? ResponseObject() => typeof(WorkflowTriggerCallbackUrlModel);

    public override string? UriSuffix() => "/listContentCallbackUrl";


}
