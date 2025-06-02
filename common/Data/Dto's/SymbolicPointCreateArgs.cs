namespace common.Data.Dto_s;

public struct SymbolicPointCreateArgs
{
    public int Id { get; set; }

    public float x { get; set; }
    
    public float y { get; set; }

    public string SymbolicPointName { get; set; }
    public string Type { get; set; }
    public int SymbolicPointId { get; set; }
}