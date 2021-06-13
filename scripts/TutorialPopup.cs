using Godot;
using System;

public class TutorialPopup : AcceptDialog
{
    private GameManager gameManager;
    
    public override void _Ready()
    {
        gameManager = GetTree().Root.GetChild(0).GetNode<GameManager>("GameManager");
        gameManager.StopMovement = true;
        LevelManager.CurrentLevel = 0;
        PopupCentered();
    }

    public void OnConfirm()
    {
        gameManager.StopMovement = false;
        GetNode<AudioStreamPlayer>("AudioStreamPlayer").Play();
    }
}
