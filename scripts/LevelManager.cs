using Godot;
using System;
using System.Xml;

public class LevelManager : Popup
{
    public static int CurrentLevel = 0;
    private string levelPathStart = "res://levels/";
    private string path1;
    private string path2;
    private string path3;
    private string path4;
    private string path5;
    private string path6;
    private string[] levelPaths;
    public override void _Ready()
    {
        path1 = levelPathStart + "Tutorial1.tscn";
        path2 = levelPathStart + "Tutorial2.tscn";
        path3 = levelPathStart + "Level3.tscn";
        path4 = levelPathStart + "Level4.tscn";
        path5 = levelPathStart + "Level5.tscn";
        path6 = levelPathStart + "Level6.tscn";
        levelPaths = new[] {path1, path2, path3, path4, path5, path6};
    }

    public void LoadMainMenu()
    {
        GD.Print("Load main menu");
        GetTree().ChangeScene("res://levels/Menus/MainMenu.tscn");
    }

    public void LoadNextLevel()
    {
        GD.Print("Load next level");
        if (LevelManager.CurrentLevel + 1 < levelPaths.Length)
        {
            GetTree().ChangeScene(levelPaths[LevelManager.CurrentLevel + 1]);
            LevelManager.CurrentLevel++;
        }
        else
        {
            GetTree().ChangeScene("res://levels/Menus/EndScreen.tscn");
        }
    }

    public void RestartLevel()
    {
        GD.Print("Restart level");
        //This is necessary to prevent crashes. It is necessary because we live in sin.
        for (int i = 0; i < GetTree().Root.GetChildren().Count; i++)
        {
            if (i == 0) continue;
            else
            {
                GetTree().Root.GetChild<Node>(i).Free();
            }
        }
        GetTree().ReloadCurrentScene();
    }
}
