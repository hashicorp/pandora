using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.CapacityReservationGroups;

internal class UpdateOperation : Operations.PatchOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(CapacityReservationGroupUpdateModel);

\t\tpublic override ResourceID? ResourceId() => new CapacityReservationGroupId();

\t\tpublic override Type? ResponseObject() => typeof(CapacityReservationGroupModel);


}
