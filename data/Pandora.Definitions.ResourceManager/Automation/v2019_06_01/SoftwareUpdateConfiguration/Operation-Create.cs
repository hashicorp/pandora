using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfiguration;

internal class CreateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(SoftwareUpdateConfigurationModel);

    public override ResourceID? ResourceId() => new SoftwareUpdateConfigurationId();

    public override Type? ResponseObject() => typeof(SoftwareUpdateConfigurationModel);

    public override Type? OptionsObject() => typeof(CreateOperation.CreateOptions);

    internal class CreateOptions
    {
        [HeaderName("clientRequestId")]
        [Optional]
        public string ClientRequestId { get; set; }
    }
}
