using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.CommitmentPlans;

internal class CreateOrUpdateAssociationOperation : Pandora.Definitions.Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(CommitmentPlanAccountAssociationModel);

    public override ResourceID? ResourceId() => new AccountAssociationId();

    public override Type? ResponseObject() => typeof(CommitmentPlanAccountAssociationModel);


}
