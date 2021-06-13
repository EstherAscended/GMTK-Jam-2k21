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
    public LevelManager GameOverPopup;
    private LevelManager levelCompletePopup;
    
    public override void _Ready()
    {
        GameOverPopup = GetTree().Root.GetChild(0).GetNode<LevelManager>("GameOverPopup");
        levelCompletePopup = GetTree().Root.GetChild(0).GetNode<LevelManager>("LevelCompletePopup");
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

        if (Input.IsActionJustPressed("restartlevel"))
        {
            GameOverPopup.RestartLevel();
        }
        
    }

    private void GameOver()
    {
        GD.Print("Game Over");
        canGameEnd = false;
        IsGameOver = true;
        StopMovement = true;
        GameOverPopup.PopupCentered();
        //Anything else we want to happen when you fail a level goes here
    }

    private void CompleteLevel()
    {
        GD.Print("Level Complete");
        IsLevelComplete = true;
        StopMovement = true;
        levelCompletePopup.PopupCentered();
        //Anything we want to happen when you complete a level goes here
    }
}
