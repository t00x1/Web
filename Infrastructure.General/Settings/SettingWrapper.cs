using System;
using DomainGeneral;

namespace InfrastructureGeneral
{
    public class SettingWrapper
    {
        private readonly StructFileFactory _structFileFactory;
        private readonly IFileContent _fileContent;
        private readonly GetClassTypesByString _getClassTypesByString;
        private SettingsModel _settings;

        public SettingWrapper(StructFileFactory structFile, IFileContent fileContent, GetClassTypesByString getClassTypesByString) 
        {
            _structFileFactory = structFile ?? throw new ArgumentNullException(nameof(structFile));
            _fileContent = fileContent ?? throw new ArgumentNullException(nameof(fileContent));
            _getClassTypesByString = getClassTypesByString ?? throw new ArgumentNullException(nameof(getClassTypesByString));
        }

        private SettingsModel InitializationSettings()
        {
            try
            {
                
                string directory = "../../../../Settings.json"; 
                string fileContent = _fileContent.ReadFile(directory);
                return _structFileFactory.GetStructFile("json").Get<SettingsModel>(fileContent);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ошибка при чтении настроек", ex);
            }
        }

        private SettingsModel GetSettings()
        {
            if (_settings == null)
            {
                _settings = InitializationSettings();
            }
            return _settings;
        }

        public object GetPropertySettings(string propertyName)
        {
            return _getClassTypesByString.GetProperty(GetSettings(), propertyName);
        }

        public SettingsModel Settings
        {
            get
            {
                return GetSettings();
            }
        }
    }
}