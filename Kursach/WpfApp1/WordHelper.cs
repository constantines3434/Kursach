using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
namespace WpfApp1
{
    internal class WordHelper
    {
        private FileInfo fileinfo_;

        public WordHelper(string filename)
        {
            if (File.Exists(filename))
            {
                fileinfo_ = new FileInfo(filename);
            }
            else
            {
                throw new ArgumentException("File not found");
            }
        }
            

        /// <summary>
        /// ////////////
        /// </summary>
        /// <param name="items"></param>
        /// <exception cref="NotImplementedException"></exception>

          internal bool Process(Dictionary<string, string> items)
          {
                Word.Application app = null;
                try
                {
                    app = new Word.Application();
                    Object file = fileinfo_.FullName;

                    Object missing = Type.Missing;

                    app.Documents.Open(file);

                    foreach (var item in items)
                    {
                        Word.Find find = app.Selection.Find;
                        find.Text = item.Key;
                        find.Replacement.Text = item.Value;

                        Object wrap = Word.WdFindWrap.wdFindContinue;
                        Object replace = Word.WdReplace.wdReplaceAll;

                        find.Execute(FindText: Type.Missing,
                            MatchCase: false,
                            MatchWholeWord: false,
                            MatchWildcards: false,
                            MatchSoundsLike: missing,
                            MatchAllWordForms: false,
                            Forward: true,
                            Wrap: wrap,
                            Format: false,
                            ReplaceWith: missing, Replace: replace
                            );
                    }
                    Object newFileName = Path.Combine(fileinfo_.DirectoryName,
                        DateTime.Now.ToString("yyyyMMdd HHmmss") + fileinfo_.Name);
                    app.ActiveDocument.SaveAs2(newFileName);
                    app.ActiveDocument.Close();


                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
                finally
                {
                    if (app != null)
                    {
                        app.Quit();
                    }
                }
          }
       
    }
}
