
배경투명처리

Form로드시에 다음처리 삽입
 private void MainForm_Load(object sender, EventArgs e)
 {
      this.TransparencyKey = BackColor;
 }
 
 Form외곽선 없애기
 public MainForm()
 {
    InitializeComponent();
    this.TopMost = true;
    this.FormBorderStyle = FormBorderStyle.None;
    this.Opacity = 0.9;
 }

스크린 외곽선 그리기
private void Form1_Paint(object sender, PaintEventArgs e)
{
   DrawRectangle(e.Graphics);
}
private void DrawRectangle(Graphics grp)
{
   System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.LightSteelBlue, 10);
   Rectangle borderRectangle = this.ClientRectangle;
   grp.DrawRectangle(pen, borderRectangle);
   pen.Dispose();
   grp.Dispose();
}

마우스로 패널 옮기기
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

네임드파이프 처리: 파이프명  "border.pipe"
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
