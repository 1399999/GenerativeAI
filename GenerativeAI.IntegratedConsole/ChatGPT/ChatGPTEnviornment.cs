namespace GenerativeAI.IntegratedConsole.ChatGPT;

public static class ChatGPTEnviorment
{
    public static string? GetEnviornmentVariable() => Environment.GetEnvironmentVariable("OpenAIKey", EnvironmentVariableTarget.User);
    public static void SetEnviornmentVariable(string message) => Environment.SetEnvironmentVariable("OpenAIKey", message);
}
