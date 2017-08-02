In this solution contains a fully functional 5 Card Draw game in C#. Originally written from an old class of mine in VisualBasic.net, but rerwritten in C# completely.

It uses a decimal point system to determine the winning hand: 
  8.0 - Straight Flush
  7.0 - Four of a kind
  6.0 - Full House
  5.0 - Flush
  4.0 - Straight 
  3.0 - Three of a kind
  2.0 - Two Pair
  1.0 - One Pair
  0.0 - High Card

Ex: Let's say your hand is an Ace of Diamonds, Jack of Diamonds, 10 of Hearts, 10 of Diamonds, and 7 of Diamonds.
    You clearly have one pair, your decimal score would be 1.10141107.
      - The 10 represents the pair of cards you have.
      - The 14 represents the next highest card, which is Ace. 
      - The 11 represents the next highest card, which is Jack.
      - The 07 represents the next highest card, which is 7.

Card Numbers:
0
1
2
3
4
5
6
7
8
9
10
Jack - 11
Queen - 12
King - 13
Ace - 14
  
 
