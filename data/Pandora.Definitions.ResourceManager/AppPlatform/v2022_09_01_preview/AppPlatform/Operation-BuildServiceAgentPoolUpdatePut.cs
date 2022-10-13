using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;

internal class BuildServiceAgentPoolUpdatePutOperation : Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(BuildServiceAgentPoolResourceModel);

    public override ResourceID? ResourceId() => new AgentPoolId();

    public override Type? ResponseObject() => typeof(BuildServiceAgentPoolResourceModel);


}
