using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Microsoft.Office.Interop.Word;

namespace MainUI_namespace.Classes
{
    public class DocumentSign
    {
        public bool UnderAge { get; set; }

        private void ReplacementMethod(Word.Application WordApp, object FindText, object ReplaceText)
        {
            object matchcase = true;
            object matchWholeword = true;
            object matchWildcard = false;
            object matchSoundlike = false;
            object matchAllform = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object warp = 1;



            WordApp.Selection.Find.Execute(ref FindText, ref matchcase, ref matchWholeword, ref matchWildcard,
                ref matchSoundlike, ref matchAllform, ref forward, ref warp, ref format, ref ReplaceText,
                ref replace, ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }

        public void SignWaiverMethod(object TempFile, object SaveFile, object MemName, object MemAdd,
            object MemPhone, object MemEmail, object ParentName, object ParentPhone, object ParentEmail,
            object EMEName, object EMEPhone, object EMERel, object EffDate)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDocument = null;

            object ReadOnly = false;
            object isVisible = false;
            wordApp.Visible = false;

            object saveChange = Word.WdSaveOptions.wdDoNotSaveChanges;

            try
            {
                myDocument = wordApp.Documents.Open(ref TempFile, ref missing, ref ReadOnly, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref isVisible, ref missing, ref missing, ref missing, ref missing);

                myDocument.Activate();

                ReplacementMethod(wordApp, "[MEMBER NAME]", MemName);
                ReplacementMethod(wordApp, "[MEMBER ADDRESS]", MemAdd);
                ReplacementMethod(wordApp, "[MEMBER PHONE]", MemPhone);
                ReplacementMethod(wordApp, "[MEMBER EMAIL]", MemEmail);

                ReplacementMethod(wordApp, "[EME NAME]", EMEName);
                ReplacementMethod(wordApp, "[EME PHONE]", EMEPhone);
                ReplacementMethod(wordApp, "[EME RELATIONSHIP]", EMERel);

                if (UnderAge)
                {
                    ReplacementMethod(wordApp, "[PARENT NAME]", ParentName);
                    ReplacementMethod(wordApp, "[PARENT PHONE]", ParentPhone);
                    ReplacementMethod(wordApp, "[PARENT EMAIL]", ParentEmail);
                }
                else
                {
                    ReplacementMethod(wordApp, "[PARENT NAME]", null);
                    ReplacementMethod(wordApp, "[PARENT PHONE]", null);
                    ReplacementMethod(wordApp, "[PARENT EMAIL]", null);
                }

                ReplacementMethod(wordApp, "[DATE]", EffDate);

                myDocument.SaveAs2(ref SaveFile, ref missing, ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing);

                myDocument.Close(saveChange, missing, missing);
                wordApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                myDocument.Close(saveChange, missing, missing);
                wordApp.Quit();
            }

        }

        public void SignMembershipMethod(object TempFile, object SaveFile, object MemName, object MemAdd,
            object MemPhone, object MemEmail, object MemDOB, object MemID, object ParentName, object ParentPhone, object ParentEmail,
            object EMEName, object EMEPhone, object EMERel, object EffDate)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myDocument = null;

            object ReadOnly = false;
            object isVisible = false;
            wordApp.Visible = false;

            object saveChange = Word.WdSaveOptions.wdDoNotSaveChanges;
            try
            {
                myDocument = wordApp.Documents.Open(ref TempFile, ref missing, ref ReadOnly, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref isVisible, ref missing, ref missing, ref missing, ref missing);

                myDocument.Activate();

                ReplacementMethod(wordApp, "[MEMBER NAME]", MemName);
                ReplacementMethod(wordApp, "[MEMBER ADDRESS]", MemAdd);
                ReplacementMethod(wordApp, "[MEMBER PHONE]", MemPhone);
                ReplacementMethod(wordApp, "[MEMBER EMAIL]", MemEmail);

                ReplacementMethod(wordApp, "[MEMBER DOB]", MemDOB);
                ReplacementMethod(wordApp, "[MEMBER IDENTIFICATION]", MemID);

                ReplacementMethod(wordApp, "[EME NAME]", EMEName);
                ReplacementMethod(wordApp, "[EME PHONE]", EMEPhone);
                ReplacementMethod(wordApp, "[EME RELATIONSHIP]", EMERel);

                if (UnderAge)
                {
                    ReplacementMethod(wordApp, "[PARENT NAME]", ParentName);
                    ReplacementMethod(wordApp, "[PARENT PHONE]", ParentPhone);
                    ReplacementMethod(wordApp, "[PARENT ADDRESS]", MemAdd);
                    ReplacementMethod(wordApp, "[PARENT EMAIL]", ParentEmail);
                }
                else
                {
                    ReplacementMethod(wordApp, "[PARENT NAME]", null);
                    ReplacementMethod(wordApp, "[PARENT PHONE]", null);
                    ReplacementMethod(wordApp, "[PARENT ADDRESS]", null);
                    ReplacementMethod(wordApp, "[PARENT EMAIL]", null);
                }

                ReplacementMethod(wordApp, "[DATE]", EffDate);

                myDocument.SaveAs2(ref SaveFile, ref missing, ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                   ref missing, ref missing, ref missing, ref missing);

                myDocument.Close(saveChange, missing, missing);
                wordApp.Quit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                myDocument.Close(saveChange, missing, missing);
                wordApp.Quit();
            }
        }

        public void OpentoSignMethod(object FilePath)
        {
            Word.Application wordApp = new Word.Application();
            Word.Document myDocument = null;

            object missing = Missing.Value;
            object ReadOnly = false;
            object isVisible = true;
            wordApp.Visible = true;

            object saveChange = Word.WdSaveOptions.wdDoNotSaveChanges;

            try
            {
                myDocument = wordApp.Documents.Open(ref FilePath, ref missing, ref ReadOnly, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref isVisible, ref missing, ref missing, ref missing, ref missing);

                myDocument.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                myDocument.Close(saveChange, missing, missing);
                wordApp.Quit();
            }
        }
    }
}
