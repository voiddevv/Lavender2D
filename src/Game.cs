using Raylib_cs;

public static class Game{
    public static int maxFps = 0;



    private static State currentState;
    public static void Init(State firstState,int framerate = 60){
        maxFps = framerate;

        SwitchState(firstState);

    }
    public static void SwitchState(State state){
        if(state.Equals(null)){
            throw new Exception("state not valid");
        }
        currentState = state;
        currentState.Create();
    }
    public static void Update(float delta){
        if(!currentState.Equals(null)){
            currentState.Update(delta);
            foreach (var obj in currentState.objects)
            {
                obj.Update(delta);
            }
        }

    }
    public static void Draw(){
            currentState.Draw();
            foreach (GameObject obj in currentState.objects)
            {
                obj.Draw();
            }

    }
}
