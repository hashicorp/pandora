using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors;

internal class RulesEnginesGetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new RulesEngineId();

\t\tpublic override Type? ResponseObject() => typeof(RulesEngineModel);


}
