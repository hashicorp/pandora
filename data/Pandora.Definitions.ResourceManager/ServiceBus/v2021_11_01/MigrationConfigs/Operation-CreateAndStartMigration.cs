using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_11_01.MigrationConfigs;

internal class CreateAndStartMigrationOperation : Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(MigrationConfigPropertiesModel);

    public override ResourceID? ResourceId() => new NamespaceId();

    public override Type? ResponseObject() => typeof(MigrationConfigPropertiesModel);

    public override string? UriSuffix() => "/migrationConfigurations/$default";


}
