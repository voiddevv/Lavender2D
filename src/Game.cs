using Raylib_cs;

public class Game{
    public int maxFps = 0;



    private State currentState;
    public Game(State firstState,int framerate = 60){
        maxFps = framerate;

        SwitchState(firstState);

    }
    public void SwitchState(State state){
        if(state.Equals(null)){
            throw new Exception("state not valid");
        }
        currentState = state;
        currentState.Create();
    }
    public void Update(float delta){
        if(!currentState.Equals(null)){
            currentState.Update(delta);
        }
    }
    public void Draw(){
            currentState.Draw();
            foreach (GameObject obj in currentState.objects)
            {
                obj.Draw();
            }

    }
}
