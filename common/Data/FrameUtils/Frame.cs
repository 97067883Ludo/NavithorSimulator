namespace common.Data.FrameUtils;

public struct Frame
{
    public Int16 Id;
    public Int16 SenderId;
    public Int16 ReceiverId;
    
    public byte MessageType;
    public Int16 DataLength;

}