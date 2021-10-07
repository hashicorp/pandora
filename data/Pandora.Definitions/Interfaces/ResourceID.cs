using System;
using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public interface ResourceID
    {
        // ID is the Resource ID as a String
        string ID();

        // Segments is a list of ordered Segments present in this Resource ID
        List<ResourceIDSegment> Segments();
    }

    public class ResourceIDSegment
    {
        // Type specifies the Segment Type, such as a Constant/UserSpecified
        public ResourceIDSegmentType Type { get; set; }

        // ConstantReference is the Type of Constant that this Segment uses - if Type is `Constant`
        public Type? ConstantReference { get; set; }

        // FixedValue is a fixed/static value for this segment when Type is `Static`
        public string? FixedValue { get; set; }

        // Name is the name of this segment, for example `ResourceGroups` or `VirtualMachine` in Title Case.
        public string Name { get; set; }
    }

    public enum ResourceIDSegmentType
    {
        Unknown,
        Static,
        Constant,
        ResourceGroup,
        ResourceProvider,
        SubscriptionId,
        Scope,
        UserSpecified
    }
}