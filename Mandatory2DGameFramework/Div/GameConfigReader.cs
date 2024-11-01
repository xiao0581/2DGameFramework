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
       /// Initialize the config reader with a file path
       /// </summary>
       /// <param name="filePath">the file to read</param>
        public static void Initialize(string filePath)
        {
            if (_instance == null)
            {
                _instance = new GameConfigReader(filePath);
            }
        }

    
        private GameConfigReader(string filePath)
        {
            _config = XDocument.Load(filePath);
        }

        
        public XDocument GetConfig()
        {
            return _config;
        }


    }


}
