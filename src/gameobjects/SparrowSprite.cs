using Raylib_cs;

struct SparrowAnim
{
    public UInt16 frame;
    public String name;
    public Rectangle region;
}

public class SparrowSprite : GameObject{
    private SparrowAnim[] sparrowData = Array.Empty<SparrowAnim>();
}