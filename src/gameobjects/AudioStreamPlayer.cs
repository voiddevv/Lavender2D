using Raylib_cs;

public class AudioStreamPlayer : GameObject{
    public Music stream;
    public void Play(float time){
        Raylib.PlayMusicStream(stream);
        Seek(time);
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