using Godot;
using System;

public class SwitchFullCross : Node2D
{
    //Each junction has its own version of this script because I didn't think ahead, such is life
    private PackedScene[] pathsToJunctions;
    private PackedScene tileJunctionCross3 = GD.Load<PackedScene>("res://scenes/tracks/Junction/Cross/Cross3.tscn");
    private PackedScene tileCurvy1 = GD.Load<PackedScene>("res://scenes/tracks/CurvyOne.tscn");
    private PackedScene tileCurvy2 = GD.Load<PackedScene>("res://scenes/tracks/CurvyOne2.tscn");
    
    
    private LevelGrid currentTrack;
    [Export] private int junctionArrPosition = 0;
    private Node2D activeTrack;
    private bool canSwitch = true;
    
    public override void _Ready()
    {
        pathsToJunctions = new[] {tileJunctionCross3, tileCurvy1, tileCurvy2};
        activeTrack = GetNode<Node2D>("ActiveTrack");
        currentTrack = activeTrack.GetChild<LevelGrid>(0);
        currentTrack.QueueFree();
        currentTrack = pathsToJunctions[junctionArrPosition].Instance<LevelGrid>();
        activeTrack.AddChild(currentTrack);
    }

    public void OnSwitchClick(Node viewport, InputEvent @event, int shapeIdx)
    {
        if (Input.IsActionJustPressed("click") && canSwitch)
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

    public void OnEnter(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        canSwitch = false;

    }

    public void OnExit(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        if (trainArea.GetParent<Carriage>().Pulling == null) canSwitch = true;
    }
}
