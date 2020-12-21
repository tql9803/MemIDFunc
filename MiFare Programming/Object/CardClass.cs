using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainUI_namespace.Object
{
    public class CardClass
    {
        public int CardID { get; set; }
        public byte[] CardNumber { get; set; }
        public DateTime EffDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int CustomerID { get; set; }

        public void CreatCard(int Id, byte[] CardNo)
        {
            DateTime dummy = new DateTime(1800, 1, 1);

            this.CardID = Id;
            this.CardNumber = CardNo;

            this.EffDate = dummy;
            this.EndDate = dummy;

            this.IsActive = false;
            this.CustomerID = 0;

        }
        /// <summary>
        /// This will read a card from a set of data (from database or newly created)
        /// </summary>
        /// <param CardID="Id"></param>
        /// <param Card Number read by the card reader="CardNo"></param>
        /// <param Effective date ="rEffDate"></param>
        /// <param End Date="rEndDate"></param>
        /// <param Is the card Active="Active"></param>
        /// <param MemberID that the card associated with="MemberID"></param>
        public void ReadCard(int Id, byte[] CardNo, DateTime rEffDate, DateTime rEndDate, bool Active, int MemberID)
        {

            this.CardID = Id;
            this.CardNumber = CardNo;

            this.EffDate = rEffDate;
            this.EndDate = rEndDate;

            this.IsActive = Active;
            this.CustomerID = MemberID;

        }

        public void ReadCard(object[] Value)
        {

            this.CardID = (int)Value[0];
            this.CardNumber = (byte[])Value[1];

            this.EffDate = (DateTime)Value[2];
            this.EndDate = (DateTime)Value[3];

            this.IsActive = (bool)Value[4];
            this.CustomerID = (int)Value[5];

        }
    }
}
