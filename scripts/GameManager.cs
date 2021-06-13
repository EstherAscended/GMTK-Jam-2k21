using Godot;
using System;

public class GameManager : Node
{
    [Export] public int ResourceInLevel = 1;
    public int ResourcesCollected = 0;
    public bool IsGameOver = false;
    private bool canGameEnd = true;
    public bool IsLevelComplete = false;
    public bool StopMovement = false;
    
    public override void _Ready()
    {

    }

    public override void _Process(float delta)
    {
        if (IsGameOver && canGameEnd)
        {
            GameOver();
        }

        if (!IsLevelComplete && ResourcesCollected >= ResourceInLevel)
        {
            CompleteLevel();
        }
        
    }

    private void GameOver()
    {
        GD.Print("Game Over");
        canGameEnd = false;
        IsGameOver = true;
        StopMovement = true;
        //Anything else we want to happen when you fail a level goes here
    }

    private void CompleteLevel()
    {
        GD.Print("Level Complete");
        IsLevelComplete = true;
        StopMovement = true;
        //Anything we want to happen when you complete a level goes here
    }
}
