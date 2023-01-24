using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.PUT;

internal class ServiceTasksCreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(ProjectTaskModel);

    public override ResourceID? ResourceId() => new ServiceTaskId();

    public override Type? ResponseObject() => typeof(ProjectTaskModel);


}
