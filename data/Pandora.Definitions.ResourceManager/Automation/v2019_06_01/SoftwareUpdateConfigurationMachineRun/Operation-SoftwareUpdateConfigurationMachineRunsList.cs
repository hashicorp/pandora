using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfigurationMachineRun;

internal class SoftwareUpdateConfigurationMachineRunsListOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new AutomationAccountId();

\t\tpublic override Type? ResponseObject() => typeof(SoftwareUpdateConfigurationMachineRunListResultModel);

\t\tpublic override Type? OptionsObject() => typeof(SoftwareUpdateConfigurationMachineRunsListOperation.SoftwareUpdateConfigurationMachineRunsListOptions);

\t\tpublic override string? UriSuffix() => "/softwareUpdateConfigurationMachineRuns";

    internal class SoftwareUpdateConfigurationMachineRunsListOptions
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
