using Godot;
using System;

public class DropOffBottom : Sprite
{
    public bool HasReceivedResource = false;
    [Export] public Resources WantedResource = Resources.Alcohol;
    private string imgPath = "res://assets/art/resources/";
    private Sprite resourceSprite; 
    
    public override void _Ready()
    {
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
        if (!HasReceivedResource && trainArea.GetParent().Name.Contains("Train"))
        {
            if (trainArea.GetParent<Train>().HeldGoods.Contains(WantedResource))
            {
                GD.Print(WantedResource.ToString(), " dropped off.");
                HasReceivedResource = true;
                trainArea.GetParent<Train>().HeldGoods.Remove(WantedResource);
                resourceSprite.Texture = new ImageTexture();
                GetNode<SFX>("../DropOffSFX").Play();
            }
        }
    }
}
