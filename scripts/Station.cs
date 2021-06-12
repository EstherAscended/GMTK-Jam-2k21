using Godot;
using System;

public class Station : Sprite
{
    public bool HasGivenResource = false;
    [Export] public Resources AvailableResource = Resources.Alcohol;
    private string imgPath = "res://assets/art/resources/";
    private Sprite resourceSprite; 
    public override void _Ready()
    {
        resourceSprite = GetNode<Sprite>("ResourceSprite");
        switch (AvailableResource)
        {
            case Resources.Alcohol:
                resourceSprite.Texture = GD.Load<Texture>(imgPath + "Alcohol.PNG");
                break;
            case Resources.Apples:
                resourceSprite.Texture = GD.Load<Texture>(imgPath + "Apples.PNG");
                break;
            case Resources.Coal:
                resourceSprite.Texture = GD.Load<Texture>(imgPath + "Coal.PNG");
                break;
            case Resources.Dynamite:
                resourceSprite.Texture = GD.Load<Texture>(imgPath + "Dynamite.PNG");
                break;
            case Resources.Gems:
                resourceSprite.Texture = GD.Load<Texture>(imgPath + "Gems.PNG");
                break;
            case Resources.Gold:
                resourceSprite.Texture = GD.Load<Texture>(imgPath + "Gold.PNG");
                break;
            case Resources.Mail:
                resourceSprite.Texture = GD.Load<Texture>(imgPath + "Oil.PNG");
                break;
            case Resources.Oil:
                resourceSprite.Texture = GD.Load<Texture>(imgPath + "Oil.PNG");
                break;
            case Resources.Steel:
                resourceSprite.Texture = GD.Load<Texture>(imgPath + "Steel.PNG");
                break;
            case Resources.Wood:
                resourceSprite.Texture = GD.Load<Texture>(imgPath + "Wood.PNG");
                break;
        }
    }

    public void StationEntered(Area2D trainArea)
    {
        GD.Print("station entered");
        if (!HasGivenResource && trainArea.GetParent().Name.Contains("Train"))
        {
            GD.Print("station given resource");
            HasGivenResource = true;
            resourceSprite.Texture = new ImageTexture();
        }
    }
}
