using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPanel
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void tbl_LoginBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_LoginBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.myDatabaseData);

        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDatabaseData.tbl_Login' table. You can move, or remove it, as needed.
            this.tbl_LoginTableAdapter.Fill(this.myDatabaseData.tbl_Login);

        }
    }
}
