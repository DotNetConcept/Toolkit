namespace DotNetConcept.Toolkit.RestSharp.Serialization
{
    using global::RestSharp;
    using global::RestSharp.Serialization;

    using Newtonsoft.Json;

    public class JsonNetSerializer : IRestSerializer
    {
        private readonly JsonSerializerSettings settings;
        
        public JsonNetSerializer()
        {
        }

        public JsonNetSerializer(JsonSerializerSettings settings)
        {
            this.settings = settings;
        }

        public T Deserialize<T>(IRestResponse response)
        {
            //this.logger?.Debug("Deserialization message : {Message}", response.Content);
            return JsonConvert.DeserializeObject<T>(response.Content, this.settings);
        }

        public string Serialize(object obj)
        {
            var result = JsonConvert.SerializeObject(obj, this.settings);
            //this.logger.Debug("Serialization message : {Message}", result);
            return result;
        }

        public string Serialize(Parameter parameter)
        {
            var result = JsonConvert.SerializeObject(parameter.Value, this.settings);
            //this.logger.Debug("Serialization message : {Message}", result);
            return result;
        }

        public string[] SupportedContentTypes { get; } =
        {
            "application/json", "text/json", "text/x-json", "text/javascript", "*+json"
        };
        
        public DataFormat DataFormat { get; } = DataFormat.Json;

        public string ContentType { get; set; } = "application/json";
    }
}
