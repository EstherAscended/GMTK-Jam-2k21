using Godot;
using System;

public class SwitchLeft : Node2D
{
    //Each junction has its own version of this script because I didn't think ahead, such is life
    private PackedScene[] pathsToJunctions;
    private PackedScene tileJunctionDown0 = GD.Load<PackedScene>("res://scenes/tracks/Junction/Left/TileJunctionLeft0.tscn");
    private PackedScene tileJunctionDown1 = GD.Load<PackedScene>("res://scenes/tracks/Junction/Left/TileJunctionLeft1.tscn");
    private PackedScene tileJunctionDown2 = GD.Load<PackedScene>("res://scenes/tracks/Junction/Left/TileJunctionLeft2.tscn");
    private LevelGrid currentTrack;
    [Export] private int junctionArrPosition = 0;
    private Node2D activeTrack;
    
    public override void _Ready()
    {
        pathsToJunctions = new[] {tileJunctionDown0, tileJunctionDown1, tileJunctionDown2};
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
            GetNode<SFX>("../RailCreakSFX").Play();
        }
    }
}
