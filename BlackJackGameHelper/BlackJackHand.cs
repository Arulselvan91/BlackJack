using System;
using CardGameFramework;

namespace BlackJack
{
    public class BlackJackHand : Hand
    {
        /// <summary>
        /// Compares the sum of face values of cards in computer/player hands
        /// </summary>
        /// <returns>Retrun -1, 0, 1 based on the comparision</returns>
        public int CompareFaceValue(object otherHand)
        {
            BlackJackHand aHand = otherHand as BlackJackHand;
            if (aHand != null)
            {
                return this.GetSumOfCards().CompareTo(aHand.GetSumOfCards());
            }
            return 0;
        }

        /// <summary>
        /// Calculate the sum of face values of cards in hand
        /// </summary>
        /// <returns>Retrun the sum of face values of cards in hand</returns>
        public int GetSumOfCards()
        {
            int value = 0;
            foreach (var c in _cards)
            {
                value += c.FaceValue;
            }
            return value;
        }
    }
}