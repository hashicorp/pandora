// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

﻿using System;
using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces;

public interface CommonTypesDefinition
{
    public IEnumerable<Type> Constants { get; set; }
    public IEnumerable<Type> Models { get; set; }
}
