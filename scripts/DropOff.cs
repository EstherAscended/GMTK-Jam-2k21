using Godot;
using System;

public class DropOff : Sprite
{
    public bool HasReceivedResource = false;
    [Export] public Resources WantedResource = Resources.Alcohol;
    private string imgPath = "res://assets/art/resources/";
    private Sprite resourceSprite;
    private GameManager gameManager;
    
    public override void _Ready()
    {
        gameManager = GetTree().Root.GetChild(0).GetNode<GameManager>("GameManager");
        
        resourceSprite = GetNode<Sprite>("ResourceSprite");
        switch (WantedResource)
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
                resourceSprite.Texture = GD.Load<Texture>(imgPath + "Mail.PNG");
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

    public void DropOffEntered(Area2D trainArea)
    {
        if (trainArea.Name != "WaypointCollider" || HasReceivedResource
            || trainArea.GetParent<Carriage>().PulledBy != null) return;

        Carriage trainEngine = trainArea.GetParent<Carriage>();
        Carriage carriageWithResource = trainEngine.getNextCarriageWithResource(WantedResource);
        
        if (carriageWithResource == null) return;
        carriageWithResource.RemoveCarriage();
        GD.Print(WantedResource.ToString(), " dropped off.");
        HasReceivedResource = true;
        resourceSprite.Texture = new ImageTexture();
        GetNode<SFX>("../DropOffSFX").Play();

        gameManager.ResourcesCollected++;
    }
}
