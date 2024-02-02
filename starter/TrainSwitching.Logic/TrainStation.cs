namespace TrainSwitching.Logic;

public class TrainStation
{
    public Track[] Tracks { get; }

    public TrainStation()
    {
        Tracks = new Track[10];

        for (int i = 0; i < 10; i++)
        {
            Tracks[i] = new Track();
        }
    }

    /// <summary>
    /// Tries to apply the given operation to the train station.
    /// </summary>
    /// <param name="op">Operation to apply</param>
    /// <returns>Returns true if the operation could be applied, otherwise false</returns>
    public bool TryApplyOperation(SwitchingOperation op)
    {
        // Things to consider:
        // Removing more wagons than available.
        // Adding or removing wagons from a track that is not accessible from the specified side.
        // Adding or removing wagons to/from tracks that do not exist.
        // A train leaves without a locomotive.
        // A train leaves from a track that does not exist.
        // A train leaves when there are no wagons on the track.

        if (op.TrackNumber < 1 || op.TrackNumber > 10)
        {
            return false;
        }

        if (op.Direction == Constants.DIRECTION_EAST && (op.TrackNumber == 9 || op.TrackNumber == 10))
        {
            return false;
        }

        if (Tracks[op.TrackNumber - 1].Wagons.Count < op.NumberOfWagons)
        {
            return false;
        }

        if (op.OperationType == Constants.OPERATION_TRAIN_LEAVE &&
        !Tracks[op.TrackNumber - 1].Wagons.Contains(Constants.WAGON_TYPE_LOCOMOTIVE))
        {
            return false;
        }

        if (op.OperationType == Constants.OPERATION_TRAIN_LEAVE &&
        Tracks[op.TrackNumber - 1].Wagons.Count == 0)
        {
            return false;
        }

        if (op.OperationType == Constants.OPERATION_ADD)
        {
            if (op.Direction == Constants.DIRECTION_EAST)
            {
                Tracks[op.TrackNumber - 1].Wagons.Add(op.WagonType!.Value);
            }
            else
            {
                Tracks[op.TrackNumber - 1].Wagons.Insert(0, op.WagonType!.Value);
            }


        }
        else if (op.OperationType == Constants.OPERATION_REMOVE)
        {

            if (op.Direction == Constants.DIRECTION_EAST)
            {
                for (int i = 0; i < op.NumberOfWagons; i++)
                {
                    Tracks[op.TrackNumber - 1].Wagons.RemoveAt(Tracks[op.TrackNumber - 1].Wagons.Count - 1);
                }
            }
            else
            {
                for (int i = 0; i < op.NumberOfWagons; i++)
                {
                    Tracks[op.TrackNumber - 1].Wagons.RemoveAt(0);
                }
            }
        }
        else if (op.OperationType == Constants.OPERATION_TRAIN_LEAVE)
        {
            Tracks[op.TrackNumber - 1].Wagons.Clear();

        }

        return true;
    }

    /// <summary>
    /// Calculates the checksum of the train station.
    /// </summary>
    /// <returns>The calculated checksum</returns>
    /// <remarks>
    /// See readme.md for details on how to calculate the checksum.
    /// </remarks>
    public int CalculateChecksum()
    {
        int sum = 0;

        for (int i = 0; i < Tracks.Length; i++)
        {
            int wagonSum = 0;

            foreach (var wagon in Tracks[i].Wagons)
            {
                wagonSum += wagon switch
                {
                    Constants.WAGON_TYPE_PASSENGER => 1,
                    Constants.WAGON_TYPE_LOCOMOTIVE => 10,
                    Constants.WAGON_TYPE_FREIGHT => 20,
                    Constants.WAGON_TYPE_CAR_TRANSPORT => 30,
                    _ => 0
                };
            }

            sum += (i + 1) * wagonSum;
        }

        return sum;
    }
}