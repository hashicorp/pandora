using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.SentinelOnboardingStates;

internal class CreateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(SentinelOnboardingStateModel);

    public override ResourceID? ResourceId() => new OnboardingStateId();

    public override Type? ResponseObject() => typeof(SentinelOnboardingStateModel);


}
