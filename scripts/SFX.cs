using Godot;
using System;

public class SFX : Node
{
    public void Play()
    {
        var children = GetChildren();
        ((AudioStreamPlayer) children[new Random().Next() % children.Count]).Play();
    }
}
