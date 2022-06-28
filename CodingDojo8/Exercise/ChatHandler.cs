using System;
using System.Collections.Generic;

namespace CodingDojo8.Exercise
{
    public class ChatHandler
    {
        private string userName;
        protected ITimeService timeService;
        protected ILogger logger;
        public List<string> unsupportedWords = new List<string>();

        public bool IsChatEnabled => timeService.CurrentTime.Hour > ChatActiveFromHs &&
                                     timeService.CurrentTime.Hour < ChatActiveToHs;

        public int ChatActiveFromHs { get; private set; }
        public int ChatActiveToHs  { get; private set; }

        public ChatHandler()
        {
            this.timeService = new TimeService();
            this.logger = new ChatLogger() ;
        }

        public void SetActivityTime(int from, int to)
        {
            ChatActiveFromHs = from;
            ChatActiveToHs = to;
        }
        
        public string Username => string.IsNullOrEmpty(userName) ? "guest" : userName;

        public void SetUser(string userName) => this.userName = userName;

        public List<string> UnsupportedWords => new List<string>(unsupportedWords);

        public void SendMessage(string message)
        {
            if (!IsChatEnabled)
            {
                throw new Exception("Chat is disabled, can't send message!");
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new Exception("The message you want to send is empty");
            }
            
            if (ContainsUnsupportedWord(message))
            {
                throw new Exception("The message you want to send contains unsupported words.");
            }

            
            logger.Log(timeService.CurrentTime, Username, message);
        }

        private bool ContainsUnsupportedWord(string message)
        {
            message = message.ToLower();
            
            foreach (string word in unsupportedWords)
            {
                if (message.Contains(word.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        public void AddUnsupportedWord(params string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();
                
                if (!unsupportedWords.Contains(word))
                {
                    unsupportedWords.Add(word);
                }
            }
        }
        
    }
}