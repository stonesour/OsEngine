﻿/*
 * Your rights to use code governed by this license https://github.com/AlexWan/OsEngine/blob/master/LICENSE
 * Ваши права на использование кода регулируются данной лицензией http://o-s-a.net/doc/license_simple_engine.pdf
*/

using System;
using System.Windows;
using OsEngine.Language;

namespace OsEngine.OsConverter
{
    public partial class OsConverterUi
    {
        public OsConverterUi()
        {
            InitializeComponent();
            OsEngine.Layout.StickyBorders.Listen(this);
            OsEngine.Layout.StartupLocation.Start_MouseInCentre(this);

            LabelOsa.Content = "V " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            _master = new OsConverterMaster(TextBoxSource, TextBoxExit, ComboBoxTimeFrame, HostLog);

            Label1.Content = OsLocalization.Converter.Label1;
            Label2.Content = OsLocalization.Converter.Label2;
            ButtonSetSource.Content = OsLocalization.Converter.Label3;
            ButtonSetExitFile.Content = OsLocalization.Converter.Label3;
            Label4.Header = OsLocalization.Converter.Label4;
            ButtonStart.Content = OsLocalization.Converter.Label5;

            this.Activate();
            this.Focus();
        }

        private OsConverterMaster _master;

        private void ButtonSetSource_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _master.SelectSourceFile();
            }
            catch (Exception ex)
            {
                _master.SendNewLogMessage(ex.ToString(), Logging.LogMessageType.Error);
            }
        }

        private void ButtonSetExitFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _master.CreateExitFile();
            }
            catch (Exception ex)
            {
                _master.SendNewLogMessage(ex.ToString(), Logging.LogMessageType.Error);
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _master.StartConvert();
            }
            catch (Exception ex)
            {
                _master.SendNewLogMessage(ex.ToString(), Logging.LogMessageType.Error);
            }
        }
    }
}