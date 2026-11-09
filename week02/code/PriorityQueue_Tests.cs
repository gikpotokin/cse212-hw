using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities, with the highest-priority item added last.
    // Expected Result: Items are dequeued in descending priority order, and every item is removed exactly once.
    // Defect(s) Found: The original loop did not inspect the final queue element, and Dequeue did not remove the selected item.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority, with another lower-priority item.
    // Expected Result: Equal-priority items are dequeued in their original FIFO order, then the lower-priority item.
    // Defect(s) Found: The original comparison used >=, which selected the later item on a priority tie instead of preserving FIFO order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 7);
        priorityQueue.Enqueue("Second", 7);
        priorityQueue.Enqueue("Lower", 2);
        priorityQueue.Enqueue("Third", 7);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
        Assert.AreEqual("Lower", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException is thrown with the exact message "The queue is empty.".
    // Defect(s) Found: No defect; the original implementation already handled the empty queue as required.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: Enqueue items in a mixed order and repeatedly dequeue to verify that each selected item is removed.
    // Expected Result: The highest priority is always returned next, and the queue eventually becomes empty.
    // Defect(s) Found: The original implementation returned the selected value without removing it from the queue.
    public void TestPriorityQueue_RemovesDequeuedItems()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 9);
        priorityQueue.Enqueue("C", 4);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
