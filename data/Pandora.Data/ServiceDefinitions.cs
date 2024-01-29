// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Models;
using ServiceDefinition = Pandora.Definitions.Interfaces.ServiceDefinition;

namespace Pandora.Data;

public static class SupportedServices
{
    public static Dictionary<ServiceDefinitionType, IEnumerable<ServiceDefinition>> Get()
    {
        var data = DefinitionTypes.Get();
        var output = new Dictionary<ServiceDefinitionType, IEnumerable<ServiceDefinition>>();
        foreach (var item in data)
        {
            var definitions = item.Value.SelectMany(Definitions.Discovery.Services.WithinServicesDefinition).ToList();
            output.Add(item.Key, definitions);
        }

        return output;
    }
}