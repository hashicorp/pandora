using System;
using System.Linq;
using Pandora.Data.Helpers;

namespace Pandora.Data.Transformers;

public static class TerraformResourceDefinition
{
    public static Models.TerraformResourceDefinition Map(Definitions.Interfaces.TerraformResourceDefinition input)
    {
        var resourceName = input.GetType().Name.TrimSuffix("Resource");

        var resourceIdDetails = DetailsForResourceId(input.ResourceId);
        var deleteMethod = TerraformMethodDefinition.Map(input.DeleteMethod);
        var deleteMethodDetails = MetaDataFromResourceNamespace.Get(input.DeleteMethod.Method);
        if (resourceIdDetails.APIResource != deleteMethodDetails.APIResource || resourceIdDetails.APIVersion != deleteMethodDetails.APIVersion)
        {
            throw new NotSupportedException("the Resource ID and Delete Methods use different API Resources / API Versions");
        }

        var readMethod = TerraformMethodDefinition.Map(input.ReadMethod);
        var readMethodDetails = MetaDataFromResourceNamespace.Get(input.ReadMethod.Method);
        if (resourceIdDetails.APIResource != readMethodDetails.APIResource || resourceIdDetails.APIVersion != readMethodDetails.APIVersion)
        {
            throw new NotSupportedException("the Resource ID and Delete Methods use different API Resources / API Versions");
        }

        // TODO: sanity-check that the (Create/Update) methods come from the same Service/API Version

        return new Models.TerraformResourceDefinition
        {
            DeleteMethod = deleteMethod,
            DisplayName = input.DisplayName,
            GenerateIDValidationFunction = input.GenerateIDValidationFunction,
            GenerateSchema = input.GenerateSchema,
            ReadMethod = readMethod,
            Resource = resourceIdDetails.APIResource,
            ResourceLabel = input.ResourceLabel,
            ResourceName = resourceName,
            ResourceIdName = resourceIdDetails.Name,
        };
    }

    private class ResourceIdMetaData
    {
        public string Name { get; set; }
        public string APIVersion { get; set; }
        public string APIResource { get; set; }
    }

    private static ResourceIdMetaData DetailsForResourceId(Definitions.Interfaces.ResourceID input)
    {
        var metaData = MetaDataFromResourceNamespace.Get(input.GetType());
        return new ResourceIdMetaData
        {
            Name = input.GetType().Name,
            APIResource = metaData.APIResource,
            APIVersion = metaData.APIVersion,
        };
    }

    private class MetaDataFromResourceNamespace
    {
        public string APIVersion { get; set; }
        public string APIResource { get; set; }

        internal static MetaDataFromResourceNamespace Get(Type input)
        {
            // all resources within Pandora's Data Layer are within the namespace `Service.vAPIVersion.Resource`
            // as such we can lean on this convention here to identify both the API Version and the Resource in question
            var components = input.Namespace.Split(".").Reverse();
            if (input.FullName.Contains("+"))
            {
                // if it's a unit test we fake these with private classes, which come out as
                // Pandora.Data.Transformers.TerraformResourceDefinitionTests+Example+v2020_01_01+Example+FakeResourceId
                // since this is a test-only condition, we'll fake this as a single string
                var replacementComponents = input.FullName.Split("+").Reverse();

                // then remove the TypeName at the start (since it's reversed)
                replacementComponents = replacementComponents.Skip(1).ToList();

                // and then add the new components
                components = replacementComponents.ToList();
            }
            var resourceStr = components.First();
            var apiVersion = components.Skip(1).First();
            // the apiVersion is in the `vXXXX_XX_XX` format however and wants to be converted back
            apiVersion = apiVersion.TrimPrefix("v").Replace("_", "-");
            return new MetaDataFromResourceNamespace
            {
                APIVersion = apiVersion,
                APIResource = resourceStr,
            };
        }
    }
}