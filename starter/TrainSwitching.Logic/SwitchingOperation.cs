namespace TrainSwitching.Logic;

public class SwitchingOperation
{
    /*
    public int TrackNumber { get; set; }

    public int OperationType { get; set; }

    public int Direction { get; set; }

    public int? WagonType { get; set; }

    public int? NumberOfWagons { get; set; }
    */

    public int TrackNumber { get; set; }

    public Constants.OperationType OperationType { get; set; }

    public Constants.Direction Direction { get; set; }

    public Constants.WagonType? WagonType { get; set; }

    public int? NumberOfWagons { get; set; }
}