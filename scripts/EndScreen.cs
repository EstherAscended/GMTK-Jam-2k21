using Godot;
using System;

public class EndScreen : Node
{
    public void ReturnToMenu()
    {
        GetTree().ChangeScene("res://levels/Menus/MainMenu.tscn");
    }
}
