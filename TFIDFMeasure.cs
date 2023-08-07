/*
 * tf/idf implementation 
 * Author: Thanh Dao, thanh.dao@gmx.net
 */
using System;
using System.Collections;


namespace ServiceRanking
{
	/// <summary>
	/// Summary description for TF_IDFLib.
	/// </summary>
    public class TFIDFMeasure
    {
        private int[] pfreqvent;
        private int[] sfreqvent; 
        private int[][] pvector;
        private int[][] svector;
        private string[] _docs;
        private string sdocs;
        private string pdocs;
        private int _numDocs = 0;
        private int _pnumTerms = 0;
        private int _snumTerms = 0;
        private ArrayList set;
        private ArrayList _pterms;
        private ArrayList _fpterms;
        private ArrayList _sterms;
        private ArrayList _fsterms;


      
        public string[] TFIDFMeasur(string doc0, string docs1)
        {
            pdocs = doc0;
            sdocs = docs1;
            MyInit();
            return ideamining();
        }

       
        private void MyInit()
        {
            _pterms = GenerateTerms(pdocs);
            _sterms = GenerateTerms(sdocs);
            _fpterms = GenerateTerms1(pdocs);
            _fsterms = GenerateTerms1(sdocs);
            _pnumTerms = _pterms.Count;
            _snumTerms = _sterms.Count;
            svector = GenerateTermVector(_sterms, _fsterms);
            pvector = GenerateTermVector(_pterms, _fpterms);

        }
        private ArrayList GenerateTerms(string docs)
        {
            ArrayList uniques = new ArrayList();
            Tokeniser tokenizer = new Tokeniser();
            string[] words = tokenizer.Partition(docs);

            for (int j = 0; j < words.Length; j++)
                uniques.Add(words[j]);
            return uniques;
        }
        private ArrayList GenerateTerms1(string docs)
        {
            ArrayList uniques = new ArrayList();
            Tokeniser tokenizer = new Tokeniser();
            string[] words = tokenizer.Partition1(docs);

            for (int j = 0; j < words.Length; j++)
                uniques.Add(words[j]);

            return uniques;
        }
        private string[] ideamining() 
        {
            string[] result = new string[_fsterms.Count]; 
            int[] finalvector=new int[_fsterms.Count];
            pfreqvent = GetTermFrequency(_fpterms);
            sfreqvent = GetTermFrequency(_fsterms);
            int[][] similar = GetSimilarity(svector, pvector);
            int[] character = Getcharacter(set);
            for (int i = 0; i < _fsterms.Count; i++)
            {
                finalvector[i] = 0;
                double q = 0;
                double p = 0;
                double m1 = 0;
                double m2 = 0;
                double r = 0;
                double s = 0;
                double z = 0;
                double m3 = 0;
                double m = 0;
                double t = 0;
                double m4 = 0;
                for(int k=0;k<_fpterms.Count;k++)
                    if(similar[i][k]==1)
                    {
                for (int j = 0; j < set.Count; j++)
                {
                    
                    p += svector[i][j];
                    q += svector[i][j] * pvector[k][j];
                    r += svector[i][j] * pvector[k][j] * pfreqvent[j];
                    z += svector[i][j] * sfreqvent[j];
                    s += svector[i][j] * pvector[k][j] * sfreqvent[j];
                    t += svector[i][j] * character[j];
                }
                s = z - s;
                if (q >=(p / 2)&& p!=0 )
                    m1 = (2 * (p - q)) / p;
                else if(p!=0)
                    m1 = 2 * q / p;
                if(q!=0)
                m2 = r / q;
                if(p-q!=0)
                m3 = s / (p - q);
            if (t > 0)
                m4 = 1;
            else
                m4 = 0;
            if(p!=q)
                m = (50 * m1) + (20 * m2) + (20 * m3)+(10*m4);
                if (m>62)
                    finalvector[i] = 1;
                    }

            }
            for (int i = 0; i <_fsterms.Count; i++)
            {
                if (finalvector[i] == 1)
                {
                    int k=0;
                    int l = i;
                    for (int j = 0; j <= i; j++)
                        if (_fsterms[j].ToString() == _fsterms[i].ToString())
                            k += 1;
                    for (int j = 0; j <_sterms.Count-1 && k>1; j++)
                        if (_sterms[j].ToString() == _fsterms[i].ToString())
                        {
                            k -= 1;
                            l = j;
                        }
                    for (int j = l; j < l + 10 && j < _sterms.Count; j++)
                        result[i] = result[i] + " " + _sterms[j].ToString();
                    for (int j = l-1; j > l - 10 && j>0; j--)
                        result[i] = _sterms[j].ToString() + " " + result[i];
                }
                else
                    result[i]="";
            }

            return result;
        }
        
