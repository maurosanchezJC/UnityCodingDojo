namespace CodingDojo6
{
    public class TestablePlayerDataHandler : PlayerDataHandler
    {
        public ICloudService CloudService
        {
            get => cloudService;
            set => cloudService = value;
        }
    }
}