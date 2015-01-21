using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WpfProcessControllerApp
{
    public class ConfigFile
    {
        public string FileName { get; set; }

        public List<ButtonFunction> ButtonFunctions { get; private set; }

        public ConfigFile(string fileName)
        {
            this.FileName = fileName;
        }

        public bool Load()
        {
            if (File.Exists(FileName))
            {
                try
                {
                    var formatter = new DataContractSerializer(typeof(List<ButtonFunction>));
                    using (Stream stream = File.OpenRead(FileName))
                    {
                        this.ButtonFunctions = (List<ButtonFunction>)formatter.ReadObject(stream);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("{0} occurred while deserializing config file: {1}", ex.GetType().Name, ex.Message);
                    ButtonFunctions = new List<ButtonFunction>();
                    return false;
                }
            }
            else
            {
                //No config file
                ButtonFunctions = new List<ButtonFunction>();
                return true;
            }
        }

        public bool Save()
        {
            try
            {
                string directory = Path.GetDirectoryName(FileName);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                using (Stream stream = File.Create(FileName))
                {
                    var formatter = new DataContractSerializer(typeof(List<ButtonFunction>));
                    using (var writer = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8))
                    {
                        formatter.WriteObject(writer, ButtonFunctions);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} occurred while serializing config file: {1}", ex.GetType().Name, ex.Message);
                return false;
            }
        }
    }
}
