using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainUI_namespace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MainUI miFareCardProg = new MainUI();
            //Mifare_Ex mifare_Ex = new Mifare_Ex();
            //miFareCardProg.NewMemTriggered += mifare_Ex.ExNewMemTriggered;

            Application.Run(miFareCardProg);
        }
    }
}