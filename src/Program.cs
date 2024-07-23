using System.Numerics;
using Raylib_cs;

public class Program{
    static Texture2D bgTex;
    public static void Main(String[] args){
        
        Raylib.InitWindow(1280,720,"Friday Night Funkin'");
        Raylib.InitAudioDevice();
        int fps = int.Parse(File.ReadAllText(Paths.GetPath("assets/fps.txt")));
        Game.Init(new Test(),fps);
        Raylib.SetTargetFPS(Game.maxFps);
        Image img = Raylib.GenImageChecked(16,16,1,1,Color.DarkPurple,Color.Maroon); 
        bgTex = Raylib.LoadTextureFromImage(img);
        Raylib.UnloadImage(img);
        while(!Raylib.WindowShouldClose()){
            update();
        }
    }
    static void update(){
        Raylib.PollInputEvents();
        float delta = Raylib.GetFrameTime();
        
        Vector2 offset = new();
        Vector2 windowSize = new(Raylib.GetScreenWidth(),Raylib.GetScreenHeight());

        Game.Update(delta);
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        Raylib.DrawTexturePro(bgTex,new(0,0,bgTex.Width,bgTex.Height),new(0,0,Raylib.GetScreenWidth(),Raylib.GetScreenHeight()),Vector2.Zero,0.0f,Color.White);
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
