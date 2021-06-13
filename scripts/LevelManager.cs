using Godot;
using System;

public class LevelManager : Popup
{
    public override void _Ready()
    {
        
    }

    public void LoadMainMenu()
    {
        GD.Print("Load main menu");
    }

    public void LoadNextLevel()
    {
        GD.Print("Load next level");
    }

    public void RestartLevel()
    {
        GD.Print("Restart level");
    }
}
