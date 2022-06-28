using CodingDojo8.Exercise;

namespace CodingDojo8Tests.Exercise
{
    public class TestableChatHandler : ChatHandler
    {
        public ITimeService TimeService
        {
            get => timeService;
            set => timeService = value;
        }
        
        public ILogger Logger
        {
            get => logger;
            set => logger = value;
        }
    }
}