using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;
using System.Diagnostics.Eventing.Reader;

namespace SmartHome
{
    public partial class HouseForm : Form
    {
        static bool _continue;
        static SerialPort _serialLumiPort;
        int x = 0;

        char[] receiveBuffer = new char[512];

        List<byte> msginbytes = new List<byte>();
        List<String> message = new List<string>();


        string plainText;
        string plainTextDec;
        string plainTextHex;
        int bufpos = 0;
        int debugtrap = 1;
        int DisplayTrace = 0;  // 0 = no trace, 1 = trace





        public HouseForm()
        {
            InitializeComponent();
            // InitializeTimer();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); 
            Graphics g = e.Graphics; 
            Pen pen = new Pen(Color.Black, 3);
            
            // Draw a circle for Temperature
            int x = 200; 
            int y = 75; 
            int diameter = 75; 
            g.DrawEllipse(pen, x, y, diameter, diameter);

            // Draw a circle for Humidity
            Pen pen1 = new Pen(Color.Black, 3);
            x = 650;
            y = 75;
            diameter = 75;
            g.DrawEllipse(pen1, x, y, diameter, diameter);

        }

        /*
        private void InitializeTimer()
        {
            timer1 = new Timer();
            timer1.Interval = 1000; // Update every second
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }
        */


        /*
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Simulate fetching temperature
            double temperature = GetTemperature();
            tempLabel.Text = $"{temperature:F1}°C";
        }
        */

        private double GetTemperature()
        {
            // Replace this with actual code to fetch temperature from a sensor or API
            Random rand = new Random();
            return rand.Next(-10, 40) + rand.NextDouble();


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HouseForm_Load(object sender, EventArgs e)
        {
            toolStripDateTimeLabel.Text = DateTime.Now.ToLongDateString();
        }

        private void lumiStartButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Open the port used to communicate with the Master Controller
                _serialLumiPort = new SerialPort();
                _serialLumiPort.PortName = lumiComboBox.Text;
                _serialLumiPort.BaudRate = 9600;
                _serialLumiPort.Parity = Parity.None;
                _serialLumiPort.DataBits = 8;
                _serialLumiPort.StopBits = StopBits.One;
                _serialLumiPort.Handshake = Handshake.None;

                _serialLumiPort.ReadTimeout = 500;

                _serialLumiPort.Open();
                _continue = true;
                monitorTextBox.AppendText("Lumi   COM Port  >>>  " + lumiComboBox.SelectedItem + " Opened and Configured. \r\n");
            }
            catch (UnauthorizedAccessException ex)
            {

                monitorTextBox.AppendText("Lumi   COM Port  >>>  " + lumiComboBox.SelectedItem + " Open Failed " + ex + "\r\n");
                _continue = false;
                // return;
            }
            catch (IOException)
            {
                monitorTextBox.AppendText("Lumi   COM Port  >>>  " + lumiComboBox.SelectedItem + " Open Failed " + "\r\n");
                _continue = false;
                // return;
            }

            if (_continue == true)
            {
                toolStripPortLabel.Text = "Connnected";
                toolStripPortLabel.ForeColor = Color.Black;
            }
            else
            {
                toolStripPortLabel.Text = "Not Connnected";
                toolStripPortLabel.ForeColor = Color.Red;
                return;
            }

