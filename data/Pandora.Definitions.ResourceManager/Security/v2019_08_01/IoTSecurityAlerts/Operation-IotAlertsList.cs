using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecurityAlerts;

internal class IotAlertsListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new IotSecuritySolutionId();

    public override Type NestedItemType() => typeof(IotAlertModel);

    public override Type? OptionsObject() => typeof(IotAlertsListOperation.IotAlertsListOptions);

    public override string? UriSuffix() => "/iotAlerts";

    internal class IotAlertsListOptions
    {
        [QueryStringName("alertType")]
        [Optional]
        public string AlertType { get; set; }

        [QueryStringName("compromisedEntity")]
        [Optional]
        public string CompromisedEntity { get; set; }

        [QueryStringName("$limit")]
        [Optional]
        public int Limit { get; set; }

        [QueryStringName("startTimeUtc<")]
        [Optional]
        public string StartTimeUtc< { get; set; }

        [QueryStringName("startTimeUtc>")]
        [Optional]
        public string StartTimeUtc> { get; set; }
}
}
