using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICE.Commander
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        }

        private void MenuItemAPIFieldUpdater_Click(object sender, EventArgs e)
        {
            using (var win = new FieldUpdaterWIN())
            {
                win.ShowDialog();
            }
        }

        private void MenuItemQueryBuilder_Click(object sender, EventArgs e)
        {
            using (var win = new QueryBuilderWIN())
            {
                win.ShowDialog();
            }
        }

        private void MenuItemVersionCompare_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.Form win = new FieldComparerWIN())
            {
                win.ShowDialog();
            }
        }

        private void MenuItemWebHook_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.Form win = new WebHookWIN())
            {
                win.ShowDialog();
            }
        }

        private void MenuItemGenerateV3Classes_Click(object sender, EventArgs e)
        {
            using (Form win = new GenerateV3ClassesWIN())
            {
                win.ShowDialog();
            }
        }

        private void aPIFieldValidatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new ValidateAPIFieldWIN())
            {
                win.ShowDialog();
            }
        }

        private void eNumGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new ENumGenerationWIN())
            {
                win.ShowDialog();
            }
        }

        private void allUsersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Form win = new AllUsersWIN())
            {
                win.ShowDialog();
            }
        }

        private void usersGroupsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Form win = new AllUsersAndGroupsWIN())
            {
                win.ShowDialog();
            }
        }

        private void usersPersonasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Form win = new AllUsersAndPersonasWIN())
            {
                win.ShowDialog();
            }
        }

        private void usersCompensationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Form win = new AllUsersCompensationPlansWIN())
            {
                win.ShowDialog();
            }
        }

        private void usersLicensesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (Form win = new AllUsersLicensesWIN())
            {
                win.ShowDialog();
            }
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllRolesWIN())
            {
                win.ShowDialog();
            }
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllPersonasWIN())
            {
                win.ShowDialog();
            }
        }

        private void underwritingConditionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllUnderwritingConditionsWIN())
            {
                win.ShowDialog();
            }
        }

        private void allMilestonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllMilestonesWIN())
            {
                win.ShowDialog();
            }
        }

        private void lastOmpletedMilestonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllLastCompletedMilestonesWIN())
            {
                win.ShowDialog();
            }
        }

        private void nextMilestonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllNextMilestonesWIN())
            {
                win.ShowDialog();
            }
        }

        private void allAssociatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllAssociatesWIN())
            {
                win.ShowDialog();
            }
        }

        private void associatesByRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllAssociatesByRoleWIN())
            {
                win.ShowDialog();
            }
        }

        private void rateLockRequestSummariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllRateLockSummariesWIN())
            {
                win.ShowDialog();
            }
        }

        private void resourceLockListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllResourceLockListWIN())
            {
                win.ShowDialog();
            }
        }

        private void loanTemplateFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllTemplateLoanFoldersWIN())
            {
                win.ShowDialog();
            }
        }

        private void publicTempalteFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllTemplateFilesWIN())
            {
                win.ShowDialog();
            }
        }

        private void allFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllFoldersWIN())
            {
                win.ShowDialog();
            }
        }

        private void documentsAndAttachmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new AllDocsAndAttachmentsWIN())
            {
                win.ShowDialog();
            }
        }

        private void fieldDefinitionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form win = new ViewAllFieldDefinitionsWIN())
            {
                win.ShowDialog();
            }
        }
    }
}
