namespace common.Data.Utils;

public static class Appender
{
    public static void AppendRange(ref byte[] dest, byte[] source, int offset = 0)
    {
        for (int i = 0; i < source.Length; i++)
        {
            dest[i + offset] = source[i];
        }
    }
}