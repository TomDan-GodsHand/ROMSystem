
namespace ROMSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            DBInit();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        static void DBInit()
        {
            if (File.Exists("ROM_SQL.db"))
            {
                return;
            }
            else
            {
                DB.CodeFirst();
                DB.CodeFirst();
            }
        }
    }
}