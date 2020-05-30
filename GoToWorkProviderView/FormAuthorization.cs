using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkProviderView
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            FormRegistration form = new FormRegistration();
            form.ShowDialog();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmail.Text) && !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                try
                {
                    Program.Provider = APIClient.GetRequest<ProviderViewModel>($"api/provider/login?email={textBoxEmail.Text}&password={textBoxPassword.Text}");
                    if (Program.Provider == null)
                    {
                        MessageBox.Show("Неверно введенный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                    else
                    {
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
