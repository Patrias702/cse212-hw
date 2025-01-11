using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(3, 5) will result in: {3, 6, 9, 12, 15}.
    /// </summary>
    /// <returns>Array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // Step 1: Create an empty array of size 'length'.
        // Step 2: Use a loop to populate the array.
        //         - Each element in the array is calculated as number * (index + 1).
        // Step 3: Return the filled array.

        // Step 1: Create an empty array of size 'length'.
        double[] result = new double[length];

        // Step 2: Populate the array using a loop.
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1); // Multiply the number by (index + 1) to get the multiple.
        }

        // Step 3: Return the result array.
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// For example, if data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3,
    /// the list after the function runs will be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    /// <param name="data">The list of integers to rotate</param>
    /// <param name="amount">The number of positions to rotate to the right</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // Step 1: Validate input (ensure the list is not null or empty).
        // Step 2: Calculate the effective rotation by using amount % data.Count.
        //         - This accounts for cases where amount is greater than the size of the list.
        // Step 3: Use GetRange to extract the elements that will be rotated to the front.
        // Step 4: Remove those elements from the original list.
        // Step 5: Insert the extracted elements at the beginning of the list.

        // Step 1: Validate the input.
        if (data == null || data.Count == 0)
        {
            throw new ArgumentException("The list cannot be null or empty.");
        }

        // Step 2: Calculate the effective rotation amount.
        amount = amount % data.Count;

        if (amount == 0)
        {
            // No rotation needed if the amount is a multiple of the list size.
            return;
        }

        // Step 3: Extract the last 'amount' elements.
        List<int> temp = data.GetRange(data.Count - amount, amount);

        // Step 4: Remove the extracted elements from the end of the original list.
        data.RemoveRange(data.Count - amount, amount);

        // Step 5: Insert the extracted elements at the beginning of the list.
        data.InsertRange(0, temp);
    }
}
