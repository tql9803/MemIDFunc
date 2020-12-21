using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MainUI_namespace.DataBase_Access;
using MainUI_namespace.Classes;

namespace MainUI_namespace.Forms
{
    public partial class CheckInOutForm : Form
    {

        CardThreading CardThread;

        MemberTableAccess MemberAccess;
        CardTableAccess CardAccess;
        DocumentTableAccess DocAccess;

        public CheckInOutForm()
        {
            InitializeComponent();
        }

        private void InitMenu()
        {
            CardThread = new CardThreading();
            CardAccess = new CardTableAccess();


            Task cardState = new Task(CardThread.CardChecking.Invoke);
            cardState.Start();

        }
    }
}
