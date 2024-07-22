public abstract class State{
    public List<GameObject> objects = [];
    public State(){}
    public abstract void Update(float delta);

    public abstract void Create();

    public abstract void Draw();

    public void Add(GameObject obj){
        objects.Add(obj);
        obj.Added();
    }

    
}