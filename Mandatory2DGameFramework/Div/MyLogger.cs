
using System.Diagnostics;
namespace Mandatory2DGameFramework.Div
{
   

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


        /// <summary>
        /// Adds a TraceListener to the TraceSource.
        /// </summary>
        /// <param name="listener">The TraceListener to add.</param>
        public void AddListener(TraceListener listener)
        {
            _traceSource.Listeners.Add(listener);
        }


        /// <summary>
        /// Removes a TraceListener from the TraceSource.
        /// </summary>
        /// <param name="listener">The TraceListener to remove.</param>
        public void RemoveListener(TraceListener listener)
        {
            _traceSource.Listeners.Remove(listener);
        }


        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The informational message to log.</param>
        public void LogInformation(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Information, 700, message);
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The warning message to log.</param>
        public void LogWarning(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Warning, 700, message);
        }


        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The error message to log.</param>

        public void LogError(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Error, 700, message);
        }

        /// <summary>
        /// Logs a critical message.
        /// </summary>
        /// <param name="message">The critical message to log.</param>
        public void LogCritical(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Critical, 700, message);
        }

        /// <summary>
        /// Closes the TraceSource and releases resources.
        /// </summary>
        public void Close()
        {
            _traceSource.Close();
        }


    }


}
