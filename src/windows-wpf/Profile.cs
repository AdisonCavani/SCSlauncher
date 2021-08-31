using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSlauncher.Windows
{
    public class Profile
    {
        public string profileName { get; set; }
        public string profileImage { get; set; }
        public string steamPath { get; set; }
        public bool homeDirectory { get; set; }
        public string homeDirectoryPath { get; set; }
        public bool conversionDump { get; set; }
        public string conversionDumpPath { get; set; }
        public bool logFile { get; set; }
        public string logFilePath { get; set; }
        public Ets ets { get; set; }
        public Ats ats { get; set; }
    }

    public class Ets
    {
        public string gameMode { get; set; }
        public string modActivation { get; set; }
        public string renderDevice { get; set; }
        public string vrMode { get; set; }
        public string logFile { get; set; }
        public string editorStartingMap { get; set; }
        public bool noIntro { get; set; }
        public bool force64bit { get; set; }
        public bool unmountUserMap { get; set; }
        public bool useDefaultMemorySettings { get; set; }
        public MemorySettings etsMemorySettings { get; set; }
        public EtsDlc etsDlc { get; set; }
    }

    public class MemorySettings
    {
        public int maxResourceSize { get; set; }
        public int maxTempBuffers { get; set; }
        public int poolSize { get; set; }
        public int maxMemory { get; set; }
    }

    public class EtsDlc
    {
        public bool east { get; set; }
        public bool north { get; set; }
        public bool fr { get; set; }
        public bool it { get; set; }
        public bool balt { get; set; }
        public bool balkan_e { get; set; }
        public bool iberia { get; set; }
    }

    public class Ats
    {
        public string gameMode { get; set; }
        public string modActivation { get; set; }
        public string renderDevice { get; set; }
        public string vrMode { get; set; }
        public string logFile { get; set; }
        public string editorStartingMap { get; set; }
        public bool noIntro { get; set; }
        public bool force64bit { get; set; }
        public bool unmountUserMap { get; set; }
        public bool useDefaultMemorySettings { get; set; }
        public MemorySettings atsMemorySettings { get; set; }
        public AtsDlc atsDlc { get; set; }
    }

    public class AtsDlc
    {
        public bool nevada { get; set; }
        public bool arizona { get; set; }
        public bool nm { get; set; }
        public bool or { get; set; }
        public bool wa { get; set; }
        public bool ut { get; set; }
        public bool co { get; set; }
    }
}
