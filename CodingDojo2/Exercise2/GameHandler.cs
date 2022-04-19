using System;

namespace UnityCodingDojo.Dojo1.Exercise2
{
    public class GameHandler
    {
        public void StartGame(AbstractHero playerOne, AbstractHero playerTwo, object terrain)
        {
            if (terrain is GrasslandTerrain grassTerrain)
            {
                grassTerrain.ApplyStartingEffect(playerOne, playerTwo);
            }
            
            bool playersCanPlay = true;
            do
            {
                Console.WriteLine("________________________");
                Console.WriteLine($"{playerOne.Name} TURN");
                int playerOneAction = GetPlayerAction(playerOne);
                if (playerOneAction == 1)
                {
                    playerOne.DefaultAbility.Execute(playerOne, playerTwo);
                }
                else
                {
                    playerOneAction-=2;
                    playerOne.Abilities[playerOneAction].Execute(playerOne, playerTwo);
                }
                
                Console.WriteLine($"{playerTwo.Name} HP: {playerTwo.LifePoints}");
                
                Console.WriteLine();
                Console.WriteLine("________________________");
                Console.WriteLine($"{playerTwo.Name} TURN");
                int playerTwoAction = GetPlayerAction(playerTwo);
                if (playerTwoAction == 1)
                {
                    playerTwo.DefaultAbility.Execute(playerTwo, playerOne);
                }
                else
                {
                    playerTwoAction-=2;
                    playerTwo.Abilities[playerTwoAction].Execute(playerTwo, playerOne);
                }
                
                Console.WriteLine($"{playerOne.Name} HP: {playerOne.LifePoints}");
                
                Console.WriteLine();

                if (terrain is PoisonTerrain poisonTerrain)
                {
                    poisonTerrain.ApplyTurnEffect(playerOne, playerTwo);
                }
                
                playersCanPlay = playerOne.LifePoints > 0 && playerTwo.LifePoints > 0;

            } while (playersCanPlay);

            AbstractHero winner = playerOne.LifePoints > 0 ? playerOne : playerTwo;
            
            Console.WriteLine($"The winner is {winner.Name}!");
        }

        private int GetPlayerAction(AbstractHero player)
        {
            Console.Write($"HP: {player.LifePoints} \n");

            Console.WriteLine($"1 - {player.DefaultAbility.AbilityName}");

            int abilitiesAmount = 0;
            if (player.Abilities != null)
            {
                abilitiesAmount = player.Abilities.Length;
                for (int i = 0; i < abilitiesAmount; i++)
                {
                    Console.WriteLine($"{i + 2} - {player.Abilities[i].AbilityName}");
                }
            }

            Func<int, bool> isValidInput = (val) => val > 0 && val <= abilitiesAmount + 1;
            return GetAbilityIndexByInput(isValidInput);
        }

        private int GetAbilityIndexByInput(Func<int, bool> isValidInput)
        {
            Console.WriteLine("Choose your ability:");
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int result) && isValidInput(result))
            {
                return result;
            }
            
            Console.WriteLine("Invalid input! Select an index from the list!");
            return GetAbilityIndexByInput(isValidInput);
        }

        private void Attack(AbstractHero attacker, AbstractHero defender)
        {
            defender.LifePoints -= attacker.AttackPoints;
            Console.WriteLine($"{attacker.Name} did {attacker.AttackPoints} damage to {defender.Name}! {defender.Name} HP: {defender.LifePoints}");
        }
    }
}