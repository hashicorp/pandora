using System;
using System.Text.Json.Serialization;
using Pandora.Data.Models;

namespace Pandora.Api.V1.Helpers;

public static class ApiObjectDefinitionMapper
{
    internal static ApiObjectDefinition? Map(ObjectDefinition? input)
    {
        if (input == null)
        {
            return null;
        }

        var definition = new ApiObjectDefinition
        {
            ReferenceName = input.ReferenceName,
            Type = MapApiObjectType(input.Type)
        };
        if (input.NestedItem != null)
        {
            definition.NestedItem = Map(input.NestedItem);
        }
        return definition;
    }

    private static string MapApiObjectType(ObjectType input)
    {
        switch (input)
        {
            case ObjectType.Boolean:
                return ApiObjectType.Boolean.ToString();
            case ObjectType.Csv:
                return ApiObjectType.Csv.ToString();
            case ObjectType.DateTime:
                return ApiObjectType.DateTime.ToString();
            case ObjectType.Dictionary:
                return ApiObjectType.Dictionary.ToString();
            case ObjectType.Float:
                return ApiObjectType.Float.ToString();
            case ObjectType.Integer:
                return ApiObjectType.Integer.ToString();
            case ObjectType.List:
                return ApiObjectType.List.ToString();
            case ObjectType.RawObject:
                return ApiObjectType.RawObject.ToString();
            case ObjectType.Reference:
                return ApiObjectType.Reference.ToString();
            case ObjectType.String:
                return ApiObjectType.String.ToString();

            // Custom Types
            case ObjectType.Location:
                return ApiObjectType.Location.ToString();
            case ObjectType.RawFile:
                return ApiObjectType.RawFile.ToString();
            case ObjectType.SystemAssignedIdentity:
                return ApiObjectType.SystemAssignedIdentity.ToString();
            case ObjectType.LegacySystemAndUserAssignedIdentityList:
                return ApiObjectType.LegacySystemAndUserAssignedIdentityList.ToString();
            case ObjectType.LegacySystemAndUserAssignedIdentityMap:
                return ApiObjectType.LegacySystemAndUserAssignedIdentityMap.ToString();
            case ObjectType.SystemAndUserAssignedIdentityList:
                return ApiObjectType.SystemAndUserAssignedIdentityList.ToString();
            case ObjectType.SystemAndUserAssignedIdentityMap:
                return ApiObjectType.SystemAndUserAssignedIdentityMap.ToString();
            case ObjectType.SystemOrUserAssignedIdentityList:
                return ApiObjectType.SystemOrUserAssignedIdentityList.ToString();
            case ObjectType.SystemOrUserAssignedIdentityMap:
                return ApiObjectType.SystemOrUserAssignedIdentityMap.ToString();
            case ObjectType.UserAssignedIdentityList:
                return ApiObjectType.UserAssignedIdentityList.ToString();
            case ObjectType.UserAssignedIdentityMap:
                return ApiObjectType.UserAssignedIdentityMap.ToString();
            case ObjectType.Tags:
                return ApiObjectType.Tags.ToString();
            case ObjectType.SystemData:
                return ApiObjectType.SystemData.ToString();
        }

        throw new NotSupportedException($"Unsupported ObjectType {input}");
    }
}

public class ApiObjectDefinition
{
    [JsonPropertyName("nestedItem")]
    public ApiObjectDefinition? NestedItem { get; set; }

    [JsonPropertyName("referenceName")]
    public string? ReferenceName { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

public enum ApiObjectType
{
    Boolean,
    Csv,
    DateTime,
    Dictionary,
    Integer,
    Float,
    List,
    RawFile,
    RawObject,
    Reference,
    String,

    // Custom Types
    Location,
    SystemAssignedIdentity,
    SystemAndUserAssignedIdentityList,
    SystemAndUserAssignedIdentityMap,
    LegacySystemAndUserAssignedIdentityList,
    LegacySystemAndUserAssignedIdentityMap,
    SystemOrUserAssignedIdentityList,
    SystemOrUserAssignedIdentityMap,
    UserAssignedIdentityList,
    UserAssignedIdentityMap,
    Tags,
    SystemData,
}