namespace Application.Interfaces.Services
{
    public interface ILinkProvider
    {
        string Scheme { get; }
        string Host { get; }
    }
}
