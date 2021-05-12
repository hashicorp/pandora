namespace Pandora.Api.V1.Helpers
{
    public static class SelfReference
    {
        public static string? To(string selfReference, object? requestObject) {
            if (requestObject == null) {
                return null;
            }

            var objectName = requestObject.GetType();
            return $"{selfReference}#{objectName.Name}";
        }
        
        public static string? To(string selfReference, string objectName) {
            if (string.IsNullOrWhiteSpace(objectName)) {
                return null;
            }
            
            return $"{selfReference}#{objectName}";
        }
    }
}