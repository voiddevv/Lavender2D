using System.Numerics;
using Raylib_cs;

public class Test : State{
    Texture2D tex;
    Sprite s = new();
    AudioStreamPlayer vox;
    AudioStreamPlayer inst;

    public override void Create()
    {
        Raylib.SetMasterVolume(0.4f);
        vox = new();
        inst = new();

        Raylib.SetExitKey(KeyboardKey.Null);
        Image img = Raylib.GenImageCellular(1280*2,720*2,32);
        tex = Raylib.LoadTextureFromImage(img);
        Raylib.UnloadImage(img);
        s.texture = tex;
        s.scale = new(0.5f,0.5f);
        s.position = new(640,360);  
        objects.Add(s);
        vox.stream = Raylib.LoadMusicStream("assets/songs/voices.ogg");
        inst.stream = Raylib.LoadMusicStream("assets/songs/inst.ogg");

        Add(vox);
        Add(inst);
        vox.Play(360);
        inst.Play(360);


    }

    float rot = 0.0f;
    public override void Update(float delta)
    {
        rot += delta*30.0f;
        s.rotation = rot;
        if(Raylib.IsKeyPressed(KeyboardKey.Escape)){
            Environment.Exit(0);
        }


    }
    public override void Draw()
    {
        Raylib.DrawRectanglePro(new Rectangle(640,360,640,360),new Vector2(320,180),rot,Raylib.ColorFromHSV(rot*3.0f,0.7f,0.4f));

    }
}