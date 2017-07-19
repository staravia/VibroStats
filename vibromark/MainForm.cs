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
        private bool testing;
        private bool sec10;
        private bool[] keys;
        private int[] curData;
        private int[,] allData;
        private float[] prevAverageBPM;
        private float curAverageBPM;
        private bool isRunning;

        delegate void SetTextCallback(string cooler, string bpma, int progressa);


        public MainForm()
        {
            isRunning = true;
            keys = new bool[4];
            curData = new int[4];
            allData = new int[4, 0];
            prevAverageBPM = new float[100];
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
                sec10 = true;
                beginTest();
            }
            else
            {
                sec10 = false;
                beginTest();
            }
        }
        private void beginTest()
        {
            if (!testing)
            {
                testing = true;
                label2.Text = "Vibrate on assigned keys to begin";
                label3.Text = "00.0 bpm";
                progressBar1.Value = 0;
                groupBox1.Hide();
                groupBox3.Show();
                prevAverageBPM = new float[100];
                if (sec10)
                {
                    allData = new int[4, 500];
                }
                else
                {
                    allData = new int[4, 1250];
                }
                Task measureVibro = Task.Factory.StartNew(() => trackTap())
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
            groupBox3.Hide();
            groupBox1.Show();


            //CALCULATIONS

            int curLength = (int)allData.Length / 4;
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
                            tempStats[i, j] = tempStats[i, j] + allData[i,j+a];
                            counter++;
                        }
                        else if (a > 50 && j+50-a >= 0)
                        {
                            tempStats[i, j] = tempStats[i, j] + allData[i, j+50 - a];
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
            if (averagebpm0.Average() + averagebpm1.Average() + averagebpm2.Average() + averagebpm3.Average() > 0)
            {

                //FIND PEAK/STAMINA
                for (int j = 0; j < curLength; j++)
                {
                    counter = 0;
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


                //CREATE WINDOW
                StatsWindow frm = new StatsWindow();
                //ADD POINTS TO GRAPH
                if (bestBpml[1]>160 || bestBpmr[1] > 160)
                {
                    //IS VIBRO
                    for (int i = 0; i < curLength; i++)
                    {

                        if (i % 10 == 0)
                        {
                            frm.bpmChart.Series["rhBpm"].Points.AddXY
                                ((float)i * 20 / 1000f, (averagebpm[2, i] + averagebpm[3, i]) / 2f);
                            frm.bpmChart.Series["lhBpm"].Points.AddXY
                                ((float)i * 20 / 1000f, (averagebpm[0, i] + averagebpm[1, i]) / 2f);
                        }
                    }
                }
                else
                {
                    frm.bpmChart.Series["rhBpm"].Points.AddXY(0, 161);
                    frm.bpmChart.Series["lhBpm"].Points.AddXY(0, 161);
                }

                double curAvgBpm = Math.Round((averagebpm0.Average() + averagebpm1.Average() + averagebpm2.Average() + averagebpm3.Average()) / 4f, 2);
                frm.averageBPM.Text = curAvgBpm.ToString();
                frm.dateText.Text = DateTime.Now.ToString();
                frm.L_medianBPM.Text = "Median BPM: " + Math.Round((GetMedian(averagebpm0) + GetMedian(averagebpm1)) / 2, 2).ToString() + "bpm";
                frm.R_medianBPM.Text = "Median BPM: " + Math.Round((GetMedian(averagebpm2) + GetMedian(averagebpm3)) / 2, 2).ToString() + "bpm";
                frm.L_peakBPM.Text = "Peak BPM: " + Math.Round(bestBpml[1], 2).ToString() + "bpm";
                frm.R_peakBPM.Text = "Peak BPM: " + Math.Round(bestBpmr[1], 2).ToString() + "bpm";
                frm.L_BpmDrain.Text = "Stamina Rate: " + Math.Round(Math.Min(0,(60f * (averageUR0.Average() + averageUR1.Average()))) / 2f, 2).ToString() + "bpm²";
                frm.R_bpmDrain.Text = "Stamina Rate: " + Math.Round(Math.Min(0,(60f * (averageUR2.Average() + averageUR3.Average()))) / 2f, 2).ToString() + "bpm²";

                double staminaBpmL = (GetMedian(averagebpm0) + GetMedian(averagebpm1)) / 2f - Math.Pow((averageUR0.Average() + averageUR1.Average()) * 60f / 2f, 2f);
                double staminaBpmR = (GetMedian(averagebpm2) + GetMedian(averagebpm3)) / 2f - Math.Pow((averageUR2.Average() + averageUR3.Average()) * 60f / 2f, 2f);

                frm.L_staminaDrain.Text = "Stamina BPM: " + Math.Round(staminaBpmL, 2).ToString() + "bpm";
                frm.R_staminaDrain.Text = "Stamina BPM: " + Math.Round(staminaBpmR, 2).ToString() + "bpm";

                //CONVERT TO MAGNITUDE
                for (int i = 0; i < curLength - 1; i++)
                {
                    averageUR0[i] = Math.Abs(averageUR0[i]);
                    averageUR1[i] = Math.Abs(averageUR1[i]);
                    averageUR2[i] = Math.Abs(averageUR2[i]);
                    averageUR3[i] = Math.Abs(averageUR3[i]);
                }
                double bpmURl = (10000d / 6d) * (averageUR0.Select(val => (val - Math.Pow((averageUR0.Average() + averageUR1.Average()) / 2,2))).Sum()
                    + averageUR1.Select(val => (val - Math.Pow((averageUR0.Average() + averageUR1.Average()) / 2, 2))).Sum()) 
                    / curLength;
                double bpmURr = (10000d / 6d) * (averageUR2.Select(val => (val - Math.Pow((averageUR2.Average() + averageUR3.Average()) / 2, 2))).Sum()
                    + averageUR3.Select(val => (val - Math.Pow((averageUR2.Average() + averageUR3.Average()) / 2, 2))).Sum())
                    / curLength;

                //genURl = Math.Pow((100f / 6f) * (averageUR0. - averageUR1.Average()), 2) / (curAvgBpm / 15000);
                double genURl = Math.Pow((100d / 6d) * (averageUR0.Average() - averageUR1.Average()), 2)/(curAvgBpm / 15000);
                double genURr = Math.Pow((100d / 6d) * (averageUR2.Average() - averageUR3.Average()), 2) / (curAvgBpm / 15000);
                //double bpmURl = Math.Pow((100f / 6f) * (Math.Abs(averageUR0.Average()) + Math.Abs(averageUR1.Average())) / 2f, 2) / (curAvgBpm / 15000); OLD
                //double bpmURr = Math.Pow((100f / 6f) * (Math.Abs(averageUR2.Average()) + Math.Abs(averageUR3.Average())) / 2f, 2) / (curAvgBpm / 15000); OLD
                frm.L_GeneralUnstability.Text = "General Instability: " + Math.Round(genURl,4);
                frm.R_Unstability.Text = "General Instability: " + Math.Round(genURr,4);
                frm.L_BpmUnstability.Text = "BPM Unstable Rate: " + Math.Round(bpmURl,1);
                frm.R_BpmUnstability.Text = "BPM Unstable Rate: " + Math.Round(bpmURr,1);


                string handtextr = "";
                double handPref;
                handPref = Math.Round(Math.Min(100 * ((averagebpm0.Average() + averagebpm1.Average()) / (averagebpm2.Average() + averagebpm3.Average()) - 1f), 100),1);
                if (handPref == 0)
                {
                    handtextr = "Equal Hand Preference";
                }
                else if (handPref > 0)
                {
                    handtextr = handPref + "% Left Hand Preference";
                }
                else
                {
                    handtextr = Math.Abs(handPref) + "% Right Hand Preference";
                }
                frm.handPrefText.Text = handtextr;
                frm.averageUR.Text = Math.Round(((genURl+ genURr)/2f + (bpmURl+ bpmURr)/2f),2).ToString();
                
                double curAcc = 100/Math.Log10(10f + ((genURl + genURr) / 2f + (bpmURl + bpmURr) / 2f)/60f);
                double curScore = Math.Pow(curAcc/100,0.8)*Math.Pow((staminaBpmL+staminaBpmR)/(Math.Max(2 * curAvgBpm, 1)), 1.4)*Math.Pow(curAvgBpm/175,2.2)*2000;


                frm.accText.Text = Math.Round(curAcc,2)+"%";
                frm.scoreText.Text = Math.Floor(curScore).ToString();

                frm.Show();

            }
            testing = false;
        }

        private void trackTap()
        {
            int a = 0;
            curData = new int[4];
            while (curData[0]== 0 && curData[1] == 0 && curData[2] == 0 && curData[3] == 0 && a<200)
            {
                Thread.Sleep(20);
                a++;
            }
            curData = new int[4];
            if (a < 200)
            {
                int waittime = 10000;
                if (!sec10){
                    waittime = 25000;
                }
                a = 0;
                int tempb;
                while (a*20 < waittime)
                {
                    tempb = (int)Math.Ceiling((waittime - a*20) / 1000f);
                    Thread.Sleep(20);
                    curAverageBPM = 0;
                    for (int i = 0; i< 4; i++)
                    {
                        allData[i, a] = curData[i];
                        curData[i] = 0;
                        if (a >= 10)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                curAverageBPM += allData[i, a - j];
                            }
                        }
                    }
                    for (int i = 0; i < 99; i++)
                    {
                        prevAverageBPM[i] = prevAverageBPM[i+1];
                    }
                    prevAverageBPM[99] = curAverageBPM;
                    curAverageBPM = prevAverageBPM.Average() * 15 * 5 / 4;
                    this.hideTip(tempb.ToString() + " seconds remaining", Math.Round(curAverageBPM,1)+"bpm",(int)Math.Ceiling((double)(a *100* 20/waittime)));
                    curAverageBPM = curAverageBPM * 75f / 4f;
                    a += 1;
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
                if (isRunning)
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
                if (isRunning)
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
                if (isRunning)
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
                        if (!keys[0])
                        {
                            keys[0] = true;
                            curData[0]++;
                        }
                    }
                    else if ((textBox2.Text != "") && (az.Equals(textBox2.Text[0].ToString().ToUpper())))
                    {
                        if (!keys[1])
                        {
                            keys[1] = true;
                            curData[1]++;
                        }
                    }
                    else if ((textBox3.Text != "") && (az.Equals(textBox3.Text[0].ToString().ToUpper())))
                    {
                        if (!keys[2])
                        {
                            keys[2] = true;
                            curData[2]++;
                        }
                    }
                    else if ((textBox4.Text != "") && (az.Equals(textBox4.Text[0].ToString().ToUpper())))
                    {
                        if (!keys[3])
                        {
                            keys[3] = true;
                            curData[3]++;
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
                        keys[0] = false;
                    }
                    else if ((textBox2.Text != "") && (az.Equals(textBox2.Text[0].ToString().ToUpper())))
                    {
                        keys[1] = false;
                    }
                    else if ((textBox3.Text != "") && (az.Equals(textBox3.Text[0].ToString().ToUpper())))
                    {
                        keys[2] = false;
                    }
                    else if ((textBox4.Text != "") && (az.Equals(textBox4.Text[0].ToString().ToUpper())))
                    {
                        keys[3] = false;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
