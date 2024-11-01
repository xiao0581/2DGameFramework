using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mandatory2DGameFramework.Div
{
    public class GameConfigReader
    {
        private static GameConfigReader _instance;
        private XDocument _config;


       
        
        public static GameConfigReader Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException("Please initialize the config reader with a file path first.");
                }
                return _instance;
            }
        }
        /// <summary>
        /// Private constructor that loads the configuration from the specified file path.
        /// </summary>
        /// <param name="filePath">The path to the XML configuration file.</param>
        private GameConfigReader(string filePath)
        {
            _config = XDocument.Load(filePath);
        }


        /// <summary>
        /// Initializes the singleton instance of GameConfigReader with the specified file path.
        /// </summary>
        /// <param name="filePath">The path to the XML configuration file.</param>

        public static void Initialize(string filePath)
        {
            if (_instance == null)
            {
                _instance = new GameConfigReader(filePath);
            }
        }



        /// <summary>
        /// Gets the loaded configuration as an XDocument.
        /// </summary>
        /// <returns>The XDocument containing the configuration data.</returns>
        public XDocument GetConfig()
        {
            return _config;
        }


    }


}
