namespace OatMilk.Backend.Api.Tests.TestingHelpers
{
    public interface IFixture<out T>
    {
        T GetSut();
    }
}