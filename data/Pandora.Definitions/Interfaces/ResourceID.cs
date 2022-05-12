using System;
using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces;

public interface ResourceID
{
    // CommonAlias is the name of the Common Resource ID that should be used for this Resource ID 
    string? CommonAlias { get; }

    // ID is the Resource ID as a String
    string ID { get; }

    // Segments is a list of ordered Segments present in this Resource ID
    List<ResourceIDSegment> Segments { get; }
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

    public static ResourceIDSegment Constant(string name, Type constantType)
    {
        return new ResourceIDSegment
        {
            Name = name,
            Type = ResourceIDSegmentType.Constant,
            ConstantReference = constantType,
        };
    }

    public static ResourceIDSegment ResourceGroup(string name)
    {
        return new ResourceIDSegment
        {
            Name = name,
            Type = ResourceIDSegmentType.ResourceGroup,
        };
    }

    public static ResourceIDSegment ResourceProvider(string name, string fixedValue)
    {
        return new ResourceIDSegment
        {
            Name = name,
            Type = ResourceIDSegmentType.ResourceProvider,
            FixedValue = fixedValue,
        };
    }

    public static ResourceIDSegment Scope(string name)
    {
        return new ResourceIDSegment
        {
            Name = name,
            Type = ResourceIDSegmentType.Scope,
        };
    }

    public static ResourceIDSegment Static(string name, string fixedValue)
    {
        return new ResourceIDSegment
        {
            Name = name,
            Type = ResourceIDSegmentType.Static,
            FixedValue = fixedValue,
        };
    }

    public static ResourceIDSegment SubscriptionId(string name)
    {
        return new ResourceIDSegment
        {
            Name = name,
            Type = ResourceIDSegmentType.SubscriptionId,
        };
    }

    public static ResourceIDSegment UserSpecified(string name)
    {
        return new ResourceIDSegment
        {
            Name = name,
            Type = ResourceIDSegmentType.UserSpecified,
        };
    }
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