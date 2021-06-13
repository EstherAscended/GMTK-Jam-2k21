using Godot;
using System;

public class ZoomingCamera : Camera2D
{
    private const float CAMERA_SPEED = 10;
    private const float ZOOM_STEP = 0.25f;

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        
        // Every frame, if one of the movement buttons is pressed, move. Increase speed if we're zoomed out to give a 
        // "feeling" of constant speed.
        // TODO: Add panning with mouse
        if (Input.IsActionPressed("ui_up"))
        {
            this.GlobalPosition += new Vector2(0, -CAMERA_SPEED * this.Zoom.y);
        }
        if (Input.IsActionPressed("ui_right"))
        {
            this.GlobalPosition += new Vector2(CAMERA_SPEED * this.Zoom.x, 0);
        }
        if (Input.IsActionPressed("ui_left"))
        {
            this.GlobalPosition += new Vector2(-CAMERA_SPEED * this.Zoom.x, 0);
        }
        if (Input.IsActionPressed("ui_down"))
        {
            this.GlobalPosition += new Vector2(0, CAMERA_SPEED * this.Zoom.y);
        }

    }

    public override void _Input(InputEvent inputEvent)
    {
        // When an input event happens, check if it's a zoom event. If so, zoom in or out.
        if (inputEvent.IsActionPressed("zoom_out_one_step"))
        {
            this.Zoom += new Vector2(ZOOM_STEP, ZOOM_STEP);
        }
        if (inputEvent.IsActionPressed("zoom_in_one_step") && !Zoom.IsEqualApprox(new Vector2(0.25f, 0.25f)))
        {
            this.Zoom += new Vector2(-ZOOM_STEP, -ZOOM_STEP);
        }
        
        // If the panning button (usually right mouse button) is held, move the camera the opposite direction of
        // the mouse movement. Also account for the speed difference needed when we're zoomed out.
        if (inputEvent is InputEventMouseMotion && Input.IsActionPressed("pan_button"))
        {
            Vector2 relativeMovement = ((InputEventMouseMotion) inputEvent).Relative;
            this.GlobalPosition -= relativeMovement * this.Zoom;
        }
    }
    
}
