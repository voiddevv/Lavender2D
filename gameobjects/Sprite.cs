using System.Numerics;
using Raylib_cs;
public class Sprite{
    public Vector2 position = Vector2.Zero;
    public Vector2 scale = Vector2.One;
    public float rotation = 0.0f;
    public Texture2D texture;
    public void draw(){
        if(!texture.Equals(null))
            Raylib.DrawTexturePro(texture,new Rectangle(0,0,texture.Width,texture.Height),new Rectangle(position,texture.Width,texture.Height),new Vector2(texture.Width*0.5f,texture.Height*0.5f),rotation,Color.White);
    }
    public void update(float dt){}
}