using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2021_06_01.PolicyDefinitions;

internal class GetAtManagementGroupOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new Providers2PolicyDefinitionId();

    public override Type? ResponseObject() => typeof(PolicyDefinitionModel);


}
