using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.MonitorsResource;

internal class MonitorsCreateOperation : Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(ElasticMonitorResourceModel);

    public override ResourceID? ResourceId() => new MonitorId();

    public override Type? ResponseObject() => typeof(ElasticMonitorResourceModel);


}
