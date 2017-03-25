using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32.TaskScheduler;
using RFGs.Client.AutoRunController;
using System;

namespace Client.Test
{
    [TestClass]
    public class AutoRun
    {
        [TestMethod, TestCategory("Client.Test")]
        public void SetTaskScheduler()
        {
            var testName = "testTaskName";

            var timeTrigger = new TimeTrigger
            {
                StartBoundary = DateTime.Now + new TimeSpan(0, 1, 0),
                Enabled = true,
                Repetition = new RepetitionPattern(new TimeSpan(9, 5, 0), TimeSpan.Zero),
                RandomDelay = new TimeSpan(9, 3, 33),
                EndBoundary = DateTime.Now + new TimeSpan(1, 1, 0)
            };

            var execAction = new ExecAction("cmd");
            TaskSchedulerAPI.CreateTask(testName, timeTrigger, execAction);
            Assert.IsTrue(TaskSchedulerAPI.TaskExist(testName));
            TaskSchedulerAPI.DeleteTask(testName);
            Assert.IsFalse(TaskSchedulerAPI.TaskExist(testName));
        }
    }
}
