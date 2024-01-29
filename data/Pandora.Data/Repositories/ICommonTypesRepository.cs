// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Data.Models;

namespace Pandora.Data.Repositories;

public interface ICommonTypesRepository
{
    IEnumerable<CommonTypesDefinition> Get(ServiceDefinitionType serviceDefinitionType);
}
