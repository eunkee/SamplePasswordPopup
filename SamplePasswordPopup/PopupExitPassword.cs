using System;
using System.Drawing;
using System.Windows.Forms;

namespace SamplePasswordPopup
{
    public partial class PopupExitPassword : Form
    {
        public PopupExitPassword()
        {
            InitializeComponent();
            BindControlMouseClicks(this);
        }

        #region background click move

        //Background movement judgment even when control is clicked (Except for exceptions)
        public delegate void GlobalMouseClickEventHander(object sender, MouseEventArgs e);

        private void BindControlMouseClicks(Control con)
        {
            if (con != this)
            {
                con.MouseDown += delegate (object sender, MouseEventArgs e)
                {
                    TriggerMouseDowned(sender, e);
                };
                con.MouseMove += delegate (object sender, MouseEventArgs e)
                {
                    TriggerMouseMoved(sender, e);
                };
            }
            foreach (Control i in con.Controls)
            {
                //Controls not belonging to the background
                if ((i != TextBoxPassword) && (i != ButtonClose) && (i != btn1) && (i != btn2)
                    && (i != btn3) && (i != btn4) && (i != btn5) && (i != btn6) && (i != btn7)
                    && (i != btn8) && (i != btn9) && (i != btn0) && (i != btnBS) && (i != ButtonEnter))
                {
                    BindControlMouseClicks(i);
                }
            }
            con.ControlAdded += delegate (object sender, ControlEventArgs e)
            {
                BindControlMouseClicks(e.Control);
            };
        }

        private void TriggerMouseDowned(object sender, MouseEventArgs e)
        {
            PopupExitPassword_MouseDown(sender, e);
        }

        private void TriggerMouseMoved(object sender, MouseEventArgs e)
        {
            PopupExitPassword_MouseMove(sender, e);
        }

        //폼 배경클릭 이동
        private Point _mousePoint;

        private void PopupExitPassword_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePoint = new Point(e.X, e.Y);
        }

        private void PopupExitPassword_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (_mousePoint.X - e.X),
                    this.Top - (_mousePoint.Y - e.Y));
            }
        }

        #endregion background click move

        //Validate password at confirmation
        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            //Validate only the last 4 number
            if (TextBoxPassword.Text.Length >= 4)
            {
                string subText = TextBoxPassword.Text.Substring(TextBoxPassword.Text.Length - 4, 4);
                if (subText == "1234")
                {
                    LabelNotify.Text = string.Empty;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    LabelNotify.Text = "The password is incorrect.";
                }
            }
            else if (TextBoxPassword.Text.Length <= 0)
            {
                LabelNotify.Text = "No password has been entered.";
            }
            else
            {
                LabelNotify.Text = "The password is incorrect.";
            }
        }

        //exit
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        //exit
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            ButtonExit_Click(null, null);
        }

        #region Numpad + Backspace

        private void Btn1_Click(object sender, EventArgs e)
        {
            TextBoxPassword.Text += "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TextBoxPassword.Text += "2";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TextBoxPassword.Text += "3";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TextBoxPassword.Text += "4";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TextBoxPassword.Text += "5";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TextBoxPassword.Text += "6";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TextBoxPassword.Text += "7";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TextBoxPassword.Text += "8";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TextBoxPassword.Text += "9";
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            TextBoxPassword.Text += "0";
        }

        private void BtnBS_Click(object sender, EventArgs e)
        {
            if (TextBoxPassword.Text.Length > 0)
            {
                TextBoxPassword.Text = TextBoxPassword.Text.Substring(0, TextBoxPassword.Text.Length - 1);
            }
        }

        #endregion Numpad + Backspace

        private void PopupExitPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            Common.AnimateWindow(this.Handle, 100,
                Common.AnimateWindowFlags.AW_HIDE | Common.AnimateWindowFlags.AW_CENTER);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Console.WriteLine(keyData);
            if (this.Visible && !TextBoxPassword.Focused)
            {
                if (keyData == Keys.D0)
                {
                    TextBoxPassword.Text += "0";
                }
                else if (keyData == Keys.D1)
                {
                    TextBoxPassword.Text += "1";
                }
                else if (keyData == Keys.D2)
                {
                    TextBoxPassword.Text += "2";
                }
                else if (keyData == Keys.D3)
                {
                    TextBoxPassword.Text += "3";
                }
                else if (keyData == Keys.D4)
                {
                    TextBoxPassword.Text += "4";
                }
                else if (keyData == Keys.D5)
                {
                    TextBoxPassword.Text += "5";
                }
                else if (keyData == Keys.D6)
                {
                    TextBoxPassword.Text += "6";
                }
                else if (keyData == Keys.D7)
                {
                    TextBoxPassword.Text += "7";
                }
                else if (keyData == Keys.D8)
                {
                    TextBoxPassword.Text += "8";
                }
                else if (keyData == Keys.D9)
                {
                    TextBoxPassword.Text += "9";
                }
                else if (keyData == Keys.Back)
                {
                    if (TextBoxPassword.Text.Length > 0)
                    {
                        TextBoxPassword.Text = TextBoxPassword.Text.Substring(0, TextBoxPassword.Text.Length - 1);
                    }
                }
                else if (keyData == Keys.Return)
                {
                    ButtonEnter_Click(null, null);
                }
                else
                {
                    //none
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}