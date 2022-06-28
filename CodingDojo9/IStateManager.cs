namespace CodingDojo9
{
    public interface IStateManager
    {
        string Identifier { get; set; }
        void Initialize(string identifier);
        T GetValue<T>(string key);
        void SetValue<T>(string key, T value);

        void SubmitState();
    }
}