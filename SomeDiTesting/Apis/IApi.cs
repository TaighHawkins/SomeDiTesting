namespace SomeDiTesting.Apis
{
    interface IApi
    {
        int Id { get; } 
        string GetResponse();
    }
}