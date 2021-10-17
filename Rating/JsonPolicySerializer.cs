using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rating
{
    public class JsonPolicySerializer
    {
        public Policy GetPolicyFromJson(string policyJson)
        {
            return JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
        }
    }
}
