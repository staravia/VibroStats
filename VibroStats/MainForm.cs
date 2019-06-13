using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace vibromark
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Determines if the user is currently doing the test.
        /// </summary>
        private bool IsAnalyzingTest { get; set; }

        /// <summary>
        /// Determines if the vibro will last for 10 seconds. If not, it'll last for 25 seconds.
        /// </summary>
        private bool TenSecondMode { get; set; }

        /// <summary>
        /// Determines which KeysDown are pressed down.
        /// </summary>
        private bool[] KeysDown { get; set; }

        /// <summary>
        /// Used for simple NPS calculation
        /// </summary>
        private int[] ShortData { get; set; }

        /// <summary>
        /// Used to calculate NPS/consistancy of each finger
        /// </summary>
        private int[,] LongData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private float CurrentAverageBPM { get; set; }

        /// <summary>
        /// If the program is still running.
        /// </summary>
        private bool IsRunning { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private const int SleepTime = 100;

        delegate void SetTextCallback(string cooler, string bpma, int progressa);

        /// <summary>
        /// Initializes whenever the program starts.
        /// </summary>
        public MainForm()
        {
            IsRunning = true;
            KeysDown = new bool[4];
            ShortData = new int[4];
            LongData = new int[4, 0];
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                TenSecondMode = true;
                BeginTest();
            }
            else
            {
                TenSecondMode = false;
                BeginTest();
            }
        }

        private void BeginTest()
        {
            if (!IsAnalyzingTest)
            {
                IsAnalyzingTest = true;
                label2.Text = "Vibrate on assigned KeysDown to begin";
                label3.Text = "00.0 bpm";
                progressBar1.Value = 0;
                groupBox1.Hide();
                groupBox3.Show();
                if (TenSecondMode)
                {
                    LongData = new int[4, (int)(10000/SleepTime)];
                }
                else
                {
                    LongData = new int[4, (int)(25000/ SleepTime)];
                }
                Task measureVibro = Task.Factory.StartNew(() => TrackTap())
                    .ContinueWith((t1) => doneTrack(), TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private float GetMedian(float[] source)
        {
            float[] tempwe = source;
            Array.Sort(tempwe);

            int count = tempwe.Length;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }
            else if (count % 2 == 0)
            {
                float aa = tempwe[count / 2 - 1];
                float bb = tempwe[count / 2];

                return (aa + bb) / 2f;
            }
            else
            {
                return tempwe[count / 2];
            }
        }


        private void doneTrack()
        {
            //Update Main Window
            groupBox3.Hide();
            groupBox1.Show();

            //Assign Calculation Variables
            int curLength = (int)LongData.Length / 4;
            float[,] averagebpm = new float[4, curLength];
            float[] averagebpm0 = new float[curLength];
            float[] averagebpm1 = new float[curLength];
            float[] averagebpm2 = new float[curLength];
            float[] averagebpm3 = new float[curLength];
            float[,] tempStats = new float[4, curLength];
            float[] averageUR0 = new float[curLength];
            float[] averageUR1 = new float[curLength];
            float[] averageUR2 = new float[curLength];
            float[] averageUR3 = new float[curLength];
            float[] bestBpmr = new float[2] { 0, 0 };
            float[] bestBpml = new float[2] { 0, 0 };
            int counter;


            //FIND AVERAGE BPM
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < curLength; j++)
                {
                    counter = 0;
                    for (int a = 0; a < 101; a++)
                    {
                        if (a<=50 && j+a<curLength)
                        {
                            tempStats[i, j] = tempStats[i, j] + LongData[i,j+a];
                            counter++;
                        }
                        else if (a > 50 && j+50-a >= 0)
                        {
                            tempStats[i, j] = tempStats[i, j] + LongData[i, j+50 - a];
                            counter++;
                        }
                    }
                    if (counter-1 > 0)
                    {
                        tempStats[i, j] = 1000f /(20f* ((float)counter-1f)) * (float)tempStats[i, j] * 15f;
                    }
                    else
                    {
                        tempStats[i, j] = 0;
                    }
                }
            }
            //SMOOTH AVERAGE BPM
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < curLength; j++)
                {
                    counter = 0;
                    for (int a = 0; a < 101; a++)
                    {
                        if (a <= 50 && j + a < curLength)
                        {
                            averagebpm[i, j] = averagebpm[i, j] + tempStats[i, j + a];
                            counter++;
                        }
                        else if (a > 50 && j + 50 - a >= 0)
                        {
                            //Console.WriteLine(j);
                            averagebpm[i, j] = averagebpm[i, j] + tempStats[i, j + 50 - a];
                            counter++;
                        }
                    }
                    if (counter - 1 > 0)
                    {
                        averagebpm[i, j] = (float)averagebpm[i, j]/ ((float)counter - 1f);
                    }
                    else
                    {
                        averagebpm[i, j] = 0;
                    }

                    if (i == 0)
                    {
                        averagebpm0[j] = averagebpm[i, j];
                    }
                    else if (i == 1)
                    {
                        averagebpm1[j] = averagebpm[i, j];
                    }
                    else if (i == 2)
                    {
                        averagebpm2[j] = averagebpm[i, j];
                    }
                    else if (i == 3)
                    {
                        averagebpm3[j] = averagebpm[i, j];
                    }

                }
            }

            //If the player has pressed any keys at all
            if (averagebpm0.Average() + averagebpm1.Average() + averagebpm2.Average() + averagebpm3.Average() > 0)
            {
                //FIND PEAK/STAMINA
                for (int j = 0; j < curLength; j++)
                {
                    if (j > 25 && (averagebpm0[j] + averagebpm1[j]) / 2f > bestBpml[1])
                    {
                        bestBpml[1] = (averagebpm0[j] + averagebpm1[j]) / 2f;
                        bestBpml[0] = j;
                    }
                    if (j > 25 && (averagebpm2[j] + averagebpm3[j]) / 2f > bestBpmr[1])
                    {
                        bestBpmr[1] = (averagebpm2[j] + averagebpm3[j]) / 2f;
                        bestBpmr[0] = j;
                    }
                }

                //FIND BPM UR
                for (int j = 0; j < curLength - 1; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (i == 0)
                        {
                            averageUR0[j] = (averagebpm[i, j + 1] - averagebpm[i, j]);
                        }
                        else if (i == 1)
                        {
                            averageUR1[j] = (averagebpm[i, j + 1] - averagebpm[i, j]);
                        }
                        else if (i == 2)
                        {
                            averageUR2[j] = (averagebpm[i, j + 1] - averagebpm[i, j]);
                        }
                        else if (i == 3)
                        {
                            averageUR3[j] = (averagebpm[i, j + 1] - averagebpm[i, j]);
                        }
                    }

                }

                //Create result screen
                StatsWindow frm = new StatsWindow();

                //Plot graph if player has vibroed
                if (bestBpml[1]>160 || bestBpmr[1] > 160)
                {
                    for (int i = 0; i < curLength; i++)
                    {
                        //Plots a point every 10 data points
                        if (i % 10 == 0)
                        {
                            frm.bpmChart.Series["rhBpm"].Points.AddXY((float)i * 20 / 1000f, (averagebpm[2, i] + averagebpm[3, i]) / 2f);
                            frm.bpmChart.Series["lhBpm"].Points.AddXY((float)i * 20 / 1000f, (averagebpm[0, i] + averagebpm[1, i]) / 2f);
                        }
                    }
                }

                //If no points are on graph, create nil graph.
                else
                {
                    frm.bpmChart.Series["rhBpm"].Points.AddXY(0, 161);
                    frm.bpmChart.Series["lhBpm"].Points.AddXY(0, 161);
                }

                //Calculate Average BPM
                double curAvgBpm = Math.Round((averagebpm0.Average() + averagebpm1.Average() + averagebpm2.Average() + averagebpm3.Average()) / 4f, 2);

                //Calculate Peak/Median BPM
                double L_medianBPM = (GetMedian(averagebpm0) + GetMedian(averagebpm1)) / 2;
                double L_peakkBPM = bestBpml[1];
                double R_medianBPM = (GetMedian(averagebpm2) + GetMedian(averagebpm3)) / 2;
                double R_peakBPM = bestBpmr[1];

                //Calculate BPM Drain
                double L_BpmDrain = Math.Min(0, (60f * (averageUR0.Average() + averageUR1.Average()))) / 2f;
                double R_BpmDrain = Math.Min(0, (60f * (averageUR2.Average() + averageUR3.Average()))) / 2f;

                //Calculate BPM of Stamina Drain
                double staminaBpmL = (GetMedian(averagebpm0) + GetMedian(averagebpm1)) / 2f - Math.Pow((averageUR0.Average() + averageUR1.Average()) * 60f / 2f, 2f);
                double staminaBpmR = (GetMedian(averagebpm2) + GetMedian(averagebpm3)) / 2f - Math.Pow((averageUR2.Average() + averageUR3.Average()) * 60f / 2f, 2f);

                //Convert UR to magnitude
                for (int i = 0; i < curLength - 1; i++)
                {
                    averageUR0[i] = Math.Abs(averageUR0[i]);
                    averageUR1[i] = Math.Abs(averageUR1[i]);
                    averageUR2[i] = Math.Abs(averageUR2[i]);
                    averageUR3[i] = Math.Abs(averageUR3[i]);
                }

                //Calculate UR
                double bpmURl = (10000d / 6d) * (averageUR0.Select(val => (val - Math.Pow((averageUR0.Average() + averageUR1.Average()) / 2,2))).Sum()
                    + averageUR1.Select(val => (val - Math.Pow((averageUR0.Average() + averageUR1.Average()) / 2, 2))).Sum()) 
                    / curLength;
                double bpmURr = (10000d / 6d) * (averageUR2.Select(val => (val - Math.Pow((averageUR2.Average() + averageUR3.Average()) / 2, 2))).Sum()
                    + averageUR3.Select(val => (val - Math.Pow((averageUR2.Average() + averageUR3.Average()) / 2, 2))).Sum())
                    / curLength;

                //Calculate General Unstable Rate
                double genURl = Math.Pow((100d / 6d) * (averageUR0.Average() - averageUR1.Average()), 2)/(curAvgBpm / 15000);
                double genURr = Math.Pow((100d / 6d) * (averageUR2.Average() - averageUR3.Average()), 2) / (curAvgBpm / 15000);

                //Set Text of top body
                frm.averageBPM.Text = curAvgBpm.ToString();
                frm.dateText.Text = DateTime.Now.ToString();

                //Set Text of bottom body (Unstability)
                frm.L_GeneralUnstability.Text = "General Instability: " + Math.Round(genURl,4);
                frm.R_Unstability.Text = "General Instability: " + Math.Round(genURr,4);
                frm.L_BpmUnstability.Text = "BPM Unstable Rate: " + Math.Round(bpmURl,1);
                frm.R_BpmUnstability.Text = "BPM Unstable Rate: " + Math.Round(bpmURr,1);

                //Set Text of bottom body (Average/Median BPM)
                frm.L_medianBPM.Text = "Median BPM: " + Math.Round(L_medianBPM, 2) + "bpm";
                frm.R_medianBPM.Text = "Median BPM: " + Math.Round(R_medianBPM, 2) + "bpm";
                frm.L_peakBPM.Text = "Peak BPM: " + Math.Round(L_peakkBPM, 2) + "bpm";
                frm.R_peakBPM.Text = "Peak BPM: " + Math.Round(R_peakBPM, 2) + "bpm";

                //Set Text of bottom body (Stamina Drain)
                frm.L_BpmDrain.Text = "Stamina Rate: " + Math.Round(L_BpmDrain, 2) + "bpm²";
                frm.R_bpmDrain.Text = "Stamina Rate: " + Math.Round(R_BpmDrain, 2) + "bpm²";
                frm.L_staminaDrain.Text = "Stamina BPM: " + Math.Round(staminaBpmL, 2) + "bpm";
                frm.R_staminaDrain.Text = "Stamina BPM: " + Math.Round(staminaBpmR, 2) + "bpm";

                //Calculate HandPref
                string handtextr = "";
                double handPref = Math.Round(Math.Min(100 * ((averagebpm0.Average() + averagebpm1.Average()) / (averagebpm2.Average() + averagebpm3.Average()) - 1f), 100),1);

                //Set Hand Pref Text
                if (handPref == 0)  handtextr = "Equal Hand Preference";
                else if (handPref > 0) handtextr = handPref + "% Left Hand Preference";
                else handtextr = Math.Abs(handPref) + "% Right Hand Preference";
                frm.handPrefText.Text = handtextr;

                //Calculate Main Vibro Stats
                double averageUR = ((genURl + genURr) / 2f + (bpmURl + bpmURr) / 2f);
                double curAcc = 100 / Math.Log10(10f + ((genURl + genURr) / 2f + (bpmURl + bpmURr) / 2f) / 60f);
                double curScore = Math.Pow(curAcc / 100, 0.8) * Math.Pow((staminaBpmL + staminaBpmR) / (Math.Max(2 * curAvgBpm, 1)), 1.4) * Math.Pow(curAvgBpm / 175, 2.2) * 2000;

                //Set Main Vibro Stat Text
                frm.averageUR.Text = Math.Round(averageUR,2).ToString();
                frm.accText.Text = Math.Round(curAcc,2)+"%";
                frm.scoreText.Text = Math.Floor(curScore).ToString();

                //Show Results
                frm.Show();
            }
            //Finish Test
            IsAnalyzingTest = false;
        }

        private void TrackTap()
        {
            int interval = 0;
            ShortData = new int[4];

            //Wait until a key is pressed
            while (ShortData[0]== 0 && ShortData[1] == 0 && ShortData[2] == 0 && ShortData[3] == 0 && interval<40)
            {
                Thread.Sleep(100);
                interval++;
            }

            //Start analyzing data if player has tapped within 4 seconds
            ShortData = new int[4];
            if (interval < 40)
            {
                //Set how long the analyze time is in miliseconds
                int waittime = 10000;
                if (!TenSecondMode) waittime = 25000;
                float[] PrevAverageBPM = new float[10];

                //reset interval
                interval = 0;

                //Loop through until analyzing is done
                while (interval * SleepTime < waittime)
                {
                    var tempb = (int)Math.Ceiling((waittime - interval * SleepTime) / 1000f);
                    Thread.Sleep(SleepTime);
                    CurrentAverageBPM = 0;
                    for (int i = 0; i< 4; i++)
                    {
                        LongData[i, interval] = ShortData[i];
                        ShortData[i] = 0;
                        if (interval >= 10)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                CurrentAverageBPM += LongData[i, interval - j];
                            }
                        }
                    }
                    for (int i = 0; i < 9; i++)
                    {
                        PrevAverageBPM[i] = PrevAverageBPM[i+1];
                    }
                    PrevAverageBPM[9] = CurrentAverageBPM;
                    CurrentAverageBPM = PrevAverageBPM.Average() * 15/SleepTime;
                    hideTip(tempb + " seconds remaining", Math.Round(CurrentAverageBPM,1)+"bpm",(int)Math.Ceiling((double)(interval * 100* SleepTime/ waittime)));
                    interval += 1;
                }
            }
        }

        private void hideTip(string coola, string bpmer, int progress)
        {
            if (label2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(hideTip);
                label2.Invoke(d, new object[] { coola, bpmer, progress });
            }
            else
            {
                if (IsRunning)
                {
                    label2.Text = coola;
                }
            }
            if (label3.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(hideTip);
                label3.Invoke(d, new object[] { coola, bpmer, progress });
            }
            else
            {
                if (IsRunning)
                {
                    label3.Text = bpmer;
                }
            }
            if (progressBar1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(hideTip);
                progressBar1.Invoke(d, new object[] { coola, bpmer, progress });
            }
            else
            {
                if (IsRunning)
                {
                    progressBar1.Value = progress;
                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            TextBox tb = (sender as TextBox);
            tb.SelectAll();
        }

        private void tchanged(object sender, EventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb.Name != "textBox1" && tb.Text==textBox1.Text)//find if textboxes have same text lol
            {
                tb.Text = "";
            }
            if (tb.Name != "textBox2" && tb.Text == textBox2.Text)
            {
                tb.Text = "";
            }
            if (tb.Name != "textBox3" && tb.Text == textBox3.Text)
            {
                tb.Text = "";
            }
            if (tb.Name != "textBox4" && tb.Text == textBox4.Text)
            {
                tb.Text = "";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        //TODO: Update key inputs
        private void kDown(object sender, KeyEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                if (char.IsLetterOrDigit((char)e.KeyCode)|| char.IsPunctuation((char)e.KeyCode)) 
                {
                    string az = e.KeyCode.ToString().ToUpper();
                    if (az.Length != 1)
                    {
                        az = az.TrimStart('D');
                        if (az.Length != 1)
                        {
                            az = az.TrimStart('N', 'U', 'M', 'P', 'A','D');
                        }
                    }
                    if ((textBox1.Text != "") && (az.Equals(textBox1.Text[0].ToString().ToUpper())))
                    {
                        if (!KeysDown[0])
                        {
                            KeysDown[0] = true;
                            ShortData[0]++;
                        }
                    }
                    else if ((textBox2.Text != "") && (az.Equals(textBox2.Text[0].ToString().ToUpper())))
                    {
                        if (!KeysDown[1])
                        {
                            KeysDown[1] = true;
                            ShortData[1]++;
                        }
                    }
                    else if ((textBox3.Text != "") && (az.Equals(textBox3.Text[0].ToString().ToUpper())))
                    {
                        if (!KeysDown[2])
                        {
                            KeysDown[2] = true;
                            ShortData[2]++;
                        }
                    }
                    else if ((textBox4.Text != "") && (az.Equals(textBox4.Text[0].ToString().ToUpper())))
                    {
                        if (!KeysDown[3])
                        {
                            KeysDown[3] = true;
                            ShortData[3]++;
                        }
                    }
                }
            }
        }

        private void kUp(object sender, KeyEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                if (char.IsLetterOrDigit((char)e.KeyCode))
                {
                    string az = e.KeyCode.ToString().ToUpper();
                    if (az.Length != 1)
                    {
                        az = az.TrimStart('D');
                        if (az.Length != 1)
                        {
                            az = az.TrimStart('N', 'U', 'M', 'P', 'A', 'D');
                        }
                    }
                    if ((textBox1.Text != "") && (az.Equals(textBox1.Text[0].ToString().ToUpper())))
                    {
                        KeysDown[0] = false;
                    }
                    else if ((textBox2.Text != "") && (az.Equals(textBox2.Text[0].ToString().ToUpper())))
                    {
                        KeysDown[1] = false;
                    }
                    else if ((textBox3.Text != "") && (az.Equals(textBox3.Text[0].ToString().ToUpper())))
                    {
                        KeysDown[2] = false;
                    }
                    else if ((textBox4.Text != "") && (az.Equals(textBox4.Text[0].ToString().ToUpper())))
                    {
                        KeysDown[3] = false;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
