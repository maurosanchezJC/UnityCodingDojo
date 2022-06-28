using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodingDojo9
{
    public class GameEvent
    {
        private const string SCORE_STATE_KEY = "Score";
        private const string REWARDS_CLAIMED_STATE_KEY = "RewardsClaimed";
        
        private ITimeService timeService;
        private IStateManager stateManager;

        public bool IsEventReadyToStart => IsEventOnTime;

        public bool IsEventReadyToEnd => (IsScoreAchieved && WereRewardsClaimed) || ArrivedToEndTime;

        public bool IsScoreAchieved => CurrentScore == EventGoal;

        [JsonProperty] public List<IItem> AvailableRewards { get; private set; } = null;
        
        [JsonProperty] public string EventID { get; private set; }
        
        [JsonProperty] public int EventGoal { get; private set; }
        
        [JsonProperty] public DateTime StartTime { get; private set; }
        
        [JsonProperty] public DateTime EndTime { get; private set; }

        
        private bool ArrivedToStartTime => timeService.GetCurrentTime() > StartTime;
        private bool ArrivedToEndTime => timeService.GetCurrentTime() > EndTime;
        public bool IsEventOnTime => ArrivedToStartTime && !ArrivedToEndTime;

        public bool WereRewardsClaimed { get; private set; } = false;
        public int CurrentScore
        {
            get => stateManager.GetValue<int>(SCORE_STATE_KEY);
            private set => stateManager.SetValue(SCORE_STATE_KEY, value);
        }
        
        public void StartEvent()
        {
            if (!IsEventReadyToStart)
            {
                throw new Exception("Event is not ready to start.");
            }
            
            stateManager.Initialize(EventID);
        }

        public void EndEvent()
        {
            if (!IsEventReadyToEnd)
            {
                throw new Exception("Event is not ready to end.");
            }
            
            stateManager.SubmitState();
        }

        public void AddScore(int score)
        {
            if (IsScoreAchieved) return;
            
            if (CurrentScore + score >= EventGoal)
            {
                score = EventGoal;
            }
            
            CurrentScore += score;
        }

        public void RemoveScore(int score)
        {
            if (IsScoreAchieved) return;
            
            if (CurrentScore - score <= 0)
            {
                score = 0;
            }
            
            CurrentScore -= score;
        }

        public List<IItem> GetRewards()
        {
            if (!IsScoreAchieved) return null;

            stateManager.SetValue(REWARDS_CLAIMED_STATE_KEY, true);
            WereRewardsClaimed = true;
            return AvailableRewards;
        }
    }
}