using DDSMassCompressor.Source.Definitions;
using System.IO;
using System.Text.Json;

namespace DDSMassCompressor.Source.Saves
{
    internal class CompressionSettings
    {
        private const string FILE_NAME = "settings.json";

        public string Path { get; set; }
        public BackupMode BackupMode { get; set; } = BackupMode.None;
        public MipMode MipMode { get; set; } = MipMode.Generate;
        public SupportedDXTFormat Compression { get; set; } = SupportedDXTFormat.BC1_Alpha;

        internal static CompressionSettings LoadOrGetDefault()
        {
            try
            {
                var f = File.ReadAllText(FILE_NAME);

                if (string.IsNullOrEmpty(f))
                {
                    return GetDefault();
                }
                else
                {
                    return JsonSerializer.Deserialize<CompressionSettings>(f);
                }
            }
            catch
            {
                return GetDefault();
            }
        }

        private static CompressionSettings GetDefault()
        {
            return new CompressionSettings();
        }

        internal void SaveSettings()
        {
            try
            {
                var json = JsonSerializer.Serialize<CompressionSettings>(this, new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(FILE_NAME, json);
            }
            catch
            {
                // ignore
            }
        }
    }
}