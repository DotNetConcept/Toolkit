namespace DotNetConcept.Toolkit.RestSharp.Serialization
{
    using global::RestSharp;
    using global::RestSharp.Serialization;

    using JetBrains.Annotations;

    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    public class JsonNetSerializer : IRestSerializer
    {
        
        private readonly JsonSerializerSettings settings;

        private readonly ILogger<JsonNetSerializer> logger;

        public JsonNetSerializer([NotNull]ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<JsonNetSerializer>();
        }

        public JsonNetSerializer([NotNull]ILoggerFactory loggerFactory, [NotNull]JsonSerializerSettings settings)
        {
            this.logger = loggerFactory.CreateLogger<JsonNetSerializer>();
            this.settings = settings;
        }

        public T Deserialize<T>(IRestResponse response)
        {
            this.logger?.LogDebug("Deserialization message : {Message}", response.Content);

            var test = new JsonNetSerializer(null);
            return JsonConvert.DeserializeObject<T>(response.Content, this.settings);
        }

        public string Serialize(object obj)
        {
            var result = JsonConvert.SerializeObject(obj, this.settings);
            this.logger.LogDebug("Serialization message : {Message}", result);
            return result;
        }

        public string Serialize(Parameter parameter)
        {
            var result = JsonConvert.SerializeObject(parameter.Value, this.settings);
            this.logger.LogDebug("Serialization message : {Message}", result);
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
