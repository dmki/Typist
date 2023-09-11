namespace LexType;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        //Application.Run(new Form1());
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        frmMain mainForm = new frmMain();
        Application.Run(mainForm);  // Don't pass the form here. This will prevent it from showing.
    }    
}