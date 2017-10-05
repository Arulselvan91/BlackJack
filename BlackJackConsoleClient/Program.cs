using System;
using System.Collections.Generic;
using BlackJack;
using CardGameFramework;

namespace BlackJackConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackJackPlayer player=new BlackJackPlayer();
            BlackJackPlayer computer=new BlackJackPlayer();
            Deck deck=new Deck();
            //Applying a Singleton Design Pattern
            BlackJackGame game = BlackJackGame.BlackJackGameInstance(player,computer,deck);
            //Starting a new game
            game.DealNewGame();
            Console.WriteLine("Player-Sum of Cards:{0}", game.CurrentPlayer.Hand.GetSumOfCards());
            Console.WriteLine("Player Cards:");
            List<Card> pcards = game.CurrentPlayer.Hand.Cards;
            foreach (Card t in pcards)
            {
                Console.WriteLine(t.FaceValue);
            }
            Console.WriteLine("Computer-Sum of Cards:{0}", game.Computer.Hand.GetSumOfCards());
            Console.WriteLine("Computer Cards:");
            List<Card> dcards = game.Computer.Hand.Cards;
            foreach (Card t in dcards)
            {
                Console.WriteLine(t.FaceValue);
            }

            int totalCards = 10;
            int remainingCards = totalCards - (game.Computer.Hand.Cards.Count + game.CurrentPlayer.Hand.Cards.Count);
            while (remainingCards > 0 && game.Computer.Hand.GetSumOfCards() < 21 && game.CurrentPlayer.Hand.GetSumOfCards() < 21)
            {
                Console.WriteLine("Do you want another card?(Y/N)");
                string userChoice = Console.ReadLine();
                if (userChoice == "Y" || userChoice == "y")
                {
                    game.CurrentPlayer.Hit();
                }
                else
                {
                    game.ComputerPlay();
                    break;
                }
                Console.WriteLine("Player-Sum of Cards:{0}", game.CurrentPlayer.Hand.GetSumOfCards());
                Console.WriteLine("Player Cards:");
                pcards = game.CurrentPlayer.Hand.Cards;
                foreach (Card t in pcards)
                {
                    Console.WriteLine(t.FaceValue);
                }
                remainingCards = totalCards - (game.Computer.Hand.Cards.Count + game.CurrentPlayer.Hand.Cards.Count);
            }
            Console.WriteLine("Computer-Sum of Cards:{0}", game.Computer.Hand.GetSumOfCards());
            Console.WriteLine("Computer Cards");
            dcards = game.Computer.Hand.Cards;
            foreach (Card t in dcards)
            {
                Console.WriteLine(t.FaceValue);
            }

            // Validate against the game rules and declare the result
            if (game.Computer.HasBlackJack() || game.Computer.Hand.CompareFaceValue(game.CurrentPlayer.Hand) > 0 || game.CurrentPlayer.IsBusted())
            {
                Console.WriteLine("Computer has Won!!!");
            }
            else if (game.CurrentPlayer.HasBlackJack() || game.CurrentPlayer.Hand.CompareFaceValue(game.Computer.Hand) > 0 || game.Computer.IsBusted())
            {
                Console.WriteLine("Player has Won!!!");
            }
            else if (game.Computer.Hand.GetSumOfCards() == game.CurrentPlayer.Hand.GetSumOfCards())
            {
                Console.WriteLine("Game is drawn.");
            }
            Console.ReadLine();
        }
    }
}