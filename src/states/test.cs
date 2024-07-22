using System.Numerics;
using System.Reflection.Metadata;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using Microsoft.VisualBasic;
using Raylib_cs;

public class Test : State{
    Texture2D tex;
    
    List<Rectangle> texRegions = [];
    AudioStreamPlayer vox;
    AudioStreamPlayer inst;
    public override void Create()
    {
        Raylib.SetWindowState(ConfigFlags.ResizableWindow);
        Raylib.SetMasterVolume(0.4f);
        vox = new();
        inst = new();

        Raylib.SetExitKey(KeyboardKey.Null);
        Image img = Raylib.LoadImage(Paths.GetPath("assets/images/scorched.png"));
        tex = Raylib.LoadTextureFromImage(img);

        // vox.stream = Raylib.LoadMusicStream("assets/songs/voices.ogg");
        // inst.stream = Raylib.LoadMusicStream("assets/songs/inst.ogg");
        // inst.Play(300);
        // vox.Play(300);
        // Add(vox);
        // Add(inst);
        XDocument doc = XDocument.Load(Paths.GetPath("assets/images/scorched.xml"));
        foreach (var item in doc.Root.Elements())
        {
            String itemName = item.Name.ToString();
            if(itemName == "SubTexture"){
                String name = item.Attribute("name").Value;
                int x = int.Parse(item.Attribute("x").Value);
                int y = int.Parse(item.Attribute("y").Value);
                int width = int.Parse(item.Attribute("width").Value);
                int height = int.Parse(item.Attribute("height").Value);
                texRegions.Add(new(x,y,width,height));
            }
            
        }
    }

    float rot = 0.0f;
    int curframe = 0;
    float time = 0.0f;
    public override void Update(float delta)
    {
        rot += delta*30.0f;
        
        if(Raylib.IsKeyPressed(KeyboardKey.Escape)){
            Environment.Exit(0);
        }
        time += delta;
        if(time > 1.0f/24.0f){
            curframe ++;
            time = 0;
            if(curframe > texRegions.Count){
                curframe = 0;
            }
        }
        


    }
    public override void Draw()
    {
        if(curframe > texRegions.Count-1){
            return;
        }
        Raylib.DrawTexturePro(tex,texRegions[curframe],new(640,360,texRegions[curframe].Size),texRegions[curframe].Size/2,0.0f,Color.White);
    }
}