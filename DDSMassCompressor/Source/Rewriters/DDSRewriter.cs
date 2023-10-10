using BCnEncoder.Decoder;
using BCnEncoder.Encoder;
using BCnEncoder.Shared;
using BCnEncoder.Shared.ImageFiles;
using DDSMassCompressor.Source.Definitions;
using DDSMassCompressor.Source.Helpers;
using DDSMassCompressor.Source.Interfaces;
using DDSMassCompressor.Source.Saves;
using Microsoft.Toolkit.HighPerformance;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DDSMassCompressor.Source.Rewriters
{
    internal class DDSRewriter : IRewriter
    {
        public float Progress { get; set; }

        private CompressionSettings _settings;
        private IConsoleOutput _output;

        public DDSRewriter(CompressionSettings settings, IConsoleOutput console)
        {
            _output = console;
            _settings = settings;
        }

        public async Task HandleDirectory()
        {
            await Task.Run(() => CreateBackupIfNeed());

            if (!Directory.Exists(_settings.Path)) return;

            var files = Directory.EnumerateFiles(_settings.Path, "*.dds", SearchOption.AllDirectories);
            int files_checked = 0;

            await Task.Run(() =>
            {
                files.AsParallel().ForAll(file_path =>
                {
                    HandleFile(file_path);
                    files_checked++;
                    Progress = (100f * files_checked) / files.Count();

                    //Debug.WriteLine(Progress);
                });
            });
        }

        private void CreateBackupIfNeed()
        {
            if (_settings.BackupMode == BackupMode.CreateFolderBackup)
            {
                DirectoryHelper.CopyDirectory(_settings.Path, $"{_settings.Path} - backup({DateTime.Now.ToString().Replace(':', '_')})", true);
            }
        }

        private void HandleFile(string fileName)
        {
            var backup = File.ReadAllBytes(fileName);
            int size_before_compress = backup.Length;

            try
            {
                Memory2D<ColorRgba32> pixels2;

                using (FileStream fs = File.OpenRead(fileName))
                {
                    var decoder = new BcDecoder();
                    pixels2 = decoder.Decode2D(DdsFile.Load(fs));
                }

                var encoder = new BcEncoder();
                encoder.OutputOptions.GenerateMipMaps = _settings.MipMode == MipMode.Generate;
                encoder.OutputOptions.Quality = CompressionQuality.Balanced;
                encoder.OutputOptions.Format = CompressionFormatWrapHelper.Convert(_settings.Compression);
                encoder.OutputOptions.FileFormat = OutputFileFormat.Dds;

                using (FileStream fs = File.OpenWrite(fileName /*+ "new"*/))
                {
                    fs.SetLength(0);
                    encoder.EncodeToStream(pixels2, fs);
                }

                var new_file = File.ReadAllBytes(fileName);
                int size_after_compression = new_file.Length;

                _output.SendToConsole($"Status: Success\nPath: ({fileName})\nOriginal size: {FormatInt(size_before_compress)}\nNew size: {FormatInt(size_after_compression)}\nDifference: {FormatInt(Math.Abs(size_before_compress - size_after_compression))}\n");

            }
            catch (Exception ex)
            {
                _output.SendToConsole($"Status: Success\nPath: ({fileName})\nOriginal size: {FormatInt(size_before_compress)}\nError: {ex.Message}\n");
                File.WriteAllBytes(fileName, backup);
            }

        }

        private string FormatInt(int value)
        {
            return value.ToString("N0") + " bytes";
        }
    }
}