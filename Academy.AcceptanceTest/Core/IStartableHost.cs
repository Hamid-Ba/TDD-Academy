namespace Academy.AcceptanceTest.Core
{
    public interface IStartableHost : IHost
    {
        void Start();
        void Stop();
    }
}