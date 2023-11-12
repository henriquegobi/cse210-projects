namespace Develop02
{
    public class Prompts
    {
        public string[] GetPrompts(string FilePromptsName)
        {
            string[] prompts = System.IO.File.ReadAllLines(FilePromptsName);
            
            return prompts;
        }
    }
}