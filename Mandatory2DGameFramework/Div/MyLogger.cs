using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Div
{
    using System;
    using System.Diagnostics;

    using System.Diagnostics;

    public class MyLogger
    {
        
        private TraceSource _traceSource;

        // 1
        private MyLogger()
        {
            _traceSource = new TraceSource("MyApplicationLog");
            _traceSource.Switch = new SourceSwitch("MyApplicationLog", SourceLevels.All.ToString());


            _traceSource.Listeners.Add(new TextWriterTraceListener("MyApplicationLog.txt"));
           
        }
        //2
        private static readonly MyLogger _instance = new MyLogger();
        //3
        public static MyLogger Instance => _instance;

        public void AddListener(TraceListener listener)
        {
            _traceSource.Listeners.Add(listener);
        }

        // 移除监听器
        public void RemoveListener(TraceListener listener)
        {
            _traceSource.Listeners.Remove(listener);
        }

        // 记录信息日志
        public void LogInformation(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Information, 700, message);
        }

        // 记录警告日志
        public void LogWarning(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Warning, 700, message);
        }

        // 记录错误日志
        public void LogError(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Error, 700, message);
        }

        // 记录关键日志
        public void LogCritical(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Critical, 700, message);
        }

        // 关闭日志
        public void Close()
        {
            _traceSource.Close();
        }
    }


}
