// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Linq;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Discovery;

public class CommonTypesDefinition : Pandora.Definitions.Interfaces.CommonTypesDefinition
{
    public IEnumerable<Type> Constants { get; set; }
    public IEnumerable<Type> Models { get; set; }

    public static CommonTypesDefinition ForServiceDefinition(ServicesDefinition input)
    {
        var commonTypesNamespace = $"{input.GetType().Assembly.GetName().Name}.CommonTypes";
        var theType = input.GetType();
        var commonTypes = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => a.FullName == input.GetType().Assembly.FullName)
            .SelectMany(a => a.DefinedTypes)
            .Where(t => t.Namespace == commonTypesNamespace)
            .Select(t => t.UnderlyingSystemType).ToList();

        var definition = new CommonTypesDefinition();
        definition.Constants = commonTypes.Where(c => c.IsEnum).ToList();
        definition.Models = commonTypes.Where(c => !c.IsEnum).ToList();

        return definition;
    }
}
