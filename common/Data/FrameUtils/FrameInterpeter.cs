using common.Data.Utils;

namespace common.Data.FrameUtils;

public static class FrameInterpeter
{
    public static Frame Deserialize(byte[] frameBytes)
    {
        if (frameBytes.Length > 9)
        {
            throw new ArgumentException("Frame cannot be larger than 9 bytes");
        }

        Frame frame = new Frame();

        frame.Id = BitConverter.ToInt16(frameBytes, 0);
        frame.SenderId = BitConverter.ToInt16(frameBytes, 2);
        frame.ReceiverId = BitConverter.ToInt16(frameBytes, 4);
        frame.MessageType = frameBytes[6];
        frame.DataLength = BitConverter.ToInt16(frameBytes, 7);
        
        return frame;
    }

    public static byte[] Serialize(Frame frame)
    {
        byte[] frameBytes = new byte[9];

        Appender.AppendRange(ref frameBytes, BitConverter.GetBytes(frame.Id));
        Appender.AppendRange(ref frameBytes, BitConverter.GetBytes(frame.SenderId), 2);
        Appender.AppendRange(ref frameBytes, BitConverter.GetBytes(frame.ReceiverId), 4);
        Appender.AppendRange(ref frameBytes, BitConverter.GetBytes(frame.DataLength), 7);

        return frameBytes;
    }
}