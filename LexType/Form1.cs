using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Timer = System.Timers.Timer;

namespace LexType;

public partial class frmMain : Form
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);


    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private static LowLevelKeyboardProc _proc = HookCallback;
    private static IntPtr _hookID = IntPtr.Zero;
    private static Random _rand = new Random();
    private static int _speed = 180;
    private static int _maxSpeed = 240;
    private static bool _inHook = false;//When true, we don't listen to new keypresses
    private static string _code = string.Empty;
    private static Timer _timer;
    private static int _minutesLeft;
#if DEBUG
    private const string BaseURL = "https://localhost:32768/api/Message/";//that's your Docker
#else
    private const string BaseURL = "https://intellexa.eu/api/api/Message/";//Change this when deploying API elsewhere for your needs.
#endif


    public frmMain()
    {
        InitializeComponent();
        _hookID = SetHook(_proc);
    }
    protected override void OnClosed(EventArgs e)
    {
        UnhookWindowsHookEx(_hookID);
        base.OnClosed(e);
    }

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using System.Diagnostics.Process curProcess = System.Diagnostics.Process.GetCurrentProcess();
        using System.Diagnostics.ProcessModule curModule = curProcess.MainModule;
        return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
    }


    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (!_inHook && nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            if (vkCode == (int)Keys.T && Control.ModifierKeys == (Keys.Control | Keys.Alt))// 
            {
                _inHook = true;
                //SendText("Hello World!", 60);
                var text = GetNewText();
                if (!string.IsNullOrEmpty(text))
                {
                    SendText(text, _speed);
                }
                _inHook = false;
            }
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    private static string? GetNewText()
    {
        var client = new HttpClient();
        string url = $"{BaseURL}{_code}";
        try
        {
            string response = client.GetStringAsync(url).Result; //async not needed here
            return "." + response;
        }
        catch (Exception ex)
        {
            //do nothing, really, app supposed to be silent.
            //todo: log error to file
        }

        return "";
    }

    private static void SendText(string text, int speed)
    {
        Thread.Sleep(500);
        foreach (char c in text)
        {
            // Clamp the speed between 32 and (max speed) characters per minute.
            int clampedSpeed = Math.Clamp(speed, 32, _maxSpeed);

            // Calculate the base delay for the given speed in milliseconds
            double baseDelay = (60.0 / clampedSpeed) * 1000;

            // Adjust the speed by a random factor between -40% and +20%
            double factor = 1 + (_rand.NextDouble() * 0.6 - 0.4);
            int adjustedDelay = (int)(baseDelay * factor);

            // Send the character
            SendKeys.SendWait(c.ToString());

            // Wait for the adjusted delay before sending the next character
            System.Threading.Thread.Sleep(adjustedDelay);
        }
    }

    private void cmdPaste_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        if (!Clipboard.ContainsText()) return;
        txtCode.Text = Clipboard.GetText();
    }

    private void cmdStart_Click(object sender, EventArgs e)
    {
        if (cmdStart.Text == "STOP")
        {
            cmdStart.Text = "START";
            _timer.Stop();
            _inHook = true;
            return;
        }
        _code = txtCode.Text.Trim();
        if (string.IsNullOrEmpty(_code))
        {
            MessageBox.Show("Request the typist code from ilexa bot, then paste it here!", "Code required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        _inHook = false;
        _speed = (int)updMaxSpeed.Value;
        if (chAutoHide.Checked) this.Hide();
        if (chAutoExit.Checked)
        {
            _minutesLeft = (int)updAutoExit.Value;
            _timer.Start();
        }

        cmdStart.Text = "STOP";
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
        _inHook = true;//Don't listen to keys before we start
        _timer = new Timer();
        _timer.Interval = 60000;//Check every 60 seconds if we should quit
        _timer.Elapsed += _timer_Elapsed;
    }

    private void _timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        _minutesLeft--;
        if (_minutesLeft < 1)
        {
            _timer.Stop();
            Environment.Exit(0);
        }
    }
}
