using System;
using Microsoft.Win32.TaskScheduler;
using System.Reflection;

namespace RFGs.Client.AutoRunController
{
    class AutoStartTaskScheduler : IAutoRun
    {
        public void Setup()
        {
            var taskName = "RFGs";
            TaskSchedulerAPI.DeleteTask(taskName);

            var timeTrigger = new TimeTrigger
            {
                StartBoundary = DateTime.Now + new TimeSpan(0, 1, 0),
                Enabled = true,
                Repetition = new RepetitionPattern(new TimeSpan(0, 5, 0), TimeSpan.Zero),
                RandomDelay = new TimeSpan(0, 3, 33)
            };
            var execAction = new ExecAction(Assembly.GetEntryAssembly().Location);

            TaskSchedulerAPI.CreateTask(taskName, timeTrigger, execAction);
        }
    }
}
