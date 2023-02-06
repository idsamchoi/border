using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace Border
{
    public partial class MainForm : Form
    {
        private Point loc;

        public MainForm()
        {
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.9;
        }

        private void DrawRectangle(Graphics grp)
        {
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.LightSteelBlue, 10);
            Rectangle borderRectangle = this.ClientRectangle;
            grp.DrawRectangle(pen, borderRectangle);
            pen.Dispose();
            grp.Dispose();
        }

        private void onLoad()
        {
            this.TransparencyKey = BackColor;
            int px = (this.Width - pnlControl.Width) / 2;
            int py = 5;
            pnlControl.Location = new Point(px, py);

            PipeRun();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //base.OnPaint(e);
            // draw what you want
            DrawRectangle(e.Graphics);
        }

        private void lbStop_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                loc = e.Location;
            }
        }

        private void pnlControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pnlControl.Left = e.X + pnlControl.Left - loc.X;
                pnlControl.Top = e.Y + pnlControl.Top - loc.Y;
            }
        }

        private void PipeRun()
        {
            Thread trd = new Thread(new ThreadStart(this.PipeTask));
            trd.IsBackground = true;
            trd.Start();
        }

        private void PipeTask()
        {
            NamedPipeServerStream pipe = new NamedPipeServerStream(
                          "border.pipe",
                          PipeDirection.InOut,
                          NamedPipeServerStream.MaxAllowedServerInstances,
                          PipeTransmissionMode.Message);
            Console.WriteLine("Pipe Created...");
            pipe.WaitForConnection();
            Console.WriteLine("Pipe Connected...");
            
            try
            {
                while (true)
                {
                    string cmd = ReadMessage(pipe);
                    Console.WriteLine("[*] Received: {0}", cmd);
                    if (cmd.ToLower() == "exit")
                    {
                        break;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            pipe.Close();
            Application.Exit();
        }

        private string ReadMessage(PipeStream pipe)
        {
            byte[] buffer = new byte[1024];
            using (var ms = new MemoryStream())
            {
                do
                {
                    var readBytes = pipe.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, readBytes);
                }
                while (!pipe.IsMessageComplete);
                string cmd = Encoding.Default.GetString(ms.ToArray());
                return cmd;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            onLoad();
        }
    }
}
