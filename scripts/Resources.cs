using Godot;
using System;
public enum Resources
    {
        Alcohol,
        Apples,
        Coal,
        Dynamite,
        Gems,
        Gold,
        Mail,
        Oil,
        Steel,
        Wood
    }

public static class ResourcesMethods
{
    public static String GetResourceNameForResource(Resources resource)
    {
        switch (resource)
        {
            case Resources.Alcohol:
                return "Carriage Oli and Alcohol.PNG";
            case Resources.Apples:
                return "Apple and Mail Carriage.PNG";
            case Resources.Coal:
                return "Coal Carriage.PNG";
            case Resources.Dynamite:
                return "Carriage Gold Gem Dynamite.PNG";
            case Resources.Gems:
                return "Carriage Gold Gem Dynamite.PNG";
            case Resources.Gold:
                return "Carriage Gold Gem Dynamite.PNG";
            case Resources.Mail:
                return "Apple and Mail Carriage.PNG";
            case Resources.Oil:
                return "Carriage Oli and Alcohol.PNG";
            case Resources.Steel:
                return "Steel Carriage.PNG";
            case Resources.Wood:
                return "Steel Carriage.PNG";
            default:
                return null;
        }
    }
    public static String GetResourceIconName(Resources resource)
    {
        switch (resource)
        {
            case Resources.Alcohol:
                return "Alcohol.PNG";
            case Resources.Apples:
                return "Apple.PNG";
            case Resources.Coal:
                return "Coal.PNG";
            case Resources.Dynamite:
                return "Dynamite.PNG";
            case Resources.Gems:
                return "Gem.PNG";
            case Resources.Gold:
                return "Gold.PNG";
            case Resources.Mail:
                return "Mail.PNG";
            case Resources.Oil:
                return "Oil.PNG";
            case Resources.Steel:
                return "Steel.PNG";
            case Resources.Wood:
                return "Wood.PNG";
            default:
                return null;
        }
    }

}
