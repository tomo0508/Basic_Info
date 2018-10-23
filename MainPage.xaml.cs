using Basicnfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Windows.ApplicationModel.DataTransfer;
using Windows.Devices.Power;
using Windows.Networking;
using Windows.Networking.Connectivity;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.Storage;
using Windows.System.Profile;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Web.Http;

using static BasicInfo.NativeMethods;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BasicInfo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private const int LIST_HEIGHT_OFFSET = 200;
        private const int SCROLLBAR_WIDTH_OFFSET = 24;
        private const int DEFAULT_APPLIST_TIMER_INTERVAL = 5;
        private const int DEFAULT_PROCESSLIST_TIMER_INTERVAL = 30;
        private const string DEFAULT_PIVOT_NAME = "Processes";

        //////private DispatcherTimer processUpdateTimer;
        //////private DispatcherTimer appUpdateTimer;
        //////private DispatcherTimer systemUpdateTimer;
        //private ProcRowInfoCollection processes = new ProcRowInfoCollection();
        //private AppRowInfoCollection apps = new AppRowInfoCollection();
        //////private bool isFocusOnDetails = false;
        //private AppRowInfo detailsApp;
        //private AppProcessesTasks appProcessTasks;
        //////private string processSortColumn = "ExecutableFileName";
        //////private string appSortColumn = "Name";

        private const double GB = 1024 * 1024 * 1024;
        private const double MBPS = 1000 * 1000;
        //////private bool isStaticSystemInfoInitialized;
        //////private bool isFrozen;

        public StaticSystemInfo StaticSystemData { get; internal set; }
        public DynamicSystemInfo DynamicSystemData { get; internal set; }


        public MainPage()
        {
            this.InitializeComponent();
            btnCopy.Visibility = Visibility.Collapsed;
            btnCopy1.Visibility = Visibility.Collapsed;
            txtNoInternet.Text = "";
            spGlavna.BorderBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));




        }



        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            //var process = ProcessDiagnosticInfo.GetForCurrentProcess();
            //var report = process.CpuUsage.GetReport();



            var http = new HttpClient();
            System.Uri url = new System.Uri("https://api.ipify.org");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            //txtAdresa.Text = result;

            RootObject ro = await DetailsAboutIP.ShowTemp(result);


            txtManufacturer.Text = "Device Manufacturer: " + Informacije.DeviceManufacturer;
            txtModel.Text = "Device model: " + Informacije.DeviceModel;
            txtSystem.Text = "Operating system: " + Informacije.DeviceSystem;
            txtFirmware.Text = "OS version (Firmware): " + Informacije.SystemVersion;
            txtDeviceFamily.Text = "Device family: " + Informacije.SystemFamily;
            txtArc.Text = "System Architecture: " + Informacije.SystemArchitecture;

            txtIP.Text = "IP Address: " + result;
            txtIsp.Text = "Internet Service Provider (ISP): " + ro.isp;
            txtCity.Text = "City: " + ro.city;
            txtCountry.Text = "Country: " + ro.country;
            txtZip.Text = "Zip Code: " + ro.zip;
            txtLat.Text = "Latitude: " + ro.lat;
            txtLong.Text = "Longitude: " + ro.lon;

            //txtAdresa.Text = result + ro.@as + ro.city;
            //txtDetalji.Text = "IP: " + result + "\n" + "City: " + ro.city + ""
            //    + "\n Country: " + ro.country + ""
            //    + "\n Country code: " + ro.countryCode + ""
            //    + "\n ISP: " + ro.isp + ""
            //    + "\n Lat: " + ro.lat + ""
            //    + "\n Long: " + ro.lon + ""
            //    + "\n Org: " + ro.org + ""
            //    + "\n Time zone: " + ro.timezone + ""
            //    + "\n Region: " + ro.region + ""
            //    + "\n Region details: " + ro.regionName + ""
            //    + "\n Zip: " + ro.zip + ""
            //    + "\nInfo: " + Informacije.DeviceManufacturer + "\nKoji: " + Informacije.DeviceModel + "\nmmmmm: "+ Informacije.Nesto1;

            //IReadOnlyList<ProcessDiagnosticInfo> processes = ProcessDiagnosticInfo.GetForProcesses();

            //if (processes != null)
            //{
            //    foreach (ProcessDiagnosticInfo process in processes)
            //    {
            //        string exeName = process.ExecutableFileName;
            //        string pid = process.ProcessId.ToString();

            //        ProcessCpuUsageReport cpuReport = process.CpuUsage.GetReport();
            //        TimeSpan userCpu = cpuReport.UserTime;
            //        TimeSpan kernelCpu = cpuReport.KernelTime;

            //        ProcessMemoryUsageReport memReport = process.MemoryUsage.GetReport();
            //        ulong npp = memReport.NonPagedPoolSizeInBytes;
            //        ulong pp = memReport.PagedPoolSizeInBytes;
            //        ulong peakNpp = memReport.PeakNonPagedPoolSizeInBytes;
            //        //...etc

            //        ProcessDiskUsageReport diskReport = process.DiskUsage.GetReport();
            //        long bytesRead = diskReport.BytesReadCount;
            //        long bytesWritten = diskReport.BytesWrittenCount;
            //        //...etc

            //        txtNovo.Text = exeName+"----" + pid + "----" + userCpu + "----" + kernelCpu + "----" + npp;
            //    }
            //}





            //var geoLocator = new Geolocator();
            //geoLocator.DesiredAccuracy = PositionAccuracy.High;
            //Geoposition pos = await geoLocator.GetGeopositionAsync();

            //double lat = pos.Coordinate.Point.Position.Latitude; // current latitude
            //double longt = pos.Coordinate.Point.Position.Longitude; // current longitude
            //var uriNewYork = new Uri(@"bingmaps:?where=" + c + "&ss=1&lvl=20&=sty=a&pit=30");

            //string a = Convert.ToString(ro.lat);
            //string b = Convert.ToString(ro.lon);
            //var uriNewYork = new Uri(@"bingmaps:?cp=" + a + "~" + b + "&ss=1&lvl=20&=sty=a&pit=30");

            //// Launch the Windows Maps app
            //////////var launcherOptions = new Windows.System.LauncherOptions();
            //////////launcherOptions.TargetApplicationPackageFamilyName = "Microsoft.WindowsMaps_8wekyb3d8bbwe";
            //////////var success = await Windows.System.Launcher.LaunchUriAsync(uriNewYork, launcherOptions);
            //////////BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = ro.lat, Longitude = ro.lon };
            //Geopoint cityCenter = new Geopoint(cityPosition);
            //map.Center = cityCenter;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //btnPokazi.Click += BtnPokazi_Click;
            BtnPokazi_Click(sender, e);
            //if (txtManufacturer.Text!= "Device Manufacturer: ")
            //{

            //}

            UpdateDynamicSystemData();
            GetStaticSystemInfo();
        }

        private async void BtnPokazi_Click(object sender, RoutedEventArgs e)
        {

            var connection = NetworkInformation.GetInternetConnectionProfile();
            bool status = (connection != null &&
                connection.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);

            if (status)
            {
                var http = new HttpClient();
                System.Uri url = new System.Uri("https://api.ipify.org");
                var response = await http.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                //txtAdresa.Text = result;

                RootObject ro = await DetailsAboutIP.ShowTemp(result);


                txtManufacturer.Text = "Device Manufacturer: " + Informacije.DeviceManufacturer;

                //if (txtManufacturer.Text=="Device Manufacturer: HP")
                //{
                //  imgManufacturer.Source=  new BitmapImage(new Uri("https://vignette.wikia.nocookie.net/harrypotter/images/a/ac/Logo_HP.png/revision/latest/scale-to-width-down/540?cb=20130804205525.png"));
                //}
                txtModel.Text = "Device model: " + Informacije.DeviceModel;
                txtSystem.Text = "Operating system: " + Informacije.DeviceSystem;
                txtFirmware.Text = "Firmware: " + Informacije.SystemVersion;
                txtDeviceFamily.Text = "Device family: " + Informacije.SystemFamily.Replace("Windows.", "");
                txtArc.Text = "System Architecture: " + Informacije.SystemArchitecture;

                txtIP.Text = "IP Address: " + result;
                txtIsp.Text = "Internet Service Provider (ISP): " + ro.isp;
                txtCity.Text = "City: " + ro.city;
                txtCountry.Text = "Country: " + ro.country;
                txtZip.Text = "Zip Code: " + ro.zip;
                txtLat.Text = "Latitude: " + ro.lat;
                txtLong.Text = "Longitude: " + ro.lon;

                btnCopy.Visibility = Visibility.Visible;
                btnCopy1.Visibility = Visibility.Visible;
            }

            else
            {
                txtModel.Text = "Device model: " + Informacije.DeviceModel;
                txtSystem.Text = "Operating system: " + Informacije.DeviceSystem;
                txtFirmware.Text = "Firmware: " + Informacije.SystemVersion;
                txtDeviceFamily.Text = "Device family: " + Informacije.SystemFamily.Replace("Windows.", "");
                txtArc.Text = "System Architecture: " + Informacije.SystemArchitecture;

                txtNoInternet.Text = "There is no Internet connection, some info can't be displayed.";
                txtIP.Text = "IP Address: -";
                txtIsp.Text = "Internet Service Provider (ISP): -";
                txtCity.Text = "City: -";
                txtCountry.Text = "Country: -";
                txtZip.Text = "Zip Code: -";
                txtLat.Text = "Latitude: -";
                txtLong.Text = "Longitude: -";

                btnCopy.Visibility = Visibility.Visible;
                btnCopy1.Visibility = Visibility.Collapsed;
            }
            spGlavna.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            //btnPokazi.Click += BtnPokazi_Click;
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            var dataPackage = new DataPackage();
            dataPackage.SetText(txtManufacturer.Text + "\n" + txtModel.Text + "\n" + txtSystem.Text + "\n" + txtFirmware.Text + "\n" + txtDeviceFamily.Text + "\n" + txtArc.Text);
            Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
        }

        private void btnCopy1_Click(object sender, RoutedEventArgs e)
        {
            var dataPackage = new DataPackage();
            dataPackage.SetText(txtIP.Text + "\n" + txtIsp.Text + "\n" + txtCity.Text + "\n" + txtCountry.Text + "\n" + txtZip.Text);
            Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
        }



        #region Static system info

        private void GetStaticSystemInfo()
        {
            StaticSystemData = new StaticSystemInfo();

            try
            {
                EasClientDeviceInformation deviceInfo = new EasClientDeviceInformation();
                StaticSystemData.MachineName = deviceInfo.FriendlyName;
                StaticSystemData.MakeModel = $"{deviceInfo.SystemManufacturer}, {deviceInfo.SystemProductName}";
                StaticSystemData.FormFactor = App.FormFactor.ToString();

                string familyVersion = AnalyticsInfo.VersionInfo.DeviceFamilyVersion;
                ulong v = ulong.Parse(familyVersion);
                ulong v1 = (v & 0xFFFF000000000000L) >> 48;
                ulong v2 = (v & 0x0000FFFF00000000L) >> 32;
                ulong v3 = (v & 0x00000000FFFF0000L) >> 16;
                ulong v4 = (v & 0x000000000000FFFFL);
                string deviceVersion = $"{v1}.{v2}.{v3}.{v4}";
                StaticSystemData.OSVersion = deviceVersion;

                SYSTEM_INFO sysInfo = new SYSTEM_INFO();
                GetSystemInfo(ref sysInfo);
                StaticSystemData.LogicalProcessors = sysInfo.dwNumberOfProcessors.ToString();
                StaticSystemData.Processor = $"{sysInfo.wProcessorArchitecture}, level {sysInfo.wProcessorLevel}, rev {sysInfo.wProcessorRevision}";
                StaticSystemData.PageSize = sysInfo.dwPageSize.ToString();
            }
            catch (Exception ex)
            {
                App.AnalyticsWriteLine("MainPage.GetStaticSystemInfo", "Exception", ex.Message);
            }
            staticDataGrid.DataContext = StaticSystemData;
        }

        #endregion


        #region Dynamic system info

        private void UpdateDynamicSystemData()
        {
            DynamicSystemData = new DynamicSystemInfo();

            try
            {
                MEMORYSTATUSEX memoryStatus = new MEMORYSTATUSEX();
                GlobalMemoryStatusEx(memoryStatus);
                DynamicSystemData.PhysicalMemory = $"total = {memoryStatus.ullTotalPhys / GB:N2} GB, available = {memoryStatus.ullAvailPhys / GB:N2} GB";
                DynamicSystemData.PhysicalPlusPagefile = $"total = {memoryStatus.ullTotalPageFile / GB:N2} GB, available = {memoryStatus.ullAvailPageFile / GB:N2} GB";
                DynamicSystemData.VirtualMemory = $"total = {memoryStatus.ullTotalVirtual / GB:N2} GB, available = {memoryStatus.ullAvailVirtual / GB:N2} GB";
                ulong pageFileOnDisk = memoryStatus.ullTotalPageFile - memoryStatus.ullTotalPhys;
                DynamicSystemData.PagefileOnDisk = $"{pageFileOnDisk / GB:N2} GB";
                DynamicSystemData.MemoryLoad = $"{memoryStatus.dwMemoryLoad}%";
            }
            catch (Exception ex)
            {
                App.AnalyticsWriteLine("MainPage.UpdateDynamicSystemData", "MEMORYSTATUSEX", ex.Message);
            }

            bool isBatteryAvailable = true;
            try
            {
                SYSTEM_POWER_STATUS powerStatus = new SYSTEM_POWER_STATUS();
                GetSystemPowerStatus(ref powerStatus);
                DynamicSystemData.ACLineStatus = powerStatus.ACLineStatus.ToString();

                DynamicSystemData.BatteryChargeStatus = $"{powerStatus.BatteryChargeStatus:G}";
                if (powerStatus.BatteryChargeStatus == BatteryFlag.NoSystemBattery
                    || powerStatus.BatteryChargeStatus == BatteryFlag.Unknown)
                {
                    isBatteryAvailable = false;
                    DynamicSystemData.BatteryLife = "n/a";
                }
                else
                {
                    DynamicSystemData.BatteryLife = $"{powerStatus.BatteryLifePercent}%";
                }
                DynamicSystemData.BatterySaver = powerStatus.BatterySaver.ToString();
            }
            catch (Exception ex)
            {
                App.AnalyticsWriteLine("MainPage.UpdateDynamicSystemData", "SYSTEM_POWER_STATUS", ex.Message);
            }

            if (isBatteryAvailable)
            {
                try
                {
                    Battery battery = Battery.AggregateBattery;
                    BatteryReport batteryReport = battery.GetReport();
                    DynamicSystemData.ChargeRate = $"{batteryReport.ChargeRateInMilliwatts:N0} mW";
                    DynamicSystemData.Capacity =
                        $"design = {batteryReport.DesignCapacityInMilliwattHours:N0} mWh, " +
                        $"full = {batteryReport.FullChargeCapacityInMilliwattHours:N0} mWh, " +
                        $"remaining = {batteryReport.RemainingCapacityInMilliwattHours:N0} mWh";
                }
                catch (Exception ex)
                {
                    App.AnalyticsWriteLine("MainPage.UpdateDynamicSystemData", "BatteryReport", ex.Message);
                }
            }
            else
            {
                DynamicSystemData.ChargeRate = "n/a";
                DynamicSystemData.Capacity = "n/a";
            }

            try
            {
                ulong freeBytesAvailable;
                ulong totalNumberOfBytes;
                ulong totalNumberOfFreeBytes;

                // You can only specify a folder path that this app can access, but you can
                // get full disk information from any folder path.
                IStorageFolder appFolder = ApplicationData.Current.LocalFolder;
                GetDiskFreeSpaceEx(appFolder.Path, out freeBytesAvailable, out totalNumberOfBytes, out totalNumberOfFreeBytes);
                DynamicSystemData.TotalDiskSize = $"{totalNumberOfBytes / GB:N2} GB";
                DynamicSystemData.DiskFreeSpace = $"{freeBytesAvailable / GB:N2} GB";
            }
            catch (Exception ex)
            {
                App.AnalyticsWriteLine("MainPage.UpdateDynamicSystemData", "GetDiskFreeSpaceEx", ex.Message);
            }

            try
            {
                IntPtr infoPtr = IntPtr.Zero;
                uint infoLen = (uint)Marshal.SizeOf<FIXED_INFO>();
                int ret = -1;

                while (ret != ERROR_SUCCESS)
                {
                    infoPtr = Marshal.AllocHGlobal(Convert.ToInt32(infoLen));
                    ret = GetNetworkParams(infoPtr, ref infoLen);
                    if (ret == ERROR_BUFFER_OVERFLOW)
                    {
                        // Try again with a bigger buffer.
                        Marshal.FreeHGlobal(infoPtr);
                        continue;
                    }
                }

                FIXED_INFO info = Marshal.PtrToStructure<FIXED_INFO>(infoPtr);
                DynamicSystemData.DomainName = info.DomainName;

                string nodeType = string.Empty;
                switch (info.NodeType)
                {
                    case BROADCAST_NODETYPE:
                        nodeType = "Broadcast";
                        break;
                    case PEER_TO_PEER_NODETYPE:
                        nodeType = "Peer to Peer";
                        break;
                    case MIXED_NODETYPE:
                        nodeType = "Mixed";
                        break;
                    case HYBRID_NODETYPE:
                        nodeType = "Hybrid";
                        break;
                    default:
                        nodeType = $"Unknown ({info.NodeType})";
                        break;
                }
                DynamicSystemData.NodeType = nodeType;
            }
            catch (Exception ex)
            {
                App.AnalyticsWriteLine("MainPage.UpdateDynamicSystemData", "GetNetworkParams", ex.Message);
            }

            try
            {
                ConnectionProfile profile = NetworkInformation.GetInternetConnectionProfile();
                DynamicSystemData.ConnectedProfile = profile.ProfileName;

                NetworkAdapter internetAdapter = profile.NetworkAdapter;
                DynamicSystemData.IanaInterfaceType = $"{(IanaInterfaceType)internetAdapter.IanaInterfaceType}";
                DynamicSystemData.InboundSpeed = $"{internetAdapter.InboundMaxBitsPerSecond / MBPS:N0} Mbps";
                DynamicSystemData.OutboundSpeed = $"{internetAdapter.OutboundMaxBitsPerSecond / MBPS:N0} Mbps";

                IReadOnlyList<HostName> hostNames = NetworkInformation.GetHostNames();
                HostName connectedHost = hostNames.Where
                    (h => h.IPInformation != null
                    && h.IPInformation.NetworkAdapter != null
                    && h.IPInformation.NetworkAdapter.NetworkAdapterId == internetAdapter.NetworkAdapterId)
                    .FirstOrDefault();
                if (connectedHost != null)
                {
                    DynamicSystemData.HostAddress = connectedHost.CanonicalName;
                    DynamicSystemData.AddressType = connectedHost.Type.ToString();
                }
            }
            catch (Exception ex)
            {
                App.AnalyticsWriteLine("MainPage.UpdateDynamicSystemData", "GetInternetConnectionProfile", ex.Message);
            }

            dynamicDataGrid.DataContext = DynamicSystemData;

            //txtTasks.Text = String.Format( DynamicSystemData.ConnectedProfile+"sssssss"+ DynamicSystemData.PhysicalMemory +"-----"+ DynamicSystemData.TotalDiskSize+"----"+ DynamicSystemData.DiskFreeSpace+ " aaaa " + StaticSystemData.Processor );
            //txtTasks.Text = DynamicSystemData.PhysicalMemory + DynamicSystemData.NodeType.ToString();

            //spNesto.DataContext = DynamicSystemData;
        }


        #endregion
    }
}

