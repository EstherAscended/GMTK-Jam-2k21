using Godot;
using System;
using System.Collections.Specialized;

public class SFX : Node
{

    private bool childIsPlaying()
    {
        var children = GetChildren();

        foreach (var child in children)
        {
            if (((AudioStreamPlayer) child).Playing)
            {
                return true;
            }
        }

        return false;
    }
    
    public void Play()
    {
        if (childIsPlaying())
        {
            return;
        }
        
        var children = GetChildren();
        ((AudioStreamPlayer) children[new Random().Next() % children.Count]).Play();
    }
}
