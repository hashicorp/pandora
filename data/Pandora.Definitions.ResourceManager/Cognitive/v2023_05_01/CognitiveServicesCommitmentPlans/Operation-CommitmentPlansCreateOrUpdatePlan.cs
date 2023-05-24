using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2023_05_01.CognitiveServicesCommitmentPlans;

internal class CommitmentPlansCreateOrUpdatePlanOperation : Pandora.Definitions.Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(CommitmentPlanModel);

    public override ResourceID? ResourceId() => new CommitmentPlanId();

    public override Type? ResponseObject() => typeof(CommitmentPlanModel);


}
