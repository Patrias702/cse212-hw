public class PriorityQueue<T>
{
    private readonly List<(T Item, int Priority)> _queue = new();

    public int Count => _queue.Count;

    public void Enqueue(T item, int priority)
    {
        _queue.Add((item, priority));
    }

    public T Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var highestPriority = _queue.MaxBy(x => x.Priority);
        _queue.Remove(highestPriority);

        return highestPriority.Item;
    }
}

[TestMethod]
public void TestPriorityQueue_EnqueueMultipleItems()
{
    var queue = new PriorityQueue<string>();
    queue.Enqueue("Task1", 2);
    queue.Enqueue("Task2", 5);
    queue.Enqueue("Task3", 5);
    queue.Enqueue("Task4", 3);

    Assert.AreEqual("Task2", queue.Dequeue());
    Assert.AreEqual("Task3", queue.Dequeue());
    Assert.AreEqual("Task4", queue.Dequeue());
    Assert.AreEqual("Task1", queue.Dequeue());
}


[TestMethod]
public void TestPriorityQueue_DequeueEmpty()
{
    var queue = new PriorityQueue<string>();

    try
    {
        queue.Dequeue();
        Assert.Fail("Exception should have been thrown.");
    }
    catch (InvalidOperationException e)
    {
        Assert.AreEqual("The queue is empty.", e.Message);
    }
}


[TestMethod]
public void TestPriorityQueue_MixedEnqueueDequeue()
{
    var queue = new PriorityQueue<string>();
    queue.Enqueue("Task1", 3);
    queue.Enqueue("Task2", 1);
    queue.Dequeue(); // Removes Task1
    queue.Enqueue("Task3", 5);

    Assert.AreEqual("Task3", queue.Dequeue());
    Assert.AreEqual("Task2", queue.Dequeue());
}
