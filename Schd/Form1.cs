﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ScottPlot;

namespace Schd
{
    public partial class Scheduling : MetroFramework.Forms.MetroForm
    {
        string path;
        string[] readText;
        private bool readFile = false;
        List<Process> pList, pView, pBackup;
        List<Result> resultList;
        List<ResultData> resultDataList = new List<ResultData>();

        public Scheduling()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            pView.Clear();
            pList.Clear();

            Button btn = (Button)sender;
            if (btn.Name == "randomize")
            {
                Form3 form3 = new Form3();
                if (form3.ShowDialog() == DialogResult.OK)
                {
                    Random r = new Random();
                    string[] ret = form3.getNumbers;
                    int processes = int.Parse(ret[0]), arrival = int.Parse(ret[1]), burst = int.Parse(ret[2]);

                    for (int i = 0; i < processes; i++)
                    {
                        int randBurst = 0;
                        while (randBurst == 0)
                            randBurst = r.Next(burst);

                        Process p = new Process(i + 1, r.Next(arrival), randBurst, 1);
                        pList.Add(p);
                    }

                    statusLabel.Text = "Status : Generating process completed.";
                }
            }
            else
            {
                //파일 오픈
                path = SelectFilePath();
                if (path == null) return;

                readText = File.ReadAllLines(path);

                //토큰 분리
                for (int i = 0; i < readText.Length; i++)
                {
                    string[] token = readText[i].Split(' ');
                    Process p = new Process(int.Parse(token[1]), int.Parse(token[2]), int.Parse(token[3]), int.Parse(token[4]));
                    pList.Add(p);
                }

                statusLabel.Text = "Status : File loaded.";
            }

            //Grid에 process 출력
            dataGridView1.Rows.Clear();
            string[] row = { "", "", "", "" };
            foreach (Process p in pList)
            {
                row[0] = p.processID.ToString();
                row[1] = p.arriveTime.ToString();
                row[2] = p.burstTime.ToString();
                row[3] = p.priority.ToString();

                dataGridView1.Rows.Add(row);
            }

            //arriveTime으로 정렬
            pList.Sort(delegate (Process x, Process y)
            {
                if (x.arriveTime > y.arriveTime) return 1;
                else if (x.arriveTime < y.arriveTime) return -1;
                else
                {
                    return x.processID.CompareTo(y.processID);
                }
            });

            readFile = true;
        }

        private string SelectFilePath()
        {
            openFileDialog1.Filter = "텍스트 파일|*.txt";
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            return (openFileDialog1.ShowDialog() == DialogResult.OK) ? openFileDialog1.FileName : null;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Scheduling NewForm = new Scheduling();
            NewForm.Show();
            this.Dispose(false);
        }

