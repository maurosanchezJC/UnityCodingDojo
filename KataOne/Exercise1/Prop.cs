using System;

namespace KataOne
{
    public class Prop
    {
        public void OnAttacked(int attackPoints)
        {
            if (attackPoints > 0)
            {
                Console.WriteLine("the prop was broken!");
                SpawnItem();
            }
        }

        public void SpawnItem()
        {
            Console.WriteLine("the prop drop a super mega archi sword!");
        }
    }
}