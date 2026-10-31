
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>Array of doubles that are the multiples of the supplied number.</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create a new double array with the requested length.
        // 2. Start a loop at index 0 and continue until the array is filled.
        // 3. For each position, multiply the supplied number by the position plus 1.
        // 4. Store the calculated multiple in the corresponding array position.
        // 5. Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    /// This function modifies the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Find the index where the last 'amount' elements begin.
        // 2. Get a copy of the elements from that index to the end of the list.
        // 3. Remove those elements from their original positions.
        // 4. Insert the copied elements at the beginning of the list.
        // 5. The list is now rotated to the right by the requested amount.

        int startIndex = data.Count - amount;

        List<int> lastElements = data.GetRange(startIndex, amount);

        data.RemoveRange(startIndex, amount);

        data.InsertRange(0, lastElements);
    }
}
