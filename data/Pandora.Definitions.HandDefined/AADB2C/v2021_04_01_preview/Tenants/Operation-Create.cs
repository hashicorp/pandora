// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

﻿using System;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants;

internal class Create : LongRunningPutOperation
{
    public override Type? RequestObject()
    {
        return typeof(CreateTenantModel);
    }

    public override ResourceID? ResourceId()
    {
        return new B2CDirectoryId();
    }
}