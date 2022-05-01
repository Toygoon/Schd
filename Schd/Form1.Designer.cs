﻿namespace Schd
{
    partial class Scheduling
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.algsFCFS = new System.Windows.Forms.Button();
            this.OpenFile1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.algsSJF = new System.Windows.Forms.Button();
            this.algsSRTF = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.algsHRRN = new System.Windows.Forms.Button();
            this.algsRR = new System.Windows.Forms.Button();
            this.inputLabel = new MetroFramework.Controls.MetroLabel();
            this.outputLabel = new MetroFramework.Controls.MetroLabel();
            this.TRTime = new MetroFramework.Controls.MetroLabel();
            this.avgRT = new MetroFramework.Controls.MetroLabel();
            this.algSelect = new MetroFramework.Controls.MetroComboBox();
            this.selectLabel = new MetroFramework.Controls.MetroLabel();
            this.proceedButton = new MetroFramework.Controls.MetroButton();
            this.randomize = new MetroFramework.Controls.MetroButton();
            this.openFile = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // algsFCFS
            // 
            this.algsFCFS.Location = new System.Drawing.Point(97, 676);
            this.algsFCFS.Name = "algsFCFS";
            this.algsFCFS.Size = new System.Drawing.Size(75, 23);
            this.algsFCFS.TabIndex = 1;
            this.algsFCFS.Text = "FCFS";
            this.algsFCFS.UseVisualStyleBackColor = true;
            this.algsFCFS.Click += new System.EventHandler(this.Run_Click);
            // 
            // OpenFile1
            // 
            this.OpenFile1.Location = new System.Drawing.Point(14, 676);
            this.OpenFile1.Name = "OpenFile1";
            this.OpenFile1.Size = new System.Drawing.Size(75, 23);
            this.OpenFile1.TabIndex = 0;
            this.OpenFile1.Text = "OpenFile";
            this.OpenFile1.UseVisualStyleBackColor = true;
            this.OpenFile1.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(23, 555);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 103);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(469, 139);
            this.dataGridView1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(24, 361);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(469, 122);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // algsSJF
            // 
            this.algsSJF.Location = new System.Drawing.Point(180, 676);
            this.algsSJF.Name = "algsSJF";
            this.algsSJF.Size = new System.Drawing.Size(75, 23);
            this.algsSJF.TabIndex = 2;
            this.algsSJF.Text = "SJF";
            this.algsSJF.UseVisualStyleBackColor = true;
            this.algsSJF.Click += new System.EventHandler(this.Run_Click);
            // 
            // algsSRTF
            // 
            this.algsSRTF.Location = new System.Drawing.Point(263, 676);
            this.algsSRTF.Name = "algsSRTF";
            this.algsSRTF.Size = new System.Drawing.Size(75, 23);
            this.algsSRTF.TabIndex = 2;
            this.algsSRTF.Text = "SRTF";
            this.algsSRTF.UseVisualStyleBackColor = true;
            this.algsSRTF.Click += new System.EventHandler(this.Run_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(14, 710);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.Reset_Click);
            // 
            // algsHRRN
            // 
            this.algsHRRN.Location = new System.Drawing.Point(346, 676);
            this.algsHRRN.Name = "algsHRRN";
            this.algsHRRN.Size = new System.Drawing.Size(75, 23);
            this.algsHRRN.TabIndex = 2;
            this.algsHRRN.Text = "HRRN";
            this.algsHRRN.UseVisualStyleBackColor = true;
            this.algsHRRN.Click += new System.EventHandler(this.Run_Click);
            // 
            // algsRR
            // 
            this.algsRR.Location = new System.Drawing.Point(429, 676);
            this.algsRR.Name = "algsRR";
            this.algsRR.Size = new System.Drawing.Size(75, 23);
            this.algsRR.TabIndex = 2;
            this.algsRR.Text = "RR";
            this.algsRR.UseVisualStyleBackColor = true;
            this.algsRR.Click += new System.EventHandler(this.Run_Click);
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Location = new System.Drawing.Point(23, 155);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(37, 19);
            this.inputLabel.TabIndex = 10;
            this.inputLabel.Text = "입력";
            this.inputLabel.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(24, 336);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(37, 19);
            this.outputLabel.TabIndex = 11;
            this.outputLabel.Text = "출력";
            this.outputLabel.Click += new System.EventHandler(this.outputLabel_Click);
            // 
            // TRTime
            // 
            this.TRTime.AutoSize = true;
            this.TRTime.Location = new System.Drawing.Point(24, 501);
            this.TRTime.Name = "TRTime";
            this.TRTime.Size = new System.Drawing.Size(104, 19);
            this.TRTime.TabIndex = 12;
            this.TRTime.Text = "전체 실행시간 :";
            // 
            // avgRT
            // 
            this.avgRT.AutoSize = true;
            this.avgRT.Location = new System.Drawing.Point(24, 526);
            this.avgRT.Name = "avgRT";
            this.avgRT.Size = new System.Drawing.Size(104, 19);
            this.avgRT.TabIndex = 12;
            this.avgRT.Text = "평균 대기시간 :";
            // 
            // algSelect
            // 
            this.algSelect.FormattingEnabled = true;
            this.algSelect.ItemHeight = 23;
            this.algSelect.Items.AddRange(new object[] {
            "FCFS",
            "SJF",
            "SRTF",
            "HRRN",
            "RR"});
            this.algSelect.Location = new System.Drawing.Point(263, 102);
            this.algSelect.Name = "algSelect";
            this.algSelect.Size = new System.Drawing.Size(131, 29);
            this.algSelect.TabIndex = 14;
            this.algSelect.UseSelectable = true;
            this.algSelect.SelectedIndex = 0;
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(263, 73);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(37, 19);
            this.selectLabel.TabIndex = 10;
            this.selectLabel.Text = "선택";
            this.selectLabel.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // proceedButton
            // 
            this.proceedButton.BackgroundImage = global::Schd.Properties.Resources.ok;
            this.proceedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.proceedButton.Location = new System.Drawing.Point(426, 73);
            this.proceedButton.Name = "proceedButton";
            this.proceedButton.Size = new System.Drawing.Size(66, 58);
            this.proceedButton.TabIndex = 13;
            this.proceedButton.UseSelectable = true;
            this.proceedButton.Click += new System.EventHandler(this.Run_Click);
            // 
            // randomize
            // 
            this.randomize.BackgroundImage = global::Schd.Properties.Resources.random;
            this.randomize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.randomize.Location = new System.Drawing.Point(115, 73);
            this.randomize.Name = "randomize";
            this.randomize.Size = new System.Drawing.Size(66, 58);
            this.randomize.TabIndex = 13;
            this.randomize.UseSelectable = true;
            this.randomize.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // openFile
            // 
            this.openFile.BackgroundImage = global::Schd.Properties.Resources.fileopen;
            this.openFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openFile.Location = new System.Drawing.Point(24, 73);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(66, 58);
            this.openFile.TabIndex = 13;
            this.openFile.UseSelectable = true;
            this.openFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // Scheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 747);
            this.Controls.Add(this.algSelect);
            this.Controls.Add(this.proceedButton);
            this.Controls.Add(this.randomize);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.avgRT);
            this.Controls.Add(this.TRTime);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.algsSJF);
            this.Controls.Add(this.algsFCFS);
            this.Controls.Add(this.algsSRTF);
            this.Controls.Add(this.algsHRRN);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OpenFile1);
            this.Controls.Add(this.algsRR);
            this.Name = "Scheduling";
            this.Text = "Scheduling";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFile1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button algsFCFS;
        private System.Windows.Forms.Button algsSJF;
        private System.Windows.Forms.Button algsSRTF;
        private System.Windows.Forms.Button algsHRRN;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button algsRR;
        private MetroFramework.Controls.MetroLabel inputLabel;
        private MetroFramework.Controls.MetroLabel outputLabel;
        private MetroFramework.Controls.MetroLabel TRTime;
        private MetroFramework.Controls.MetroLabel avgRT;
        private MetroFramework.Controls.MetroButton openFile;
        private MetroFramework.Controls.MetroComboBox algSelect;
        private MetroFramework.Controls.MetroLabel selectLabel;
        private MetroFramework.Controls.MetroButton randomize;
        private MetroFramework.Controls.MetroButton proceedButton;
    }
}

