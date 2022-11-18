using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(SqlVirtualMachineModel);

\t\tpublic override ResourceID? ResourceId() => new SqlVirtualMachineId();

\t\tpublic override Type? ResponseObject() => typeof(SqlVirtualMachineModel);


}
