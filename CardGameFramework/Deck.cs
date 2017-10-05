using System;
using System.Collections.Generic;

namespace CardGameFramework
{
    // Using Interface to declare the methods which are useful for Deck creation
    interface DeckCreation
    {
        Card DrawCard();
        void Shuffle();
    }
    //Deck entity presents pile of cards
    public class Deck : DeckCreation
    { 
        List<Card> _cards = new List<Card>();
        public Card this[int position] { get { return (Card)_cards[position]; } }
        //Default constructor for creation of Deck
        public Deck()
        {
            foreach (int faceVal in Card.CardFaceValues)
            {
                _cards.Add(new Card(faceVal));
            }
        }
        public Card DrawCard()
        {
            Card card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < _cards.Count; i++)
            {
                int fristCard = i;
                int secondCard = random.Next(_cards.Count);
                Card card = _cards[fristCard];
                _cards[fristCard] = _cards[secondCard];
                _cards[secondCard] = card;
            }
        }
    }
}