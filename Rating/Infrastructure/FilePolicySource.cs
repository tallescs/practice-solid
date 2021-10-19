using System.IO;

namespace Rating.Infrastructure
{
    public class FilePolicySource : IPolicySource
    {
        public string GetPolicyFromSource() =>
            File.ReadAllText("policy.json");
    }
}