using common.Data.FrameUtils;

namespace common.Data.EventArgs;

public record OnReceiveArgs
{
    public OnReceiveArgs(Frame frame, byte[] data)
    {
        Frame = frame;
        Data = data;
    }

    public Frame Frame;

    public byte[] Data;
}