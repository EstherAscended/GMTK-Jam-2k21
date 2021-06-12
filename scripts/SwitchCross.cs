using Godot;
using System;

public class SwitchCross : Node2D
{
    //Each junction has its own version of this script because I didn't think ahead, such is life
    private PackedScene[] pathsToJunctions;
    private PackedScene tileJunctionCross0 = GD.Load<PackedScene>("res://scenes/tracks/Junction/Cross/Cross1.tscn");
    private PackedScene tileJunctionCross1 = GD.Load<PackedScene>("res://scenes/tracks/Junction/Cross/Cross2.tscn");
    private LevelGrid currentTrack;
    [Export] private int junctionArrPosition = 0;
    private Node2D activeTrack;
    
    public override void _Ready()
    {
        pathsToJunctions = new[] {tileJunctionCross0, tileJunctionCross1};
        activeTrack = GetNode<Node2D>("ActiveTrack");
        currentTrack = activeTrack.GetChild<LevelGrid>(0);
        currentTrack.QueueFree();
        currentTrack = pathsToJunctions[junctionArrPosition].Instance<LevelGrid>();
        activeTrack.AddChild(currentTrack);
    }

    public void OnSwitchClick(Node viewport, InputEvent @event, int shapeIdx)
    {
        if (Input.IsActionJustPressed("click"))
        {
            if (junctionArrPosition + 1 < pathsToJunctions.Length)
            {
                junctionArrPosition++;
            }
            else junctionArrPosition = 0;
            
            GD.Print("clicked in switch");
            currentTrack.QueueFree();
            currentTrack = pathsToJunctions[junctionArrPosition].Instance<LevelGrid>();
            activeTrack.AddChild(currentTrack);
            GetNode<RailCreakSFX>("../RailCreakSFX").Play();
        }
    }
}
