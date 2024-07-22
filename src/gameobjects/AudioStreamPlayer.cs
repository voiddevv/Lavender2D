using Raylib_cs;

public class AudioStreamPlayer : GameObject{
    public Music stream;
    public void Play(float time){
        Seek(time);
        Raylib.PlayMusicStream(stream);
    }
    public void Stop(){
        Raylib.StopMusicStream(stream);
    }
    public void Seek(float time){
        Raylib.SeekMusicStream(stream,time);
    }
    public override void Update(float delta)
    {
        base.Update(delta);
        Raylib.UpdateMusicStream(stream);
    }
}