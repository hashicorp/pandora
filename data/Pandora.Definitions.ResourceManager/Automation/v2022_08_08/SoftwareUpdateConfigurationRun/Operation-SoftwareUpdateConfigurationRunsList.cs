using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.SoftwareUpdateConfigurationRun;

internal class SoftwareUpdateConfigurationRunsListOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new AutomationAccountId();

\t\tpublic override Type? ResponseObject() => typeof(SoftwareUpdateConfigurationRunListResultModel);

\t\tpublic override Type? OptionsObject() => typeof(SoftwareUpdateConfigurationRunsListOperation.SoftwareUpdateConfigurationRunsListOptions);

\t\tpublic override string? UriSuffix() => "/softwareUpdateConfigurationRuns";

    internal class SoftwareUpdateConfigurationRunsListOptions
    {
        [HeaderName("clientRequestId")]
        [Optional]
        public string ClientRequestId { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public string Top { get; set; }
    }
}
