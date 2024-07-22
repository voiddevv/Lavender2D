using System.Numerics;
using Raylib_cs;

public class Test : State{
    Texture2D tex;
    ColorRect s = new();
    public override void Create()
    {
        Raylib.SetExitKey(KeyboardKey.Null);
        Image img = Raylib.GenImageColor(4096*8,4096*8,Color.Pink);
        tex = Raylib.LoadTextureFromImage(img);
        s.Size = new(100,100);
        objects.Add(s);
        Console.WriteLine(objects.Count);
        Raylib.UnloadImage(img);

    }

    float rot = 0.0f;
    public override void Update(float delta)
    {
        rot += delta*30.0f;
        if(Raylib.IsKeyPressed(KeyboardKey.Escape)){
            Environment.Exit(0);
        }

    }
    public override void Draw()
    {
        Raylib.DrawRectanglePro(new Rectangle(640,360,640,360),new Vector2(320,180),rot,Raylib.ColorFromHSV(rot*3.0f,0.7f,0.4f));

    }
}