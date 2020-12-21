using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainUI_namespace.Object
{
    public class DocumentClass
    {
        public int SystemID { get; set; }
        public string EventLog { get; set; }
        public string Waiver { get; set; }
        public string MembershipDoc { get; set; }
        public int? DocID { get; set; }


        public void CreateDocument(string Log, string Waive, string MemDoc, int? DocumentNo)
        {
            this.EventLog = Log;

            this.Waiver = Waive ??  "";
            this.MembershipDoc = MemDoc ?? "";
            
            this.DocID = DocumentNo ?? 0;
        }

        public void ReadDocument(int SysID, string Log, string Waive, string MemDoc, int? DocumentNo)
        {
            this.SystemID = SysID;
            this.EventLog = Log;

            this.Waiver = Waive;
            this.MembershipDoc = MemDoc;
            
            this.DocID = DocumentNo ?? 0;
        }

        public void ReadDocument(object[] ValueArray)
        {
            this.SystemID = (int)ValueArray[0];
            this.EventLog = (string)ValueArray[1];

            this.Waiver = (string)ValueArray[2];
            this.MembershipDoc = (string)ValueArray[3];

            this.DocID = (ValueArray[4] == DBNull.Value) ? 0 : (int)ValueArray[4];
        }
    }
}
