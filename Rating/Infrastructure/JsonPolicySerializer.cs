using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rating.Infrastructure
{
    public class JsonPolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromString(string policyJson)
        {
            return JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
        }
    }
}
