using DomainGeneral;
using InfrastructureGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace InfrastructureGeneral
{
    public class SettingRead

    {
        public SettingRead()
        {

        }
        SettingsModel _settings;
        public SettingsModel Settings
        {
            get
            {
                try
                {
                    if (_settings == null)
                    {
                        
                        IStructFile<SettingsModel> structFile =  new JSONFile<SettingsModel>("../../../Settings.json");
                        structFile.Read();
                        _settings = structFile.Model;
                    }
                    return _settings;

                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }
        
        
    }
}
