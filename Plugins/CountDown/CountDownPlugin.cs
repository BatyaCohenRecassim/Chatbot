﻿using BasePlugin;
using BasePlugin.Interfaces;
using BasePlugin.Records;
using System;
using System.Collections.Generic;

namespace CountDown
{
    public class CountDownPlugin : IPluginWithScheduler
    {
        IScheduler _scheduler;

        public CountDownPlugin(IScheduler scheduler) => _scheduler = scheduler;

        public static string _Id = "count-down";
        public string Id => _Id;

        public PluginOutput Execute(PluginInput input)
        {
            if (input.Message == "")
            {
                input.Callbacks.StartSession();
                return new PluginOutput("enter number secaond", input.Message);
            }
            else 
            { 
                var interval = int.Parse(input.Message);
                _scheduler.Schedule(TimeSpan.FromSeconds(interval), Id, "");
                input.Callbacks.EndSession();
                return new PluginOutput("the count down stooped", input.PersistentData);
            }

           

        }
        

        public void OnScheduler(string data)
        {
           
            Console.WriteLine("Fired.");
        }
    }
}
