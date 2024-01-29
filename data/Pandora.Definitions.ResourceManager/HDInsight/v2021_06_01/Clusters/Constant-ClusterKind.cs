// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterKindConstant
{
    [Description("HBASE")]
    HBase,

    [Description("HADOOP")]
    Hadoop,

    [Description("INTERACTIVEHIVE")]
    InteractiveHive,

    [Description("KAFKA")]
    Kafka,

    [Description("SPARK")]
    Spark,
}
