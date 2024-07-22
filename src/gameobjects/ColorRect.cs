using System.Numerics;
using Raylib_cs;

public class ColorRect : GameObject{
    public Color Color = Color.White;
    public Vector2 Position = Vector2.Zero;
    public Vector2 Size = Vector2.One;
    public override void Draw(){
        Raylib.DrawRectangleV(Position,Size,Color);
    }
}