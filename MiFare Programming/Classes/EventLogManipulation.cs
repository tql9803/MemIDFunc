using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainUI_namespace.Classes
{
    public class EventLogManipulation
    {
        public enum EventTranslationFirst : uint
        {
            CheckIn,
            CheckOut,
            Member_DropIn,
            Member_Promote,
            Member_New,
            Member_Renew,
            Member_Inactived,
            Member_Expelled,
            Member_FeePaid,
            Member_FeeDue,
            Card_New,
            Card_Replace,
            Card_Loss,
            Document_New,
            Document_Update,
            Order_MembershipPaid,
            Order_MembershipOverdue,

            Process_Cancel

            
        }

        public string LogFile;

    }
}
