using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataDog.v2023_01_01.SingleSignOn;

internal class ConfigurationsCreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(DatadogSingleSignOnResourceModel);

    public override ResourceID? ResourceId() => new SingleSignOnConfigurationId();

    public override Type? ResponseObject() => typeof(DatadogSingleSignOnResourceModel);


}
