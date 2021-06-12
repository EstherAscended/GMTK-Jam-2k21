using Godot;
using System;

public class Music : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {   
        
    }

    public override void _Process(float delta)
    {
        
    }

    public void _on_NormalLeadIn_finished()
    {
        GetNode<AudioStreamPlayer>("NormalLoop").Play();
    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
