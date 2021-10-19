namespace Rating.Infrastructure
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string text);
    }
}
