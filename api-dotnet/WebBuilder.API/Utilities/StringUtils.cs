namespace WebBuilder.API.Utilities;

public static class StringUtils
{
    public static string SetGitName(this string url)
    {
        string[] words = url.Split("/");
        string repoName = words[words.Length - 1];
        repoName = repoName.Replace(".git", "");
        return repoName;
    }
}