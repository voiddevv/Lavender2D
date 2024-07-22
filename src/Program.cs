// See https://aka.ms/new-console-template for more informationnu
using System.Diagnostics;
using Raylib_cs;

public class Program{
    static Process proc = Process.GetCurrentProcess();
    public static int Main(){
        Raylib.InitWindow(1280,720,"Friday Night Funkin'");
        int fps = int.Parse(File.ReadAllText($"{PathUtils.GetElfPath()}assets/fps.txt"));
        Game.Init(new Test(),fps);
        Raylib.SetTargetFPS(Game.maxFps);
         
        while(!Raylib.WindowShouldClose()){
            update();
        }
        return 0;
    }
    static void update(){
        float delta = Raylib.GetFrameTime();
        Game.Update(delta);
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Lime);
        Game.Draw();
        Raylib.EndDrawing();
    }
}
