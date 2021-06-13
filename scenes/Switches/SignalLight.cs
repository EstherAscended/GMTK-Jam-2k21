using Godot;
using System;

public class SignalLight : AnimatedSprite
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void OnEnter(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        this.Animation = "Inactive";
    }

    public void OnExit(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider") return;
        if (trainArea.GetParent<Carriage>().Pulling == null) this.Animation = "Active";
    }
}
