using DDSMassCompressor.Source.Definitions;
using DDSMassCompressor.Source.Interfaces;
using DDSMassCompressor.Source.Rewriters;
using DDSMassCompressor.Source.Saves;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DDSMassCompressor
{
    public partial class Form1 : Form, IConsoleOutput
    {
        private CompressionSettings _settings;
        private IRewriter _rewriter;

        public Form1()
        {
            Application.ApplicationExit += OnApplicationExit;

            InitializeComponent();
            SetFormSettings();
            ActivateTimer();
        }

        private void SetFormSettings()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            outputConsoleTextBox.ReadOnly = true;
        }

        private void ActivateTimer()
        {
            var t = new Timer();
            t.Interval = 100;
            t.Start();
            t.Tick += Tick;
        }

        private void Tick(object sender, EventArgs e)
        {
            if (_rewriter == null)
            {
                progressBar1.Value = 0;
            }
            else
            {
                progressBar1.Value = (int)_rewriter.Progress;
            }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            _settings?.SaveSettings();
        }

        private void OnFormLoaded(object sender, EventArgs e)
        {
            _settings = CompressionSettings.LoadOrGetDefault();
            SendToConsole("Settings loaded.");

            FillTextBoxes();
            VisualizeSettings();
        }

        private async void OnStartButton_Clicked(object sender, EventArgs e)
        {
            ReadSettingsFromInput();

            if (!string.IsNullOrEmpty(inputPathTextBox.Text))
            {
                SetActiveStatus(false);
                SendToConsole($"/// Start time: {DateTime.Now} ///\n");

                var timer = new Stopwatch();
                timer.Start();

                _rewriter = new DDSRewriter(_settings, this);
                await _rewriter.HandleDirectory();

                timer.Stop();

                SendToConsole($"/// End time: {DateTime.Now}. Elapsed: {timer.ElapsedMilliseconds} ms ///");
                PrintConsoleLine();
                SetActiveStatus(true);
            }
            else
            {
                SendToConsole("Incorrect path");
            }
        }

        private void OnSelectFileButton_Clicked(object sender, EventArgs e)
        {
            var ofd = new FolderBrowserDialog();
            var dial_res = ofd.ShowDialog();

            if (dial_res == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(ofd.SelectedPath))
                {
                    inputPathTextBox.Text = ofd.SelectedPath;
                }
                else
                {
                    SendToConsole("Incorrect path");
                }
            }
            ReadSettingsFromInput();
        }

        private void FillTextBoxes()
        {
            FillComboBox<BackupMode>(comboBoxSaveMode);
            FillComboBox<MipMode>(comboBoxMipMaps);
            FillComboBox<SupportedDXTFormat>(comboBoxCompressionMode);
        }

        private static void FillComboBox<TEnum>(ComboBox cb) where TEnum : Enum
        {
            cb.Items.AddRange(GetEnumValues(typeof(TEnum)).ToArray());
        }

        private static IEnumerable<object> GetEnumValues(Type t)
        {
            foreach (var g in Enum.GetValues(t))
            {
                yield return g.ToString();
            }
        }

        private void ReadSettingsFromInput()
        {
            _settings.BackupMode = (BackupMode)comboBoxSaveMode.SelectedIndex;
            _settings.Compression = (SupportedDXTFormat)comboBoxCompressionMode.SelectedIndex;
            _settings.MipMode = (MipMode)comboBoxMipMaps.SelectedIndex;
            _settings.Path = inputPathTextBox.Text;
        }

        private void VisualizeSettings()
        {
            try
            {
                comboBoxSaveMode.SelectedIndex = (int)_settings.BackupMode;
                comboBoxCompressionMode.SelectedIndex = (int)_settings.Compression;
                comboBoxMipMaps.SelectedIndex = (int)_settings.MipMode;
                inputPathTextBox.Text = _settings.Path;
            }
            catch
            {
                // nothing
            }
        }

        public void PrintConsoleLine()
        {
            SendToConsole(new string('-', 80));
        }

        public void SendToConsole(object o)
        {
            outputConsoleTextBox.Invoke(new Action(() => outputConsoleTextBox.Text += $"\n{o.ToString()}"));
        }

        private void buttonClearConsole_Click(object sender, EventArgs e)
        {
            outputConsoleTextBox.Text = string.Empty;
        }

        private void SetActiveStatus(bool isActive)
        {
            startButton.Enabled = isActive;
            buttonClearConsole.Enabled = isActive;
            selectFileButton.Enabled = isActive;
        }
    }
}