            // If COMM Port Opened a Success..
            if (_continue == true)
            {
                lumiStartButton.Enabled = false;

                if (backgroundWorker.IsBusy != true)
                {
                    // Start the asynchronous operation.
                    backgroundWorker.RunWorkerAsync();
                    monitorTextBox.AppendText("The backgroundWorker_RunWorker Process Started! \r\n");
                }
                else
                {
                    monitorTextBox.AppendText("The backgroundWorker_RunWorker Process reported back as already running ?? \r\n");
                    lumiStartButton.Enabled = true;
                    _serialLumiPort.Close();
                    _continue = false;
                    monitorTextBox.AppendText("Lumi   COM Port  >>>  " + lumiComboBox.SelectedItem + " Closed! \r\n");

                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // backgroundWorker_DoWork reads a command from the Lumi IOT Home
            // and processes the response.

            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            for (int i = 1; i < 10; i++)
            {
                if (backgroundWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    // Perform the COM ReadTo operation and report progress.
                    x = 0;
                    while (true)
                    {
                        msginbytes.Clear();

                        // I need a try here to catch exceptions from Lumi House

                        while (true)
                        {
                            try
                            {

                            
                                if (_serialLumiPort.BytesToRead == 0) continue;
                                int b = _serialLumiPort.ReadByte();
                                if (b < 0) continue; // -1 if end of stream

                                msginbytes.Add((byte)b);
                                if (b == 13)  // '\r' in the Metasys Data ?? Issue if Binary Data
                                {
                                    message.Clear();
                                    for (int y = 0; y < msginbytes.Count; y++)
                                    {
                                        message.Add(msginbytes[y].ToString());
                                    }
                                    x = x + 1;
                                    backgroundWorker.ReportProgress(x, message);
                                    // Thread.Sleep(250);
                                    // Thread.Sleep(50);
                                    Thread.Sleep(100);
                                    msginbytes.Clear();
                                }
                            }
                            catch (IOException ex)
                            {
                                monitorTextBox.AppendText("Lumi   COM Port  >>>  " + lumiComboBox.SelectedItem + " Comm Port Failed " + ex + "\r\n");
                                _continue = false;
                                return;
                            }
                            catch (UnauthorizedAccessException ex)
                            {

                                monitorTextBox.AppendText("Lumi   COM Port  >>>  " + lumiComboBox.SelectedItem + " Comm Port Failed " + ex + "\r\n");
                                _continue = false;
                                return;
                            }
                            catch (InvalidOperationException ex)
                            {

                                monitorTextBox.AppendText("Lumi   COM Port  >>>  " + lumiComboBox.SelectedItem + " Comm Port Failed " + ex + "\r\n");
                                _continue = false;
                                return;
                            }

                        }
                    }
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // string result = String.Join(" ", LumiMessage);
            // 
            plainText = "";
            plainTextDec = "";


            if (DisplayTrace == 1)
            {

                // foreach (byte b in result)
                foreach (byte b in msginbytes)
                {
                    switch (b)
                    {
                        case 0x00:
                            // bText[formatmsgpos] = b;
                            plainText += "NUL ";
                            plainTextDec += "0   ";
                            break;

                        case 0x01:
                            // bText[formatmsgpos] = b;
                            plainText += "SOH ";
                            plainTextDec += "1   ";
                            break;

                        case 0x02:
                            // bText[formatmsgpos] = b;
                            plainText += "STX ";
                            plainTextDec += "2   ";
                            break;

                        case 0x03:
                            // bText[formatmsgpos] = b;
                            plainText += "ETX ";
                            plainTextDec += "3   ";
                            break;

                        case 0x04:
                            // bText[formatmsgpos] = b;
                            plainText += "EOT ";
                            plainTextDec += "4   ";
                            break;

                        case 0x05:
                            // bText[formatmsgpos] = b;
                            plainText += "ENQ ";
                            plainTextDec += "5   ";
                            break;

                        case 0x06:
                            // bText[formatmsgpos] = b;
                            plainText += "ACK ";
                            plainTextDec += "6   ";
                            break;

                        case 0x07:
                            // bText[formatmsgpos] = b;
                            plainText += "BEL ";
                            plainTextDec += "7   ";
                            break;

                        case 0x08:
                            // bText[formatmsgpos] = b;
                            plainText += "BS  ";
                            plainTextDec += "8   ";
                            break;

                        case 0x09:
                            // bText[formatmsgpos] = b;
                            plainText += "TAB ";
                            plainTextDec += "9   ";
                            break;

                        case 0x0A:
                            // bText[formatmsgpos] = b;
                            plainText += "LF  ";
                            plainTextDec += "10  ";
                            break;

                        case 0x0B:
                            // bText[formatmsgpos] = b;
                            plainText += "VT  ";
                            plainTextDec += "11  ";
                            break;

                        case 0x0C:
                            // bText[formatmsgpos] = b;
                            plainText += "FF  ";
                            plainTextDec += "12  ";
                            break;

                        case 0x0D:
                            // bText[formatmsgpos] = b;
                            plainText += "CR  ";
                            plainTextDec += "13  ";
                            break;

                        case 0x0E:
                            // bText[formatmsgpos] = b;
                            plainText += "SO  ";
                            plainTextDec += "14  ";
                            break;

                        case 0x0F:
                            // bText[formatmsgpos] = b;
                            plainText += "SI  ";
                            plainTextDec += "15  ";
                            break;

                        case 0x10:
                            // bText[formatmsgpos] = b;
                            plainText += "DLE ";
                            plainTextDec += "16  ";
                            break;

                        case 0x11:
                            // bText[formatmsgpos] = b;
                            plainText += "DC1 ";
                            plainTextDec += "17  ";
                            break;

                        case 0x12:
                            // bText[formatmsgpos] = b;
                            plainText += "DC2 ";
                            plainTextDec += "18  ";
                            break;

                        case 0x13:
                            // bText[formatmsgpos] = b;
                            plainText += "DC3 ";
                            plainTextDec += "19  ";
                            break;

                        case 0x14:
                            // bText[formatmsgpos] = b;
                            plainText += "DC4 ";
                            plainTextDec += "20  ";
                            break;

                        case 0x15:
                            // bText[formatmsgpos] = b;
                            plainText += "NAK ";
                            plainTextDec += "21  ";
                            break;

                        case 0x16:
                            // bText[formatmsgpos] = b;
                            plainText += "SYN ";
                            plainTextDec += "22  ";
                            break;

                        case 0x17:
                            // bText[formatmsgpos] = b;
                            plainText += "ETB ";
                            plainTextDec += "23  ";
                            break;

                        case 0x18:
                            // bText[formatmsgpos] = b;
                            plainText += "CAN ";
                            plainTextDec += "24  ";
                            break;

                        case 0x19:
                            // bText[formatmsgpos] = b;
                            plainText += "EM  ";
                            plainTextDec += "25  ";
                            break;

                        case 0x1A:
                            // bText[formatmsgpos] = b;
                            plainText += "SUB ";
                            plainTextDec += "26  ";
                            break;

                        case 0x1B:
                            // bText[formatmsgpos] = b;
                            plainText += "ESC ";
                            plainTextDec += "27  ";
                            break;

                        case 0x1C:
                            // bText[formatmsgpos] = b;
                            plainText += "FS  ";
                            plainTextDec += "28  ";
                            break;

                        case 0x1D:
                            // bText[formatmsgpos] = b;
                            plainText += "GS  ";
                            plainTextDec += "29  ";
                            break;

                        case 0x1E:
                            // bText[formatmsgpos] = b;
                            plainText += "RS  ";
                            plainTextDec += "30  ";
                            break;

                        case 0x1F:
                            // bText[formatmsgpos] = b;
                            plainText += "US  ";
                            plainTextDec += "31  ";
                            break;

                        case 0x20:
                            // bText[formatmsgpos] = b;
                            plainText += "     ";          // Space
                            plainTextDec += "32   ";       // Space
                            break;


                        default:
                            // bText[formatmsgpos] = b;
                            plainTextDec += (byte)b + "   ";


                            if (b > 0x63 && b < 0x80)
                            {
                                plainText += (char)b + "     ";
                            }
                            else if (b < 0x64)
                            {
                                plainText += (char)b + "    ";
                            }
                            else
                            {
                                plainText += "." + "     ";
                            }
                            break;
                    }
                }

                bufpos = 0;
                StringBuilder bufferPositionString = new StringBuilder(msginbytes.Count * 2);
                StringBuilder hexadecimalString = new StringBuilder(msginbytes.Count * 2);

                // foreach (byte t in result)
                foreach (byte t in msginbytes)
                    {
                    if (bufpos < 10)
                    {
                        bufferPositionString.Append(bufpos.ToString() + " ");
                    }
                    else
                    {
                        bufferPositionString.Append(bufpos.ToString());
                    }


                    bufpos += 1;
                    if (bufpos == 100) { bufpos = 0; };            // Keep the allignment for buffer count aligned...
                    hexadecimalString.AppendFormat("{0:x2}", t);
                    if (t > 0x63)
                    {
                        hexadecimalString.Append("    ");
                        bufferPositionString.Append("    ");
                    }
                    else if (t < 0x20)
                    {
                        hexadecimalString.Append("  ");
                        bufferPositionString.Append("  ");
                    }
                    else
                    {
                        hexadecimalString.Append("   ");
                        bufferPositionString.Append("   ");
                    }
                }

                monitorTextBox.AppendText("BUF LOC : " + bufferPositionString.ToString() + "\r\n");
                monitorTextBox.AppendText("ASCII   : " + plainText + "\r\n");
                // monitorTextBox.AppendText("Decimal : " + plainTextDec + "\r\n");

                // Change to Display HEX characters to Uppder Case
                // string temphexadecimalString = hexadecimalString.ToString();
                // string uppsecasehexadecimalString = temphexadecimalString.ToUpper();

                // monitorTextBox.AppendText("HEX     : " + uppsecasehexadecimalString + "\r\n");
                // monitorTextBox.AppendText("HEX     : " + hexadecimalString.ToString() + "\r\n");
                // monitorTextBox.AppendText("\r\n");

            }

            if (msginbytes.Count > 0)
            {
                if (msginbytes[1] == 0x24) // "$" Command
                {
                    byte[] byteArray = msginbytes.ToArray();
                    string str = Encoding.ASCII.GetString(byteArray);
                    char[] chars = str.ToCharArray();

                    switch (msginbytes[2]) // Second Byte is type of Response to Process
                    {
                        case 0x31: // #1 Temp

                            if (tempHumidityIsFahrenheitToolStripMenuItem.Text == "Temp-Humidity is Fahrenheit")
                            {
                                // byte[] byteArray = msginbytes.ToArray();
                                // string str = Encoding.ASCII.GetString(byteArray);
                                // char[] chars = str.ToCharArray();
                                string cmd_temperature = new string(chars);
                                string temperature = cmd_temperature.Substring(3);

                                float Celsius = float.Parse(temperature);
                                float fahrenhelt = (Celsius * 9 / 5) + 32;
                                string fahrenheitString = fahrenhelt.ToString();

                                tempLabel.Text = fahrenheitString + "\rF";
                            }
                            else
                            {
                                // byte[] byteArray = msginbytes.ToArray();
                                // string str = Encoding.ASCII.GetString(byteArray);
                                // char[] chars = str.ToCharArray();
                                string cmd_temperature = new string(chars);
                                string temperature = cmd_temperature.Substring(3);
                                tempLabel.Text = temperature + "C";
                            }

                            break;


                        case 0x32: // #2 Humidity
                                string cmd_humidity = new string(chars);
                                string humidity = cmd_humidity.Substring(3);
                                humLabel.Text = humidity;

                            break;


                        case 0x33: // #3 Street Light Status (0 off, 1 on )
                                monitorTextBox.AppendText("Lumi Received Light Toggle\r\n");
                                if (msginbytes[3] == 0x31) // Light is on..
                                {
                                    lightPictureBox.Image = SmartHome.Properties.Resources.LIGHTBULB_ON1;
                                }
                                else
                                {
                                lightPictureBox.Image = SmartHome.Properties.Resources.LIGHTBULB_OFF1;
                            }
                                break;


                        case 0x39: // #9 Unknown Command
                            monitorTextBox.AppendText("Lumi Received Unknown Command\r\n");
                            break;

                        default:
                            break;

                    }
                }
            }
            // monitorTextBox.AppendText(result + "\r\n");
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void traceOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (traceOffToolStripMenuItem.Text == "Trace is OFF")
            {
                DisplayTrace = 1;
                traceOffToolStripMenuItem.Text = "Trace is ON";
            }
            else
            {
                DisplayTrace = 0;
                traceOffToolStripMenuItem.Text = "Trace is OFF";
            }
        }

        private void tempHumidityIsFahrenheitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tempHumidityIsFahrenheitToolStripMenuItem.Text == "Temp-Humidity is Fahrenheit")
            {
                tempHumidityIsFahrenheitToolStripMenuItem.Text = "Temp-Humidity is Celsius";
            }
            else
            {
                tempHumidityIsFahrenheitToolStripMenuItem.Text = "Temp-Humidity is Fahrenheit";
            }
        }

        private void lumiLightsButton_Click(object sender, EventArgs e)
        {
            // Toggle the Street Light..
            _serialLumiPort.WriteLine("#1"); // Toggle Street Light
        }
    }
 }
