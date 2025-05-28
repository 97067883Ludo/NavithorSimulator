using common.Data.Sending;

namespace Contracts.TCP_Contracts;

public interface ISendingContract
{
    public void SendMessage(SendTask message);
    
}