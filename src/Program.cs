using System.Numerics;
using Raylib_cs;

public class Program{
    public static void Main(String[] args){
        Raylib.InitWindow(1280,720,"Friday Night Funkin'");
        Raylib.InitAudioDevice();
        int fps = int.Parse(File.ReadAllText(Paths.GetPath("assets/fps.txt")));
        Game.Init(new Test(),fps);
        Raylib.SetTargetFPS(Game.maxFps);
         
        while(!Raylib.WindowShouldClose()){
            update();
        }
    }
    static void update(){
        float delta = Raylib.GetFrameTime();
        Raylib.ClearBackground(Color.Black);
        Vector2 offset = new();
        Vector2 windowSize = new(Raylib.GetScreenWidth(),Raylib.GetScreenHeight());

        Game.Update(delta);
        Raylib.BeginDrawing();
        Raylib.BeginTextureMode(Game.renderTexture);
        Raylib.ClearBackground(Color.Lime);

        Game.Draw();
        Raylib.DrawText($"gameScale: {Game.ContentScale}",0,0,32,Color.RayWhite);
        Raylib.EndTextureMode();
        Rectangle src = new(0,0,Game.ContentSize.X,-Game.ContentSize.Y);
        Raylib.DrawTexturePro(Game.renderTexture.Texture,src,Game.RenderRec,Vector2.Zero,0,Color.White);
        Raylib.EndDrawing();

    }
}
