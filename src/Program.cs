// See https://aka.ms/new-console-template for more informationnu
using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

public class Program{
    static Process proc = Process.GetCurrentProcess();
    public static int Main(){
        Raylib.InitWindow(1280,720,"hello");
        Raylib.InitAudioDevice();
        Game.Init(new Test(),60);
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
        Raylib.ClearBackground(Color.Blank);
        Game.Draw();
        Raylib.EndDrawing();
    }
}
