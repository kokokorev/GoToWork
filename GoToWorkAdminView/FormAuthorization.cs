using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace GoToWorkAdminView
{
    public partial class FormAuthorization : Form
    {
        [Dependency] public new IUnityContainer Container { get; set; }
        public FormAuthorization()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text != null && textBoxPassword.Text != null)
            {
                Program.Email = textBoxLogin.Text;
                Program.Password = textBoxPassword.Text;
                Close();
            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
