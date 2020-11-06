using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemIDFunc_namespace.Classes
{
    public class MemberClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string IDType { get; set; }
        public string MemberID { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string MemDetail { get; set; }
        public string KeyNum { get; set; }
        public byte[] Picture { get; set; }
        public string Address { get; set; }
        public string MembershipDoc { get; set; }
        public string EventLog { get; set; }
        public DateTime EffDate { get; set; }

        public void CreateNewMember(string MName, DateTime MDOB, string MIDType, string MID,
            string MPhone, string MEmail, string MDetail, string MKey, byte[] MPic,
            string MAddress, string MDoc, string MLog, DateTime MEff)
        {
            this.Name = MName;
            this.DOB = MDOB;
            this.IDType = MIDType;
            this.MemberID = MID;
            this.PhoneNum = MPhone;
            this.Email = MEmail;
            this.MemDetail = MDetail;
            this.KeyNum = MKey;
            this.Picture = MPic;
            this.Address = MAddress;
            this.MembershipDoc = MDoc;
            this.EventLog = MLog;
            this.EffDate = MEff;
        }
    }
}
