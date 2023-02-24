using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.DataFlowDebugSession;

internal class AddDataFlowOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(DataFlowDebugPackageModel);

    public override ResourceID? ResourceId() => new FactoryId();

    public override Type? ResponseObject() => typeof(AddDataFlowToDebugSessionResponseModel);

    public override string? UriSuffix() => "/addDataFlowToDebugSession";


}
