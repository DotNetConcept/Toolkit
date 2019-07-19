namespace DotNetConcept.Toolkit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    using DotNetConcept.Toolkit.Threading;

    using Xunit;
    using Xunit.Abstractions;

    public class LockTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        private readonly NamedLock<string> namedLock = new NamedLock<string>();

        public LockTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void NamedLockIntensiveTest()
        {
            var initial1 = 1;
            var initial2 = 5;
            var initial3 = 7;
            var counter1 = initial1;
            var counter2 = initial2;
            var counter3 = initial3;

            var tasks = new List<Task>();
            var r1 = new Random();
            var r2 = new Random();

            var taskCount = r1.Next(100, 10000);
            this.testOutputHelper.WriteLine($"Task count : {taskCount}");

            var sw = new Stopwatch();
            sw.Start();

            for (var i = 1; i <= taskCount; i++)
            {
                var task1 = Task.Run(() => this.Execute("key1", ref counter1, initial1, r2.Next(2, 10)));
                var task2 = Task.Run(() => this.Execute("key2", ref counter2, initial2, r2.Next(2, 10)));
                var task3 = Task.Run(() => this.Execute("key3", ref counter3, initial3, r2.Next(2, 10)));
                tasks.AddRange(new[] { task1, task2, task3 });
            }

            Task.WaitAll(tasks.ToArray());
            
            Assert.Equal(initial1, counter1);
            Assert.Equal(initial2, counter2);
            Assert.Equal(initial3, counter3);

            sw.Stop();
            this.testOutputHelper.WriteLine($"Elapsed time : {sw.Elapsed}");
        }

        private void Execute(string key, ref int counter, int initial, int coefficient)
        {
            var r = new Random();

            using (this.namedLock.Enter(key))
            {
                Assert.Equal(initial, counter);
                counter *= coefficient;
                Assert.Equal(initial * coefficient, counter);

                Thread.Sleep(r.Next(1, 10));

                Assert.Equal(initial * coefficient, counter);
                counter /= coefficient;
                Assert.Equal(initial, counter);
            }
        }
    }
}