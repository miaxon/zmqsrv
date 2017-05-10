using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace zmqsrv
{
    public partial class ZMQService : ServiceBase
    {
        public ZMQService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            AddLog("start " + DateTime.Now.ToLongDateString());
        }

        protected override void OnStop()
        {
            AddLog("stop " + DateTime.Now.ToLongDateString());
        }

        public void AddLog(string log)
        {
            try
            {
                if (!EventLog.SourceExists("ZMQService"))
                {
                    EventLog.CreateEventSource("ZMQService", "ZMQService");
                }
                eventLog.Source = "ZMQService";
                eventLog.WriteEntry(log);
            }
            catch { }
        }
    }
}
