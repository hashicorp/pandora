using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.SoftwareUpdateConfigurationMachineRun;

internal class GetByIdOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SoftwareUpdateConfigurationMachineRunId();

    public override Type? ResponseObject() => typeof(SoftwareUpdateConfigurationMachineRunModel);

    public override Type? OptionsObject() => typeof(GetByIdOperation.GetByIdOptions);

    internal class GetByIdOptions
    {
        [HeaderName("clientRequestId")]
        [Optional]
        public string ClientRequestId { get; set; }
    }
}
