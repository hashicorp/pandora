// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

﻿using System;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants;

public class ListByResourceGroup : ListOperation
{
    public override Type NestedItemType()
    {
        return typeof(TenantModel);
    }

    public override ResourceID? ResourceId()
    {
        return new ResourceGroupId();
    }

    public override string? UriSuffix()
    {
        return "/providers/Microsoft.AzureActiveDirectory/b2cDirectories";
    }
}