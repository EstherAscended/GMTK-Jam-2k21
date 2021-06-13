using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Train : Sprite
{
    [Export]
    public float TrainSpeed = 1;
    
    [Export] public Vector2 InitialWaypoint;
    [Export] public Node2D LastTouchedTile;
    [Export] public Node2D SecondLastTouchedTile;
    
    public Queue<Vector2> waypointQueue;
    public Vector2 lastWaypoint;
    public List<Resources> HeldGoods;
    
    private float displacementEpsilon = 5f;

    public override void _Ready()
    {
        waypointQueue = new Queue<Vector2>();
        this.AddWaypoint(InitialWaypoint);
        
        lastWaypoint = this.Position;
        LastTouchedTile = new Node2D();
        SecondLastTouchedTile = new Node2D();
        HeldGoods = new List<Resources>();
    }

    public override void _Process(float delta)
    {
        MoveToWaypoint(delta);
    }

    // Figure out whether we're going straight or curvy and call the corresponding function
    private void MoveToWaypoint(float delta) 
    {
        if (waypointQueue.Count == 0) return; // No waypoints in queue, so do nothing.
        
        Vector2 nextWaypoint = waypointQueue.Peek();
        Vector2 direction = this.GlobalPosition.DirectionTo(nextWaypoint);
        double angle = Math.Atan2(direction.y, direction.x);
        this.GlobalRotation = (float) (angle + Math.PI / 2);

        this.Position = Lerp(lastWaypoint, nextWaypoint, delta); 
        //if (IsDistanceSmallEnough(this.Position, nextWaypoint, displacementEpsilon))
		if (IsDistanceFurther(this.Position, nextWaypoint, lastWaypoint))
        {
            this.Position = nextWaypoint;
            lastWaypoint = nextWaypoint;
            GD.Print("==========");
            foreach (Vector2 waypoint in waypointQueue)
            {
                //GD.Print(waypoint);
            }
            GD.Print("==========");
            waypointQueue.Dequeue();
        }
    }

    public void AddWaypoint(Vector2 newPosition)
    { 
        waypointQueue.Enqueue(newPosition);
    }

    private Vector2 Lerp(Vector2 firstVector, Vector2 secondVector, float delta)
    {
        Vector2 direction = firstVector.DirectionTo(secondVector);
        Vector2 movement = direction * TrainSpeed * delta;
        return this.Position + movement;
    }

    private bool IsDistanceSmallEnough(Vector2 a, Vector2 b, float epsilon)
    {
        return a.DistanceTo(b) < epsilon;
    }

    private bool AreFloatsCloseEnough(float a, float b, float epsilon)
    {
        return Math.Abs(b - a) < epsilon;
    }

	private bool IsDistanceFurther(Vector2 a, Vector2 b, Vector2 origin)
	{
		return a.DistanceTo(origin) > b.DistanceTo(origin);
	}
}
