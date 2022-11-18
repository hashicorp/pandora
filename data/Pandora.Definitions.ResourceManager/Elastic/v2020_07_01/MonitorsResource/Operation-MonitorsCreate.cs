using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.MonitorsResource;

internal class MonitorsCreateOperation : Operations.PutOperation
{
\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(ElasticMonitorResourceModel);

\t\tpublic override ResourceID? ResourceId() => new MonitorId();

\t\tpublic override Type? ResponseObject() => typeof(ElasticMonitorResourceModel);


}
