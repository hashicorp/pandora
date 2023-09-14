using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.WebAppDiscoverySiteDataSourcesController;

internal class CreateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(DiscoverySiteDataSourceModel);

    public override ResourceID? ResourceId() => new WebAppSiteDiscoverySiteDataSourceId();

    public override Type? ResponseObject() => typeof(DiscoverySiteDataSourceModel);


}
