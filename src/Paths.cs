public static class Paths{
    public static String Elf(){
        String p = Environment.GetCommandLineArgs()[0];
        p = p.Replace("\\","/");
        List<String> parr =  new(p.Split("/"));
        parr.RemoveAt(parr.Count-1);
        return String.Join("/",parr) + "/";
    }
    public static String GetPath(String newPath){
        return $"{Elf()}{newPath}";
    }
}