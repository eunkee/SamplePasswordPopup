using System;
using System.Drawing;
using System.Windows.Forms;

namespace SamplePasswordPopup
{
    public partial class Form1 : Form
    {
        private PopupExitPassword popupExitPassword = null;

        public Form1()
        {
            InitializeComponent();
        }

        #region method

        //Popup Position : Center
        private Point GetPopupLocation(Form form)
        {
            const int AxisYCorrection = 30;
            int X = this.Location.X + (this.Width / 2 - form.Width / 2);
            int Y = this.Location.Y + (this.Height / 2 - form.Height / 2);
            return new Point(X, Y + AxisYCorrection);
        }

        private void SetAnimationPopup(IntPtr Handle, bool isVisble)
        {
            if (isVisble)
            {
                Common.AnimateWindow(Handle, 100,
                    Common.AnimateWindowFlags.AW_ACTIVATE | Common.AnimateWindowFlags.AW_CENTER);
            }
            else
            {
                Common.AnimateWindow(Handle, 100,
                    Common.AnimateWindowFlags.AW_HIDE | Common.AnimateWindowFlags.AW_CENTER);
            }
        }

        #endregion method

        #region control

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ButtonExit_Click(sender, e);

            e.Cancel = true;
        }

        private void ButtonMini_Click(object sender, EventArgs e)
        {
            popupExitPassword = new PopupExitPassword();
            popupExitPassword.Location = GetPopupLocation(popupExitPassword);
            SetAnimationPopup(popupExitPassword.Handle, true);
            DialogResult result = popupExitPassword.ShowDialog();
            if (result == DialogResult.OK)
            {
                WindowState = FormWindowState.Minimized;
            }
            popupExitPassword = null;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            popupExitPassword = new PopupExitPassword();
            popupExitPassword.Location = GetPopupLocation(popupExitPassword);
            SetAnimationPopup(popupExitPassword.Handle, true);
            DialogResult result = popupExitPassword.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    Application.ExitThread();
                    Environment.ExitCode = 0;
                }
                catch { }
            }

            popupExitPassword = null;
        }

        #endregion control

    }
}