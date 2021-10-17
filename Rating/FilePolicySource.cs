using System.IO;

namespace Rating
{
    public class FilePolicySource
    {
        public string GetPolicyFromSource() =>
            File.ReadAllText("policy.json");
    }
}