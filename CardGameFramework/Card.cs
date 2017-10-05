namespace CardGameFramework
{
    //Card is a primary entity in any card game
    public class Card
    {
        //Information about card
        public static readonly int[] CardFaceValues = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        //Face value of the card 1, 2, etc.
        public int FaceValue { get; set; }
        //Constructor for Card class
        public Card(int faceValue)
        {
            FaceValue = faceValue;
        }
    }

}
