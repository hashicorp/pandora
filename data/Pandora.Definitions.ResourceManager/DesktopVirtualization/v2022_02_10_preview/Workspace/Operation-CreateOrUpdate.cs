using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.Workspace;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(WorkspaceModel);

\t\tpublic override ResourceID? ResourceId() => new WorkspaceId();

\t\tpublic override Type? ResponseObject() => typeof(WorkspaceModel);


}
