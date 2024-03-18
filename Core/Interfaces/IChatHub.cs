namespace Core.Interfaces
{
    public interface IChatHub
    {
         Task SendMessage(string message);
    }
}
