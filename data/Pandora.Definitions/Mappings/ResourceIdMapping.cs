// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.Mappings;

public class ResourceIdMapping : MappingType
{
    public string SchemaFieldName { get; set; }
    public string SegmentName { get; set; }
    public bool ParsedFromParentID { get; set; }
}