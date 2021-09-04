namespace SCSlauncher.Core
{
    public class Profile
    {
        public object profileName { get; set; }
        public object profileImage { get; set; }
        public object steamPath { get; set; }
        public object homeDirectory { get; set; }
        public object homeDirectoryPath { get; set; }
        public object conversionDump { get; set; }
        public object conversionDumpPath { get; set; }
        public object logFile { get; set; }
        public object logFilePath { get; set; }
        public Ets ets { get; set; }
        public Ats ats { get; set; }
    }

    public class MemorySettings
    {
        public object maxResourceSize { get; set; }
        public object maxTempBuffers { get; set; }
    }

    public class Ets
    {
        public object gameMode { get; set; }
        public object modActivation { get; set; }
        public object renderDevice { get; set; }
        public object vrMode { get; set; }
        public object logFile { get; set; }
        public object editorStartingMap { get; set; }
        public object noIntro { get; set; }
        public object force64bit { get; set; }
        public object unmountUserMap { get; set; }
        public object useDefaultMemorySettings { get; set; }
        public MemorySettings memorySettings { get; set; }
        public EtsDlc etsDlc { get; set; }
    }

    public class Ats
    {
        public object gameMode { get; set; }
        public object modActivation { get; set; }
        public object renderDevice { get; set; }
        public object vrMode { get; set; }
        public object logFile { get; set; }
        public object editorStartingMap { get; set; }
        public object noIntro { get; set; }
        public object force64bit { get; set; }
        public object unmountUserMap { get; set; }
        public object useDefaultMemorySettings { get; set; }
        public MemorySettings memorySettings { get; set; }
        public AtsDlc atsDlc { get; set; }
    }

    public class EtsDlc
    {
        public object east { get; set; }
        public object north { get; set; }
        public object fr { get; set; }
        public object it { get; set; }
        public object balt { get; set; }
        public object balkan_e { get; set; }
        public object iberia { get; set; }
    }

    public class AtsDlc
    {
        public object nevada { get; set; }
        public object arizona { get; set; }
        public object nm { get; set; }
        public object or { get; set; }
        public object wa { get; set; }
        public object ut { get; set; }
        public object co { get; set; }
    }
}
