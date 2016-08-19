//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iMobileDevice
{
    using iMobileDevice.Usbmuxd;
    using iMobileDevice.Plist;
    using iMobileDevice.iDevice;
    using iMobileDevice.Lockdown;
    using iMobileDevice.Afc;
    using iMobileDevice.DebugServer;
    using iMobileDevice.DiagnosticsRelay;
    using iMobileDevice.FileRelay;
    using iMobileDevice.HeartBeat;
    using iMobileDevice.HouseArrest;
    using iMobileDevice.InstallationProxy;
    using iMobileDevice.Misagent;
    using iMobileDevice.MobileBackup;
    using iMobileDevice.MobileBackup2;
    using iMobileDevice.MobileSync;
    using iMobileDevice.MobileImageMounter;
    using iMobileDevice.NotificationProxy;
    using iMobileDevice.Pinvoke;
    using iMobileDevice.PropertyListService;
    using iMobileDevice.Restore;
    using iMobileDevice.SpringBoardServices;
    using iMobileDevice.Screenshotr;
    using iMobileDevice.Service;
    using iMobileDevice.SyslogRelay;
    using iMobileDevice.WebInspector;
    
    
    public class LibiMobileDevice : ILibiMobileDevice
    {
        
        static ILibiMobileDevice instance = new LibiMobileDevice();
        
        private IUsbmuxdApi usbmuxd;
        
        private IPlistApi plist;
        
        private IiDeviceApi idevice;
        
        private ILockdownApi lockdown;
        
        private IAfcApi afc;
        
        private IDebugServerApi debugServer;
        
        private IDiagnosticsRelayApi diagnosticsRelay;
        
        private IFileRelayApi fileRelay;
        
        private IHeartBeatApi heartBeat;
        
        private IHouseArrestApi houseArrest;
        
        private IInstallationProxyApi installationProxy;
        
        private IMisagentApi misagent;
        
        private IMobileBackupApi mobileBackup;
        
        private IMobileBackup2Api mobileBackup2;
        
        private IMobileSyncApi mobileSync;
        
        private IMobileImageMounterApi mobileImageMounter;
        
        private INotificationProxyApi notificationProxy;
        
        private IPinvokeApi pinvoke;
        
        private IPropertyListServiceApi propertyListService;
        
        private IRestoreApi restore;
        
        private ISpringBoardServicesApi springBoardServices;
        
        private IScreenshotrApi screenshotr;
        
        private IServiceApi service;
        
        private ISyslogRelayApi syslogRelay;
        
        private IWebInspectorApi webInspector;
        
        public LibiMobileDevice()
        {
            this.usbmuxd = new UsbmuxdApi(this);
            this.plist = new PlistApi(this);
            this.idevice = new iDeviceApi(this);
            this.lockdown = new LockdownApi(this);
            this.afc = new AfcApi(this);
            this.debugServer = new DebugServerApi(this);
            this.diagnosticsRelay = new DiagnosticsRelayApi(this);
            this.fileRelay = new FileRelayApi(this);
            this.heartBeat = new HeartBeatApi(this);
            this.houseArrest = new HouseArrestApi(this);
            this.installationProxy = new InstallationProxyApi(this);
            this.misagent = new MisagentApi(this);
            this.mobileBackup = new MobileBackupApi(this);
            this.mobileBackup2 = new MobileBackup2Api(this);
            this.mobileSync = new MobileSyncApi(this);
            this.mobileImageMounter = new MobileImageMounterApi(this);
            this.notificationProxy = new NotificationProxyApi(this);
            this.pinvoke = new PinvokeApi(this);
            this.propertyListService = new PropertyListServiceApi(this);
            this.restore = new RestoreApi(this);
            this.springBoardServices = new SpringBoardServicesApi(this);
            this.screenshotr = new ScreenshotrApi(this);
            this.service = new ServiceApi(this);
            this.syslogRelay = new SyslogRelayApi(this);
            this.webInspector = new WebInspectorApi(this);
        }
        
        public static ILibiMobileDevice Instance
        {
            get
            {
                return LibiMobileDevice.instance;
            }
            set
            {
                LibiMobileDevice.instance = value;
            }
        }
        
        public virtual IUsbmuxdApi Usbmuxd
        {
            get
            {
                return this.usbmuxd;
            }
            set
            {
                this.usbmuxd = value;
            }
        }
        
        public virtual IPlistApi Plist
        {
            get
            {
                return this.plist;
            }
            set
            {
                this.plist = value;
            }
        }
        
        public virtual IiDeviceApi iDevice
        {
            get
            {
                return this.idevice;
            }
            set
            {
                this.idevice = value;
            }
        }
        
        public virtual ILockdownApi Lockdown
        {
            get
            {
                return this.lockdown;
            }
            set
            {
                this.lockdown = value;
            }
        }
        
        public virtual IAfcApi Afc
        {
            get
            {
                return this.afc;
            }
            set
            {
                this.afc = value;
            }
        }
        
        public virtual IDebugServerApi DebugServer
        {
            get
            {
                return this.debugServer;
            }
            set
            {
                this.debugServer = value;
            }
        }
        
        public virtual IDiagnosticsRelayApi DiagnosticsRelay
        {
            get
            {
                return this.diagnosticsRelay;
            }
            set
            {
                this.diagnosticsRelay = value;
            }
        }
        
        public virtual IFileRelayApi FileRelay
        {
            get
            {
                return this.fileRelay;
            }
            set
            {
                this.fileRelay = value;
            }
        }
        
        public virtual IHeartBeatApi HeartBeat
        {
            get
            {
                return this.heartBeat;
            }
            set
            {
                this.heartBeat = value;
            }
        }
        
        public virtual IHouseArrestApi HouseArrest
        {
            get
            {
                return this.houseArrest;
            }
            set
            {
                this.houseArrest = value;
            }
        }
        
        public virtual IInstallationProxyApi InstallationProxy
        {
            get
            {
                return this.installationProxy;
            }
            set
            {
                this.installationProxy = value;
            }
        }
        
        public virtual IMisagentApi Misagent
        {
            get
            {
                return this.misagent;
            }
            set
            {
                this.misagent = value;
            }
        }
        
        public virtual IMobileBackupApi MobileBackup
        {
            get
            {
                return this.mobileBackup;
            }
            set
            {
                this.mobileBackup = value;
            }
        }
        
        public virtual IMobileBackup2Api MobileBackup2
        {
            get
            {
                return this.mobileBackup2;
            }
            set
            {
                this.mobileBackup2 = value;
            }
        }
        
        public virtual IMobileSyncApi MobileSync
        {
            get
            {
                return this.mobileSync;
            }
            set
            {
                this.mobileSync = value;
            }
        }
        
        public virtual IMobileImageMounterApi MobileImageMounter
        {
            get
            {
                return this.mobileImageMounter;
            }
            set
            {
                this.mobileImageMounter = value;
            }
        }
        
        public virtual INotificationProxyApi NotificationProxy
        {
            get
            {
                return this.notificationProxy;
            }
            set
            {
                this.notificationProxy = value;
            }
        }
        
        public virtual IPinvokeApi Pinvoke
        {
            get
            {
                return this.pinvoke;
            }
            set
            {
                this.pinvoke = value;
            }
        }
        
        public virtual IPropertyListServiceApi PropertyListService
        {
            get
            {
                return this.propertyListService;
            }
            set
            {
                this.propertyListService = value;
            }
        }
        
        public virtual IRestoreApi Restore
        {
            get
            {
                return this.restore;
            }
            set
            {
                this.restore = value;
            }
        }
        
        public virtual ISpringBoardServicesApi SpringBoardServices
        {
            get
            {
                return this.springBoardServices;
            }
            set
            {
                this.springBoardServices = value;
            }
        }
        
        public virtual IScreenshotrApi Screenshotr
        {
            get
            {
                return this.screenshotr;
            }
            set
            {
                this.screenshotr = value;
            }
        }
        
        public virtual IServiceApi Service
        {
            get
            {
                return this.service;
            }
            set
            {
                this.service = value;
            }
        }
        
        public virtual ISyslogRelayApi SyslogRelay
        {
            get
            {
                return this.syslogRelay;
            }
            set
            {
                this.syslogRelay = value;
            }
        }
        
        public virtual IWebInspectorApi WebInspector
        {
            get
            {
                return this.webInspector;
            }
            set
            {
                this.webInspector = value;
            }
        }
        
        public virtual bool LibraryFound
        {
            get
            {
                return NativeLibraries.LibraryFound;
            }
        }
    }
}
