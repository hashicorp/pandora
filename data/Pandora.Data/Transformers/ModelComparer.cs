// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Data.Models;

namespace Pandora.Data.Transformers;

internal class ModelComparer : IEqualityComparer<ModelDefinition>
{
    public bool Equals(ModelDefinition a, ModelDefinition b)
    {
        // should be sufficient since these are classes (we shouldn't be importing outside of a namespace)
        return a.Name == b.Name;
    }

    public int GetHashCode(ModelDefinition obj)
    {
        return obj.Name.GetHashCode();
    }
}