namespace OSSApi.Models;

public class CompatibilityMatrix
{
    public int Id { get; set; }
    public int License_id_1 { get; set; }
    public int License_id_2 { get; set; }
    public bool Compatible { get; set; }
}