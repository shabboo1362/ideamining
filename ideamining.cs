using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ServiceRanking
{
    public partial class ideamining : Form
    {
        public ideamining()
        {
            InitializeComponent();
        }
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ideamining());
            //StopWordsHandler stopword=new StopWordsHandler() ;
            //characteristic characteristic = new characteristic();
            //string pdoc="test b c c dd d d d d";
            //string sdoc="a b c c c d dd d d test";

            //TFIDFMeasure tf=new TFIDFMeasure() ;
            //tf.TFIDFMeasur(pdoc,sdoc);
            ///Trace.WriteLine((double)Math.Log(10000/50) ) ;
            ////Trace.WriteLine(tf.GetSimilarity(0, 1) ) ;
            ///string[] _3grams=NGram.GenerateNGrams("TEXT", 3) ;
            //
            // TODO: Add code to start application here
            //
        }

        private void problem_FileOk(object sender, CancelEventArgs e)
        {
            //string pdoc = problem;
        }

        private void newtext_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StopWordsHandler stopword = new StopWordsHandler();
            characteristic characteristic = new characteristic();

            string pdoc =problem.Text;
            string sdoc =solve.Text;

            TFIDFMeasure tf = new TFIDFMeasure();
            string[] finalresult=tf.TFIDFMeasur(pdoc, sdoc);
            for (int i = 0; i < finalresult.Length; i++)
                if(finalresult[i]!="")
                 result.Text += "\n"+finalresult[i];
            ///Trace.WriteLine((double)Math.Log(10000/50) ) ;
            ////Trace.WriteLine(tf.GetSimilarity(0, 1) ) ;
            ///string[] _3grams=NGram.GenerateNGrams("TEXT", 3) ;
            //
            // TODO: Add code to start application here
            //
        }


    }
}