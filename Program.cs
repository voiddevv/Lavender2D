// See https://aka.ms/new-console-template for more informationnu
using System.Diagnostics;
using System.Numerics;
using Raylib_cs;

public class Program{
    private static Game _g;
    static Process proc = Process.GetCurrentProcess();

    static Thread gameThread = new(new ThreadStart(update));

    public static int Main(){
        Raylib.InitWindow(1280,720,"hello");
        Raylib.InitAudioDevice();
        _g = new Game(new Test(),30);
        Raylib.SetTargetFPS(_g.maxFps);
         
        while(!Raylib.WindowShouldClose()){
            update();
        }
        return 0;
    }
    static String filestr = File.ReadAllText("assets/test.txt");
    static void update(){
        float delta = Raylib.GetFrameTime();
        _g.Update(delta);
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.DarkGray);
        _g.Draw();
        var fiestr = File.ReadAllText("assets/test.txt");
        Raylib.DrawText(filestr,8,16,32,Color.Maroon);
        Raylib.EndDrawing();
    }
}
