using System.Drawing;

namespace Schd
{
    partial class Form3
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.okButton = new MetroFramework.Controls.MetroButton();
            this.cancelButton = new MetroFramework.Controls.MetroButton();
            this.processInput = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.arrivalInput = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.burstInput = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(23, 305);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&OK";
            this.okButton.UseSelectable = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(104, 305);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseSelectable = true;
            // 
            // processInput
            // 
            // 
            // 
            // 
            this.processInput.CustomButton.Image = null;
            this.processInput.CustomButton.Location = new System.Drawing.Point(318, 1);
            this.processInput.CustomButton.Name = "";
            this.processInput.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.processInput.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.processInput.CustomButton.TabIndex = 1;
            this.processInput.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.processInput.CustomButton.UseSelectable = true;
            this.processInput.CustomButton.Visible = false;
            this.processInput.Lines = new string[] {
        "5"};
            this.processInput.Location = new System.Drawing.Point(23, 107);
            this.processInput.MaxLength = 32767;
            this.processInput.Name = "processInput";
            this.processInput.PasswordChar = '\0';
            this.processInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.processInput.SelectedText = "";
            this.processInput.SelectionLength = 0;
            this.processInput.SelectionStart = 0;
            this.processInput.ShortcutsEnabled = true;
            this.processInput.Size = new System.Drawing.Size(340, 23);
            this.processInput.TabIndex = 2;
            this.processInput.Text = "5";
            this.processInput.UseSelectable = true;
            this.processInput.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.processInput.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.processInput.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 85);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(134, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Number of Processes";
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // arrivalInput
            // 
            // 
            // 
            // 
            this.arrivalInput.CustomButton.Image = null;
            this.arrivalInput.CustomButton.Location = new System.Drawing.Point(318, 1);
            this.arrivalInput.CustomButton.Name = "";
            this.arrivalInput.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.arrivalInput.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.arrivalInput.CustomButton.TabIndex = 1;
            this.arrivalInput.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.arrivalInput.CustomButton.UseSelectable = true;
            this.arrivalInput.CustomButton.Visible = false;
            this.arrivalInput.Lines = new string[] {
        "10"};
            this.arrivalInput.Location = new System.Drawing.Point(23, 180);
            this.arrivalInput.MaxLength = 32767;
            this.arrivalInput.Name = "arrivalInput";
            this.arrivalInput.PasswordChar = '\0';
            this.arrivalInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.arrivalInput.SelectedText = "";
            this.arrivalInput.SelectionLength = 0;
            this.arrivalInput.SelectionStart = 0;
            this.arrivalInput.ShortcutsEnabled = true;
            this.arrivalInput.Size = new System.Drawing.Size(340, 23);
            this.arrivalInput.TabIndex = 2;
            this.arrivalInput.Text = "10";
            this.arrivalInput.UseSelectable = true;
            this.arrivalInput.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.arrivalInput.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.arrivalInput.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 158);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(109, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Max Arrival Time";
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // burstInput
            // 
            // 
            // 
            // 
            this.burstInput.CustomButton.Image = null;
            this.burstInput.CustomButton.Location = new System.Drawing.Point(318, 1);
            this.burstInput.CustomButton.Name = "";
            this.burstInput.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.burstInput.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.burstInput.CustomButton.TabIndex = 1;
            this.burstInput.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.burstInput.CustomButton.UseSelectable = true;
            this.burstInput.CustomButton.Visible = false;
            this.burstInput.Lines = new string[] {
        "5"};
            this.burstInput.Location = new System.Drawing.Point(23, 252);
            this.burstInput.MaxLength = 32767;
            this.burstInput.Name = "burstInput";
            this.burstInput.PasswordChar = '\0';
            this.burstInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.burstInput.SelectedText = "";
            this.burstInput.SelectionLength = 0;
            this.burstInput.SelectionStart = 0;
            this.burstInput.ShortcutsEnabled = true;
            this.burstInput.Size = new System.Drawing.Size(340, 23);
            this.burstInput.TabIndex = 2;
            this.burstInput.Text = "5";
            this.burstInput.UseSelectable = true;
            this.burstInput.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.burstInput.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.burstInput.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 230);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(100, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Max Burst Time";
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(387, 351);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.burstInput);
            this.Controls.Add(this.arrivalInput);
            this.Controls.Add(this.processInput);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Set the numbers";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public string[] getNumbers
        {
            get {
                string[] ret = new string[3];
                ret[0] = processInput.Text;
                ret[1] = arrivalInput.Text;
                ret[2] = burstInput.Text;
                return ret; }
        }

        #endregion

        private MetroFramework.Controls.MetroButton okButton;
        private MetroFramework.Controls.MetroButton cancelButton;
        private MetroFramework.Controls.MetroTextBox processInput;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox arrivalInput;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox burstInput;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}
