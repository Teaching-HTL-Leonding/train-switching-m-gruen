namespace TrainSwitching.Logic;

public static class Constants
{
    // Integers vales for the different operations
    public const int OPERATION_ADD = 1;
    public const int OPERATION_TRAIN_LEAVE = 0;
    public const int OPERATION_REMOVE = -1;

    public const int WAGON_TYPE_PASSENGER = 0;
    public const int WAGON_TYPE_LOCOMOTIVE = 1;
    public const int WAGON_TYPE_FREIGHT = 2;
    public const int WAGON_TYPE_CAR_TRANSPORT = 3;

    public const int DIRECTION_EAST = 0;
    public const int DIRECTION_WEST = 1;

    // Enumerations for the different operations

    public enum OperationType
    {
        Add = 1,
        TrainLeave = 0,
        Remove = -1
    }

    public enum WagonType
    {
        Passenger = 1,
        Locomotive = 10,
        Freight = 20,
        CarTransport = 30
    }

    public enum Direction
    {
        East,
        West
    }
}