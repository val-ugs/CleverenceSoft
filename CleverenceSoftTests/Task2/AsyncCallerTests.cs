using CleverenceSoftTasks.Task2;
using NUnit.Framework;
using System;
using System.Threading;

namespace CleverenceSoftTests.Task2
{
    public class AsyncCallerTests
    {
        [Test]
        public void CallADelegate_DoingLess5000ms_ShouldReturnTrue()
        {
            // arrange
            EventHandler h = new EventHandler((sender, e) => { });
            AsyncCaller ac = new AsyncCaller(h);

            // act
            bool completedOk = ac.Invoke(5000, null, EventArgs.Empty);

            // assert
            Assert.IsTrue(completedOk);
        }

        [Test]
        public void CallADelegate_DoingLess5000ms_ShouldReturnFalse()
        {
            // arrange
            EventHandler h = new EventHandler((sender, e) => Thread.Sleep(7000));
            AsyncCaller ac = new AsyncCaller(h);

            // act
            bool completedOk = ac.Invoke(5000, null, EventArgs.Empty);

            // assert
            Assert.IsFalse(completedOk);
        }
    }
}
