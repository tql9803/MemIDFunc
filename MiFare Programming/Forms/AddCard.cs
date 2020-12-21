
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using MainUI_namespace.Classes;
using MainUI_namespace.Object;
using MainUI_namespace.DataBase_Access;


namespace MainUI_namespace.Forms
{
    public partial class AddCard : Form
    {
        private MemberTableAccess MemberAccess;
        private CardTableAccess CardAccess;
        private CardClass NewCard;
        private CardThreading CardProcess;

        public AddCard()
        {
            InitializeComponent();
            CardProcess = new CardThreading();
        }

        private int UpdateCardID()
        {

            CardAccess = new CardTableAccess();
            return CardAccess.FindLastCardID() + 1;
        }

        private void bScan_Click(object sender, EventArgs e)
        {
            this.Invoke(CardProcess.CardChecking);
            
        }

        private void AddCard_Load(object sender, EventArgs e)
        {
            bAddCard.Enabled = false;
            CardProcess.CardPresent += this.CardPresent;
        }

        private void CardPresent(object sender, EventArgs e)
        {
            NewCard = new CardClass();
            int NewestCardID = UpdateCardID();
            byte[] CardNumber = CardProcess.KeyNo;

            NewCard.CreatCard(NewestCardID, CardNumber);

            bAddCard.Enabled = true;
        }

        private void bAddCard_Click(object sender, EventArgs e)
        {
            CardTableAccess CardAccess = new CardTableAccess();
            List<CardClass> bufcard;
            bufcard = CardAccess.FindCard("CardNo", NewCard.CardNumber);

            if (bufcard.Count == 0)
            {
                CardAccess.AddCard(NewCard);
            }
            else
            {
                MessageBox.Show("Card Exist in the system");
            }
        }
    }
}