        private void Export_Click(object sender, EventArgs e)
        {
            if (resultDataList.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(
                this,
                "No results to save.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "텍스트 파일|*.txt";
            sfd.ShowDialog();

            if (sfd.FileName == "")
                return;

            var sb = new System.Text.StringBuilder();

            for (int i = 0; i < resultDataList.Count; i++)
            {
                sb.AppendLine("[Run " + (i + 1) + "]");
                sb.AppendLine("* Scheduling Algorithm : " + resultDataList[i].algsType);

                if (resultDataList[i].algsType == "RR")
                    sb.AppendLine("* Time Quantum : " + resultDataList[i].timeQuantum);

                sb.AppendLine("\n*** Summary of Execution Time ***");
                sb.AppendLine("* Total Processes : " + resultDataList[i].resultList.Count);
                sb.AppendLine("* Total Execution Time : " + resultDataList[i].totalExecTime);
                sb.AppendLine("* Average Waiting Time : " + resultDataList[i].avgWaitingTime);

                sb.AppendLine("\n*** Result of Execution for the Processes ***");
                foreach (var v in resultDataList[i].resultList)
                    sb.AppendLine("Process " + v.processID + " : Started at " + v.startP + ", burst time : " + v.burstTime + ", waiting time : " + v.waitingTime);

                sb.AppendLine("\n");
            }

            File.WriteAllText(sfd.FileName, sb.ToString());
            statusLabel.Text = "Status : Result text file saved to " + sfd.FileName.Substring(sfd.FileName.LastIndexOf('\\') + 1);
        }

        private void Run_Click(object sender, EventArgs e)
        {
            int timeQuantum = -1;

            if (!readFile)
            {
                MetroFramework.MetroMessageBox.Show(
                this,
                "Open the file, or generate the processes");
                return;
            }

            pBackup = pList.ConvertAll(x => new Process(x.processID, x.arriveTime, x.burstTime, x.priority));

            // Simulate scheduling
            switch (algSelect.GetItemText(algSelect.SelectedItem))
            {
                case "":
                    MetroFramework.MetroMessageBox.Show(
                    this,
                    "Select an algorithm");
                    return;

                case "FCFS":
                    resultList = AlgsFCFS.Run(pList, resultList);
                    statusLabel.Text = "Status : FCFS completed.";
                    break;

                case "SJF":
                    resultList = AlgsSJF.Run(pList, resultList);
                    statusLabel.Text = "Status : SJF completed.";
                    break;

                case "SRTF":
                    resultList = AlgsSRTF.Run(pList, resultList);
                    statusLabel.Text = "Status : SRTF completed.";
                    break;

                case "HRRN":
                    resultList = AlgsHRRN.Run(pList, resultList);
                    statusLabel.Text = "Status : HRRN completed.";
                    break;

                case "RR":
                    using (Form2 form2 = new Form2())
                    {
                        timeQuantum = int.Parse(form2.getQuantum);
                        if (form2.ShowDialog() == DialogResult.OK)
                            resultList = AlgsRR.Run(pList, resultList, timeQuantum);
                        else
                            return;
                    }
                    statusLabel.Text = "Status : RR completed.";
                    break;

                case "HRF":
                    resultList = AlgsHRF.Run(pList, resultList);
                    statusLabel.Text = "Status : HRF completed.";
                    break;

                case "ATR":
                    resultList = AlgsATR.Run(pList, resultList);
                    statusLabel.Text = "Status : ATR completed.";
                    break;
            }

            //결과출력
            dataGridView2.Rows.Clear();

            string[] row = { "", "", "", "" };

            double waitingTime = 0.0;
            foreach (Result r in resultList)
            {
                row[0] = r.processID.ToString();
                row[1] = r.burstTime.ToString();
                row[2] = r.waitingTime.ToString();
                waitingTime += r.waitingTime;

                dataGridView2.Rows.Add(row);
            }

            ResultData resultData = new ResultData();

            int totalExecTime = resultList[resultList.Count - 1].startP + resultList[resultList.Count - 1].burstTime;
            double avgWaitingTime = waitingTime / resultList.Count;

            TRTime.Text = "전체 실행시간: " + totalExecTime.ToString();
            avgRT.Text = "평균 대기시간: " + avgWaitingTime.ToString();
            panel1.Invalidate();

            // Backup imported current processes
            pList = pBackup.ConvertAll(x => new Process(x.processID, x.arriveTime, x.burstTime, x.priority));

            // Draw a pie graph
            Dictionary<int, int> waitingTimeList = new Dictionary<int, int>();

            for (int i = 0; i < pList.Count; i++)
                waitingTimeList.Add(pList[i].processID, 0);

            for (int i = 0; i < resultList.Count; i++)
                waitingTimeList[resultList[i].processID] += resultList[i].waitingTime;

            formsPlot1_Paint(waitingTimeList);

            resultData.algsType = algSelect.GetItemText(algSelect.SelectedItem);
            if (resultData.algsType == "RR")
                resultData.timeQuantum = timeQuantum;
            resultData.totalExecTime = totalExecTime;
            resultData.avgWaitingTime = avgWaitingTime;
            resultData.resultList = resultList;
            resultData.waitingTimeList = waitingTimeList;
            resultDataList.Add(resultData);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int startPosition = 10;
            double waitingTime = 0.0;

            int resultListPosition = 0;
            foreach (Result r in resultList)
            {
                e.Graphics.DrawString("p" + r.processID.ToString(), Font, Brushes.Black, startPosition + (r.startP * 10), resultListPosition);
                e.Graphics.DrawRectangle(Pens.Red, startPosition + (r.startP * 10), resultListPosition + 20, r.burstTime * 10, 30);
                e.Graphics.DrawString(r.burstTime.ToString(), Font, Brushes.Black, startPosition + (r.startP * 10), resultListPosition + 60);
                e.Graphics.DrawString(r.waitingTime.ToString(), Font, Brushes.Black, startPosition + (r.startP * 10), resultListPosition + 80);
                waitingTime += (double)r.waitingTime;
            }
        }

        private void formsPlot1_Paint(Dictionary<int, int> list)
        {
            var plt = formsPlot1.Plot;
            plt.Clear();

            double[] waitingTime = list.Values.Select(x => (double)x).ToArray();
            string[] processID = list.Keys.Select(x => x.ToString()).ToArray();

            var pie = plt.AddPie(waitingTime);
            pie.SliceLabels = processID;
            pie.ShowLabels = true;

            formsPlot1.Plot.Legend();
            formsPlot1.Plot.Render();

            formsPlot1.Refresh();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void TRTime_Click(object sender, EventArgs e)
        {

        }

        private void outputLabel_Click(object sender, EventArgs e)
        {

        }

        private void fileOpen_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pList = new List<Process>();
            pView = new List<Process>();
            resultList = new List<Result>();

            //입력창
            DataGridViewTextBoxColumn processColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn arriveTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn burstTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn priorityColumn = new DataGridViewTextBoxColumn();

            processColumn.HeaderText = "프로세스";
            processColumn.Name = "process";
            arriveTimeColumn.HeaderText = "도착시간";
            arriveTimeColumn.Name = "arriveTime";
            burstTimeColumn.HeaderText = "실행시간";
            burstTimeColumn.Name = "burstTime";
            priorityColumn.HeaderText = "우선순위";
            priorityColumn.Name = "priority";

            dataGridView1.Columns.Add(processColumn);
            dataGridView1.Columns.Add(arriveTimeColumn);
            dataGridView1.Columns.Add(burstTimeColumn);
            dataGridView1.Columns.Add(priorityColumn);

            //결과창
            DataGridViewTextBoxColumn resultProcessColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn resultBurstTimeColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn resultWaitingTimeColumn = new DataGridViewTextBoxColumn();

            resultProcessColumn.HeaderText = "프로세스";
            resultProcessColumn.Name = "process";
            resultBurstTimeColumn.HeaderText = "실행시간";
            resultBurstTimeColumn.Name = "resultBurstTimeColumn";
            resultWaitingTimeColumn.HeaderText = "대기시간";
            resultWaitingTimeColumn.Name = "waitingTime";

            dataGridView2.Columns.Add(resultProcessColumn);
            dataGridView2.Columns.Add(resultBurstTimeColumn);
            dataGridView2.Columns.Add(resultWaitingTimeColumn);

            // Initialize pie graph
            var plt = formsPlot1.Plot;
            double[] values = { 778, 43, 283, 76, 184 };
            formsPlot1.Refresh();
            var pie = plt.AddPie(values);
            formsPlot1.Render();
        }
    }
}
