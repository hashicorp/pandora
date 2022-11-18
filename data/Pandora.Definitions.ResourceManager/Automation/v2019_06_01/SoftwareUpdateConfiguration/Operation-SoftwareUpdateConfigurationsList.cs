using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfiguration;

internal class SoftwareUpdateConfigurationsListOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new AutomationAccountId();

\t\tpublic override Type? ResponseObject() => typeof(SoftwareUpdateConfigurationListResultModel);

\t\tpublic override Type? OptionsObject() => typeof(SoftwareUpdateConfigurationsListOperation.SoftwareUpdateConfigurationsListOptions);

\t\tpublic override string? UriSuffix() => "/softwareUpdateConfigurations";

    internal class SoftwareUpdateConfigurationsListOptions
    {
        [HeaderName("clientRequestId")]
        [Optional]
        public string ClientRequestId { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
