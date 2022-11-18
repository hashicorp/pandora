using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.BatchEndpoint;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(BatchEndpointTrackedResourceModel);

\t\tpublic override ResourceID? ResourceId() => new BatchEndpointId();

\t\tpublic override Type? ResponseObject() => typeof(BatchEndpointTrackedResourceModel);


}
