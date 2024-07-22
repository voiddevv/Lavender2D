public static class PathUtils{
    public static String GetElfPath(){
        String p = Environment.GetCommandLineArgs()[0];
        p = p.Replace("\\","/");
        List<String> parr =  new(p.Split("/"));
        parr.RemoveAt(parr.Count-1);
        return String.Join("/",parr) + "/";
    }
}