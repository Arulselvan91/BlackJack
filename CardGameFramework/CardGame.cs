namespace CardGameFramework
{
    //Base class for any card game
    public class CardGame
    {
        //Deck in a card game
        protected Deck _deck;
        //Get the current deck
        public Deck CurrentDeck { get { return _deck; } }
    }
}
