using common.Data.EventArgs;

namespace Contracts.TCP_Contracts;

public interface IReceivingContract
{
    public void ReceiveMessage(OnReceiveArgs message);
}