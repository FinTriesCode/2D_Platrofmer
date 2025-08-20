
public static class GameManager
{
    public static float playerScore;
    public static float playerLives;
    
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
        return playerScore;
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
