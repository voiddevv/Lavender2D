using System.Numerics;
using Raylib_cs;

public static class Game{
    public static int maxFps = 0;
    private static State currentState;
    public static float ContentScale = 1.0f;
    public static Vector2 ContentSize = Vector2.Zero;
    public static Rectangle RenderRec = new();


    public static RenderTexture2D renderTexture;
    public static void Init(State firstState,int framerate = 60){
        maxFps = framerate;
        renderTexture = Raylib.LoadRenderTexture(1280,720);
        ContentSize = new(1280,720);
        SwitchState(firstState);

    }
    public static void SwitchState(State state){
        if(state.Equals(null)){
            throw new Exception("state not valid");
        }
        currentState = state;
        currentState.Create();
    }
    public static void Update(float delta){
        ContentScale = Math.Min((float)Raylib.GetScreenHeight()/ContentSize.Y,(float)Raylib.GetScreenWidth()/ContentSize.X);
        RenderRec.Width = (renderTexture.Texture.Width * ContentScale);
        RenderRec.Height = (renderTexture.Texture.Height * ContentScale);
        RenderRec.X = (Raylib.GetScreenWidth() - RenderRec.Width) / 2.0f;
        RenderRec.Y = (Raylib.GetScreenHeight() - RenderRec.Height) / 2.0f;
        if(!currentState.Equals(null)){
            currentState.Update(delta);
            foreach (var obj in currentState.objects)
            {
                obj.Update(delta);
            }
        }

    }
    public static void Draw(){
            currentState.Draw();
            foreach (GameObject obj in currentState.objects)
            {
                obj.Draw();
            }

    }
}
