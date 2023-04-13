using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2022_05_01.ConfigurationStores;

internal class UpdateOperation : Pandora.Definitions.Operations.PatchOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(ConfigurationStoreUpdateParametersModel);

    public override ResourceID? ResourceId() => new ConfigurationStoreId();

    public override Type? ResponseObject() => typeof(ConfigurationStoreModel);


}
