using System.Collections.Generic;
using CardGameFramework;

namespace BlackJack
{
    //Using Interface to declare the methods which are useful for game rules
    interface GameRules
    {
        void Hit();
        bool IsBusted();
        bool HasBlackJack();
    }
    public class BlackJackPlayer : GameRules
    {
        private BlackJackHand hand;
        private Deck currentDeck;
        private List<Card> cards = new List<Card>();
        public Deck CurrentDeck { get { return currentDeck; } set { currentDeck = value; } }
        public BlackJackHand Hand { get { return hand; } }
        /// <summary>
        /// Return new BlackJackHand
        /// </summary>
        /// <returns></returns>
        public BlackJackHand NewHand()
        {
            this.hand = new BlackJackHand();
            return this.hand;
        }
        /// <summary>
        /// If player makes a choice to take a new card, it will be drawn from Deck and added to player hand
        /// </summary>
        public void Hit()
        {
            Card c = currentDeck.DrawCard();
            hand.Cards.Add(c);
        }
        /// <summary>
        /// If hands have value > 21 the player/computer going to be busted
        /// </summary>
        /// <returns> Bool value to specify whether the player/computer is busted</returns>
        public bool IsBusted()
        {

            int sumOfCards = hand.GetSumOfCards();
            if (sumOfCards > 21)
                return true;

            return false;
        }
        /// <summary>
        /// Check to see if player/computer has BlackJack
        /// </summary>
        /// <returns>Bool value to specify whether the player/computer has a BlackKack</returns>
        public bool HasBlackJack()
        {
            int sumOfCards = hand.GetSumOfCards();
            if (sumOfCards == 21)
                return true;
            else return false;
        }
    }
}
