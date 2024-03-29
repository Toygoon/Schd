﻿using System.Linq;

namespace Schd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scheduling));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.resetButton = new System.Windows.Forms.Button();
            this.inputLabel = new MetroFramework.Controls.MetroLabel();
            this.outputLabel = new MetroFramework.Controls.MetroLabel();
            this.TRTime = new MetroFramework.Controls.MetroLabel();
            this.avgRT = new MetroFramework.Controls.MetroLabel();
            this.algSelect = new MetroFramework.Controls.MetroComboBox();
            this.selectLabel = new MetroFramework.Controls.MetroLabel();
            this.proceedButton = new MetroFramework.Controls.MetroButton();
            this.randomize = new MetroFramework.Controls.MetroButton();
            this.openFile = new MetroFramework.Controls.MetroButton();
            this.statusLabel = new MetroFramework.Controls.MetroLabel();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.exportButton = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(977, 400);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 204);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(45, 406);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(871, 278);
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
            this.dataGridView2.Location = new System.Drawing.Point(45, 810);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(871, 278);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(43, 1170);
            this.resetButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(139, 46);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.Reset_Click);
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Location = new System.Drawing.Point(43, 356);
            this.inputLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(37, 19);
            this.inputLabel.TabIndex = 10;
            this.inputLabel.Text = "입력";
            this.inputLabel.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(45, 760);
            this.outputLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(37, 19);
            this.outputLabel.TabIndex = 11;
            this.outputLabel.Text = "출력";
            this.outputLabel.Click += new System.EventHandler(this.outputLabel_Click);
            // 
            // TRTime
            // 
            this.TRTime.AutoSize = true;
            this.TRTime.Location = new System.Drawing.Point(977, 1104);
            this.TRTime.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TRTime.Name = "TRTime";
            this.TRTime.Size = new System.Drawing.Size(104, 19);
            this.TRTime.TabIndex = 12;
            this.TRTime.Text = "전체 실행시간 :";
            // 
            // avgRT
            // 
            this.avgRT.AutoSize = true;
            this.avgRT.Location = new System.Drawing.Point(977, 1154);
            this.avgRT.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
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
            "RR",
            "HRF",
            "ATR"});
            this.algSelect.Location = new System.Drawing.Point(977, 208);
            this.algSelect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.algSelect.Name = "algSelect";
            this.algSelect.Size = new System.Drawing.Size(240, 29);
            this.algSelect.TabIndex = 14;
            this.algSelect.UseSelectable = true;
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(977, 150);
            this.selectLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(37, 19);
            this.selectLabel.TabIndex = 10;
            this.selectLabel.Text = "선택";
            this.selectLabel.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // proceedButton
            // 
            this.proceedButton.BackgroundImage = global::Schd.Properties.Resources.ok_scaled;
            this.proceedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.proceedButton.Location = new System.Drawing.Point(1280, 150);
            this.proceedButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.proceedButton.Name = "proceedButton";
            this.proceedButton.Size = new System.Drawing.Size(123, 116);
            this.proceedButton.TabIndex = 13;
            this.proceedButton.UseSelectable = true;
            this.proceedButton.Click += new System.EventHandler(this.Run_Click);
            // 
            // randomize
            // 
            this.randomize.BackgroundImage = global::Schd.Properties.Resources.random_scaled;
            this.randomize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.randomize.Location = new System.Drawing.Point(546, 150);
            this.randomize.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.randomize.Name = "randomize";
            this.randomize.Size = new System.Drawing.Size(123, 116);
            this.randomize.TabIndex = 13;
            this.randomize.UseSelectable = true;
            this.randomize.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // openFile
            // 
            this.openFile.BackgroundImage = global::Schd.Properties.Resources.fileopen_scaled;
            this.openFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openFile.Location = new System.Drawing.Point(377, 150);
            this.openFile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(123, 116);
            this.openFile.TabIndex = 13;
            this.openFile.UseSelectable = true;
            this.openFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(43, 298);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(75, 19);
            this.statusLabel.TabIndex = 15;
            this.statusLabel.Text = "Status : idle";
            this.statusLabel.Click += new System.EventHandler(this.metroLabel1_Click_1);
            // 
            // formsPlot1
            // 
            this.formsPlot1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formsPlot1.Location = new System.Drawing.Point(981, 686);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(866, 372);
            this.formsPlot1.TabIndex = 16;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(977, 356);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(77, 19);
            this.metroLabel1.TabIndex = 12;
            this.metroLabel1.Text = "Gantt Chart";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(977, 636);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(86, 19);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Waiting Time";
            // 
            // exportButton
            // 
            this.exportButton.BackgroundImage = global::Schd.Properties.Resources.export_scaled;
            this.exportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportButton.Location = new System.Drawing.Point(724, 150);
            this.exportButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(123, 116);
            this.exportButton.TabIndex = 13;
            this.exportButton.UseSelectable = true;
            this.exportButton.Click += new System.EventHandler(this.Export_Click);
            // 
            // Scheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1918, 1262);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.algSelect);
            this.Controls.Add(this.proceedButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.randomize);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.avgRT);
            this.Controls.Add(this.TRTime);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Scheduling";
            this.Padding = new System.Windows.Forms.Padding(37, 120, 37, 40);
            this.Text = "CPU Scheduling";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button resetButton;
        private MetroFramework.Controls.MetroLabel inputLabel;
        private MetroFramework.Controls.MetroLabel outputLabel;
        private MetroFramework.Controls.MetroLabel TRTime;
        private MetroFramework.Controls.MetroLabel avgRT;
        private MetroFramework.Controls.MetroButton openFile;
        private MetroFramework.Controls.MetroComboBox algSelect;
        private MetroFramework.Controls.MetroLabel selectLabel;
        private MetroFramework.Controls.MetroButton randomize;
        private MetroFramework.Controls.MetroButton proceedButton;
        private MetroFramework.Controls.MetroLabel statusLabel;
        private ScottPlot.FormsPlot formsPlot1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton exportButton;
    }
}

