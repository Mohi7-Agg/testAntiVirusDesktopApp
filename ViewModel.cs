using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Management;
namespace testAntiVirusDesktopApp
{
    public class ViewModel : ViewModelBase
    {
        private SystemInfo _SystemInfo;

        private ICommand _SubmitCommand;

        public SystemInfo SystemInfo
        {
            get
            {
                return _SystemInfo;
            }
            set
            {
                _SystemInfo = value;
                NotifyPropertyChanged("SystemInfo");
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(param => this.Submit(),
                        null);
                }
                return _SubmitCommand;
            }
        }

        public ViewModel()
        {
            SystemInfo = new SystemInfo();
        }

        private void Submit()
        {
            SystemInfo.Result = GetAntiVirusState();
            NotifyPropertyChanged("SystemInfo");
        }

        private string GetAntiVirusState()
        {
            try
            {
                int OSMajorVersion = System.Environment.OSVersion.Version.Major;
                string wmipathstr = @"\\" + Environment.MachineName;
                bool isVersionGreaterThanVista=true;
                if (OSMajorVersion >= 4 && OSMajorVersion < 6)
                {
                    wmipathstr += @"\root\SecurityCenter";
                    isVersionGreaterThanVista = false;
                }
                // From Windows Vista onwards 
                else if (OSMajorVersion >= 6 && OSMajorVersion <= 10)
                {
                    wmipathstr += @"\root\SecurityCenter2";
                }
                else
                {
                    return "Version Not Supported";
                }

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct"))
                {
                    ManagementObjectCollection instances = searcher.Get();
                    if (instances.Count > 0 && !isVersionGreaterThanVista)
                    {
                        foreach (var inst in instances)
                        {
                            if (Convert.ToBoolean(inst.Properties["productUpToDate"].Value) == true)
                            {
                                return "AntiVirus is Installed and is Active";
                            }
                        }
                        return "AntiVirus is Installed and is In-Active";
                    }
                    else if (instances.Count > 0 && isVersionGreaterThanVista)
                    {
                        foreach (var inst in instances)
                        {
                            // Converting productState value to Hexadecimal string

                            string hex = String.Format("{0:x}", Convert.ToInt32(inst.Properties["productState"].Value));
                            // Dividing the hexadecimal number in three byte pairs {00},{00},{00}
                            // The second pair will tell us about the Active/InActive state of Antivirus    
                            int len = hex.Length;

                            if (len >= 4 && hex.Substring(len - 4, 2) == "10")
                            {
                                return "AntiVirus is Installed and is Active";
                            }
                        }
                        return "AntiVirus is Installed and is In-Active";
                    }
                    return "No AntiVirus is Installed";
                }
            }
            catch (Exception e)
            {
                return String.Format("Operation Failed with Error:{0}", e.Message);
            }
        }

    }
}
