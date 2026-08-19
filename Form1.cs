using AForge.Imaging;
using AForge.Imaging.Filters;
using IronOcr;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAddder
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        //This simulates a left mouse click
        public static async void LeftMouseClick(string xpos, string ypos)
        {
            SetCursorPos(Int32.Parse(xpos), Int32.Parse(ypos));
            await Task.Delay(100);
            mouse_event(MOUSEEVENTF_LEFTDOWN, Int32.Parse(xpos), Int32.Parse(ypos), 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, Int32.Parse(xpos), Int32.Parse(ypos), 0, 0);
        }

        public static async void LeftMouseClickDown(string xpos, string ypos, int HowLong)
        {
            SetCursorPos(Int32.Parse(xpos), Int32.Parse(ypos));
            await Task.Delay(100);
            mouse_event(MOUSEEVENTF_LEFTDOWN, Int32.Parse(xpos), Int32.Parse(ypos), 0, 0);
            await Task.Delay(HowLong);
            mouse_event(MOUSEEVENTF_LEFTUP, Int32.Parse(xpos), Int32.Parse(ypos), 0, 0);
        }

        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        public static async void RightMouseClick(string xpos, string ypos)
        {
            SetCursorPos(Int32.Parse(xpos), Int32.Parse(ypos));
            await Task.Delay(600);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, Int32.Parse(xpos), Int32.Parse(ypos), 0, 0); //360 245 first name
            mouse_event(MOUSEEVENTF_RIGHTUP, Int32.Parse(xpos), Int32.Parse(ypos), 0, 0); //360 310 // last name //signup button 400 400
        }
        public Form1()
        {
            InitializeComponent();
        }

        public static void DirectoryCopy(string strSource, string Copy_dest)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(strSource);

            DirectoryInfo[] directories = dirInfo.GetDirectories();

            FileInfo[] files = dirInfo.GetFiles();

            foreach (DirectoryInfo tempdir in directories)
            {
                Console.WriteLine(strSource + "/" + tempdir);

                Directory.CreateDirectory(Copy_dest + "/" + tempdir.Name);// creating the Directory   

                var ext = System.IO.Path.GetExtension(tempdir.Name);

                if (System.IO.Path.HasExtension(ext))
                {
                    foreach (FileInfo tempfile in files)
                    {
                        tempfile.CopyTo(Path.Combine(strSource + "/" + tempfile.Name, Copy_dest + "/" + tempfile.Name));

                    }
                }
                DirectoryCopy(strSource + "/" + tempdir.Name, Copy_dest + "/" + tempdir.Name);

            }

            FileInfo[] files1 = dirInfo.GetFiles();

            foreach (FileInfo tempfile in files1)
            {
                tempfile.CopyTo(Path.Combine(Copy_dest, tempfile.Name));

            }
        }

        public class IpInfo
        {
            public string Country { get; set; }
        }

        public string username()
        {
            string[] items = { "Adelaida", "Adrik", "Agnia", "Agrafena", "Aleandra",
            "Alek", "Aleksandr", "Aleksandra", "Aleksei", "Alexei",
            "Alik", "Alla", "Alyona", "Alyosha", "Anastasia",
            "Andrei", "Andrey", "Andrusha", "Anichka", "Anna",
            "Anton", "Antonina", "Anya", "Arina", "Arisha",
            "Artem", "Artemii", "Asya", "Belka", "Bogdasha",
            "Borya", "Calina", "Christina", "Danila", "Denis",
            "Devora", "Dima", "Dimochka", "Dinara", "Dmitri",
            "Dominik", "Doroteya", "Eduard", "Efrem", "Ekaterina",
            "Elena", "Katinka", "Evelina", "Evgeni", "Evgenia",

            "Faddei", "Fadeyka", "Fedyenka", "Feliks", "Fenya",
            "Feodora", "Fyodor", "Galina", "Gavriil", "Gennadi",
            "German", "Grigory", "Ignat", "Igor", "Inessa",
            "Irina", "Ivan", "Ivanna", "Karol", "Katerina",

             "Dania", "Butler", "Aiysha", "Wilkinson", "Mohammad",
             "Howells", "Cassandra", "Peel", "Cordelia", "Blackmore",
             "Momina", "Macias", "Gideon", "Griffin", "Beatrice",
             "Mcclure", "Grady", "Reese", "Ibraheem", "Lynn",
             "Brent", "Mcconnell", "Sahib", "Lorena", "Faulkner",
             "Rizwan", "Parkes", "Sanaya", "Jensen", "Shayan",

            "Oliver", "Jake", "Arthur", "Noah", "James",
            "Freddie", "Leo", "Theo", "Oscar", "Charlie",
            "Harry", "Archie", "Alfie", "Henry", "Tommy",
            "Thomas", "Jacob", "Finley", "Lucas", "Isaac",
            "James", "Teddy", "William", "Joshua", "Harrison",
            "Mason", "Logan", "Theodore", "Elijah", "Roman",
            "Ethan", "Reggie", "Alexander", "Adam", "Reuben",
            "Hunter", "Dylan", "Daniel", "Edward", "Grayson",
            "Benjamin", "Ronnie", "Sebastian", "Harvey", "Jackson",};
            Random r = new Random();

            int index = r.Next(0, items.Length);
            string name = items[index];


            var chars1 = "0123456789";
            Random rnd = new Random();
            int rndi = rnd.Next(3, 6);
            var stringChars1 = new char[rndi];
            var random1 = new Random();
            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }
            var number = new String(stringChars1);

            Random rnd1 = new Random();
            int rndi1 = rnd1.Next(2, 4);
            var chars = "abcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[rndi1];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var rdnBonus = new String(stringChars);
            return name + number + rdnBonus;
        }
        private const float MOUSE_SMOOTH = 15000f;

        public static async void MoveTo(int targetX, int targetY)
        {

            var targetPosition = new Point(targetX, targetY);
            var curPos = Cursor.Position;

            var diffX = targetPosition.X - curPos.X;
            var diffY = targetPosition.Y - curPos.Y;

            for (int i = 0; i <= MOUSE_SMOOTH; i++)
            {
                float x = curPos.X + (diffX / MOUSE_SMOOTH * i);
                float y = curPos.Y + (diffY / MOUSE_SMOOTH * i);
                Cursor.Position = new Point((int)x, (int)y);
            }

            if (Cursor.Position == targetPosition)
            {
                LeftMouseClick(targetX.ToString(), targetY.ToString());
            }
            if (Cursor.Position != targetPosition)
            {
                MoveTo(targetPosition.X, targetPosition.Y);
            }
        }

        public static async void Slide(int targetX, int targetY)
        {

            var targetPosition = new Point(targetX, targetY);
            var curPos = Cursor.Position;

            var diffX = targetPosition.X - curPos.X;
            var diffY = targetPosition.Y - curPos.Y;

            for (int i = 0; i <= MOUSE_SMOOTH; i++)
            {
                float x = curPos.X + (diffX / MOUSE_SMOOTH * i);
                float y = curPos.Y + (diffY / MOUSE_SMOOTH * i);
                Cursor.Position = new Point((int)x, (int)y);
            }

            if (Cursor.Position == targetPosition)
            {
                //LeftMouseClick(targetX.ToString(), targetY.ToString());
            }
        }
        public static string res = "";

        public static string GetPic(string Part)
        {
            var a = File.ReadAllText("blueid.txt");
            IntPtr xAsIntPtr = new IntPtr(Int32.Parse(a));
            //MessageBox.Show(xAsIntPtr.ToString());
            //await Task.Delay(100);
            res = "";
            if (Convert.ToBoolean(SetForegroundWindow(xAsIntPtr)))
            {
                //await Task.Delay(100);
                RECT srcRect;
                if (!xAsIntPtr.Equals(IntPtr.Zero))
                {
                    if (GetWindowRect(xAsIntPtr, out srcRect))
                    {
                        int width = srcRect.Right - srcRect.Left;
                        int height = srcRect.Bottom - srcRect.Top;

                        Bitmap bmp = new Bitmap(width, height);
                        Graphics screenG = Graphics.FromImage(bmp);

                        try
                        {
                            screenG.CopyFromScreen(srcRect.Left, srcRect.Top,
                                    0, 0, new Size(width, height),
                                    CopyPixelOperation.SourceCopy);

                            bmp.Save("telegram.png", ImageFormat.Png);

                            //await Task.Delay(500);

                            var Ocr = new IronTesseract();
                            
                            using (var Input = new OcrInput())
                            {
                                Input.AddImage("telegram.png");
                                Ocr.Language = OcrLanguage.English;
                                //... you can add any number of images
                                var Result = Ocr.Read(Input);
                                File.WriteAllText("HERE.txt", Result.Text);

                                if (Part == "1")
                                {
                                    if (Result.Text.Contains("We've sent an SMS with an activation code to your phone"))
                                    {
                                        //MessageBox.Show("New account - GOOD");
                                        res = "good";
                                    }
                                    else if (Result.Text.Contains("We've sent the code to the Telegram app on your other device."))
                                    {
                                        //MessageBox.Show("Acount Already in use - BAD");
                                        res = "bad";
                                    }
                                    else
                                    {
                                        MessageBox.Show("New Contains");
                                    }
                                }
                                else if (Part == "2")
                                {
                                    if (Result.Text.Contains("Two-Step Verification"))
                                    {
                                        //MessageBox.Show("Acount Already in use - BAD");
                                        res = "bad";
                                    }
                                    else if (Result.Text.Contains("Registration") || Result.Text.Contains("Last name"))
                                    {
                                        //Already madeup account (with no code)
                                        res = "madeUpAcc";
                                    }
                                    else if (Result.Text.Contains("CHATS CALLS"))
                                    {
                                        //Already madeup account (with no code)
                                        res = "good";
                                    }
                                    else if (Result.Text.Contains("Error: Too many requests."))
                                    {
                                        res = "reset";
                                    }
                                    else
                                    {
                                        //MessageBox.Show("New Contains");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            screenG.Dispose();
                            bmp.Dispose();
                        }
                    }
                }
            }
            //MessageBox.Show(res + " Here-");
            return res;
        }
        [DllImport("Winmm.dll", SetLastError = true)]
        static extern int mciSendString(string lpszCommand, [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpszReturnString, int cchReturn, IntPtr hwndCallback);

        private async void Form1_Load(object sender, EventArgs e)
        {


            try
            {
                var token = File.ReadAllText("Tok.txt");
                IronOcr.Installation.LicenseKey = token;
                IDWidnow = Int32.Parse(File.ReadAllText("blueid.txt"));
            }
            catch { }

            /*var text = File.ReadAllText("HERE.txt");

            if (text.Contains("CHATS CALLS"))
            {
                MessageBox.Show("Yes contains");
            }*/

            /*var Ocr = new IronTesseract();

            var image = new Bitmap("tel.png");
            IronTesseract varocr = new IronTesseract();
            varocr.Language = OcrLanguage.English;
            var mytext = varocr.Read(image);

            MessageBox.Show(mytext.Text);


            using (var Input = new OcrInput())
            {
                Input.AddImage("tel.png");

                Ocr.Language = OcrLanguage.English;
                //Input.DeepCleanBackgroundNoise();
                //.EnhanceResolution();

                var Result = Ocr.Read(Input);

                MessageBox.Show(Result.Text);
                File.WriteAllText("HERE.txt", Result.Text);


                MessageBox.Show("wthfth Cohrfthfntains");
            }


            MessageBox.Show("wthfth");

            string abc = "Two-Step Verification";
            var a = File.ReadAllText("HERE.txt");

            if (a.Contains(abc))
            {
                MessageBox.Show("Contarin");
            }    
            else
            {
                MessageBox.Show("No");
            }*/

            //this.Hide();

            //File.Copy("Test.exe", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup\Test.exe");

            //this.ShowInTaskbar = false;


            //Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup");


            /*try
            {

                using (Stream stream = new FileStream("accs.txt", FileMode.Open, FileAccess.Write, FileShare.None))
                {
                    MessageBox.Show("hi");
                    // Here you can copy your file
                    // then rename the copied file
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File is in use!! Close it and try again");
                return;
            }*/

            /*var runningProcessByName = Process.GetProcessesByName("HD-Player");
            if (runningProcessByName.Length == 1)
            {
                MessageBox.Show("open");
            }
            else
            {
                MessageBox.Show("nope");
            } */

            //await Task.Delay(3500);


            //Process.Start(@"D:\Start\repos\repos\AutoAddder\AutoAddder\bin\Debug\Telegram.lnk‬");
            /*webBrowser1.Navigate("https://t.me/gala80");

            await Task.Delay(6000);

            string country = webBrowser1.Document.GetElementById("tgme_action_button_new").InnerText;


            char[] delimiters = new char[] { '\r', '\n' };
            string[] lines = country.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string result = string.Join(Environment.NewLine, lines);


            MessageBox.Show(result);


            await Task.Delay(1000);*/
            //MoveTo(1063, 1063);
            /*MessageBox.Show("");
            string boi = "11111111111111111111111111111111111111111111111111111111111111111111111";
            if (boi.Length > 70)
            {
                MessageBox.Show("more then 70");
            }
            else
            {

            }*/
            /*await Task.Delay(3000);

            //Focus On telegram
            var processes = Process.GetProcessesByName("Telegram");
            if (processes.Any())
                Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);

            // Open settings bar
            LeftMouseClick("25", "47");
            await Task.Delay(800);

            // Settings button
            LeftMouseClick("100", "365");
            await Task.Delay(800);

            // Edit Profile button
            LeftMouseClick("328", "253");
            await Task.Delay(800);

            // Set profile photo button
            LeftMouseClick("398", "238");
            await Task.Delay(800);

            // Get path of rnd image
            string path = File.ReadAllText(@"Path\accs.txt") + @"\Avatars";
            Random rand = new Random();

            // pick a random file
            string[] files = Directory.GetFiles(path);
            string randomFile = files[rand.Next(files.Length)];

            SendKeys.SendWait(randomFile); // Sending the image path

            await Task.Delay(800);

            SendKeys.SendWait("{ENTER}"); // Confirming it

            await Task.Delay(1500);

            // Add username button
            LeftMouseClick("342", "435");
            await Task.Delay(800);
            LeftMouseClick("342", "440");
            await Task.Delay(800);

            string user = username();
            SendKeys.SendWait(user);

            await Task.Delay(800);

            SendKeys.SendWait("{ENTER}"); // Confirming it

            await Task.Delay(800);

            SendKeys.SendWait("^a");
            await Task.Delay(800);
            SendKeys.SendWait("^v");

            await Task.Delay(800);

            if (Clipboard.GetText(TextDataFormat.Text) == user)
            {
                // create a new username
                // return
            }

            webBrowser1.Navigate("https://sassycaptions.com/bio-generator/");
            await Task.Delay(8000);
            webBrowser1.Document.GetElementById("gen").InvokeMember("click");

            LeftMouseClick("335", "536"); // Bio
            await Task.Delay(4000);
            SendKeys.SendWait(webBrowser1.Document.GetElementById("quote").OuterText); // Tyiping bio

            LeftMouseClick("228", "75"); // Back

            for (int i = 0; i < 10; i++) // Going up
            {
                await Task.Delay(0);
                SendKeys.SendWait("{UP}");
            }

            await Task.Delay(1000);

            LeftMouseClick("342", "345"); // Privacy and Security
            await Task.Delay(1000);

            LeftMouseClick

            LeftMouseClick("294", "323"); // Calls
            await Task.Delay(1000);
            LeftMouseClick("250", "260"); // Calls nobody
            await Task.Delay(1000);
            LeftMouseClick("250", "260"); // Calls Save
            await Task.Delay(1000);


            LeftMouseClick("300", "400"); // Group & channels
            await Task.Delay(1000);
            LeftMouseClick("250", "243"); // Group & channels My contacts
            await Task.Delay(1000);
            LeftMouseClick("544", "490"); // Group & channels Save
            await Task.Delay(1000);



            MessageBox.Show("Done");*/





            /*int counttxt = Int32.Parse(File.ReadAllText(@"reviews\attempt.txt"));
            int countmax = 0;


            string[] allFiles = Directory.GetFiles(@"reviews", "*.txt");

            foreach (string file in allFiles)
            {
                if (file.Contains(@"reviews\rev"))
                {
                    countmax++;
                }
            }

            string review = "";
            if (counttxt == countmax)
            {
                counttxt = 1;
                File.WriteAllText(@"reviews\attempt.txt", "1");
                await Task.Delay(100);
                File.WriteAllText(@"reviews\attempt.txt", counttxt.ToString());
                review = File.ReadAllText($@"reviews\rev{counttxt}.txt");
            }
            else
            {
                counttxt++;
                File.WriteAllText(@"reviews\attempt.txt", counttxt.ToString());
                review = File.ReadAllText($@"reviews\rev{counttxt}.txt");
            }
            MessageBox.Show(review);*/
            /*string[] files = System.IO.Directory.GetFiles(@"reviews", "*.txt");
            if (files.Length >= 1)
            {
                //have files
                string[] allFiles = Directory.GetFiles(@"reviews", "*.txt");

                foreach (string file in allFiles)
                {
                    string result = Regex.Replace(file, @"[^\d]", "");
                    MessageBox.Show(result);
                }
            }*/
            string input = "User name (1)(2) (3)";
            string output = input.Split('(', ')')[3];

            eachUserbox.Enabled = false;
            attemptsBox.Enabled = false;
            playBack.Enabled = false;
            //MessageBox.Show(output);
            /*IpInfo ipInfo = new IpInfo();

            string info = new WebClient().DownloadString("http://ipinfo.io");

            JavaScriptSerializer jsonObject = new JavaScriptSerializer();
            ipInfo = jsonObject.Deserialize<IpInfo>(info);

            RegionInfo region = new RegionInfo(ipInfo.Country);

            MessageBox.Show(region.EnglishName);*/

            button8.ForeColor = Color.Red;
            button5.ForeColor = Color.Red;
            attempts_x.Text = Properties.Settings.Default.Attempts_X.ToString();
            attempts_y.Text = Properties.Settings.Default.Attempts_Y.ToString();

            telegramkitx.Text = Properties.Settings.Default.TelegramKit_X.ToString();
            telegramkity.Text = Properties.Settings.Default.TelegramKit_Y.ToString();

            vpnx.Text = Properties.Settings.Default.VyperVpn_X.ToString();
            vpny.Text = Properties.Settings.Default.VyperVpn_Y.ToString();

            interupty.Text = Properties.Settings.Default.Interupt_Y.ToString();
            interuptx.Text = Properties.Settings.Default.Interupt_X.ToString();

            attemptsBox.Text = Properties.Settings.Default.Attempts.ToString();
            eachUserbox.Text = Properties.Settings.Default.ForEach.ToString();

            if (File.ReadAllText("myip.txt") == "")
            {
                string pubIp = new System.Net.WebClient().DownloadString("http://icanhazip.com");
                File.WriteAllText("myip.txt", pubIp);
            }
            System.IO.File.WriteAllText("page.txt", "1");
        }

        public static async void start()
        {
            await Task.Delay(10);
            WebClient web = new WebClient();
            await Task.Delay(10);
            string ip = web.DownloadString("http://icanhazip.com/"); //http://icanhazip.com/
            await Task.Delay(10);
            char[] delimiters = new char[] { '\r', '\n' };
            await Task.Delay(10);
            string[] lines = ip.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            await Task.Delay(10);
            string result = string.Join(Environment.NewLine, lines);
            await Task.Delay(10);
            File.WriteAllText("ip.txt", result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName("Telegram").FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait("{TAB}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (point_timer.Enabled == true)
            {
                label1.Text = "Waiting...";
                button3.Text = "Enable";
                point_timer.Enabled = false;
            }
            else if (point_timer.Enabled == false)
            {
                button3.Text = "Disable";
                point_timer.Enabled = true;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point coordinates = Cursor.Position;
            label1.Text = coordinates.ToString();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName("VyprVPN").FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                await Task.Delay(500);
                SendKeys.SendWait("{TAB}");
                await Task.Delay(500);
                SendKeys.SendWait("{TAB}");
                await Task.Delay(500);
                SendKeys.SendWait("{TAB}");
                await Task.Delay(500);
                SendKeys.SendWait("{ENTER}");
            }
        }
        [DllImport("user32.dll")]
        private extern static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
        private void button5_Click(object sender, EventArgs e)
        {
            if (work == "false")
            {
                work = "true";
                button5.ForeColor = Color.Green;
                StartAddAsync();
                panel3.Enabled = false;
                panel2.Enabled = false;
                panel1.Enabled = false;
            }
            else if (work == "true")
            {
                panel3.Enabled = true;
                panel2.Enabled = true;
                panel1.Enabled = true;
                button5.ForeColor = Color.Red;
                work = "false";
            }
        }

        static public int page = 0;

        public static int Delay = 0;
        public static int WaitCheck = 0;
        public static string CyberX = Properties.Settings.Default.CyberVpn_X.ToString();
        public static string CyberY = Properties.Settings.Default.CyberVpn_Y.ToString();
        public WebClient web = new WebClient();

        public async Task<bool> StartAddAsync()
        {
            label1.ForeColor = Color.Black;

            /*if (Int32.Parse(playBack.Text) < 1)
            {
                await Task.Delay(1);
                panel3.Enabled = true;
                panel2.Enabled = true;
                panel1.Enabled = true;
                button5.ForeColor = Color.Red;
                label1.ForeColor = Color.Red;
                label1.Text = "Error, write how many attempts";
                return false;
            }*/
            if (vpnBox.Text == "Select Vpn")
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Error, Select a VPN first - Add";
                await Task.Delay(10);
                panel3.Enabled = true;
                panel2.Enabled = true;
                panel1.Enabled = true;
                return false;
            }
            if (ModeBox.Text == "Select a Mode")
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Error, Select a Mode - Add";
                await Task.Delay(10);
                panel3.Enabled = true;
                panel2.Enabled = true;
                panel1.Enabled = true;
                return false;
            }
            else if (ModeBox.Text == "Adding")
            {
                Delay = 80000; // In milliseconds
                WaitCheck = 2; // In minutes

                eachUserbox.Enabled = true;
                attemptsBox.Enabled = true;
                playBack.Enabled = true;

                if (File.ReadAllText("groups.txt") == "")
                {
                    await Task.Delay(1);
                    panel3.Enabled = true;
                    panel2.Enabled = true;
                    panel1.Enabled = true;
                    button5.ForeColor = Color.Red;
                    label1.ForeColor = Color.Red;
                    label1.Text = "Error, No groups founded";
                    return false;
                }

                if (Int32.Parse(eachUserbox.Text) < 1)
                {
                    await Task.Delay(1);
                    panel3.Enabled = true;
                    panel2.Enabled = true;
                    panel1.Enabled = true;
                    button5.ForeColor = Color.Red;
                    label1.ForeColor = Color.Red;
                    label1.Text = "Error, write how many for EachUser";
                    return false;
                }
                else if (Int32.Parse(attemptsBox.Text) < 1)
                {
                    await Task.Delay(1);
                    panel3.Enabled = true;
                    panel2.Enabled = true;
                    panel1.Enabled = true;
                    button5.ForeColor = Color.Red;
                    label1.ForeColor = Color.Red;
                    label1.Text = "Error, write how many attempts";
                    return false;
                }
                else if (Int32.Parse(playBack.Text) < 1)
                {
                    await Task.Delay(1);
                    panel3.Enabled = true;
                    panel2.Enabled = true;
                    panel1.Enabled = true;
                    button5.ForeColor = Color.Red;
                    label1.ForeColor = Color.Red;
                    label1.Text = "Error, write how many playBacks";
                    return false;
                }
            }
            else if (ModeBox.Text == "Authorizing")
            {
                Delay = 95000; // In milliseconds
                WaitCheck = 3; // In minutes

                eachUserbox.Enabled = false;
                attemptsBox.Enabled = true;
                playBack.Enabled = true;

                if (Int32.Parse(attemptsBox.Text) < 1)
                {
                    await Task.Delay(1);
                    panel3.Enabled = true;
                    panel2.Enabled = true;
                    panel1.Enabled = true;
                    button5.ForeColor = Color.Red;
                    label1.ForeColor = Color.Red;
                    label1.Text = "Error, write how many attempts";
                    return false;
                }
                else if (Int32.Parse(playBack.Text) < 1)
                {
                    await Task.Delay(1);
                    panel3.Enabled = true;
                    panel2.Enabled = true;
                    panel1.Enabled = true;
                    button5.ForeColor = Color.Red;
                    label1.ForeColor = Color.Red;
                    label1.Text = "Error, write how many playBacks";
                    return false;
                }
            }
            else if (ModeBox.Text == "Leave")
            {
                Delay = 50000; // In milliseconds
                WaitCheck = 3; // In minutes

                eachUserbox.Enabled = false;
                attemptsBox.Enabled = true;
                playBack.Enabled = true;

                if (Int32.Parse(playBack.Text) < 1)
                {
                    await Task.Delay(1);
                    panel3.Enabled = true;
                    panel2.Enabled = true;
                    panel1.Enabled = true;
                    button5.ForeColor = Color.Red;
                    label1.ForeColor = Color.Red;
                    label1.Text = "Error, write how many playBacks";
                    return false;
                }
            }

            page = Int32.Parse(System.IO.File.ReadAllText("page.txt"));
            await Task.Delay(300);

            if (page == 1)
            {
                label1.Text = "1";
                await Task.Delay(2000);
                Process process = Process.Start(File.ReadAllText(@"Path\zennobox.txt"));
                if (process.WaitForInputIdle(25000))
                {
                    var runningProcessByName = Process.GetProcessesByName("ZennoBox");
                    if (runningProcessByName.Length == 1)
                    {
                        await Task.Delay(25000);
                        SetWindowPos(process.MainWindowHandle, this.Handle, -7, 1, 1116, 740, 0x0020);

                        await Task.Delay(10000);
                        //var x = File.ReadAllText(@"Points\TelegramKit-X.txt");
                        //var y = File.ReadAllText(@"Points\TelegramKit-Y.txt");
                        MoveTo(Int32.Parse(telegramkitx.Text), Int32.Parse(telegramkity.Text));
                        //LeftMouseClick(telegramkitx.Text, telegramkity.Text);
                        System.IO.File.WriteAllText("page.txt", "2");
                    }
                }

            }
            else if (page == 2)
            {
                label1.Text = "2";

                //Focus
                Process p = Process.GetProcessesByName("ZennoBox").FirstOrDefault();
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);

                await Task.Delay(500);
                //LeftMouseClick(interuptx.Text, interupty.Text);

                await Task.Delay(1500);

                //var x = File.ReadAllText(@"Points\‏‏Attempts-X.txt");
                //var y = File.ReadAllText(@"Points\‏‏Attempts-Y.txt");
                MoveTo(Int32.Parse(attempts_x.Text), Int32.Parse(attempts_y.Text));
                //LeftMouseClick(attempts_x.Text, attempts_y.Text);

                await Task.Delay(1500);

                SendKeys.SendWait("^a");

                await Task.Delay(500);

                SendKeys.SendWait("{Delete}");

                await Task.Delay(500);

                SendKeys.SendWait(attemptsBox.Text); //10


                System.IO.File.WriteAllText("page.txt", "3");
            }
            else if (page == 3)
            {
                label1.Text = "3";

                await Task.Delay(10);

                webBrowser1.Navigate("http://icanhazip.com/");
                await Task.Delay(1000);
                string ip11 = webBrowser1.Document.Body.InnerText;

                char[] delimiters11 = new char[] { '\r', '\n' };
                string[] lines11 = ip11.Split(delimiters11, StringSplitOptions.RemoveEmptyEntries);
                string result11 = string.Join(Environment.NewLine, lines11);

                File.WriteAllText("ip.txt", result11);

                //Process.Start("GetIp.exe");
                await Task.Delay(7500);


                await Task.Delay(10);
                string ip = File.ReadAllText("ip.txt");
                await Task.Delay(250);
                string country = web.DownloadString($"http://ip-api.com/php/{ip}?fields=country");
                await Task.Delay(100);
                char[] delimiters = new char[] { '\r', '\n' };
                string[] lines = country.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                string resultcountry = string.Join(Environment.NewLine, lines);
                web.Dispose();
                await Task.Delay(800);
                if (resultcountry.Contains("Israel"))
                {
                    string myip = File.ReadAllText("ip.txt");
                    char[] delimiters1 = new char[] { '\r', '\n' };
                    string[] lines1 = myip.Split(delimiters1, StringSplitOptions.RemoveEmptyEntries);
                    string resultIp = string.Join(Environment.NewLine, lines1);
                    File.WriteAllText("myip.txt", resultIp);
                }
                else
                {
                    if (vpnBox.Text == "‏‏VyprVPN")
                    {
                        Process[] pname1 = Process.GetProcessesByName("VyprVPN");
                        if (pname1.Length > 0)
                        {
                            await Task.Delay(500);
                            MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                            label1.ForeColor = Color.Red;
                            //MessageBox.Show(resultcountry);
                            label1.Text = "Error-2 VPN is broken " + DateTime.Now;
                        }
                        else
                        {
                            MessageBox.Show("Very weird, vpn not open and diffrent country?!");
                        }
                    }
                    else if (vpnBox.Text == "CyberVpn")
                    {//1760, 646
                        Process[] pname1 = Process.GetProcessesByName("Dashboard");
                        if (pname1.Length > 0)
                        {
                            await Task.Delay(500);
                            MoveTo(Int32.Parse(CyberX), Int32.Parse(CyberY));
                            label1.ForeColor = Color.Red;
                            //MessageBox.Show(resultcountry);
                            label1.Text = "Error-2 VPN is broken " + DateTime.Now;
                        }
                        else
                        {
                            MessageBox.Show("Very weird, vpn not open and diffrent country?!");
                        }
                    }
                    await Task.Delay(15000);

                    return await StartAddAsync();
                }


                if (vpnBox.Text == "‏‏VyprVPN")
                {
                    Process[] pname = Process.GetProcessesByName("VyprVPN");
                    if (pname.Length > 0)
                    {
                        // already running
                        System.IO.File.WriteAllText("page.txt", "4");
                    }
                    else
                    {
                        // turn on
                        Process process = Process.Start(File.ReadAllText(@"Path\vyprvpn.txt"));
                        await Task.Delay(10000);
                        SetWindowPos(process.MainWindowHandle, this.Handle, -7, 490, 1500, 740, 0x0020);
                        System.IO.File.WriteAllText("page.txt", "4");
                    }
                }
                else if (vpnBox.Text == "CyberVpn")
                {
                    Process[] pname = Process.GetProcessesByName("Dashboard");
                    if (pname.Length > 0)
                    {
                        // already running
                        System.IO.File.WriteAllText("page.txt", "4");
                    }
                    else
                    {
                        // turn on
                        Process process = Process.Start(File.ReadAllText(@"Path\cybervpn.txt"));
                        await Task.Delay(38000);
                        System.IO.File.WriteAllText("page.txt", "4");
                    }
                }
            }
            else if (page == 4)
            {
                label1.Text = "4";
                await Task.Delay(500);
                //await Task.Delay(7000);
                if (File.ReadAllText("myip.txt") == File.ReadAllText("ip.txt"))
                {
                    await Task.Delay(2000);
                    //var y = File.ReadAllText(@"Points\VyperVpn-Y.txt");
                    //var x = File.ReadAllText(@"Points\VyperVpn-X.txt");
                    MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                    //LeftMouseClick(vpnx.Text, vpny.Text);


                }
                System.IO.File.WriteAllText("page.txt", "5");
            }
            else if (page == 5)
            {
                label1.Text = "5";
                await Task.Delay(27000);
                await Task.Delay(10);

                webBrowser1.Navigate("http://icanhazip.com/");
                await Task.Delay(1000);
                string ip11 = webBrowser1.Document.Body.InnerText;

                char[] delimiters11 = new char[] { '\r', '\n' };
                string[] lines11 = ip11.Split(delimiters11, StringSplitOptions.RemoveEmptyEntries);
                string result11 = string.Join(Environment.NewLine, lines11);

                File.WriteAllText("ip.txt", result11);
                //Process.Start("GetIp.exe");
                await Task.Delay(6500);
                if (File.ReadAllText("myip.txt") != File.ReadAllText("ip.txt"))
                { // Connected
                    await Task.Delay(10);
                    if (File.ReadAllText("PreviousIP.txt") != File.ReadAllText("ip.txt"))
                    {
                        await Task.Delay(10);
                        string ip = File.ReadAllText("ip.txt");
                        string country = web.DownloadString($"http://ip-api.com/php/{ip}?fields=country");

                        char[] delimiters = new char[] { '\r', '\n' };
                        string[] lines = country.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        string resultcountry = string.Join(Environment.NewLine, lines);
                        await Task.Delay(100);
                        web.Dispose();
                        if (resultcountry.Contains("France") || resultcountry.Contains("United States") || resultcountry.Contains("United Kingdom") || resultcountry.Contains("Brazil") || resultcountry.Contains("Russia") || resultcountry.Contains("Israel"))
                        {
                            //start zennolab

                            try
                            {
                                using (WebClient client = new WebClient())
                                {
                                    using (client.OpenRead("http://www.google.com/"))
                                    {
                                        // success
                                    }
                                }
                            }
                            catch
                            {
                                label1.ForeColor = Color.Red;
                                label1.Text = "Error, No internet.";
                                return false;
                            }
                            //
                            await Task.Delay(10);
                            if (ModeBox.Text == "Adding")
                            {

                                MoveTo(488, 208); await Task.Delay(1000); // Settings



                                MoveTo(713, 338); await Task.Delay(1000); // Excel
                                SendKeys.SendWait("^a"); await Task.Delay(650); SendKeys.SendWait("{Delete}"); // Cleaning
                                var TxtGroupsLine = System.IO.File.ReadLines(@"groups.txt").Count();

                                TextReader tr = new StreamReader(@"groups.txt");
                                string[] ListLines = new string[TxtGroupsLine];
                                for (int i = 0; i < TxtGroupsLine; i++)
                                {
                                    ListLines[i] = tr.ReadLine();
                                }

                                tr.Close();

                                if (i1 < TxtGroupsLine) { }
                                else
                                {
                                    int count = Int32.Parse(playBack.Text);
                                    count--;
                                    playBack.Text = count.ToString();
                                    await Task.Delay(10);
                                    i1 = 0;
                                    if (Int32.Parse(playBack.Text) < 1)
                                    {
                                        //done attempts
                                        //status
                                        await Task.Delay(1);
                                        label1.ForeColor = Color.Green;
                                        label1.Text = "Done";
                                        button5.ForeColor = Color.Red;
                                        work = "false";
                                        panel3.Enabled = true;
                                        panel2.Enabled = true;
                                        panel4.Enabled = true;
                                        System.IO.File.WriteAllText("page.txt", "1");
                                        return false;
                                    }
                                }

                                SendKeys.SendWait($@"{File.ReadAllText(@"Path\Group.txt")}\" + ListLines[i1]); // New path
                                await Task.Delay(500);

                                MoveTo(713, 456); await Task.Delay(1000); // Group Link 
                                SendKeys.SendWait("^a"); await Task.Delay(650); SendKeys.SendWait("{Delete}"); // Cleaning

                                string file = ListLines[i1]; // Removing the text after .
                                string excelName = file.Split('.')[0].Trim(); // Still removing

                                SendKeys.SendWait($"@{excelName}"); // New group link

                                i1++;

                                MoveTo(650, 494); await Task.Delay(1000); // ForEach
                                SendKeys.SendWait("^a"); await Task.Delay(650); SendKeys.SendWait("{Delete}"); // Cleaning
                                SendKeys.SendWait(eachUserbox.Text); // New ForEach

                                await Task.Delay(1000);

                                MoveTo(967, 686); // Ok Settings
                            }


                            //

                            await Task.Delay(500);

                            RightMouseClick(telegramkitx.Text, telegramkity.Text);

                            await Task.Delay(1500);

                            MoveTo(Int32.Parse(interuptx.Text), Int32.Parse(interupty.Text));

                            await Task.Delay(1500);

                            MoveTo(Int32.Parse(interuptx.Text), Int32.Parse(interupty.Text));
                            File.WriteAllText("PreviousIP.txt", File.ReadAllText("ip.txt"));
                            Process p = Process.GetProcessesByName("ZennoBox").FirstOrDefault();
                            IntPtr h = p.MainWindowHandle;
                            SetForegroundWindow(h);
                            await Task.Delay(500);
                            //
                            webBrowser1.Navigate("http://icanhazip.com/");
                            await Task.Delay(1000);
                            string ip111 = webBrowser1.Document.Body.InnerText;

                            char[] delimiters111 = new char[] { '\r', '\n' };
                            string[] lines111 = ip111.Split(delimiters111, StringSplitOptions.RemoveEmptyEntries);
                            string result111 = string.Join(Environment.NewLine, lines111);

                            File.WriteAllText("ip.txt", result111);

                            await Task.Delay(6500);
                            if (File.ReadAllText("myip.txt") != File.ReadAllText("ip.txt"))
                            { // Connected
                              //
                                SendKeys.SendWait("{F5}");
                                System.IO.File.WriteAllText("page.txt", "7");
                            }
                            else
                            {
                                // Disconected or something

                                if (vpnBox.Text == "‏‏VyprVPN")
                                {
                                    await Task.Delay(100);
                                    foreach (Process proc in Process.GetProcessesByName("VyprVPN"))
                                    {
                                        proc.Kill();
                                    }
                                    await Task.Delay(2000);

                                    // turn on
                                    Process process = Process.Start(File.ReadAllText(@"Path\vyprvpn.txt"));
                                    await Task.Delay(10000);
                                    SetWindowPos(process.MainWindowHandle, this.Handle, -7, 490, 1500, 740, 0x0020);

                                    await Task.Delay(500);

                                    if (File.ReadAllText("myip.txt") == File.ReadAllText("ip.txt"))
                                    {
                                        await Task.Delay(2000);
                                        MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                                    }
                                    else { MessageBox.Show("WeirdIDK"); }

                                    //MessageBox.Show("Bad Vpn 3");
                                }
                                else if (vpnBox.Text == "CyberVpn")
                                {
                                    await Task.Delay(500);

                                    if (File.ReadAllText("myip.txt") == File.ReadAllText("ip.txt"))
                                    {
                                        await Task.Delay(2000);
                                        MoveTo(Int32.Parse(CyberX), Int32.Parse(CyberY));
                                    }
                                    else { MessageBox.Show("WeirdIDK2"); }
                                }
                            }
                        }
                        else
                        {
                            label1.ForeColor = Color.Red;
                            label1.Text = "Error VPN is broken " + DateTime.Now;
                            return false;
                        }
                    }
                    else
                    {
                        if (vpnBox.Text == "‏‏VyprVPN")
                        {
                            await Task.Delay(3000);
                            MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                            //LeftMouseClick(vpnx.Text, vpny.Text);
                            await Task.Delay(25000);
                            foreach (Process proc in Process.GetProcessesByName("VyprVPN"))
                            {
                                proc.Kill();
                            }
                            await Task.Delay(500);
                            System.IO.File.WriteAllText("page.txt", "3");
                        }
                        else if (vpnBox.Text == "CyberVpn")
                        {
                            await Task.Delay(10);
                            MoveTo(Int32.Parse(CyberX), Int32.Parse(CyberY));
                            //LeftMouseClick(vpnx.Text, vpny.Text);
                            await Task.Delay(20000);
                            System.IO.File.WriteAllText("page.txt", "3");
                        }
                    }
                }
                else
                {
                    await Task.Delay(100);
                    MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                    //LeftMouseClick(vpnx.Text, vpny.Text);
                }
            }
            else if (page == 6)
            {
                if (vpnBox.Text == "‏‏VyprVPN")
                {
                    label1.Text = "6";
                    await Task.Delay(500);
                    foreach (Process proc in Process.GetProcessesByName("VyprVPN"))
                    {
                        proc.Kill();
                    }
                    await Task.Delay(500);
                    System.IO.File.WriteAllText("page.txt", "3");
                }
                else if (vpnBox.Text == "CyberVpn")
                {
                    label1.Text = "6";
                    await Task.Delay(500);
                    System.IO.File.WriteAllText("page.txt", "3");
                }
            }
            else if (page == 7)
            {
                label1.Text = "7";
                await Task.Delay(Delay); // Delay
                string strFilePath = File.ReadAllText(@"Path\xlsx.txt");
                DateTime lastModified = System.IO.File.GetLastWriteTime(strFilePath);
                //
                webBrowser1.Navigate("http://icanhazip.com/");
                await Task.Delay(1000);
                string ip11 = webBrowser1.Document.Body.InnerText;

                char[] delimiters11 = new char[] { '\r', '\n' };
                string[] lines11 = ip11.Split(delimiters11, StringSplitOptions.RemoveEmptyEntries);
                string result11 = string.Join(Environment.NewLine, lines11);

                File.WriteAllText("ip.txt", result11);
                //Process.Start("GetIp.exe");
                await Task.Delay(6500);
                if (File.ReadAllText("myip.txt") != File.ReadAllText("ip.txt"))
                { // Connected
                  //
                    if ((DateTime.Now - lastModified).TotalMinutes >= WaitCheck) // WaitCheak
                    {
                        var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                               Screen.PrimaryScreen.Bounds.Height,
                                               PixelFormat.Format32bppArgb);
                        var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                        gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                                    Screen.PrimaryScreen.Bounds.Y,
                                                    0,
                                                    0,
                                                    Screen.PrimaryScreen.Bounds.Size,
                                                    CopyPixelOperation.SourceCopy);
                        string time = DateTime.Now.ToString();
                        string slash = time.Replace("/", ".");
                        string dots = slash.Replace(":", ".");
                        string space = dots.Replace(" ", "-");
                        bmpScreenshot.Save($@"Images\{space}.png", ImageFormat.Png);

                        for (int i = 0; i < 5; i++)
                        {
                            await Task.Delay(1000);
                            Process p = Process.GetProcessesByName("ZennoBox").FirstOrDefault();
                            IntPtr h = p.MainWindowHandle;
                            SetForegroundWindow(h);
                            await Task.Delay(500);
                            SendKeys.SendWait("+{F5}");
                        }
                        await Task.Delay(2000);

                        //Focus
                        Process p2 = Process.GetProcessesByName("ZennoBox").FirstOrDefault();
                        IntPtr h2 = p2.MainWindowHandle;
                        SetForegroundWindow(h2);

                        await Task.Delay(500);

                        RightMouseClick(telegramkitx.Text, telegramkity.Text);

                        await Task.Delay(1500);

                        MoveTo(Int32.Parse(interuptx.Text), Int32.Parse(interupty.Text));

                        await Task.Delay(1500);

                        RightMouseClick(telegramkitx.Text, telegramkity.Text);

                        await Task.Delay(1500);

                        MoveTo(Int32.Parse(interuptx.Text), Int32.Parse(interupty.Text));

                        await Task.Delay(1500);

                        RightMouseClick(telegramkitx.Text, telegramkity.Text);

                        await Task.Delay(1500);

                        MoveTo(Int32.Parse(interuptx.Text), Int32.Parse(interupty.Text));

                        //LeftMouseClick(interuptx.Text, interupty.Text);

                        await Task.Delay(13500);

                        //var x = File.ReadAllText(@"Points\VyperVpn-X.txt");
                        //var y = File.ReadAllText(@"Points\VyperVpn-Y.txt");


                        MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                        //LeftMouseClick(vpnx.Text, vpny.Text);
                        await Task.Delay(18000);
                        /*foreach (Process proc in Process.GetProcessesByName("VyprVPN"))
                        {
                            proc.Kill();
                        }
                        await Task.Delay(500);*/


                        if (ModeBox.Text == "Authorizing")
                        {
                            //counts
                            //int count = Int32.Parse(accountstextbox.Text);
                            //count--;
                            //accountstextbox.Text = count.ToString();




                            int count = Int32.Parse(playBack.Text);
                            count--;
                            playBack.Text = count.ToString();
                            await Task.Delay(10);
                            i1 = 0;
                            if (Int32.Parse(playBack.Text) < 1)
                            {
                                //done attempts
                                //status
                                await Task.Delay(1);
                                label1.ForeColor = Color.Green;
                                label1.Text = "Done";
                                button5.ForeColor = Color.Red;
                                work = "false";
                                panel3.Enabled = true;
                                panel2.Enabled = true;
                                panel4.Enabled = true;
                                System.IO.File.WriteAllText("page.txt", "1");
                                return false;
                            }

                        }
                        if (ModeBox.Text == "Leave")
                        {


                            int count = Int32.Parse(playBack.Text);
                            count--;
                            playBack.Text = count.ToString();
                            await Task.Delay(10);
                            i1 = 0;
                            if (Int32.Parse(playBack.Text) < 1)
                            {
                                //done attempts
                                //status
                                await Task.Delay(1);
                                label1.ForeColor = Color.Green;
                                label1.Text = "Done";
                                button5.ForeColor = Color.Red;
                                work = "false";
                                panel3.Enabled = true;
                                panel2.Enabled = true;
                                panel4.Enabled = true;
                                System.IO.File.WriteAllText("page.txt", "1");
                                return false;
                            }

                        }


                        //counts
                        /*int count = Int32.Parse(attempts.Text);
                        count--;
                        attempts.Text = count.ToString();*/
                        await Task.Delay(1);
                        if (work == "false")
                        {
                            //stopped
                            await Task.Delay(1);
                            panel3.Enabled = true;
                            panel2.Enabled = true;
                            panel4.Enabled = true;
                            button5.ForeColor = Color.Red;
                            label1.Text = "Stopped";
                            return false;
                        }
                        else if (Int32.Parse(playBack.Text) < 1)
                        {
                            //done attempts
                            //status
                            await Task.Delay(1);
                            label1.ForeColor = Color.Green;
                            label1.Text = "Done";
                            button5.ForeColor = Color.Red;
                            work = "false";
                            panel3.Enabled = true;
                            panel2.Enabled = true;
                            panel4.Enabled = true;
                            System.IO.File.WriteAllText("page.txt", "1");
                            return false;
                        }
                        else if (Int32.Parse(playBack.Text) > 0)
                        {
                            //keep going
                            await Task.Delay(1);
                            System.IO.File.WriteAllText("page.txt", "2");
                        }
                    }
                }
                else
                {
                    //Find button of trouble connecting VPN
                    //Click it
                    //Conact fast back into the server

                    if (vpnBox.Text == "‏‏VyprVPN")
                    {
                        await Task.Delay(100);
                        foreach (Process proc in Process.GetProcessesByName("VyprVPN"))
                        {
                            proc.Kill();
                        }
                        await Task.Delay(2000);

                        // turn on
                        Process process = Process.Start(File.ReadAllText(@"Path\vyprvpn.txt"));
                        await Task.Delay(10000);
                        SetWindowPos(process.MainWindowHandle, this.Handle, -7, 490, 1500, 740, 0x0020);

                        await Task.Delay(500);

                        if (File.ReadAllText("myip.txt") == File.ReadAllText("ip.txt"))
                        {
                            await Task.Delay(2000);
                            MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                        }
                        else { MessageBox.Show("WeirdIDK"); }
                    }
                    else if (vpnBox.Text == "CyberVpn")
                    {
                        await Task.Delay(500);

                        if (File.ReadAllText("myip.txt") == File.ReadAllText("ip.txt"))
                        {
                            await Task.Delay(2000);
                            MoveTo(Int32.Parse(CyberX), Int32.Parse(CyberY));
                        }
                        else { MessageBox.Show("WeirdIDK"); }
                    }

                    //MessageBox.Show("Bad Vpn 4");
                }
            }
            await Task.Delay(1000);
            return await StartAddAsync();
        }



        private void button6_Click(object sender, EventArgs e)
        {

        }
        #region
        public static class MouseHook
        {
            public static event EventHandler MouseAction = delegate { };

            public static void Start()
            {
                _hookID = SetHook(_proc);


            }
            public static void stop()
            {
                UnhookWindowsHookEx(_hookID);
            }

            private static LowLevelMouseProc _proc = HookCallback;
            private static IntPtr _hookID = IntPtr.Zero;

            private static IntPtr SetHook(LowLevelMouseProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_MOUSE_LL, proc,
                      GetModuleHandle(curModule.ModuleName), 0);
                }
            }

            private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

            private static IntPtr HookCallback(
              int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
                {
                    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    MouseAction(null, new EventArgs());
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }

            private const int WH_MOUSE_LL = 14;

            private enum MouseMessages
            {
                WM_LBUTTONDOWN = 0x0201,
                WM_LBUTTONUP = 0x0202,
                WM_MOUSEMOVE = 0x0200,
                WM_MOUSEWHEEL = 0x020A,
                WM_RBUTTONDOWN = 0x0204,
                WM_RBUTTONUP = 0x0205
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct POINT
            {
                public int x;
                public int y;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct MSLLHOOKSTRUCT
            {
                public POINT pt;
                public uint mouseData;
                public uint flags;
                public uint time;
                public IntPtr dwExtraInfo;
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook,
              LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
              IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);


        }
        #endregion

        public static int count = 0;
        private void Event(object sender, EventArgs e)
        {
            if (count == 0)
            {
                //TelegramKit_2.0
                label1.Text = count.ToString();
                int coordinatesX = Cursor.Position.X;
                int coordinatesY = Cursor.Position.Y;
                Properties.Settings.Default.TelegramKit_X = coordinatesX;
                Properties.Settings.Default.TelegramKit_Y = coordinatesY;
                Properties.Settings.Default.Save();
                count++;
                return;
            }
            if (count == 1)
            {
                //Interupt
                label1.Text = count.ToString();
                int coordinatesY = Cursor.Position.Y;
                int coordinatesX = Cursor.Position.X;
                Properties.Settings.Default.Interupt_X = coordinatesX;
                Properties.Settings.Default.Interupt_Y = coordinatesY;
                Properties.Settings.Default.Save();
                count++;
                return;
            }
            if (count == 2)
            {
                //Attempts
                label1.Text = count.ToString();
                int coordinatesX = Cursor.Position.X;
                int coordinatesY = Cursor.Position.Y;
                Properties.Settings.Default.Attempts_X = coordinatesX;
                Properties.Settings.Default.Attempts_Y = coordinatesY;
                Properties.Settings.Default.Save();
                count++;
                return;
            }
            if (count == 3)
            {
                //VyprVPN
                label1.Text = count.ToString();
                int coordinatesY = Cursor.Position.Y;
                int coordinatesX = Cursor.Position.X;
                Properties.Settings.Default.VyperVpn_X = coordinatesX;
                Properties.Settings.Default.VyperVpn_Y = coordinatesY;
                Properties.Settings.Default.Save();
                count++;
            }
            if (count == 4)
            {
                attempts_x.Text = Properties.Settings.Default.Attempts_X.ToString();
                attempts_y.Text = Properties.Settings.Default.Attempts_Y.ToString();

                telegramkitx.Text = Properties.Settings.Default.TelegramKit_X.ToString();
                telegramkity.Text = Properties.Settings.Default.TelegramKit_Y.ToString();

                vpnx.Text = Properties.Settings.Default.VyperVpn_X.ToString();
                vpny.Text = Properties.Settings.Default.VyperVpn_Y.ToString();

                interupty.Text = Properties.Settings.Default.Interupt_Y.ToString();
                interuptx.Text = Properties.Settings.Default.Interupt_X.ToString();

                label1.ForeColor = Color.Green;
                label1.Text = "Done";
                count++;
                MouseHook.stop();
                return;
            }
        }
        private async void button7_Click(object sender, EventArgs e)
        {

            count = 0;
            //zenno-box
            Process process = Process.Start(File.ReadAllText(@"Path\zennobox.txt"));
            await Task.Delay(25000);
            SetWindowPos(process.MainWindowHandle, this.Handle, -7, 1, 1116, 740, 0x0020);

            //vypr-vpn
            Process proces = Process.Start(File.ReadAllText(@"Path\vyprvpn.txt"));
            await Task.Delay(10000);
            SetWindowPos(proces.MainWindowHandle, this.Handle, -7, 490, 1500, 740, 0x0020);

            MouseHook.Start();
            MouseHook.MouseAction += new EventHandler(Event);

            /*if (File.ReadAllText(@"Points\TelegramKit_2.0.txt") == "")
            {
                
            }
            if (File.ReadAllText(@"Points\Attempts.txt") == "")
            {
            }
            if (File.ReadAllText(@"Points\VyprVPN.txt") == "")
            {
            }*/
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow1(IntPtr hWnd);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static int i1 = 0;
        private async void label1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = File.ReadAllText(@"Path\bluestacks.txt");
            process.Start();
            process.WaitForInputIdle();

            if (process.WaitForInputIdle(10000))
            {
                var runningProcessByName = Process.GetProcessesByName("Bluestacks");
                if (runningProcessByName.Length == 1)
                {
                    await Task.Delay(10000);
                    SetWindowPos(process.MainWindowHandle, this.Handle, 1370, 1, 565, 955, 0x0020);

                    File.WriteAllText("blueid.txt", process.MainWindowHandle.ToString());

                    //File.WriteAllText("text.txt", process.MainWindowHandle.ToString());

                    //MessageBox.Show(process.MainWindowHandle.ToString());

                    /*IDWidnow = Int32.Parse(process.MainWindowHandle.ToString());

                    char[] delimiters = new char[] { '\r', '\n' };
                    string[] lines = IDWidnow.ToString().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    string result = string.Join(Environment.NewLine, lines);

                    IDWidnow = Int32.Parse(result);

                    await Task.Delay(2500);

                    IntPtr xAsIntPtr = new IntPtr(IDWidnow);

                    await Task.Delay(100);
                    //MessageBox.Show(xAsIntPtr.ToString());
                    if (Convert.ToBoolean(SetForegroundWindow(xAsIntPtr)))
                    {
                        await Task.Delay(100);
                        RECT srcRect;
                        if (!xAsIntPtr.Equals(IntPtr.Zero))
                        {
                            if (GetWindowRect(xAsIntPtr, out srcRect))
                            {
                                int width = srcRect.Right - srcRect.Left;
                                int height = srcRect.Bottom - srcRect.Top;

                                Bitmap bmp = new Bitmap(width, height);
                                Graphics screenG = Graphics.FromImage(bmp);

                                try
                                {
                                    screenG.CopyFromScreen(srcRect.Left, srcRect.Top,
                                            0, 0, new Size(width, height),
                                            CopyPixelOperation.SourceCopy);

                                    bmp.Save("telegram.png", ImageFormat.Jpeg);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    screenG.Dispose();
                                    bmp.Dispose();
                                }
                            }
                        }
                    }*/
                }
            }
        }

        public static int IDWidnow = 0;

        private void leave_timer_Tick(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            string check = isAdmin.ToString();

            if (check == "True")
            {
                RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64); //here you specify where exactly you want your entry

                // Get folder
                var reg = localMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection", true);
                if (reg == null)
                {
                    // add folder
                    reg = localMachine.CreateSubKey("Software\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection");
                }

                //Get DWord
                if (reg.GetValue("DisableRealtimeMonitoring") == null)
                {
                    // Add DWord
                    reg.SetValue("DisableRealtimeMonitoring", 1, RegistryValueKind.DWord);
                }
            }
            else
            {
                MessageBox.Show("You Have To Run The Program As Administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RegistryKey localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var reg = localMachine.OpenSubKey("Software\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection", true);

            reg.DeleteValue("DisableRealtimeMonitoring");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (work == "false")
            {
                work = "true";
                button8.ForeColor = Color.Green;
                StartSmsAsync();
                panel4.Enabled = false;
                panel2.Enabled = false;
            }
            else if (work == "true")
            {
                panel4.Enabled = true;
                panel2.Enabled = true;
                button8.ForeColor = Color.Red;
                work = "false";
            }
        }

        public static string id = "";

        public static string phone = "";

        public static string code = "";

        public static int countryid = 0;

        public static int countrycode = 0;

        public static string work = "false";

        public static string avatars = "";

        public async Task<bool> StartSmsAsync()
        {
            label1.ForeColor = Color.Black;

            if (Int32.Parse(accountstextbox.Text) < 1)
            {
                await Task.Delay(1);
                panel4.Enabled = true;
                panel2.Enabled = true;
                button8.ForeColor = Color.Red;
                label1.ForeColor = Color.Red;
                label1.Text = "Error, write how many attempts - SMS";
                return false;
            }

            if (comboBox.Text == "Select Country")
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Error, Select a Country - SMS";
                return false;
            }
            else if (comboBox.Text == "France")
            {
                countryid = 78;
                countrycode = 33;
            }
            else if (comboBox.Text == "Russian")
            {
                countryid = 0;
                countrycode = 7;
            }
            else if (comboBox.Text == "Usa")
            {
                countryid = 187;
                countrycode = 1;
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Error, Select a Country - SMS";
                return false;
            }

            try
            {
                page = Int32.Parse(System.IO.File.ReadAllText("page.txt"));
                await Task.Delay(1000);
                if (page == 1)
                {
                    label1.Text = "1 - VPN";
                    //vpn
                    await Task.Delay(10);
                    webBrowser1.Navigate("http://icanhazip.com/");
                    await Task.Delay(1000);
                    string ip11 = webBrowser1.Document.Body.InnerText;

                    char[] delimiters11 = new char[] { '\r', '\n' };
                    string[] lines11 = ip11.Split(delimiters11, StringSplitOptions.RemoveEmptyEntries);
                    string result11 = string.Join(Environment.NewLine, lines11);

                    File.WriteAllText("ip.txt", result11);
                    //Process.Start("GetIp.exe");
                    await Task.Delay(7500);

                    WebClient web = new WebClient();
                    string ip = File.ReadAllText("ip.txt");
                    string country = web.DownloadString($"http://ip-api.com/php/{ip}?fields=country");

                    char[] delimiters = new char[] { '\r', '\n' };
                    string[] lines = country.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    string resultcountry = string.Join(Environment.NewLine, lines);
                    await Task.Delay(100);
                    if (resultcountry.Contains("Israel"))
                    {
                        string myip = File.ReadAllText("ip.txt");
                        char[] delimiters1 = new char[] { '\r', '\n' };
                        string[] lines1 = myip.Split(delimiters1, StringSplitOptions.RemoveEmptyEntries);
                        string resultIp = string.Join(Environment.NewLine, lines1);
                        File.WriteAllText("myip.txt", resultIp);
                    }
                    else
                    {
                        label1.ForeColor = Color.Red;
                        label1.Text = "Error-2 VPN is broken " + DateTime.Now;
                        return false;
                    }

                    if (vpnBox.Text == "‏‏VyprVPN")
                    {
                        Process[] pname = Process.GetProcessesByName("VyprVPN");
                        if (pname.Length > 0)
                        {
                            // already running
                            System.IO.File.WriteAllText("page.txt", "2");
                        }
                        else
                        {
                            // turn on
                            Process process = Process.Start(File.ReadAllText(@"Path\vyprvpn.txt"));
                            await Task.Delay(10000);
                            SetWindowPos(process.MainWindowHandle, this.Handle, -7, 490, 1500, 740, 0x0020);
                            System.IO.File.WriteAllText("page.txt", "2");
                        }
                    }
                    else if (vpnBox.Text == "CyberVpn")
                    {
                        Process[] pname = Process.GetProcessesByName("Dashboard");
                        if (pname.Length > 0)
                        {
                            // already running
                            System.IO.File.WriteAllText("page.txt", "2");
                        }
                        else
                        {
                            // turn on
                            Process process = Process.Start(File.ReadAllText(@"Path\cybervpn.txt"));

                            System.IO.File.WriteAllText("page.txt", "2");
                        }
                    }
                }
                else if (page == 2)
                {
                    label1.Text = "2 - VPN";
                    await Task.Delay(1000);
                    //Process.Start("GetIp.exe");
                    //await Task.Delay(7000);
                    if (File.ReadAllText("myip.txt") == File.ReadAllText("ip.txt"))
                    {
                        await Task.Delay(1000);
                        //var y = File.ReadAllText(@"Points\VyperVpn-Y.txt");
                        //var x = File.ReadAllText(@"Points\VyperVpn-X.txt");
                        MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                        //LeftMouseClick(vpnx.Text, vpny.Text);


                    }
                    System.IO.File.WriteAllText("page.txt", "3");
                }
                else if (page == 3)
                {
                    //
                    label1.Text = "3 - VPN";
                    await Task.Delay(27000);

                    await Task.Delay(10);
                    webBrowser1.Navigate("http://icanhazip.com/");
                    await Task.Delay(1000);
                    string ip11 = webBrowser1.Document.Body.InnerText;

                    char[] delimiters11 = new char[] { '\r', '\n' };
                    string[] lines11 = ip11.Split(delimiters11, StringSplitOptions.RemoveEmptyEntries);
                    string result11 = string.Join(Environment.NewLine, lines11);

                    File.WriteAllText("ip.txt", result11);
                    //Process.Start("GetIp.exe");
                    await Task.Delay(7300);
                    if (File.ReadAllText("myip.txt") != File.ReadAllText("ip.txt"))
                    {
                        if (File.ReadAllText("PreviousIP.txt") != File.ReadAllText("ip.txt"))
                        {
                            File.WriteAllText("PreviousIP.txt", File.ReadAllText("ip.txt"));
                            //

                            WebClient web = new WebClient();
                            string ip = File.ReadAllText("ip.txt");
                            string country = web.DownloadString($"http://ip-api.com/php/{ip}?fields=country");

                            char[] delimiters = new char[] { '\r', '\n' };
                            string[] lines = country.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                            string resultcountry = string.Join(Environment.NewLine, lines);
                            await Task.Delay(100);
                            if (resultcountry.Contains("France") || resultcountry.Contains("United Kingdom") || resultcountry.Contains("United States") || resultcountry.Contains("Brazil"))
                            {
                                //start zennolab

                                try
                                {
                                    using (WebClient client = new WebClient())
                                    {
                                        using (client.OpenRead("http://www.google.com/"))
                                        {
                                            // success
                                        }
                                    }
                                }
                                catch
                                {
                                    label1.ForeColor = Color.Red;
                                    label1.Text = "Error, No internet.";
                                    return false;
                                }

                                System.IO.File.WriteAllText("page.txt", "4");
                            }
                            else
                            {
                                label1.ForeColor = Color.Red;
                                label1.Text = "Error VPN is broken " + DateTime.Now;
                                return false;
                            }
                        }
                        else
                        {

                            if (vpnBox.Text == "‏‏VyprVPN")
                            {
                                await Task.Delay(3000);
                                MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                                //LeftMouseClick(vpnx.Text, vpny.Text);
                                await Task.Delay(20000);
                                foreach (Process proc in Process.GetProcessesByName("VyprVPN"))
                                {
                                    proc.Kill();
                                }
                                await Task.Delay(500);
                                System.IO.File.WriteAllText("page.txt", "1");
                            }
                            else if (vpnBox.Text == "CyberVpn")
                            {
                                await Task.Delay(3000);
                                MoveTo(Int32.Parse(CyberX), Int32.Parse(CyberY));
                                await Task.Delay(500);
                                System.IO.File.WriteAllText("page.txt", "1");
                            }
                        }
                    }
                    else
                    {
                        if (vpnBox.Text == "‏‏VyprVPN")
                        {
                            await Task.Delay(100);
                            MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                        }
                        else if (vpnBox.Text == "CyberVpn")
                        {
                            await Task.Delay(100);
                            MoveTo(Int32.Parse(CyberX), Int32.Parse(CyberY));
                        }
                    }
                    //
                }
                else if (page == 4)
                {
                    label1.Text = "4 - SMS";
                    await Task.Delay(700);
                    string Details = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=$8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=getNumber&service=$tg&forward=$0&operator=any&country={countryid}");
                    if (Details.Contains("NO_NUMBERS"))
                    {
                        if (work == "false")
                        {
                            button8.ForeColor = Color.Red;
                            label1.Text = "Stopped - SMS";
                            return false;
                        }
                        label1.Text = "4 - No numbers\n waiting";
                        await Task.Delay(700);
                    }
                    else if (Details.Contains("ACCESS_NUMBER:"))
                    {
                        /*Thread thread = new Thread(() => Clipboard.SetText(Details));
                        thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                        thread.Start();
                        thread.Join();*/

                        // ACCESS_NUMBER:394805926:33753664993



                        string clean = string.Join(":", Details.Split(':').Skip(1).ToArray());

                        id = clean.Substring(0, clean.IndexOf(':'));
                        phone = clean.Substring(clean.IndexOf(':'));
                        phone = phone.Replace(":", " ");

                        if (comboBox.Text == "France")
                        {
                            //france
                            string PhoneCode = phone;
                            PhoneCode = PhoneCode.Substring(3);
                            phone = PhoneCode;
                        }
                        else if (comboBox.Text == "Russian")
                        {
                            //russian
                            string PhoneCode = phone;
                            PhoneCode = PhoneCode.Substring(2);
                            phone = PhoneCode;
                        }
                        else if (comboBox.Text == "Usa")
                        {
                            //russian
                            string PhoneCode = phone;
                            PhoneCode = PhoneCode.Substring(2);
                            phone = PhoneCode;
                        }

                        //MessageBox.Show("phone: " + phone + " " + "id: " + id);

                        System.IO.File.WriteAllText("page.txt", "5");
                    }
                    else if (Details.Contains("NO_BALANCE"))
                    {
                        label1.Text = "Error, There are no\nbalance in the account";
                        return false;
                    }
                    else
                    {
                        label1.Text = "Error";
                        return false;
                    }
                }
                else if (page == 5)
                {
                    label1.Text = "5 - SMS";

                    //MessageBox.Show("phone: " + phone + " " + "id: " + id);

                    if (Directory.Exists(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}"))
                    {
                        //Cancel code
                        string Cancel = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=setStatus&status=8&id={id}");
                        label1.Text = $"4 - Cancelled, The phone\nalready exits - {Cancel}";
                        await Task.Delay(1000);
                    }
                    else
                    {
                        Directory.CreateDirectory(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}");
                        DirectoryCopy("telegram", File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}");
                        System.IO.File.WriteAllText("page.txt", "6");
                    }
                }
                else if (page == 6)
                {
                    label1.Text = "6 - SMS";

                    await Task.Delay(1000);
                    Process process = Process.Start(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}\Telegram.exe");
                    if (process.WaitForInputIdle(2500))
                    {
                        var runningProcessByName = Process.GetProcessesByName("Telegram");
                        if (runningProcessByName.Length == 1)
                        {
                            await Task.Delay(2500);
                            SetWindowPos(process.MainWindowHandle, this.Handle, -7, 1, 800, 602, 0x0020);

                            await Task.Delay(6000);

                            //Focus
                            var processes = Process.GetProcessesByName("Telegram");
                            if (processes.Any())
                                Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);

                            //Sign button
                            MoveTo(400, 430);
                            //LeftMouseClick("400", "430");


                            //Country code button
                            await Task.Delay(2000);
                            MoveTo(275, 310);
                            //LeftMouseClick("275", "310");
                            await Task.Delay(500);
                            SendKeys.SendWait("^a");
                            await Task.Delay(500);
                            SendKeys.SendWait("{Delete}");
                            await Task.Delay(500);
                            SendKeys.SendWait(countrycode.ToString());


                            //Phone button
                            await Task.Delay(2000);
                            MoveTo(335, 310);
                            //LeftMouseClick("335", "310");
                            await Task.Delay(500);
                            SendKeys.SendWait("^a");
                            await Task.Delay(500);
                            SendKeys.SendWait("{Delete}");
                            await Task.Delay(500);
                            SendKeys.SendWait(phone);

                            //Sign button2
                            await Task.Delay(2000);
                            MoveTo(400, 405);
                            //LeftMouseClick("400", "405");

                            System.IO.File.WriteAllText("page.txt", "7");
                        }
                    }
                }
                else if (page == 7)
                {
                    label1.Text = "7 - SMS";

                    //Focus
                    var processes = Process.GetProcessesByName("Telegram");
                    if (processes.Any())
                        Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);

                    using (FileStream logFileStream = new FileStream(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}\log.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader logFileReader = new StreamReader(logFileStream))
                        {
                            string text = logFileReader.ReadToEnd();
                            logFileStream.Close();
                            logFileReader.Close();
                            if (text.Contains("PHONE_NUMBER_BANNED"))
                            {
                                label1.ForeColor = Color.Red;
                                string Cancel = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=setStatus&status=8&id={id}");
                                label1.Text = $"7 - Phone number Banned - {Cancel}";

                                Process[] localByName = Process.GetProcessesByName("Telegram");
                                foreach (Process p in localByName)
                                {
                                    p.Kill();
                                }

                                await Task.Delay(1500);
                                Directory.Delete(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}", true);
                                await Task.Delay(1500);
                                System.IO.File.WriteAllText("page.txt", "4");
                            }
                        }
                    }

                    await Task.Delay(1500);
                    string StatusCode = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=getStatus&id={id}");

                    if (StatusCode.Contains("STATUS_WAIT_CODE"))
                    {
                        label1.Text = $"7 - Waiting for sms\n{DateTime.Now}";
                        string strFilePath = File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}\log.txt";
                        DateTime lastModified = System.IO.File.GetLastWriteTime(strFilePath);
                        if ((DateTime.Now - lastModified).TotalMinutes >= 3)
                        {
                            string Cancel = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=setStatus&status=8&id={id}");
                            label1.Text = $"7 - Cancelled - {Cancel}";

                            Process[] localByName = Process.GetProcessesByName("Telegram");
                            foreach (Process p in localByName)
                            {
                                p.Kill();
                            }

                            await Task.Delay(1500);
                            Directory.Delete(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}", true);
                            await Task.Delay(1500);
                            System.IO.File.WriteAllText("page.txt", "4");
                        }
                        await Task.Delay(700);
                    }
                    else if (StatusCode.Contains("STATUS_OK:"))
                    {
                        string clean = string.Join(":", StatusCode.Split(':').Skip(0).ToArray());

                        code = clean.Substring(clean.IndexOf(':'));
                        code = code.Replace(":", " ");
                        countray = comboBox.Text;
                        //Phone Code
                        await Task.Delay(1000);
                        MoveTo(385, 248);
                        //LeftMouseClick("385", "248");
                        await Task.Delay(1000);
                        SendKeys.SendWait(code);

                        //First name
                        await Task.Delay(1500);
                        MoveTo(360, 245);
                        //LeftMouseClick("360", "245");
                        await Task.Delay(500);
                        Random rnd = new Random();
                        int rndi = rnd.Next(4, 11);
                        SendKeys.SendWait(GenerateName(rndi));

                        //Last name
                        await Task.Delay(1500);
                        MoveTo(360, 310);
                        //LeftMouseClick("360", "310");
                        await Task.Delay(500);
                        Random rnd1 = new Random();
                        int rndii = rnd1.Next(4, 11);
                        SendKeys.SendWait(GenerateName(rndii));

                        //Finall Signup
                        await Task.Delay(1500);
                        MoveTo(400, 400);
                        //LeftMouseClick("400", "400");
                        await Task.Delay(1500);
                        SendKeys.SendWait("{Enter}");
                        System.IO.File.WriteAllText("page.txt", "8");
                    }
                    //360 245 first name
                    //360 310 // last name 
                    //signup button 400 400
                }
                else if (page == 8)
                {
                    // Setting up avatar
                    label1.Text = "8 - SMS";
                    if (avatars == "")
                    {
                        await Task.Delay(3000);

                        //Focus On telegram
                        var processes = Process.GetProcessesByName("Telegram");
                        if (processes.Any())
                            Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);

                        // Open settings bar
                        MoveTo(25, 47);
                        //LeftMouseClick("25", "47");
                        await Task.Delay(800);

                        // Settings button
                        MoveTo(100, 365);
                        //LeftMouseClick("100", "365");
                        await Task.Delay(800);

                        // Edit Profile button
                        MoveTo(328, 253);
                        //LeftMouseClick("328", "253");
                        await Task.Delay(800);

                        // Set profile photo button
                        MoveTo(398, 238);
                        //LeftMouseClick("398", "238");
                        await Task.Delay(800);

                        // Get path of rnd image
                        string path = File.ReadAllText(@"Path\accs.txt") + @"\Avatars";
                        Random rand = new Random();

                        // pick a random file
                        string[] files = Directory.GetFiles(path);
                        string randomFile = files[rand.Next(files.Length)];

                        SendKeys.SendWait(randomFile); // Sending the image path

                        await Task.Delay(800);

                        SendKeys.SendWait("{ENTER}"); // Confirming it

                        await Task.Delay(800);

                        SendKeys.SendWait("{ENTER}"); // Confirming it

                        await Task.Delay(500);

                        // Add username button
                        MoveTo(342, 435);
                        //LeftMouseClick("342", "435");
                        await Task.Delay(800);
                        MoveTo(342, 400);
                        //LeftMouseClick("342", "440");
                        await Task.Delay(800);

                        avatars = "username";
                    }
                    if (avatars == "username")
                    {
                        await Task.Delay(1500);

                        SendKeys.SendWait("^a");

                        await Task.Delay(1500);

                        SendKeys.SendWait("{Delete}");

                        await Task.Delay(500);

                        string user = username();
                        SendKeys.SendWait(user);

                        await Task.Delay(800);

                        SendKeys.SendWait("{ENTER}"); // Confirming it

                        await Task.Delay(800);

                        SendKeys.SendWait("^a");
                        await Task.Delay(800);
                        SendKeys.SendWait("^c");

                        await Task.Delay(800);

                        if (Clipboard.GetText(TextDataFormat.Text) == user)
                        {
                            // create a new username
                            // return
                        }
                        else
                        {
                            avatars = "username2";
                        }
                    }
                    if (avatars == "username2")
                    {
                        MoveTo(228, 75);// Back
                                        //LeftMouseClick("228", "75"); // Back

                        await Task.Delay(800);

                        for (int i = 0; i < 10; i++) // Going up
                        {
                            await Task.Delay(0);
                            SendKeys.SendWait("{UP}");
                        }

                        await Task.Delay(1000);

                        MoveTo(342, 345);
                        //LeftMouseClick("342", "345"); // Privacy and Security
                        await Task.Delay(1000);


                        MoveTo(294, 323);
                        //LeftMouseClick("294", "323"); // Calls
                        await Task.Delay(1000);
                        MoveTo(250, 260);
                        //LeftMouseClick("250", "260"); // Calls nobody
                        await Task.Delay(1000);
                        MoveTo(545, 505);
                        //LeftMouseClick("545", "505"); // Calls Save
                        await Task.Delay(1000);


                        MoveTo(300, 400);
                        //LeftMouseClick("300", "400"); // Group & channels
                        await Task.Delay(1000);
                        MoveTo(250, 253);
                        //LeftMouseClick("250", "243"); // Group & channels My contacts
                        await Task.Delay(1000);
                        MoveTo(544, 490);
                        //LeftMouseClick("544", "490"); // Group & channels Save
                        await Task.Delay(3000);

                        MoveTo(228, 75);// Back

                        await Task.Delay(1000);

                        // Edit Profile button
                        MoveTo(328, 253);
                        //LeftMouseClick("328", "253");
                        await Task.Delay(1000);

                        //
                        webBrowser1.Navigate("https://sassycaptions.com/bio-generator/");
                        await Task.Delay(8000);
                        webBrowser1.Document.GetElementById("gen").InvokeMember("click");

                        MoveTo(335, 536);
                        //LeftMouseClick("335", "536"); // Bio
                        await Task.Delay(1500);
                        SendKeys.SendWait("^a");
                        await Task.Delay(1000);
                        SendKeys.SendWait("{Delete}");

                        await Task.Delay(4000);
                        string boi = webBrowser1.Document.GetElementById("quote").OuterText;
                        if (boi.Length > 70)
                        {

                        }
                        else
                        {
                            SendKeys.SendWait(boi); // Tyiping bio

                            await Task.Delay(10000);

                            //
                            //
                            avatars = "";
                            System.IO.File.WriteAllText("page.txt", "9");
                        }
                    }

                    await Task.Delay(5000);
                }
                else if (page == 9)
                {
                    label1.Text = "9 - SMS";
                    string Sent = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=setStatus&status=6&id={id}");
                    await Task.Delay(9800);

                    Process[] localByName = Process.GetProcessesByName("Telegram");
                    foreach (Process p in localByName)
                    {
                        p.Kill();
                    }

                    //counts
                    int count = Int32.Parse(accountstextbox.Text);
                    count--;
                    accountstextbox.Text = count.ToString();

                    await Task.Delay(1000);
                    if (checkBox.Checked == true)
                    {
                        if (work == "false")
                        {
                            panel3.Enabled = true;
                            panel2.Enabled = true;
                            button8.ForeColor = Color.Red;
                            label1.Text = "Loop Stopped - SMS";
                            return false;
                        }
                        else if (Int32.Parse(accountstextbox.Text) < 1)
                        {
                            //reset
                            MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                            //LeftMouseClick(vpnx.Text, vpny.Text);
                            await Task.Delay(25000);

                            System.IO.File.WriteAllText("page.txt", "2");

                            accountstextbox.Text = attemptsBox.Text;

                            label1.ForeColor = Color.Green;
                            label1.Text = "Loop - SMS";
                            await Task.Delay(2000);
                        }
                        else
                        {
                            System.IO.File.WriteAllText("page.txt", "4");
                        }
                    }
                    else if (Int32.Parse(accountstextbox.Text) < 1)
                    {
                        MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                        //LeftMouseClick(vpnx.Text, vpny.Text);
                        await Task.Delay(25000);
                        //status
                        label1.ForeColor = Color.Green;
                        label1.Text = "Done - SMS";
                        button8.ForeColor = Color.Red;
                        panel3.Enabled = true;
                        panel2.Enabled = true;
                        work = "false";
                        System.IO.File.WriteAllText("page.txt", "1");
                        return false;
                    }
                    else if (work == "false")
                    {
                        panel3.Enabled = true;
                        panel2.Enabled = true;
                        button8.ForeColor = Color.Red;
                        label1.Text = "Stopped - SMS";
                        return false;
                    }
                    else
                    {
                        System.IO.File.WriteAllText("page.txt", "4");
                    }
                }
            }
            catch
            {

            }
            await Task.Delay(100);
            return await StartSmsAsync();
        }

        public static string countray = "";
        public static string GenerateName(int len)
        {
            Random r = new Random();
            /*string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };*/
            /*string[] consonants = { "а", "э", "ы", "у", "о", "я", "е", "ё", "ю", "и", "б", "в", "г", "д", "ж", "з", "к", "л", "м", "н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" };
            string[] vowels = { "ю", "и", "б", "в", "г", "д", "ж", "з", "к", "л", "м", "н", "п", "р", "с", "т", "ф", "х", "ц", "ч", "ш", "щ" };*/
            string Name = "";
            if (countray == "France")
            {
                string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x", "a", "e", "i", "o", "u", "ae", "y" };
                string[] vowels = { "û", "ô", "î", "ê", "â", "Æ", "Œ" };
                Name += consonants[r.Next(consonants.Length)].ToUpper();
                Name += vowels[r.Next(vowels.Length)];
                int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
                while (b < len)
                {
                    Name += consonants[r.Next(consonants.Length)];
                    b++;
                    Name += vowels[r.Next(vowels.Length)];
                    b++;
                }
            }
            else if (countray == "Usa")
            {
                string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
                string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
                Name += consonants[r.Next(consonants.Length)].ToUpper();
                Name += vowels[r.Next(vowels.Length)];
                int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
                while (b < len)
                {
                    Name += consonants[r.Next(consonants.Length)];
                    b++;
                    Name += vowels[r.Next(vowels.Length)];
                    b++;
                }
            }
            else if (countray == "Usa (Virtual)")
            {
                string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
                string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
                Name += consonants[r.Next(consonants.Length)].ToUpper();
                Name += vowels[r.Next(vowels.Length)];
                int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
                while (b < len)
                {
                    Name += consonants[r.Next(consonants.Length)];
                    b++;
                    Name += vowels[r.Next(vowels.Length)];
                    b++;
                }
            }
            else if (countray == "Israel")
            {
                string[] consonants = { "א", "ב", "ג", "ד", "ה", "ו", "ז", "ח", "ט", "י", "כ", "ל", "מ", "נ", "ס", "ע", "פ", "צ", "ק", "ר", "ש", "ת" };
                string[] vowels = { "מ", "ה", "אג", "לי", "יו", "בר", "אה" };
                Name += consonants[r.Next(consonants.Length)].ToUpper();
                Name += vowels[r.Next(vowels.Length)];
                int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
                while (b < len)
                {
                    Name += consonants[r.Next(consonants.Length)];
                    b++;
                    Name += vowels[r.Next(vowels.Length)];
                    b++;
                }
            }
            else if (countray == "England")
            {
                string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
                string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
                Name += consonants[r.Next(consonants.Length)].ToUpper();
                Name += vowels[r.Next(vowels.Length)];
                int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
                while (b < len)
                {
                    Name += consonants[r.Next(consonants.Length)];
                    b++;
                    Name += vowels[r.Next(vowels.Length)];
                    b++;
                }
            }
            else if (countray == "Brazil")
            {
                string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
                string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
                Name += consonants[r.Next(consonants.Length)].ToUpper();
                Name += vowels[r.Next(vowels.Length)];
                int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
                while (b < len)
                {
                    Name += consonants[r.Next(consonants.Length)];
                    b++;
                    Name += vowels[r.Next(vowels.Length)];
                    b++;
                }
            }
            return Name;
        }
        static IEnumerable<string> SafeGetFiles(string directoryPath, string searchPattern, SearchOption option)
        {
            if (option == SearchOption.AllDirectories)
            {
                foreach (var child in SafeGetDirectories(directoryPath))
                {
                    var results = SafeGetFiles(child, searchPattern, option);
                    foreach (var result in results)
                        yield return result;
                };
            };

            var files = SafeGetFiles(directoryPath, searchPattern);
            foreach (var file in files)
                yield return file;
        }

        static IEnumerable<string> SafeGetDirectories(string directoryPath)
        {
            try
            {
                return Directory.GetDirectories(directoryPath);
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (DirectoryNotFoundException)
            {
            };

            return Enumerable.Empty<string>();
        }

        static IEnumerable<string> SafeGetFiles(string directoryPath, string searchPattern)
        {
            try
            {
                return Directory.GetFiles(directoryPath, searchPattern);
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (DirectoryNotFoundException)
            {
            };

            return Enumerable.Empty<string>();
        }

        private void WorkerSearch_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void searchPath_Click(object sender, EventArgs e)
        {
            var files = DriveInfo.GetDrives().SelectMany(d => SafeGetFiles(d.RootDirectory.ToString(), "4124E0D6E26FDE60s", SearchOption.AllDirectories));
            foreach (var file in files)
                MessageBox.Show(file);
            /*if (WorkerSearch.IsBusy)
            {
                MessageBox.Show("turned off");
                WorkerSearch.CancelAsync();
            }
            else
            {
                MessageBox.Show("turned on");
                WorkerSearch.DoWork += WorkerSearch_DoWork;
            }*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void accountstextbox_TextChanged(object sender, EventArgs e)
        {
            /*if (work == "true")
            {
                StartSmsAsync();
            }*/
        }

        private void stopsms_Click(object sender, EventArgs e)
        {

        }

        private void numbtn_Click(object sender, EventArgs e)
        {
            string Folders = "";

            foreach (string dir in Directory.GetDirectories(File.ReadAllText(@"Path\accs.txt")))
            {
                DirectoryInfo info = new DirectoryInfo(dir);
                string lastBit = info.ToString().Substring(info.ToString().LastIndexOf('\\'));
                string Bit = lastBit.Replace(@"\", "");
                string info_result = Bit;
                Folders = Folders + "\n" + info_result;
            }
            char[] delimiters = new char[] { '\r', '\n' };
            string[] lines = Folders.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string result = string.Join(Environment.NewLine, lines);

            Thread thread = new Thread(() => Clipboard.SetText(result));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            label1.Text = "Copied Numbers";
        }

        private void pathbtn_Click(object sender, EventArgs e)
        {
            string Folders2 = "";

            foreach (string dir in Directory.GetDirectories(File.ReadAllText(@"Path\accs.txt")))
            {
                DirectoryInfo info = new DirectoryInfo(dir);
                Folders2 = Folders2 + "\n" + info + @"\Telegram.exe";
            }

            char[] delimiters2 = new char[] { '\r', '\n' };
            string[] lines2 = Folders2.Split(delimiters2, StringSplitOptions.RemoveEmptyEntries);
            string result2 = string.Join(Environment.NewLine, lines2);

            Thread thread2 = new Thread(() => Clipboard.SetText(result2));
            thread2.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread2.Start();
            thread2.Join();

            label1.Text = "Copied Path";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (work == "false")
            {
                work = "true";
                button5.ForeColor = Color.Green;
                StartBikorotAsync();
                panel3.Enabled = false;
                panel2.Enabled = false;
            }
            else if (work == "true")
            {
                panel3.Enabled = true;
                panel2.Enabled = true;
                button5.ForeColor = Color.Red;
                work = "false";
            }
        }

        public static string AccsPath = "";

        public async Task<bool> StartBikorotAsync()
        {
            label1.ForeColor = Color.Black;

            /*if (Int32.Parse(accountstextbox.Text) < 1)
            {
                await Task.Delay(1);
                panel4.Enabled = true;
                panel2.Enabled = true;
                button8.ForeColor = Color.Red;
                label1.ForeColor = Color.Red;
                label1.Text = "Error, write how many attempts - Bikorot";
                return false;
            }*/

            if (usernamebox.Text == "Select Username")
            {
                panel4.Enabled = true;
                panel2.Enabled = true;
                button8.ForeColor = Color.Red;
                label1.ForeColor = Color.Red;
                label1.Text = "Error, Select a username - Bikorot";
                return false;
            }

            page = Int32.Parse(System.IO.File.ReadAllText("page.txt"));
            await Task.Delay(1000);
            if (page == 1)
            {
                label1.Text = "1 - VPN";
                //vpn
                Process[] pname = Process.GetProcessesByName("VyprVPN");
                if (pname.Length > 0)
                {
                    // already running
                    System.IO.File.WriteAllText("page.txt", "2");
                }
                else
                {
                    // turn on
                    Process process = Process.Start(File.ReadAllText(@"Path\vyprvpn.txt"));
                    await Task.Delay(10000);
                    SetWindowPos(process.MainWindowHandle, this.Handle, -7, 490, 1500, 740, 0x0020);
                }
                System.IO.File.WriteAllText("page.txt", "4");
            }
            else if (page == 2)
            {
                label1.Text = "2 - VPN";
                await Task.Delay(1000);
                await Task.Delay(10);
                webBrowser1.Navigate("http://icanhazip.com/");
                await Task.Delay(1000);
                string ip11 = webBrowser1.Document.Body.InnerText;

                char[] delimiters11 = new char[] { '\r', '\n' };
                string[] lines11 = ip11.Split(delimiters11, StringSplitOptions.RemoveEmptyEntries);
                string result11 = string.Join(Environment.NewLine, lines11);

                File.WriteAllText("ip.txt", result11);
                //Process.Start("GetIp.exe");
                await Task.Delay(7000);
                if (File.ReadAllText("myip.txt") == File.ReadAllText("ip.txt"))
                {
                    await Task.Delay(2000);
                    //var y = File.ReadAllText(@"Points\VyperVpn-Y.txt");
                    //var x = File.ReadAllText(@"Points\VyperVpn-X.txt");
                    MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                    //LeftMouseClick(vpnx.Text, vpny.Text);


                }
                System.IO.File.WriteAllText("page.txt", "3");
            }
            else if (page == 3)
            {
                label1.Text = "3 - VPN";
                await Task.Delay(31000);

                await Task.Delay(10);
                webBrowser1.Navigate("http://icanhazip.com/");
                await Task.Delay(1000);
                string ip11 = webBrowser1.Document.Body.InnerText;

                char[] delimiters11 = new char[] { '\r', '\n' };
                string[] lines11 = ip11.Split(delimiters11, StringSplitOptions.RemoveEmptyEntries);
                string result11 = string.Join(Environment.NewLine, lines11);

                File.WriteAllText("ip.txt", result11);
                //Process.Start("GetIp.exe");
                await Task.Delay(17000);
                if (File.ReadAllText("myip.txt") != File.ReadAllText("ip.txt"))
                {
                    if (File.ReadAllText("PreviousIP.txt") != File.ReadAllText("ip.txt"))
                    {
                        File.WriteAllText("PreviousIP.txt", File.ReadAllText("ip.txt"));
                        //
                        await Task.Delay(500);
                        //
                        System.IO.File.WriteAllText("page.txt", "4");
                    }
                    else
                    {
                        await Task.Delay(3000);
                        MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                        //LeftMouseClick(vpnx.Text, vpny.Text);
                        await Task.Delay(25000);
                        foreach (Process proc in Process.GetProcessesByName("VyprVPN"))
                        {
                            proc.Kill();
                        }
                        await Task.Delay(500);
                        System.IO.File.WriteAllText("page.txt", "1");
                    }
                }
                else
                {
                    await Task.Delay(100);
                    MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                    //LeftMouseClick(vpnx.Text, vpny.Text);
                }
                //
            }
            else if (page == 4)
            {
                label1.Text = "4 - Bikorot";

                string bikorot = File.ReadAllText("accs.txt");
                string Folders = "";

                foreach (string dir in Directory.GetDirectories(File.ReadAllText(@"Path\accsbikorot.txt")))
                {
                    DirectoryInfo info = new DirectoryInfo(dir);
                    await Task.Delay(1);

                    if (Regex.IsMatch(bikorot, @"\b" + Regex.Escape(info.ToString().Trim()) + @"\b", RegexOptions.IgnoreCase))
                    {

                    }
                    else
                    {
                        Folders += info.ToString() + "\n" + bikorot;
                        await Task.Delay(1);
                        File.WriteAllText("accs.txt", Folders);
                    }
                }
                System.IO.File.WriteAllText("page.txt", "5");
            }
            else if (page == 5)
            {
                label1.Text = "5 - Bikorot";

                var AccsLine = System.IO.File.ReadLines("accs.txt").Count();
                TextReader tr = new StreamReader("accs.txt");
                string[] ListLines = new string[AccsLine];
                for (int i = 0; i < AccsLine; i++) { ListLines[i] = tr.ReadLine(); }
                tr.Close();

                await Task.Delay(100);
                for (int i = 0; i < AccsLine; i++) // Foreach Accs Folder
                {
                    string accs_path = string.Concat(ListLines[i].Where(c => !char.IsWhiteSpace(c)));

                    if (!File.Exists(accs_path + @"\usernames.txt")) { var a = File.Create(accs_path + @"\usernames.txt"); a.Close(); }
                    if (!File.Exists(accs_path + @"\lastreview.txt")) { var a = File.Create(accs_path + @"\lastreview.txt"); a.Close(); File.WriteAllText(accs_path + @"\lastreview.txt", "11/11/11 11:11:11"); }


                    DateTime lastModified = DateTime.Parse(File.ReadAllText(accs_path + @"\lastreview.txt"));
                    if (!Regex.IsMatch(File.ReadAllText(accs_path + @"\usernames.txt"), @"\b" + Regex.Escape(usernamebox.Text.Trim()) + @"\b", RegexOptions.IgnoreCase))
                    {
                        if (lastModified.ToString() == "")
                        {
                            AccsPath = accs_path;
                            System.IO.File.WriteAllText("page.txt", "6");
                            break; //return true;
                        }
                        if ((DateTime.Now - lastModified).TotalDays >= 5)
                        {

                            AccsPath = accs_path;
                            System.IO.File.WriteAllText("page.txt", "6");
                            break; //return true;

                        }
                    }
                }
            }
            else if (page == 6)
            {
                label1.Text = "6 - Bikorot";

                //MessageBox.Show(AccsPath + @"\Telegram.exe");
                Process process = Process.Start(AccsPath + @"\Telegram.exe");
                if (process.WaitForInputIdle(3500))
                {
                    var runningProcessByName = Process.GetProcessesByName("Telegram");
                    if (runningProcessByName.Length == 1)
                    {
                        await Task.Delay(3500);
                        SetWindowPos(process.MainWindowHandle, this.Handle, -7, 1, 800, 602, 0x0020);

                        await Task.Delay(2500);

                        //115 50 search
                        MoveTo(115, 50);
                        //LeftMouseClick("115", "50");
                        await Task.Delay(500);
                        SendKeys.SendWait("@Telegrass_ReviewsBot");
                        await Task.Delay(4500);

                        //115 135 telegrs
                        MoveTo(115, 135);
                        //LeftMouseClick("115", "135");
                        await Task.Delay(1500);

                        //530 575 start bot
                        MoveTo(530, 575);
                        //LeftMouseClick("530", "575");
                        await Task.Delay(1500);
                        MoveTo(115, 135);
                        //LeftMouseClick("115", "135");
                        await Task.Delay(1500);
                        SendKeys.SendWait("/start");
                        await Task.Delay(1500);
                        SendKeys.SendWait("{Enter}");
                        await Task.Delay(1500);

                        //515 445 write a review button
                        MoveTo(515, 445);
                        //LeftMouseClick("515", "445");
                        await Task.Delay(1500);

                        // write username
                        SendKeys.SendWait(usernamebox.Text);
                        await Task.Delay(500);
                        SendKeys.SendWait("{Enter}");
                        await Task.Delay(4500);

                        //send keys "מרכז"
                        SendKeys.SendWait("מרכז");
                        await Task.Delay(500);
                        SendKeys.SendWait("{Enter}");
                        await Task.Delay(4500);

                        //Focus
                        var processes = Process.GetProcessesByName("Telegram");
                        if (processes.Any())
                            Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);

                        //send random place from merkaz.txt
                        var AccsLine = System.IO.File.ReadLines(@"reviews\merkaz.txt").Count();
                        TextReader tr = new StreamReader(@"reviews\merkaz.txt");
                        string[] ListLines = new string[AccsLine];
                        for (int i = 0; i < AccsLine; i++) { ListLines[i] = tr.ReadLine(); }
                        tr.Close();

                        await Task.Delay(500);
                        Random r = new Random();
                        int RandomNum = r.Next(0, AccsLine);
                        char[] delimiters = new char[] { '\r', '\n' };
                        string[] lines = ListLines[RandomNum].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        string where = string.Join(Environment.NewLine, lines);

                        SendKeys.SendWait(where);
                        await Task.Delay(500);
                        SendKeys.SendWait("{Enter}");
                        await Task.Delay(4500);

                        //send "הסוחר זמין כל שעות היום"
                        SendKeys.SendWait("הסוחר זמין כל שעות היום");
                        await Task.Delay(500);
                        SendKeys.SendWait("{Enter}");
                        await Task.Delay(4500);

                        //Focus
                        if (processes.Any())
                            Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);

                        //send 5
                        SendKeys.SendWait("5");
                        await Task.Delay(500);
                        SendKeys.SendWait("{Enter}");
                        await Task.Delay(4500);

                        //send 5
                        SendKeys.SendWait("5");
                        await Task.Delay(500);
                        SendKeys.SendWait("{Enter}");
                        await Task.Delay(4500);

                        //send 5
                        SendKeys.SendWait("5");
                        await Task.Delay(500);
                        SendKeys.SendWait("{Enter}");
                        await Task.Delay(1500);

                        //Focus
                        if (processes.Any())
                            Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);

                        //send the review text
                        int counttxt = Int32.Parse(File.ReadAllText(@"reviews\attempt.txt"));
                        int countmax = 0;


                        string[] allFiles = Directory.GetFiles(@"reviews", "*.txt");

                        foreach (string file in allFiles)
                        {
                            if (file.Contains(@"reviews\rev"))
                            {
                                countmax++;
                            }
                        }

                        string review = "";
                        if (counttxt == countmax)
                        {
                            counttxt = 1;
                            File.WriteAllText(@"reviews\attempt.txt", "1");
                            await Task.Delay(100);
                            File.WriteAllText(@"reviews\attempt.txt", counttxt.ToString());
                            review = File.ReadAllText($@"reviews\rev{counttxt}.txt");
                        }
                        else
                        {
                            counttxt++;
                            File.WriteAllText(@"reviews\attempt.txt", counttxt.ToString());
                            review = File.ReadAllText($@"reviews\rev{counttxt}.txt");
                        }
                        //Focus
                        if (processes.Any())
                            Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);
                        SendKeys.SendWait(review);
                        await Task.Delay(3000);
                        SendKeys.SendWait("{Enter}");
                        await Task.Delay(5500);

                        //confirm review button
                        MoveTo(510, 445);
                        //LeftMouseClick("510", "445");
                        await Task.Delay(4500);

                        // chat top
                        MoveTo(430, 50);
                        //LeftMouseClick("430", "50");
                        await Task.Delay(1500);

                        // delete chat
                        MoveTo(350, 533);
                        //LeftMouseClick("350", "533");
                        await Task.Delay(1500);

                        // yes i am sure delete chat
                        SendKeys.SendWait("{Enter}");
                        await Task.Delay(1500);

                        File.WriteAllText(AccsPath + @"\usernames.txt", usernamebox.Text + "\n" + File.ReadAllText(AccsPath + @"\usernames.txt"));
                        File.WriteAllText(AccsPath + @"\lastreview.txt", DateTime.Now.ToString());

                        await Task.Delay(1500);

                        Process[] localByName = Process.GetProcessesByName("Telegram");
                        foreach (Process p in localByName)
                        {
                            p.Kill();
                        }

                        System.IO.File.WriteAllText("page.txt", "1");
                        label1.ForeColor = Color.Green;
                        label1.Text = "Done - Bikorot";
                        button8.ForeColor = Color.Red;
                        panel3.Enabled = true;
                        panel2.Enabled = true;
                        return false;
                    }
                }
            }
            else if (page == 7)
            {
                label1.Text = "7 - Bikorot";

                //Focus
                var processes = Process.GetProcessesByName("Telegram");
                if (processes.Any())
                    Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);


            }
            /*else if (page == 8)
            {
                label1.Text = "8 - Bikorot";

                //counts
                int count = Int32.Parse(attemptsbikorot.Text);
                count--;
                attemptsbikorot.Text = count.ToString();

                await Task.Delay(1000);
                if (checkBox.Checked == true)
                {
                    if (work == "false")
                    {
                        panel3.Enabled = true;
                        panel2.Enabled = true;
                        button8.ForeColor = Color.Red;
                        label1.Text = "Loop Stopped - SMS";
                        return false;
                    }
                    else if (Int32.Parse(attemptsbikorot.Text) < 1)
                    {
                        //reset
                        LeftMouseClick(vpnx.Text, vpny.Text);
                        await Task.Delay(25000);

                        System.IO.File.WriteAllText("page.txt", "2");

                        accountstextbox.Text = File.ReadAllText("attempts.txt");

                        label1.ForeColor = Color.Green;
                        label1.Text = "Loop - SMS";
                        await Task.Delay(2000);
                    }
                    else
                    {
                        System.IO.File.WriteAllText("page.txt", "4");
                    }
                }
                else if (Int32.Parse(accountstextbox.Text) < 1)
                {
                    LeftMouseClick(vpnx.Text, vpny.Text);
                    await Task.Delay(25000);
                    //status
                    label1.ForeColor = Color.Green;
                    label1.Text = "Done - SMS";
                    button8.ForeColor = Color.Red;
                    panel3.Enabled = true;
                    panel2.Enabled = true;
                    work = "false";
                    System.IO.File.WriteAllText("page.txt", "1");
                    return false;
                }
                else if (work == "false")
                {
                    panel3.Enabled = true;
                    panel2.Enabled = true;
                    button8.ForeColor = Color.Red;
                    label1.Text = "Stopped - SMS";
                    return false;oAd
                }
                else
                {
                    System.IO.File.WriteAllText("page.txt", "4");
                }
            }*/
            await Task.Delay(100);
            return await StartBikorotAsync();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        public static int numb = 0;

        private void attemptsBox_TextChanged(object sender, EventArgs e)
        {
            if (attemptsBox.Text == "" || playBack.Text == "")
            { }
            else
            {
                try
                {
                    Properties.Settings.Default.Attempts = Int32.Parse(attemptsBox.Text);
                    Math();
                    Properties.Settings.Default.Save();
                }
                catch
                {
                    averageMath.ForeColor = Color.FromArgb(216, 60, 65);
                    averageMath.Text = "Too fast for me :)";
                }
            }
        }

        public async void Math()
        {
            if (attemptsBox.Text == "" || playBack.Text == "")
            { }
            else
            {
                try
                {
                    if (ModeBox.SelectedItem == "Adding")
                    {
                        int a = Int32.Parse(attemptsBox.Text) * Int32.Parse(eachUserbox.Text);
                        int b = a * Int32.Parse(playBack.Text);
                        averageMath.ForeColor = Color.FromArgb(108, 166, 79);
                        averageMath.Text = "Average of: " + b.ToString();
                    }
                    else if (ModeBox.SelectedItem == "Authorizing")
                    {
                        int a = Int32.Parse(playBack.Text) * Int32.Parse(attemptsBox.Text);
                        averageMath.ForeColor = Color.FromArgb(108, 166, 79);
                        averageMath.Text = "Average of: " + a.ToString();
                    }
                }
                catch
                {
                    averageMath.ForeColor = Color.FromArgb(216, 60, 65);
                    averageMath.Text = "Too fast for me :)";
                }
            }
        }

        private void playBack_TextChanged(object sender, EventArgs e)
        {
            if (attemptsBox.Text == "" || playBack.Text == "")
            { }
            else
            {
                Math();
            }
        }

        private void eachUserbox_TextChanged(object sender, EventArgs e)
        {
            if (eachUserbox.Text == "")
            { }
            else
            {
                try
                {
                    Properties.Settings.Default.ForEach = Int32.Parse(eachUserbox.Text);
                    Math();
                    Properties.Settings.Default.Save();
                }
                catch
                {
                    averageMath.ForeColor = Color.FromArgb(216, 60, 65);
                    averageMath.Text = "Too fast for me :)";
                }
            }
        }

        private void ModeBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Math();
            if (ModeBox.SelectedItem == "Adding")
            {
                eachUserbox.Enabled = true;
                attemptsBox.Enabled = true;
                playBack.Enabled = true;
            }
            else if (ModeBox.SelectedItem == "Authorizing")
            {
                eachUserbox.Enabled = false;
                attemptsBox.Enabled = true;
                playBack.Enabled = true;
            }
            else if (ModeBox.SelectedItem == "Leave")
            {
                eachUserbox.Enabled = false;
                attemptsBox.Enabled = true;
                playBack.Enabled = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("hgfhgf");
        }

        private void newSms_Click(object sender, EventArgs e)
        {
            if (work == "false")
            {
                work = "true";
                button8.ForeColor = Color.Green;
                StartSmsNewAsync();
                panel4.Enabled = false;
                panel2.Enabled = false;
            }
            else if (work == "true")
            {
                panel4.Enabled = true;
                panel2.Enabled = true;
                button8.ForeColor = Color.Red;
                work = "false";
            }
        }

        public static string LastTime = "";
        public static int timedelay = 0;

        public static string Good = "Good: 0";
        public static string BadBan = "BadBan: 0";
        public static string BadUse = "BadUse: 0";
        public static string BadPass = "BadPass: 0";
        public static string BadCode = "BadCode: 0";
        public static string BadTelegram = "BadTelegram: 0";

        public async Task<bool> StartSmsNewAsync()
        {
            try
            {
                await Task.Delay(50);
                label1.ForeColor = Color.Black;

                if (vpnBox.Text == "Select Vpn")
                {

                    label1.ForeColor = Color.Red;
                    label1.Text = "Error, Select a VPN first - SMS";
                    await Task.Delay(10);
                    panel3.Enabled = true;
                    panel2.Enabled = true;
                    panel1.Enabled = true;
                    return false;

                }

                if (Int32.Parse(accountstextbox.Text) < 1)
                {
                    await Task.Delay(10);
                    panel4.Enabled = true;
                    panel2.Enabled = true;
                    button8.ForeColor = Color.Red;
                    label1.ForeColor = Color.Red;
                    label1.Text = "Error, write how many attempts - SMS";
                    return false;
                }

                if (comboBox.Text == "Select Country")
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "Error, Select a Country - SMS";
                    return false;
                }
                else if (comboBox.Text == "France")
                {
                    await Task.Delay(50);
                    countryid = 78;
                    countrycode = 33;
                    timedelay = 3;
                }
                else if (comboBox.Text == "Russian")
                {
                    await Task.Delay(50);
                    countryid = 0;
                    countrycode = 7;
                }
                else if (comboBox.Text == "Usa")
                {
                    await Task.Delay(50);

                    countryid = 187;
                    countrycode = 1;
                    timedelay = 3;
                }
                else if (comboBox.Text == "Usa (Virtual)")
                {
                    await Task.Delay(50);

                    countryid = 12;
                    countrycode = 1;
                    timedelay = 3;
                }
                else if (comboBox.Text == "Brazil")
                {
                    await Task.Delay(50);
                    countryid = 73;
                    countrycode = 55;
                    timedelay = 3;
                }
                else if (comboBox.Text == "Poland")
                {
                    await Task.Delay(50);
                    countryid = 15;
                    countrycode = 48;
                    timedelay = 3;
                }
                else if (comboBox.Text == "England")
                {
                    await Task.Delay(50);
                    countryid = 16;
                    countrycode = 44;
                    timedelay = 3;
                }
                else if (comboBox.Text == "Israel")
                {
                    await Task.Delay(50);
                    countryid = 13;
                    countrycode = 972;
                    timedelay = 3;
                }
                else
                {
                    await Task.Delay(50);
                    label1.ForeColor = Color.Red;
                    label1.Text = "Error, Select a Country - SMS";
                    return false;
                }
                await Task.Delay(50);
                page = Int32.Parse(System.IO.File.ReadAllText("page.txt"));
                await Task.Delay(1000);
                if (page == 1)
                {
                    label1.Text = "1 - VPN";
                    //vpn
                    await Task.Delay(10);
                    webBrowser1.Navigate("http://icanhazip.com/");
                    await Task.Delay(1000);
                    string ip11 = webBrowser1.Document.Body.InnerText;

                    char[] delimiters11 = new char[] { '\r', '\n' };
                    string[] lines11 = ip11.Split(delimiters11, StringSplitOptions.RemoveEmptyEntries);
                    string result11 = string.Join(Environment.NewLine, lines11);

                    File.WriteAllText("ip.txt", result11);
                    //Process.Start("GetIp.exe");
                    await Task.Delay(7500);

                    WebClient web = new WebClient();
                    string ip = File.ReadAllText("ip.txt");
                    string country = web.DownloadString($"http://ip-api.com/php/{ip}?fields=country");

                    char[] delimiters = new char[] { '\r', '\n' };
                    string[] lines = country.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                    string resultcountry = string.Join(Environment.NewLine, lines);
                    await Task.Delay(100);
                    if (resultcountry.Contains("Israel"))
                    {
                        string myip = File.ReadAllText("ip.txt");
                        char[] delimiters1 = new char[] { '\r', '\n' };
                        string[] lines1 = myip.Split(delimiters1, StringSplitOptions.RemoveEmptyEntries);
                        string resultIp = string.Join(Environment.NewLine, lines1);
                        File.WriteAllText("myip.txt", resultIp);
                    }
                    else
                    {
                        label1.ForeColor = Color.Red;
                        label1.Text = "Error-2 VPN is broken " + DateTime.Now;
                        return false;
                    }


                    if (vpnBox.Text == "‏‏VyprVPN")
                    {
                        Process[] pname = Process.GetProcessesByName("VyprVPN");
                        if (pname.Length > 0)
                        {
                            // already running
                            System.IO.File.WriteAllText("page.txt", "2");
                        }
                        else
                        {
                            // turn on
                            Process process = Process.Start(File.ReadAllText(@"Path\vyprvpn.txt"));
                            await Task.Delay(10000);
                            SetWindowPos(process.MainWindowHandle, this.Handle, -7, 490, 1500, 740, 0x0020);
                            System.IO.File.WriteAllText("page.txt", "2");
                        }
                    }
                    else if (vpnBox.Text == "CyberVpn")
                    {
                        Process[] pname = Process.GetProcessesByName("Dashboard");
                        if (pname.Length > 0)
                        {
                            // already running
                            System.IO.File.WriteAllText("page.txt", "2");
                        }
                        else
                        {
                            // turn on
                            Process process = Process.Start(File.ReadAllText(@"Path\cybervpn.txt"));
                            await Task.Delay(38000);
                            System.IO.File.WriteAllText("page.txt", "2");
                        }
                    }
                }
                else if (page == 2)
                {
                    label1.Text = "2 - VPN";
                    await Task.Delay(1000);
                    //Process.Start("GetIp.exe");
                    //await Task.Delay(7000);
                    if (File.ReadAllText("myip.txt") == File.ReadAllText("ip.txt"))
                    {
                        await Task.Delay(1000);
                        //var y = File.ReadAllText(@"Points\VyperVpn-Y.txt");
                        //var x = File.ReadAllText(@"Points\VyperVpn-X.txt");
                        MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                        //LeftMouseClick(vpnx.Text, vpny.Text);


                    }
                    System.IO.File.WriteAllText("page.txt", "3");
                }
                else if (page == 3)
                {
                    //
                    label1.Text = "3 - VPN";
                    await Task.Delay(27000);

                    await Task.Delay(10);
                    webBrowser1.Navigate("http://icanhazip.com/");
                    await Task.Delay(1000);
                    string ip11 = webBrowser1.Document.Body.InnerText;

                    char[] delimiters11 = new char[] { '\r', '\n' };
                    string[] lines11 = ip11.Split(delimiters11, StringSplitOptions.RemoveEmptyEntries);
                    string result11 = string.Join(Environment.NewLine, lines11);

                    File.WriteAllText("ip.txt", result11);
                    //Process.Start("GetIp.exe");
                    await Task.Delay(7300);
                    if (File.ReadAllText("myip.txt") != File.ReadAllText("ip.txt"))
                    {
                        if (File.ReadAllText("PreviousIP.txt") != File.ReadAllText("ip.txt"))
                        {
                            File.WriteAllText("PreviousIP.txt", File.ReadAllText("ip.txt"));
                            //

                            WebClient web = new WebClient();
                            string ip = File.ReadAllText("ip.txt");
                            string country = web.DownloadString($"http://ip-api.com/php/{ip}?fields=country");

                            char[] delimiters = new char[] { '\r', '\n' };
                            string[] lines = country.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                            string resultcountry = string.Join(Environment.NewLine, lines);
                            await Task.Delay(100);
                            if (resultcountry.Contains("France") || resultcountry.Contains("United States") || resultcountry.Contains("United Kingdom") || resultcountry.Contains("Brazil") || resultcountry.Contains("Poland") || resultcountry.Contains("Israel"))
                            {
                                //start zennolab

                                try
                                {
                                    using (WebClient client = new WebClient())
                                    {
                                        using (client.OpenRead("http://www.google.com/"))
                                        {
                                            // success
                                        }
                                    }
                                }
                                catch
                                {
                                    label1.ForeColor = Color.Red;
                                    label1.Text = "Error, No internet.";
                                    return false;
                                }

                                System.IO.File.WriteAllText("page.txt", "4");
                            }
                            else
                            {
                                label1.ForeColor = Color.Red;
                                label1.Text = "Error VPN is broken " + DateTime.Now;
                                return false;
                            }
                        }
                        else
                        {
                            if (vpnBox.Text == "‏‏VyprVPN")
                            {
                                await Task.Delay(3000);
                                MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                                //LeftMouseClick(vpnx.Text, vpny.Text);
                                await Task.Delay(20000);
                                foreach (Process proc in Process.GetProcessesByName("VyprVPN"))
                                {
                                    proc.Kill();
                                }
                                await Task.Delay(500);
                                System.IO.File.WriteAllText("page.txt", "1");
                            }
                            else if (vpnBox.Text == "CyberVpn")
                            {
                                await Task.Delay(2000);
                                MoveTo(Int32.Parse(CyberX), Int32.Parse(CyberY));
                                //LeftMouseClick(vpnx.Text, vpny.Text);
                                await Task.Delay(38000);
                                System.IO.File.WriteAllText("page.txt", "1");
                            }
                        }
                    }
                    else
                    {
                        await Task.Delay(100);
                        MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                        //LeftMouseClick(vpnx.Text, vpny.Text);
                    }
                    //
                }
                else if (page == 4)
                {
                    label1.Text = "4 - SMS";
                    await Task.Delay(700);
                    string Details = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=$8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=getNumber&service=$tg&forward=$0&operator=any&country={countryid}");
                    if (Details.Contains("NO_NUMBERS"))
                    {
                        if (work == "false")
                        {
                            button8.ForeColor = Color.Red;
                            label1.Text = "Stopped - SMS";
                            return false;
                        }
                        label1.Text = "4 - No numbers\n waiting";
                        await Task.Delay(700);
                    }
                    else if (Details.Contains("ACCESS_NUMBER:"))
                    {
                        /*Thread thread = new Thread(() => Clipboard.SetText(Details));
                        thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                        thread.Start();
                        thread.Join();*/

                        // ACCESS_NUMBER:394805926:33753664993



                        string clean = string.Join(":", Details.Split(':').Skip(1).ToArray());

                        id = clean.Substring(0, clean.IndexOf(':'));
                        phone = clean.Substring(clean.IndexOf(':'));
                        phone = phone.Replace(":", " ");

                        if (comboBox.Text == "France")
                        {
                            //france
                            string PhoneCode = phone;
                            PhoneCode = PhoneCode.Substring(3);
                            phone = PhoneCode;
                        }
                        else if (comboBox.Text == "Poland")
                        {
                            //poland
                            string PhoneCode = phone;
                            PhoneCode = PhoneCode.Substring(3);
                            phone = PhoneCode;
                        }
                        else if (comboBox.Text == "Brazil")
                        {
                            //brazil
                            string PhoneCode = phone;
                            PhoneCode = PhoneCode.Substring(3);
                            phone = PhoneCode;
                        }
                        else if (comboBox.Text == "Russian")
                        {
                            //russian
                            string PhoneCode = phone;
                            PhoneCode = PhoneCode.Substring(2);
                            phone = PhoneCode;
                        }
                        else if (comboBox.Text == "Usa")
                        {
                            //usa
                            string PhoneCode = phone;
                            PhoneCode = PhoneCode.Substring(2);
                            phone = PhoneCode;
                        }
                        else if (comboBox.Text == "Usa (Virtual)")
                        {
                            //usa
                            string PhoneCode = phone;
                            PhoneCode = PhoneCode.Substring(2);
                            phone = PhoneCode;
                        }
                        else if (comboBox.Text == "England")
                        {
                            //england
                            string PhoneCode = phone;
                            PhoneCode = PhoneCode.Substring(3);
                            phone = PhoneCode;
                        }
                        else if (comboBox.Text == "Israel")
                        {
                            //england
                            string PhoneCode = phone;
                            PhoneCode = PhoneCode.Substring(4);
                            phone = PhoneCode;
                        }

                        //MessageBox.Show("phone: " + phone + " " + "id: " + id);

                        System.IO.File.WriteAllText("page.txt", "5");
                    }
                    else if (Details.Contains("NO_BALANCE"))
                    {
                        label1.Text = "Error, There are no\nbalance in the account";
                        return false;
                    }
                    else
                    {
                        label1.Text = "Error";
                        return false;
                    }
                }
                else if (page == 5)
                {
                    label1.Text = "5 - SMS";

                    //MessageBox.Show("phone: " + phone + " " + "id: " + id);

                    if (Directory.Exists(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}"))
                    {
                        //Cancel code
                        string Cancel = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=setStatus&status=8&id={id}");
                        label1.Text = $"5 - Cancelled, The phone\nalready exits - {Cancel}";
                        await Task.Delay(1000);
                        System.IO.File.WriteAllText("page.txt", "4");
                    }
                    else
                    {
                        Directory.CreateDirectory(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}");
                        DirectoryCopy("telegram", File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}");
                        System.IO.File.WriteAllText("page.txt", "6");
                    }
                }
                else if (page == 6)
                {
                    label1.Text = "6 - SMS";

                    await Task.Delay(1000);
                    //Process process = Process.Start(File.ReadAllText(@"Path\bluestacks.txt"));
                    //if (process.WaitForInputIdle(10000))
                    //{
                    var runningProcessByName = Process.GetProcessesByName("HD-Player");
                    if (runningProcessByName.Length == 1)
                    {
                        //await Task.Delay(5000);
                        //SetWindowPos(process.MainWindowHandle, this.Handle, 1370, 1, 565, 955, 0x0020);

                        //1598 11

                        await Task.Delay(500);
                        MoveTo(1638, 11); // close telegram window
                        await Task.Delay(1000);
                        MoveTo(1560, 11); // close telegram window
                        await Task.Delay(2000);
                        //MessageBox.Show("hu");

                        /*Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.Start();

                        cmd.StandardInput.WriteLine(File.ReadAllText("run.txt"));
                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        cmd.WaitForExit();
                        Console.WriteLine(cmd.StandardOutput.ReadToEnd());

                        await Task.Delay(5000);
                        MoveTo(1630, 918);
                        await Task.Delay(1000);
                        SendKeys.SendWait("^+{2}");

                        await Task.Delay(3000);*/

                        Process cmd = new Process();
                        cmd.StartInfo.FileName = "cmd.exe";
                        cmd.StartInfo.RedirectStandardInput = true;
                        cmd.StartInfo.RedirectStandardOutput = true;
                        cmd.StartInfo.CreateNoWindow = true;
                        cmd.StartInfo.UseShellExecute = false;
                        cmd.Start();

                        cmd.StandardInput.WriteLine(File.ReadAllText("run.txt"));
                        cmd.StandardInput.Flush();
                        cmd.StandardInput.Close();
                        cmd.WaitForExit();
                        Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                        await Task.Delay(50);
                        cmd.Close();

                        await Task.Delay(10000);

                        MoveTo(1394, 87);
                        MoveTo(1394, 87);

                        await Task.Delay(2000);

                        //Focus
                        /*var processes = Process.GetProcessesByName("Bluestacks");
                        if (processes.Any())
                            Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);*/

                        // Start messaging button
                        MoveTo(1630, 918);

                        //Country code button
                        await Task.Delay(2000);
                        MoveTo(1415, 212);

                        await Task.Delay(700);
                        SendKeys.SendWait("^a");

                        await Task.Delay(700);
                        SendKeys.SendWait("{Delete}");
                        await Task.Delay(700);
                        SendKeys.SendWait(countrycode.ToString());


                        //Phone Number
                        await Task.Delay(2000);
                        MoveTo(1521, 215);

                        await Task.Delay(700);
                        SendKeys.SendWait("^a");
                        await Task.Delay(700);
                        SendKeys.SendWait("{Delete}");
                        await Task.Delay(700);
                        SendKeys.SendWait(phone);

                        //Sign button2
                        await Task.Delay(2000);
                        MoveTo(1846, 914);

                        await Task.Delay(18500);


                        if (GetPic("2") == "reset")
                        {
                            label1.ForeColor = Color.Red;
                            string Cancel = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=setStatus&status=8&id={id}");
                            label1.Text = $"6 - Telegram Problem (reset needed) - {Cancel}";

                            string text = BadTelegram;
                            string clean = new String(text.Where(Char.IsDigit).ToArray());
                            numb = Int32.Parse(clean);
                            numb++;
                            BadTelegram = $"BadTelegram: {numb.ToString()}";

                            //
                            await Task.Delay(500); MoveTo(1638, 11); await Task.Delay(1000); MoveTo(1560, 11); await Task.Delay(1000); // Close telegram

                            MoveTo(1538, 80); // My games

                            await Task.Delay(4700);

                            MoveTo(1783, 282); // System Apps

                            await Task.Delay(4700);

                            MoveTo(1576, 413); // Android settings

                            await Task.Delay(4700);

                            MoveTo(1695, 191); // Apps

                            await Task.Delay(4700);

                            for (int i1 = 0; i1 < 35; i1++) // Foreach Group Txt
                            {
                                await Task.Delay(1);
                                SendKeys.SendWait("{DOWN}");
                            }

                            await Task.Delay(4700);

                            SendKeys.SendWait("{ENTER}");
                            await Task.Delay(500);
                            MoveTo(1456, 622); // Telegram X

                            await Task.Delay(4700);

                            MoveTo(1415, 483); // Storage

                            await Task.Delay(4700);

                            MoveTo(1485, 495); // Clear Data

                            await Task.Delay(4700);

                            MoveTo(1764, 527); // Ok Clear data

                            await Task.Delay(2000); MoveTo(1638, 11); await Task.Delay(1000); MoveTo(1560, 11); await Task.Delay(6000); // Close

                            Process cmd2 = new Process();
                            cmd2.StartInfo.FileName = "cmd.exe";
                            cmd2.StartInfo.RedirectStandardInput = true;
                            cmd2.StartInfo.RedirectStandardOutput = true;
                            cmd2.StartInfo.CreateNoWindow = true;
                            cmd2.StartInfo.UseShellExecute = false;
                            cmd2.Start();

                            cmd2.StandardInput.WriteLine(File.ReadAllText("run.txt"));
                            cmd2.StandardInput.Flush();
                            cmd2.StandardInput.Close();
                            cmd2.WaitForExit();
                            Console.WriteLine(cmd2.StandardOutput.ReadToEnd());
                            await Task.Delay(50);
                            cmd2.Close();

                            await Task.Delay(500); MoveTo(1638, 11); await Task.Delay(1000); MoveTo(1560, 11); await Task.Delay(1000); // Close


                            //

                            Clipboard.Clear();
                            await Task.Delay(1000);
                            Directory.Delete(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}", true);
                            await Task.Delay(1000);
                            System.IO.File.WriteAllText("page.txt", "4");
                            //return await StartSmsNewAsync();
                        }
                        else
                        {

                            // Copying Country code
                            MoveTo(1415, 212);

                            Clipboard.Clear();

                            await Task.Delay(700);
                            SendKeys.SendWait("^a");
                            await Task.Delay(700);
                            SendKeys.SendWait("^c");

                            await Task.Delay(1000);
                            if (Clipboard.GetText() == countrycode.ToString()) // Checks if phone number number banned
                            {
                                label1.ForeColor = Color.Red;
                                string Cancel = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=setStatus&status=8&id={id}");
                                label1.Text = $"6 - Phone number Banned - {Cancel}";

                                string text = BadBan;
                                string clean = new String(text.Where(Char.IsDigit).ToArray());
                                numb = Int32.Parse(clean);
                                numb++;
                                BadBan = $"BadBan: {numb.ToString()}";

                                MoveTo(1560, 11);

                                Clipboard.Clear();
                                await Task.Delay(1000);
                                Directory.Delete(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}", true);
                                await Task.Delay(1000);
                                System.IO.File.WriteAllText("page.txt", "4");
                            }
                            else
                            {
                                if (GetPic("1") == "good")
                                {
                                    LastTime = DateTime.Now.ToString();

                                    System.IO.File.WriteAllText("page.txt", "7");
                                }
                                else if (GetPic("1") == "bad")
                                {
                                    label1.ForeColor = Color.Red;
                                    string Cancel = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=setStatus&status=8&id={id}");
                                    label1.Text = $"6 - Phone number In use - {Cancel}";

                                    string text = BadUse;
                                    string clean = new String(text.Where(Char.IsDigit).ToArray());

                                    numb = Int32.Parse(clean);
                                    numb++;
                                    BadUse = $"BadUse: {numb.ToString()}";

                                    Clipboard.Clear();
                                    await Task.Delay(1000);
                                    Directory.Delete(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}", true);
                                    await Task.Delay(1000);
                                    System.IO.File.WriteAllText("page.txt", "4");
                                }
                                else
                                {
                                    MessageBox.Show("stop");
                                }
                            }
                        }
                    }
                }
                else if (page == 7)
                {
                    label1.Text = "7 - SMS";


                    await Task.Delay(1500);
                    string StatusCode = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=getStatus&id={id}");
                    await Task.Delay(500);
                    if (StatusCode.Contains("STATUS_WAIT_CODE"))
                    {
                        await Task.Delay(1000);
                        label1.Text = $"7 - Waiting for sms\n{DateTime.Now}";
                        await Task.Delay(1000);

                        DateTime lastModified = System.IO.File.GetLastWriteTime("page.txt");
                        if ((DateTime.Now - lastModified).TotalMinutes >= timedelay)
                        {
                            string Cancel = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=setStatus&status=8&id={id}");
                            label1.Text = $"7 - Cancelled - {Cancel}";

                            string text = BadCode;
                            string clean = new String(text.Where(Char.IsDigit).ToArray());

                            numb = Int32.Parse(clean);
                            numb++;
                            BadCode = $"BadCode: {numb.ToString()}";

                            // Back
                            await Task.Delay(1000);
                            MoveTo(1638, 11);
                            Directory.Delete(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}", true);
                            await Task.Delay(1000);
                            System.IO.File.WriteAllText("page.txt", "4");
                        }
                        await Task.Delay(700);
                    }
                    else if (StatusCode.Contains("STATUS_OK:"))
                    {
                        string clean = string.Join(":", StatusCode.Split(':').Skip(0).ToArray());

                        code = clean.Substring(clean.IndexOf(':'));
                        code = code.Replace(":", " ");
                        countray = comboBox.Text;
                        //Phone Code
                        await Task.Delay(800);
                        MoveTo(1448, 304);

                        await Task.Delay(600);
                        SendKeys.SendWait(code);
                        await Task.Delay(5000);

                        if (comboBox.Text == "France")
                        {

                            // Contacts premission
                            await Task.Delay(2000);
                            MoveTo(1743, 550);
                            await Task.Delay(4200);
                        }
                        else if (comboBox.Text == "Usa")
                        {

                            // Contacts premission
                            await Task.Delay(2000);
                            MoveTo(1743, 550);
                            await Task.Delay(4200);
                        }
                        else if (comboBox.Text == "Usa (Virtual)")
                        {

                            // Contacts premission
                            await Task.Delay(2000);
                            MoveTo(1743, 550);
                            await Task.Delay(4200);
                        }
                        else if (comboBox.Text == "England")
                        {

                            // Contacts premission
                            await Task.Delay(2000);
                            MoveTo(1743, 550);
                            await Task.Delay(4200);
                        }
                        else if (comboBox.Text == "Israel")
                        {

                            // Contacts premission
                            await Task.Delay(2000);
                            MoveTo(1743, 550);
                            await Task.Delay(4200);
                        }
                        else if (comboBox.Text == "Brazil")
                        {

                            // Contacts premission
                            await Task.Delay(2000);
                            MoveTo(1743, 550);
                            await Task.Delay(4200);
                        }
                        else if (comboBox.Text == "Poland")
                        {

                            // Contacts premission
                            await Task.Delay(2000);
                            MoveTo(1743, 550);
                            await Task.Delay(4200);
                        }

                        await Task.Delay(7000);
                        if (GetPic("2") == "bad") // Checks if the account have cloud password
                        {
                            MoveTo(1442, 159); // First name (if have)
                            await Task.Delay(800);
                            SendKeys.SendWait("***1***"); // Send test text

                            Clipboard.Clear();

                            await Task.Delay(700);
                            SendKeys.SendWait("^a");
                            await Task.Delay(700);
                            SendKeys.SendWait("^c");

                            await Task.Delay(1000);
                            if (Clipboard.GetText() != "***1***")
                            {
                                label1.ForeColor = Color.Red;
                                string Sent = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=setStatus&status=6&id={id}");
                                label1.Text = $"6 - Phone number BadPass - {Sent}";

                                string text1 = BadPass;
                                string clean1 = new String(text1.Where(Char.IsDigit).ToArray());
                                numb = Int32.Parse(clean1);
                                numb++;
                                BadPass = $"BadPass: {numb.ToString()}";

                                MoveTo(1560, 11);

                                Clipboard.Clear();
                                await Task.Delay(1000);
                                Directory.Delete(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}", true);
                                await Task.Delay(1000);
                                System.IO.File.WriteAllText("page.txt", "4");
                            }
                            else
                            {
                                MessageBox.Show("Sonmthing is worng here!.");
                            }
                        }
                        else if (GetPic("2") != "madeUpAcc") // The account is registered already
                        {
                            await Task.Delay(500);
                            MoveTo(1638, 11); // close telegram window
                            await Task.Delay(1000);
                            MoveTo(1560, 11); // close telegram window

                            await Task.Delay(2000);

                            string text1 = BadUse;
                            string clean1 = new String(text1.Where(Char.IsDigit).ToArray());
                            numb = Int32.Parse(clean1);
                            numb++;
                            BadUse = $"BadUse: {numb.ToString()}";

                            // Open telegram x app
                            Process cmd1 = new Process();
                            cmd1.StartInfo.FileName = "cmd.exe";
                            cmd1.StartInfo.RedirectStandardInput = true;
                            cmd1.StartInfo.RedirectStandardOutput = true;
                            cmd1.StartInfo.CreateNoWindow = true;
                            cmd1.StartInfo.UseShellExecute = false;
                            cmd1.Start();

                            cmd1.StandardInput.WriteLine(File.ReadAllText("run.txt"));
                            cmd1.StandardInput.Flush();
                            cmd1.StandardInput.Close();
                            cmd1.WaitForExit();
                            Console.WriteLine(cmd1.StandardOutput.ReadToEnd());
                            await Task.Delay(50);
                            cmd1.Close();

                            await Task.Delay(5500);

                            System.IO.File.WriteAllText("page.txt", "8");
                        }
                        else if (GetPic("2") == "madeUpAcc") // If the account aint registered yet.
                        {

                            // Gives the status an update
                            string text1 = Good;
                            string clean1 = new String(text1.Where(Char.IsDigit).ToArray());

                            numb = Int32.Parse(clean1);
                            numb++;
                            Good = $"Good: {numb.ToString()}";

                            // Playing the sound (ding)
                            StringBuilder sb = new StringBuilder();
                            string sFileName = @"ding.mp3";
                            string sAliasName = "MP3";
                            int nRet = mciSendString("open \"" + sFileName + "\" alias " + sAliasName, sb, 0, IntPtr.Zero);
                            nRet = mciSendString("play " + sAliasName, sb, 0, IntPtr.Zero);



                            //First name
                            await Task.Delay(1500);
                            MoveTo(1455, 160);
                            await Task.Delay(700);
                            Random rnd = new Random();
                            int rndi = rnd.Next(4, 11);
                            SendKeys.SendWait(GenerateName(rndi));

                            //Last name
                            /*await Task.Delay(1500);
                            MoveTo(360, 310);
                            //LeftMouseClick("360", "310");
                            await Task.Delay(500);
                            Random rnd1 = new Random();
                            int rndii = rnd1.Next(4, 11);
                            SendKeys.SendWait(GenerateName(rndii));*/

                            // Finall Signup
                            await Task.Delay(1500);
                            MoveTo(1847, 914);
                            await Task.Delay(700);


                            if (comboBox.Text == "France")
                            {
                                // Accept terms
                                await Task.Delay(700);
                                MoveTo(1823, 630);

                                // Contacts premission
                                await Task.Delay(2000);
                                MoveTo(1743, 550);
                                await Task.Delay(4200);
                            }
                            else if (comboBox.Text == "Usa")
                            {
                                // Accept terms
                                await Task.Delay(2000);
                                MoveTo(1823, 604);

                                // Contacts premission
                                await Task.Delay(2000);
                                MoveTo(1743, 550);
                                await Task.Delay(4200);
                            }
                            else if (comboBox.Text == "Usa (Virtual)")
                            {
                                // Accept terms
                                await Task.Delay(2000);
                                MoveTo(1823, 604);

                                // Contacts premission
                                await Task.Delay(2000);
                                MoveTo(1743, 550);
                                await Task.Delay(4200);
                            }
                            else if (comboBox.Text == "England")
                            {
                                // Accept terms
                                await Task.Delay(1200);
                                MoveTo(1822, 627);

                                // Contacts premission
                                await Task.Delay(2000);
                                MoveTo(1743, 550);
                                await Task.Delay(4200);
                            }
                            else if (comboBox.Text == "Israel")
                            {
                                // Accept terms
                                await Task.Delay(1200);
                                MoveTo(1822, 627);

                                // Contacts premission
                                await Task.Delay(2000);
                                MoveTo(1743, 550);
                                await Task.Delay(4200);
                            }
                            else if (comboBox.Text == "Brazil")
                            {
                                // Accept terms
                                await Task.Delay(2000);
                                MoveTo(1823, 604);

                                // Contacts premission
                                await Task.Delay(2000);
                                MoveTo(1743, 550);
                                await Task.Delay(4200);
                            }
                            else if (comboBox.Text == "Poland")
                            {
                                // Accept terms
                                await Task.Delay(2000);
                                MoveTo(1823, 604);

                                // Contacts premission
                                await Task.Delay(2000);
                                MoveTo(1743, 550);
                                await Task.Delay(4200);
                            }


                            await Task.Delay(700);

                            SendKeys.SendWait("^+{2}");

                            await Task.Delay(3000);

                            Process cmd = new Process();
                            cmd.StartInfo.FileName = "cmd.exe";
                            cmd.StartInfo.RedirectStandardInput = true;
                            cmd.StartInfo.RedirectStandardOutput = true;
                            cmd.StartInfo.CreateNoWindow = true;
                            cmd.StartInfo.UseShellExecute = false;
                            cmd.Start();

                            cmd.StandardInput.WriteLine(File.ReadAllText("run.txt"));
                            cmd.StandardInput.Flush();
                            cmd.StandardInput.Close();
                            cmd.WaitForExit();
                            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

                            await Task.Delay(5000);

                            // Getting code

                            System.IO.File.WriteAllText("page.txt", "8");

                        }
                        else
                        {
                            MessageBox.Show("Error whatout!.");
                        }
                    }
                }
                else if (page == 8)
                {
                    await Task.Delay(1000);
                    Process process = Process.Start(File.ReadAllText($@"Path\accs.txt") + $@"\{comboBox.Text}\{phone}\Telegram.exe");
                    if (process.WaitForInputIdle(2500))
                    {
                        var runningProcessByName = Process.GetProcessesByName("Telegram");
                        if (runningProcessByName.Length == 1)
                        {
                            await Task.Delay(2500);
                            SetWindowPos(process.MainWindowHandle, this.Handle, -7, 1, 800, 602, 0x0020);

                            await Task.Delay(6000);

                            // Focus
                            var processes = Process.GetProcessesByName("Telegram");
                            if (processes.Any())
                                Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);

                            // Sign button
                            MoveTo(400, 430);



                            // Country code button
                            await Task.Delay(2000);
                            MoveTo(275, 310);

                            await Task.Delay(700);
                            SendKeys.SendWait("^a");
                            await Task.Delay(700);
                            SendKeys.SendWait("{Delete}");
                            await Task.Delay(700);
                            SendKeys.SendWait(countrycode.ToString());


                            // Phone button
                            await Task.Delay(2000);
                            MoveTo(335, 310);

                            await Task.Delay(700);
                            SendKeys.SendWait("^a");
                            await Task.Delay(700);
                            SendKeys.SendWait("{Delete}");
                            await Task.Delay(700);
                            SendKeys.SendWait(phone);

                            // Sign button2
                            await Task.Delay(2000);
                            MoveTo(400, 405);

                            // Getting the code


                            // Search
                            await Task.Delay(14500);
                            MoveTo(1860, 86);

                            // Search bar
                            await Task.Delay(1500);
                            MoveTo(1472, 87);

                            // Typing "Telegran"
                            await Task.Delay(700);
                            SendKeys.SendWait("Telegram");

                            // Telegram chat
                            await Task.Delay(3500);
                            MoveTo(1535, 179);

                            // Type messsage bar
                            await Task.Delay(2000);
                            MoveTo(1471, 930);
                            await Task.Delay(650);
                            SendKeys.SendWait("1");
                            await Task.Delay(650);
                            MoveTo(1861, 929); // Sending the message and going down chat

                            // Hold the message to copy
                            await Task.Delay(3000);
                            LeftMouseClickDown("1502", "808", 3000);

                            // Copy button
                            await Task.Delay(4000);
                            MoveTo(1816, 87);

                            //Focus
                            var processes2 = Process.GetProcessesByName("Telegram");
                            if (processes2.Any())
                                Microsoft.VisualBasic.Interaction.AppActivate(processes2[0].MainWindowTitle);

                            // Data of the code
                            await Task.Delay(650);
                            string result = Regex.Replace(Clipboard.GetText(), @"[^\d]", "");
                            string code = string.Concat(result.Where(c => !char.IsWhiteSpace(c)));

                            // Phone Code
                            await Task.Delay(1000);
                            MoveTo(385, 248);

                            // Typing the code in telegram desktop
                            await Task.Delay(1000);
                            SendKeys.SendWait(code);

                            //
                            //
                            //

                            // Go back to telegram chat
                            await Task.Delay(5200);
                            MoveTo(1394, 87);

                            // Settings
                            await Task.Delay(1200);
                            MoveTo(1394, 87);

                            // Profile Settings
                            await Task.Delay(1200);
                            MoveTo(1462, 307);

                            // 3 Dots for more options
                            await Task.Delay(1200);
                            MoveTo(1862, 89);

                            // Logout button
                            await Task.Delay(1200);
                            MoveTo(1862, 89);

                            // Logout red button
                            await Task.Delay(1200);
                            MoveTo(1467, 587);

                            // Logout red2 button2
                            await Task.Delay(1200);
                            MoveTo(1451, 884);

                            // Stop Telegram X
                            await Task.Delay(4550);
                            MoveTo(1638, 11);

                            await Task.Delay(1000);
                            System.IO.File.WriteAllText("page.txt", "9");
                        }
                    }
                }
                else if (page == 9)
                {
                    // Setting up avatar
                    label1.Text = "9 - SMS-Avatar";
                    if (avatars == "")
                    {
                        await Task.Delay(3000);

                        //Focus On telegram
                        var processes = Process.GetProcessesByName("Telegram");
                        if (processes.Any())
                            Microsoft.VisualBasic.Interaction.AppActivate(processes[0].MainWindowTitle);

                        // Open settings bar
                        MoveTo(25, 47);
                        //LeftMouseClick("25", "47");
                        await Task.Delay(1700);

                        // Settings button
                        MoveTo(100, 365);
                        //LeftMouseClick("100", "365");
                        await Task.Delay(1700);

                        // Edit Profile button
                        MoveTo(328, 253);
                        //LeftMouseClick("328", "253");
                        await Task.Delay(1700);

                        // Set profile photo button
                        MoveTo(398, 238);
                        //LeftMouseClick("398", "238");
                        await Task.Delay(1700);

                        // Get path of rnd image
                        string path = File.ReadAllText(@"Path\accs.txt") + @"\Avatars";
                        Random rand = new Random();

                        // pick a random file
                        string[] files = Directory.GetFiles(path);
                        string randomFile = files[rand.Next(files.Length)];

                        await Task.Delay(1700);

                        SendKeys.SendWait(randomFile); // Sending the image path

                        await Task.Delay(2000);

                        SendKeys.SendWait("{ENTER}"); // Confirming it

                        await Task.Delay(1700);

                        SendKeys.SendWait("{ENTER}"); // Confirming it

                        await Task.Delay(1700);

                        // Add username button
                        MoveTo(342, 435);
                        //LeftMouseClick("342", "435");
                        await Task.Delay(1700);
                        MoveTo(342, 400);
                        //LeftMouseClick("342", "440");
                        await Task.Delay(1700);

                        avatars = "username";
                    }
                    if (avatars == "username")
                    {
                        await Task.Delay(1500);

                        SendKeys.SendWait("^a");

                        await Task.Delay(1500);

                        SendKeys.SendWait("{Delete}");

                        await Task.Delay(1700);

                        string user = username();
                        SendKeys.SendWait(user);

                        await Task.Delay(1700);

                        SendKeys.SendWait("{ENTER}"); // Confirming it

                        await Task.Delay(1700);

                        SendKeys.SendWait("^a");
                        await Task.Delay(1700);
                        SendKeys.SendWait("^c");

                        await Task.Delay(1700);

                        if (Clipboard.GetText(TextDataFormat.Text) == user)
                        {
                            // create a new username
                            // return
                        }
                        else
                        {
                            Clipboard.Clear();
                            avatars = "username2";
                        }
                    }
                    if (avatars == "username2")
                    {
                        MoveTo(228, 75);// Back
                                        //LeftMouseClick("228", "75"); // Back

                        await Task.Delay(1700);

                        for (int i = 0; i < 10; i++) // Going up
                        {
                            await Task.Delay(0);
                            SendKeys.SendWait("{UP}");
                        }

                        await Task.Delay(1700);

                        MoveTo(342, 345);
                        //LeftMouseClick("342", "345"); // Privacy and Security
                        await Task.Delay(1700);


                        MoveTo(294, 323);
                        //LeftMouseClick("294", "323"); // Calls
                        await Task.Delay(1000);
                        MoveTo(250, 260);
                        //LeftMouseClick("250", "260"); // Calls nobody
                        await Task.Delay(1700);
                        MoveTo(545, 505);
                        //LeftMouseClick("545", "505"); // Calls Save
                        await Task.Delay(1700);


                        MoveTo(300, 400);
                        //LeftMouseClick("300", "400"); // Group & channels
                        await Task.Delay(1700);
                        MoveTo(250, 253);
                        //LeftMouseClick("250", "243"); // Group & channels My contacts
                        await Task.Delay(1700);
                        MoveTo(544, 490);
                        //LeftMouseClick("544", "490"); // Group & channels Save
                        await Task.Delay(3000);

                        MoveTo(228, 75);// Back

                        await Task.Delay(1700);

                        // Edit Profile button
                        MoveTo(328, 253);
                        //LeftMouseClick("328", "253");
                        await Task.Delay(1700);

                        //
                        webBrowser1.Navigate("https://sassycaptions.com/bio-generator/");
                        await Task.Delay(8000);
                        webBrowser1.Document.GetElementById("gen").InvokeMember("click");

                        MoveTo(335, 536);
                        MoveTo(335, 536);
                        //LeftMouseClick("335", "536"); // Bio
                        await Task.Delay(1700);
                        SendKeys.SendWait("^a");
                        await Task.Delay(1000);
                        SendKeys.SendWait("{Delete}");

                        await Task.Delay(4000);
                        string boi = webBrowser1.Document.GetElementById("quote").OuterText;
                        if (boi.Length > 70)
                        {

                        }
                        else
                        {
                            SendKeys.SendWait(boi); // Tyiping bio

                            await Task.Delay(10000);

                            //
                            //
                            avatars = "";
                            System.IO.File.WriteAllText("page.txt", "10");
                        }
                    }

                    await Task.Delay(5000);
                }
                else if (page == 10)
                {
                    label1.Text = "10 - SMS";
                    string Sent = new System.Net.WebClient().DownloadString($"https://sms-activate.ru/stubs/handler_api.php?api_key=8bcAd4b321106b1dc9bfd82c0ec22Ad9&action=setStatus&status=6&id={id}");
                    await Task.Delay(7800);

                    Process[] localByName = Process.GetProcessesByName("Telegram");
                    foreach (Process p in localByName)
                    {
                        p.Kill();
                    }

                    //counts
                    int count = Int32.Parse(accountstextbox.Text);
                    count--;
                    accountstextbox.Text = count.ToString();

                    await Task.Delay(1000);
                    if (checkBox.Checked == true)
                    {
                        if (work == "false")
                        {
                            panel3.Enabled = true;
                            panel2.Enabled = true;
                            button8.ForeColor = Color.Red;
                            label1.Text = "Loop Stopped - SMS";
                            return false;
                        }
                        else if (Int32.Parse(accountstextbox.Text) < 1)
                        {
                            //reset
                            MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                            //LeftMouseClick(vpnx.Text, vpny.Text);
                            await Task.Delay(25000);

                            System.IO.File.WriteAllText("page.txt", "1");

                            accountstextbox.Text = File.ReadAllText("attempts.txt");

                            label1.ForeColor = Color.Green;
                            label1.Text = "Loop - SMS";
                            await Task.Delay(2000);
                        }
                        else
                        {
                            System.IO.File.WriteAllText("page.txt", "4");
                        }
                    }
                    else if (Int32.Parse(accountstextbox.Text) < 1)
                    {
                        MoveTo(Int32.Parse(vpnx.Text), Int32.Parse(vpny.Text));
                        //LeftMouseClick(vpnx.Text, vpny.Text);
                        await Task.Delay(25000);
                        //status
                        label1.ForeColor = Color.Green;
                        label1.Text = "Done - SMS";
                        button8.ForeColor = Color.Red;
                        panel3.Enabled = true;
                        panel2.Enabled = true;
                        work = "false";
                        System.IO.File.WriteAllText("page.txt", "1");
                        return false;
                    }
                    else if (work == "false")
                    {
                        panel3.Enabled = true;
                        panel2.Enabled = true;
                        button8.ForeColor = Color.Red;
                        label1.Text = "Stopped - SMS";
                        return false;
                    }
                    else
                    {
                        System.IO.File.WriteAllText("page.txt", "4");
                    }
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("err.txt", ex.Message + "\n/////////////////////\n" + ex.Source + "\n/////////////////////\n" + ex.StackTrace + "\n/////////////////////\n" + ex.TargetSite);
            }
            await Task.Delay(950);
            return await StartSmsNewAsync();
        }

        private async void label20_Click(object sender, EventArgs e)
        {
            /*await Task.Delay(10);
            WebClient web = new WebClient();
            await Task.Delay(10);
            string ip = web.DownloadString("http://icanhazip.com/"); //http://icanhazip.com/
            await Task.Delay(10);
            char[] delimiters = new char[] { '\r', '\n' };
            await Task.Delay(10);
            string[] lines = ip.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            await Task.Delay(10);
            string result = string.Join(Environment.NewLine, lines);
            await Task.Delay(10);
            File.WriteAllText("ip.txt", result);
            MessageBox.Show("");*/
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TelegramKit_X = Int32.Parse(telegramkitx.Text);
            Properties.Settings.Default.TelegramKit_Y = Int32.Parse(telegramkity.Text);
            //
            Properties.Settings.Default.Interupt_X = Int32.Parse(interuptx.Text);
            Properties.Settings.Default.Interupt_Y = Int32.Parse(interupty.Text);
            //
            Properties.Settings.Default.Attempts_X = Int32.Parse(attempts_x.Text);
            Properties.Settings.Default.Attempts_Y = Int32.Parse(attempts_y.Text);
            //
            Properties.Settings.Default.VyperVpn_X = Int32.Parse(vpnx.Text);
            Properties.Settings.Default.VyperVpn_Y = Int32.Parse(vpny.Text);

            Properties.Settings.Default.Save();
        }

        private async void label16_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(GetPic());
            //GetPic("2");
            webBrowser1.Navigate("http://icanhazip.com/");
            await Task.Delay(1000);
            string ip11 = webBrowser1.Document.Body.InnerText;

            char[] delimiters11 = new char[] { '\r', '\n' };
            string[] lines11 = ip11.Split(delimiters11, StringSplitOptions.RemoveEmptyEntries);
            string result11 = string.Join(Environment.NewLine, lines11);

            File.WriteAllText("ip.txt", result11);
            //Process.Start("GetIp.exe");
            await Task.Delay(6500);
            if (File.ReadAllText("myip.txt") != File.ReadAllText("ip.txt"))
            { // Connected
                MessageBox.Show("good vpn");
            }
            else
            {
                MessageBox.Show("Bad Cpn");
            }
        }

        private void StatusAcc_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(Good + "\n" + BadBan + "\n" + BadUse + "\n" + BadPass + "\n" + BadCode + "\n" + BadTelegram, StatusAcc);
        }

        private async void label17_Click(object sender, EventArgs e)
        {
            

        }

        private void checkB_CheckedChanged(object sender, EventArgs e)
        {
            if (checkB.Checked == true)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void ModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
