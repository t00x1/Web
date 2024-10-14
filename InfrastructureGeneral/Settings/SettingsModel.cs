using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureGeneral.Settings
{
    public class SettingsModel
    {
          public int MaxLengthOfImage { get; set; }
          public int JWTExpireTimeDays { get; set; }
            public string JWTKey { get; set; }
    }
}
