# OOPAssignmentOne
Included in this repository is the code for the oop assignment 1.
Your software development company has been approached by a potential client to develop a card shuffling and dealing application (using object orientated programming).
The requirements that the client has specified are:
 - It should only be one pack of cards. 
 - It needs to be used by other card games.
 - The pack of cards should be initialised and created in the Pack constructor.
 - The methods should have the following signatures (to fit in with their other software):
    - public static bool shuffleCardPack(int typeOfShuffle)
    - public static Card dealcard()
    - public static List<Card> dealCard(int amount)
 - There is currently no way of seeing if classes in the code do as they should - so create a 'class Testing' which:
    - Creates a Pack object
    - Calls the 'shuffleCardPack' method with the different shuffle types.
    - Calls the 'deal' methods.
    - Check what is returned. 
