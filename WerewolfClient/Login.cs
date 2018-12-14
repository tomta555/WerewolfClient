using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WerewolfClient
{
    public partial class Login : Form, View
    {
        private WerewolfController controller;
        private Form _mainForm;
        //public Login(Form MainForm)
        //{
        //    InitializeComponent();
        //    _mainForm = MainForm;
        //}

        public Login(Form GameForm)
        {
            InitializeComponent();
            _mainForm = GameForm;

            this.BackgroundImage = Properties.Resources.Background_2;
            BtnSignIn.Height = Properties.Resources.SIGN_IN.Height;
            BtnSignIn.Width = Properties.Resources.SIGN_IN.Width;
            BtnSignIn.BackColor = Color.Transparent;
            BtnSignIn.FlatStyle = FlatStyle.Flat;
            BtnSignIn.FlatAppearance.BorderSize = 0;
            BtnSignIn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnSignIn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnSignIn.ForeColor = System.Drawing.Color.White;

            BtnSignUp.Height = Properties.Resources.SIGN_UP.Height;
            BtnSignUp.Width = Properties.Resources.SIGN_UP.Width;
            BtnSignUp.BackColor = Color.Transparent;
            BtnSignUp.FlatStyle = FlatStyle.Flat;
            BtnSignUp.FlatAppearance.BorderSize = 0;
            BtnSignUp.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnSignUp.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnSignUp.ForeColor = System.Drawing.Color.White;

            foreach (Control control in this.Controls)
            {
                control.EnableDoubleBuferring();
            }
        }

        public void Notify(Model m)
        {
            if (m is WerewolfModel)
            {
                WerewolfModel wm = (WerewolfModel)m;
                switch (wm.Event)
                {
                    case WerewolfModel.EventEnum.SignIn:
                        if (wm.EventPayloads["Success"] == "True")
                        {
                            _mainForm.Visible = true;
                            this.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Login or password incorrect, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case WerewolfModel.EventEnum.SignUp:
                        if (wm.EventPayloads["Success"] == "True")
                        {
                            MessageBox.Show("Sign up successfuly, please login", "Success", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            MessageBox.Show("Login or password incorrect, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case WerewolfModel.EventEnum.SignOut:
                        this.Visible = true;
                        _mainForm.Visible = false;
                        break;
                }
            }
        }

        public void setController(Controller c)
        {
            controller = (WerewolfController)c;
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            WerewolfCommand wcmd = new WerewolfCommand();
            wcmd.Action = WerewolfCommand.CommandEnum.SignIn;
            wcmd.Payloads = new Dictionary<string, string>() { { "Login", TbLogin.Text }, { "Password", TbPassword.Text }, { "Server", TBServer.Text } };
            controller.ActionPerformed(wcmd);
        }

        private void Password_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                WerewolfCommand wcmd = new WerewolfCommand();
                wcmd.Action = WerewolfCommand.CommandEnum.SignIn;
                wcmd.Payloads = new Dictionary<string, string>() { { "Login", TbLogin.Text }, { "Password", TbPassword.Text }, { "Server", TBServer.Text } };
                controller.ActionPerformed(wcmd);
            }
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            WerewolfCommand wcmd = new WerewolfCommand();
            wcmd.Action = WerewolfCommand.CommandEnum.SignUp;
            wcmd.Payloads = new Dictionary<string, string>() { { "Login", TbLogin.Text}, { "Password",TbPassword.Text}, { "Server", TBServer.Text } };
            controller.ActionPerformed(wcmd);
        }
    }

    }
