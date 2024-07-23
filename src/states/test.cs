using System.Xml.Linq;
using Raylib_cs;

public class Test : State{
    Texture2D tex;
    
    List<Rectangle> texRegions = [];
    AudioStreamPlayer vox = new();
    AudioStreamPlayer inst = new();
    public override void Create()
    {
        Raylib.SetWindowState(ConfigFlags.ResizableWindow);
        Raylib.SetMasterVolume(0.4f);
        vox = new();
        inst = new();
        Image img = Raylib.LoadImage(Paths.GetPath("assets/images/scorched.png"));
        tex = Raylib.LoadTextureFromImage(img);

        vox.stream = Raylib.LoadMusicStream("assets/songs/voices.ogg");
        inst.stream = Raylib.LoadMusicStream("assets/songs/inst.ogg");
        Add(vox);
        Add(inst);
        inst.Play(90);
        vox.Play(90);

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
        time += delta;
        if(time > 1.0f/24.0f){
            curframe ++;
            time = 0;
            if(curframe > texRegions.Count - 1){
                curframe = 0;
            }
        }
    }
    public override void Draw()
    {
        Raylib.DrawTexturePro(tex,texRegions[curframe],new(640,360,texRegions[curframe].Size),texRegions[curframe].Size/2,0.0f,Color.White);
    }
}