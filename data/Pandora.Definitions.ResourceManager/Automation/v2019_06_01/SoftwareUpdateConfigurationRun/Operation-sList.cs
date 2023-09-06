using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfigurationRun;

internal class sListOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new AutomationAccountId();

    public override Type? ResponseObject() => typeof(SoftwareUpdateConfigurationRunListResultModel);

    public override Type? OptionsObject() => typeof(sListOperation.sListOptions);

    public override string? UriSuffix() => "/softwareUpdateConfigurationRuns";

    internal class sListOptions
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