        private int[][] GenerateTermVector(ArrayList terms, ArrayList fterms)
        {
            set=new ArrayList();

            for (int i = 0; i < _fsterms.Count; i++)
                if (!set.Contains(_fsterms[i].ToString()))				
                    set.Add(_fsterms[i].ToString());
            int[][] vector = new int[fterms.Count][];
            int z = 0;
            for (int i = 0; i < fterms.Count; i++)
                vector[i] = new int[set.Count];
            for (int i = 0; i < terms.Count && z < fterms.Count; i++)
            {
                if (!StopWordsHandler.IsStopword(terms[i].ToString()))
                {
                    for (int j = 0; j < set.Count; j++)
                        vector[z][j] = 0;
                    double k = 0;
                    int p = i;
                    while (k <= 7 && p < terms.Count)
                    {
                        if (!StopWordsHandler.IsStopword(terms[p].ToString()))
                        {
                            for (int y = 0; y < set.Count; y++)
                                if (terms[p].ToString() == set[y].ToString())
                                    vector[z][y] = 1;
                                p += 1;
                                k += 1;
                                //r += 1;
                        }
                        else
                        {
                            p += 1;
                            k += 0.5;
                        }
                    }
                    k = 0;
                    p = i-1 ;
                    while (p >= 0 && k <= 7 )
                    {
                        if (!StopWordsHandler.IsStopword(terms[p].ToString()))
                        {
                            for (int y = 0; y < set.Count; y++)
                                if (terms[p].ToString() == set[y].ToString())
                                    vector[z][y] = 1;
                            p -= 1;
                            k += 1;
                        }
                        else
                        {
                            p -= 1;
                            k += 0.5;
                        }
                    }
                    z += 1;
                }
            }
            return vector;
        }
        private int[] Getcharacter(ArrayList fterms)
        {
            int[] character = new int[fterms.Count];
            for (int i = 0; i < fterms.Count; i++){
                if(characteristic.Ischaracteristic(fterms[i].ToString()))
                character[i] = 1;
                else
                character[i] = 0;
            }

            return character;
        }

        private int[] GetTermFrequency(ArrayList fterms)
        {
            int[] freqterm=new int[fterms.Count];
            int[] freqvector = new int[set.Count];
            for (int i = 0; i < fterms.Count; i++)
                freqterm[i] = 0;
            for (int i = 0; i < set.Count; i++)
                freqvector[i] = 0;
            for (int i = 0; i < fterms.Count; i++)
                for (int j = 0; j < fterms.Count; j++)
                    if (fterms[i].ToString() == fterms[j].ToString())
                        freqterm[i] += 1;
            for (int i = 0; i < (fterms.Count) * 20 / 100; i++)
            {
                int max = 0;
                int k = 0;
                for (int j = 0; j < fterms.Count; j++)
                    if (freqterm[j] > max)
                    {
                        max = freqterm[j];
                        k = j;
                    }
                for (int z = 0; z <fterms.Count; z++)
                {
                    if (z<set.Count){
                        if(set[z].ToString() == fterms[k].ToString())
                    {
                        freqvector[z] = 1;
                        freqterm[z] = 0;
                    }
                    }
                    if (fterms[z].ToString() == fterms[k].ToString())
                       freqterm[z] = 0;
                }
            }

            return freqvector;
        }

        public int[][] GetSimilarity(int[][] vector0, int[][] vector1)
        {
            int[][] similar = new int[_fsterms.Count][];
            for(int i=0 ; i<_fsterms.Count;i++)
                similar[i]=new int[_fpterms.Count];
            for (int i = 0; i < _fsterms.Count; i++)
            {
                double minresult = 1000;
                for (int j = 0; j < _fpterms.Count; j++)
                {
                    similar[i][j] = 0;
                    double result = 0;
                    for (int k = 0; k < set.Count; k++)
                        result +=Math.Pow((double)(vector0[i][k]-vector1[j][k]),2);
                    result = Math.Sqrt(result);
                    if (result < minresult )
                        minresult = result;
                }
                for (int j = 0; j < _fpterms.Count; j++)
                {
                    double result = 0;
                    for (int k = 0; k < set.Count; k++)
                        result += Math.Pow((double)(vector0[i][k] - vector1[j][k]), 2);
                    result = Math.Sqrt(result);
                    if (result == minresult)
                        similar[i][j] = 1;
                }
            }
            return similar;
           
        }

    }
}
