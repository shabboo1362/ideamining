using System;
using System.Collections;

namespace ServiceRanking
{
	/// <summary>
	/// Stop words are frequently occurring, insignificant words words 
	/// that appear in a database record, article or web page. 
	/// Common stop words include
	/// </summary>
	public class characteristic
	{		
		public static string[] characteristicList=new string[] {

															  "higher", 																													  
															  "quicker", 
															  "integrated", 
															  "minimized", 
															  "maximized",
															   
		} ;

		private static Hashtable _characteristic=null;

		public static object AddElement(IDictionary collection,Object key, object newValue)
		{
			object element = collection[key];
			collection[key] = newValue;
			return element;
		}

		public static bool Ischaracteristic(string str)
		{
			
			//int index=Array.BinarySearch(stopWordsList, str)
            return _characteristic.ContainsKey(str.ToLower());
		}
	

		public characteristic()
		{
            if (_characteristic == null)
			{
                _characteristic = new Hashtable();
				double dummy = 0;
                foreach (string word in characteristicList)
				{
                    AddElement(_characteristic, word, dummy);
				}
			}
		}
	}
}