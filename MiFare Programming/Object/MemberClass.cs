using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainUI_namespace.Object
{
    #region Object Member 
    public class MemberClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string IDType { get; set; }
        public string MemberID { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime EffDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Validity { get; set; }
        public bool IsMember { get; set; }
        public byte[] Picture { get; set; }

        public void ReadMember(int rID, string MName, DateTime MDOB, string MIDType, string MID, string MPhone,
            string MEmail, string MAddress, DateTime MEff, DateTime MEnd, bool IsValid,
            bool Type, byte[] MPic)
        {
            this.ID = rID;
            this.Name = MName;
            this.DOB = MDOB;
            this.IDType = MIDType;
            this.MemberID = MID;
            this.PhoneNum = MPhone;
            this.Email = MEmail;
            this.Address = MAddress;

            this.EffDate = MEff;
            this.EndDate = MEnd;
            this.Validity = IsValid;
            this.IsMember = Type;

            this.Picture = MPic;
        }

        public void ReadMember(object[] ValueArray)
        {
            this.ID = (int)ValueArray[0];
            this.Name = (string)ValueArray[1];

            this.DOB = (ValueArray[2] == DBNull.Value) ? (new DateTime()) : (DateTime)ValueArray[2];
            this.IDType = (ValueArray[3] == DBNull.Value) ? (null) : (string)ValueArray[3];
            this.MemberID = (ValueArray[4] == DBNull.Value) ? (null) : (string)ValueArray[4];

            this.PhoneNum = (ValueArray[5] == DBNull.Value) ? (null) : (string)ValueArray[5];
            this.Email = (ValueArray[6] == DBNull.Value) ? (null) : (string)ValueArray[6];
            this.Address = (ValueArray[7] == DBNull.Value) ? (null) : (string)ValueArray[7];

            this.EffDate = (ValueArray[8] == DBNull.Value) ? (new DateTime()) : (DateTime)ValueArray[8];
            this.EndDate = (ValueArray[9] == DBNull.Value) ? (new DateTime()) : (DateTime)ValueArray[9];
            this.Validity = (ValueArray[10] == DBNull.Value) ? (true) : (bool)ValueArray[10];
            this.IsMember = (ValueArray[11] == DBNull.Value) ? (false) : (bool)ValueArray[11];

            this.Picture = (ValueArray[12] == DBNull.Value) ? (null) : (byte[])ValueArray[12];
        }

        public void CreateNewMember(string MName, DateTime MDOB, string MIDType, string MID,
            string MPhone, string MEmail, string MAddress, DateTime MEff, DateTime MEnd, bool IsValid, 
            byte[] MPic = null)
        {
            this.Name = MName;
            this.DOB = MDOB;
            this.IDType = MIDType;
            this.MemberID = MID;
            this.PhoneNum = MPhone;
            this.Email = MEmail;
            this.Address = MAddress;

            this.EffDate = MEff;
            this.EndDate = MEnd;

            this.Validity = IsValid;
            this.IsMember = true;

            this.Picture = MPic;
        }

        public void CreateDropIn(string MName, string MPhone, string MEmail, string MAddress, DateTime MEff, byte[] MPic)
        {
            this.Name = MName;
            this.DOB = new DateTime(1800, 1, 1);
            this.IDType = "NA";
            this.MemberID = "NA";
            this.PhoneNum = MPhone;
            this.Email = MEmail;
            this.Address = MAddress;

            this.EffDate = MEff;
            this.EndDate = new DateTime(1800, 1, 1);


            this.Validity = false;
            this.IsMember = false;

            this.Picture = MPic;
        }

        //public MemberClass Promote(MemberClass WaiverSigner, DateTime MEff, DateTime MEnd, bool IsValid)
        //{
        //    MemberClass NewMember;

        //    NewMember = WaiverSigner;

        //    NewMember.IsMember = true;

        //    NewMember.EffDate = MEff;
        //    NewMember.EndDate = MEnd;

        //    NewMember.Validity = IsValid;

        //    return NewMember;
        //}
    }

    #endregion

    
}
