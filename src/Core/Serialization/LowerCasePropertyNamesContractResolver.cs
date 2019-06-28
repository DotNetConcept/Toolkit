namespace DotNetConcept.Toolkit.Serialization
{
    using Newtonsoft.Json.Serialization;

    public class LowerCasePropertyNamesContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName?.ToLower();
        }
    }
}
