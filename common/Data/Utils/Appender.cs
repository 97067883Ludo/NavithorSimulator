namespace common.Data.Utils;

public static class Appender
{
    public static void AppendRange(ref byte[] dest, byte[] source, int offset = 0)
    {
        if (dest.Length < source.Length + offset)
        {
            throw new ArgumentException("Destination array is not large enough to hold the source array");
        }
        
        for (int i = 0; i < source.Length; i++)
        {
            dest[i + offset] = source[i];
        }
    }
}