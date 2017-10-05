using System.Collections.Generic;

namespace CardGameFramework
{
    //Base class for Hand whihc will contain a list of cards for players
    public class Hand
    {
        protected List<Card> _cards = new List<Card>();
        public List<Card> Cards { get { return _cards; } }
        public int NumberOfCards { get { return _cards.Count; } }
    }
}
