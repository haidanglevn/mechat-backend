using Core.Entities;

namespace Core.Interfaces
{
    public interface IMessageRepo
    {
        Message SendMessage(Message message);
    }
}
