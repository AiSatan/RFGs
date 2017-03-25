using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RFGs.Client.AutoRunController
{
    internal static class TaskSchedulerAPI
    {
        internal static void CreateTask(string name, Trigger trigger, Microsoft.Win32.TaskScheduler.Action action)
        {
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = name;
                td.Triggers.Add(trigger);
                td.Actions.Add(action);
                ts.RootFolder.RegisterTaskDefinition(name, td);
            }
        }

        internal static void DeleteTask(string taskName)
        {
            using (TaskService ts = new TaskService())
            {
                if (ts.RootFolder.Tasks.Any(t => t.Name == taskName))
                {
                    ts.RootFolder.DeleteTask(taskName);
                }
            }
        }
    }
}
