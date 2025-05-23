namespace common.Data.Sending.SpInformation;

public struct SpInformation
{
    public uint Id;
    public uint Type;
    public short AvailableForMachineTypesCount;
    public int[] AvailableForMachineTypes;
    public short NameStringLength;
    public string Name;
}