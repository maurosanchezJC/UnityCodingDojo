using System;

namespace CodingDojo6
{
    public class DependencyIssueExample
    {
        public void Main()
        {
            // DEPENDENCY ISSUE
            SaveSystemWithDependencyIssue saveSystemWithDependency = new SaveSystemWithDependencyIssue();
            saveSystemWithDependency.Save();
        }
    }
    
    public class SaveSystemWithDependencyIssue
    {
        private DependantMemoryCard _memoryCard;

        public SaveSystemWithDependencyIssue()
        {
            _memoryCard = new DependantMemoryCard();
        }

        public void Save() => _memoryCard.Save();
    }

    public class DependantMemoryCard
    {
        public void Save()
        {
            Console.WriteLine("I'm saving the game into your heart <3");
        }
    }
}