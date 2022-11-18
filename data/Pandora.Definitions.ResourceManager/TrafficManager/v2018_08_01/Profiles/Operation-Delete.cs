using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles;

internal class DeleteOperation : Operations.DeleteOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

\t\tpublic override ResourceID? ResourceId() => new TrafficManagerProfileId();

\t\tpublic override Type? ResponseObject() => typeof(DeleteOperationResultModel);


}
