using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace tIDE
{
    public class AppSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue(null)]
        public string MapId
        {
            get
            {
                return ((string)this["MapId"]);
            }
            set
            {
                this["MapId"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue(null)]
        public string FilePath
        {
            get
            {
                return ((string)this["FilePath"]);
            }
            set
            {
                this["FilePath"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("0")]
        public FormWindowState WindowState
        {
            get
            {
                return ((FormWindowState)this["WindowState"]);
            }
            set
            {
                this["WindowState"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue(null)]
        public Point Location
        {
            get
            {
                return (Point)(this["Location"] ?? new Point(50, 50));
            }
            set
            {
                this["Location"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue(null)]
        public Size Size
        {
            get
            {
                return (Size)(this["Size"] ?? new Size(640, 480));
            }
            set
            {
                this["Size"] = value;
            }
        }
    }
}