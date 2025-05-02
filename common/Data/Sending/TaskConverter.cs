using common.Data.FrameUtils;
using common.Data.Utils;

namespace common.Data.Sending;

public class TaskConverter
{
    public static byte[] ToBytes(SendTask task)
    {
        // Convert SendTask to byte array
        // This is a placeholder implementation. You need to implement the actual conversion logic.
        byte[] data = new byte[task.data.Length + 9];
        
        byte[] frameBytes = FrameInterpeter.Serialize(task.frame);
        
        Appender.AppendRange(ref data, frameBytes);
        Appender.AppendRange(ref data, task.data, 9);
        
        return data;
    }
}