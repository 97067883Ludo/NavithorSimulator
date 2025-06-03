using System.Text;
using common.Data.Sending.SpInformation;

namespace Helpers.ReceivingHelpers;

public static class SymoblicPointHelper
{
    public static byte[] ConvertSymbolicPointToByteArray(SpInformation symbolicPoint)
    {
        List<byte> bytes = new List<byte>();

        bytes.AddRange(BitConverter.GetBytes(symbolicPoint.Id));
        bytes.AddRange(BitConverter.GetBytes(symbolicPoint.Type));
        bytes.AddRange(BitConverter.GetBytes(symbolicPoint.AvailableForMachineTypesCount));

        if (symbolicPoint.AvailableForMachineTypes != null)
        {
            foreach (var machineType in symbolicPoint.AvailableForMachineTypes)
            {
                bytes.AddRange(BitConverter.GetBytes(machineType));
            }
        }

        bytes.AddRange(BitConverter.GetBytes(symbolicPoint.NameStringLength));

        if (!string.IsNullOrEmpty(symbolicPoint.Name))
        {
            bytes.AddRange(Encoding.UTF8.GetBytes(symbolicPoint.Name));
        }

        return bytes.ToArray();
    }
    
    public static byte[] ConvertSymbolicPointToByteArray(SpSpatialInformation symbolicPoint)
    {
        List<byte> bytes = new List<byte>();

        bytes.AddRange(BitConverter.GetBytes(symbolicPoint.Id));
        bytes.AddRange(BitConverter.GetBytes(symbolicPoint.X));
        bytes.AddRange(BitConverter.GetBytes(symbolicPoint.Y));
        bytes.AddRange(BitConverter.GetBytes(symbolicPoint.Z));
        bytes.AddRange(BitConverter.GetBytes(symbolicPoint.Level));
        
        return bytes.ToArray();
    }
    
}