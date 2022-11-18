using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.SoftwareUpdateConfigurationMachineRun;

internal class SoftwareUpdateConfigurationMachineRunsGetByIdOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new SoftwareUpdateConfigurationMachineRunId();

\t\tpublic override Type? ResponseObject() => typeof(SoftwareUpdateConfigurationMachineRunModel);

\t\tpublic override Type? OptionsObject() => typeof(SoftwareUpdateConfigurationMachineRunsGetByIdOperation.SoftwareUpdateConfigurationMachineRunsGetByIdOptions);

    internal class SoftwareUpdateConfigurationMachineRunsGetByIdOptions
    {
        [HeaderName("clientRequestId")]
        [Optional]
        public string ClientRequestId { get; set; }
    }
}
