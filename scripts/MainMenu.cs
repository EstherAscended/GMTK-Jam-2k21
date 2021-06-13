using Godot;
using System;

public class MainMenu : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void onPlayButtonUp() {
        GetTree().ChangeScene("res://levels/Tutorial1.tscn");
    }
}
