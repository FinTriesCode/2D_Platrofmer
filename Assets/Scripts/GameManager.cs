
public static class GameManager
//a static class is a class that does not need a reference within other classes.
//this allows us to keep it abstract and easier to use.
//don't forget the bracket below this comment!
{
    //set variables (this is incomplete as score and lives are not yet features).
    private static float playerScore;
    private static float playerLives;
    
    
    //a series of methods that allow us to either increase or decrease the player score/lives.
    //we need GetScore and GetLives as this allows us to use this data in other classes, despite the variables being private.
    public static float IncreaseScore(float scoreIncreaseAmount)
    {
        return playerScore += scoreIncreaseAmount;
    }
    
    public static float DecreaseScore(float scoreDecreaseAmount)
    {
        return playerScore -= scoreDecreaseAmount;
    }

    public static float GetPlayerScore()
    {
        return playerScore; //we can simply return the variable here the return type of the method is a float, rather than being void (no return type).
    }

    public static float GetPlayerLives()
    {
        return playerLives;
    }

    public static float IncreasePlayerLives(float livesIncreaseAmount)
    {
        return playerLives += livesIncreaseAmount;
    }

    public static float DecreasePlayerLives(float livesDecreaseAmount)
    {
        return playerLives -= livesDecreaseAmount;
    }
}
