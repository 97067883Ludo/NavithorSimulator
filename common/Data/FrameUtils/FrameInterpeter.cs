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
        
        return frameBytes;
    }
}