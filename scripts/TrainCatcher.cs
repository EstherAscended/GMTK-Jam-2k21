using Godot;
using System;

public class TrainCatcher : Node
{
    private GameManager gameManager;
    
    public override void _Ready()
    {
        gameManager = GetTree().Root.GetChild(0).GetNode<GameManager>("GameManager");
    }

    public void CatchTrain()
    {
        gameManager.GameOverPopup.RestartLevel();
    }

}
