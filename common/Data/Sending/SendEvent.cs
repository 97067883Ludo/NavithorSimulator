using common.Data.EventArgs;

namespace common.Data.Sending;

public class SendEvent
{
    public static event OnSend OnSendEvent;
    
}

public delegate void OnSend();
