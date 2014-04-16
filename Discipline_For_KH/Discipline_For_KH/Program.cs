using FISCA;
using FISCA.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discipline_For_KH
{
    public class Program
    {
        [MainMethod()]
        static public void Main()
        {
            RibbonBarButton rbItemImport = FISCA.Presentation.MotherForm.RibbonBarItems["學生", "資料統計"]["匯入"];
            rbItemImport["學務相關匯入"]["匯入獎勵記錄(支援獎勵為0)"].Enable = FISCA.Permission.UserAcl.Current["JHSchool.Student.Ribbon0157"].Executable;
            rbItemImport["學務相關匯入"]["匯入獎勵記錄(支援獎勵為0)"].Click += delegate
            {
                SmartSchool.API.PlugIn.Import.Importer importer = new ImportDiscipline_S();
                ImportStudentV2 wizard = new ImportStudentV2(importer.Text, importer.Image);
                importer.InitializeImport(wizard);
                wizard.ShowDialog();
            };
        }
    }
}
