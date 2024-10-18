using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DomainGeneral;
public class SettingRead
{
    private readonly IStructFile _structFile;
    private SettingsModel _settings;

    public SettingRead(IStructFile structFile)
    {
        _structFile = structFile;
    }

    public SettingsModel Settings
    {
        get
        {
            try
            {
                if (_settings == null)
                {
                    string Directory = "../../../../Settings.json"; 
                    _settings = _structFile.Read<SettingsModel>(Directory);
                }
                return _settings;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
