using CardGameFramework;

namespace BlackJack
{
    public class BlackJackGame : CardGame
    {
        private BlackJackPlayer _computer;
        private BlackJackPlayer _player;
        //Implemention of Singleton Pattern
        private static BlackJackGame _blackJackGameInstance;
        public static BlackJackGame BlackJackGameInstance(BlackJackPlayer player, BlackJackPlayer computer, Deck deck)
        {
            if (_blackJackGameInstance == null)
            {
                _blackJackGameInstance = new BlackJackGame(player, computer, deck);
            }
            return _blackJackGameInstance;
        }
        private BlackJackGame()
        {
        }
        private BlackJackGame(BlackJackPlayer player, BlackJackPlayer computer, Deck deck)
        {
            _computer = computer;
            _player = player;
            _deck = deck;
        }
        public BlackJackPlayer CurrentPlayer { get { return _player; } }
        public BlackJackPlayer Computer { get { return _computer; } }
        /// <summary>
        /// Start a new game
        /// </summary>
        public void DealNewGame()
        {
            _deck.Shuffle();
            _player.NewHand();
            _computer.NewHand();
            for (int i = 0; i < 2; i++)
            {
                Card c = _deck.DrawCard();
                _player.Hand.Cards.Add(c);
                Card d = _deck.DrawCard();
                _computer.Hand.Cards.Add(d);
            }
            _player.CurrentDeck = _deck;
            _computer.CurrentDeck = _deck;
        }
        /// <summary>
        /// Computer to continue to play the game
        /// </summary>
        public void ComputerPlay()
        {
            if (_computer.Hand.GetSumOfCards() < 17)
            {
                _computer.Hit();
                ComputerPlay();
            }
        }
    }
}