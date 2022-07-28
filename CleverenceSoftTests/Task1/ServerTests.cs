using CleverenceSoftTasks.Task1;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleverenceSoftTests
{
    public class ServerTests
    {
        [Test]
        public void AddToCount_ShouldReturnTrue()
        {
            // arrange
            var tasks = new List<Task>();
            int value = 1;
            int numberOfRequests = 1000;

            // act
            for (int i = 0; i < numberOfRequests; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => Server.AddToCount(value)));
            }

            Task.WaitAll(tasks.ToArray());

            // assert
            Assert.AreEqual(numberOfRequests, Server.GetCount());
        }
    }
}