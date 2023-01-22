namespace WebBuilder.API.Constants;

public static class GitKeywords
{
    private const string GIT = "git";
    public static string CLONE = $"{GIT} clone ";
    public static string PULL = $"{GIT} pull ";
    public static string FETCH = $"{GIT} fetch";
}

public static class DotNetKeywords
{
    private static string DOTNET = "dotnet";
    public static string BUILD = $"{DOTNET} build";
    public static string CLEAN = $"{DOTNET} clean";
    public static string RESTORE = $"{DOTNET} restore";
}

public static class NodeKeywords
{
    private static string NPM = "npm";
    public static string NPM_INSTALL = $"{NPM} install";
}
