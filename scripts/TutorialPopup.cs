using Godot;
using System;

public class TutorialPopup : AcceptDialog
{
    private GameManager gameManager;
    
    public override void _Ready()
    {
        gameManager = GetTree().Root.GetChild(0).GetNode<GameManager>("GameManager");
        gameManager.StopMovement = true;
        PopupCentered();
    }

    public void OnConfirm()
    {
        gameManager.StopMovement = false;
    }
}
