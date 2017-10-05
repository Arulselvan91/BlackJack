using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGameFramework;

namespace BlackJackTest
{
    [TestClass]
    public class BlackJackTestCard
    {
        BlackJack.BlackJackPlayer player = new BlackJack.BlackJackPlayer();
        BlackJack.BlackJackPlayer computer = new BlackJack.BlackJackPlayer();
        Deck deck = new Deck();

        //Test method to validate the sum of cards
        [TestMethod]
        public void TestSumOfCards()
        {
            BlackJack.BlackJackGame game = BlackJack.BlackJackGame.BlackJackGameInstance(player, computer, deck);
            game.DealNewGame();
            game.CurrentPlayer.Hand.Cards.Clear();
            game.CurrentPlayer.Hand.Cards.Add(new Card(5));
            game.CurrentPlayer.Hand.Cards.Add(new Card(3));
            int expected = 8;
            int actual = game.CurrentPlayer.Hand.GetSumOfCards();
            Assert.AreEqual(expected, actual);
        }

        //Test method to validate the BlackJack scenario
        [TestMethod]
        public void TestHasBlackJack()
        {
            BlackJack.BlackJackGame game = BlackJack.BlackJackGame.BlackJackGameInstance(player, computer, deck);
            game.DealNewGame();
            game.CurrentPlayer.Hand.Cards.Clear();
            game.CurrentPlayer.Hand.Cards.Add(new Card(2));
            game.CurrentPlayer.Hand.Cards.Add(new Card(9));
            game.CurrentPlayer.Hand.Cards.Add(new Card(10));
            bool expected = true;
            bool actual = game.CurrentPlayer.HasBlackJack();
            Assert.AreEqual(expected, actual);
        }
    }
}
