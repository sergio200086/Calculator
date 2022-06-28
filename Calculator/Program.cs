

using System;
using System.Text.Json;




namespace Calculator
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //string JSONData = File.ReadAllText("data.txt");  // Try to read one file that contains the info

            string JSONData = @"{
	        ""Device"": ""Arista"",
	        ""Model"": ""X-Video"",
	        ""NIC"": [{
		        ""Description"": ""Linksys ABR"",
		        ""MAC"": ""14:91:82:3C:D6:7D"",
		        ""Timestamp"": ""2020-03-23T18:25:43.511Z"",
		        ""Rx"": ""3698574500"",
		        ""Tx"": ""122558800""
	        }]
	        }";

        
            var deserializedJson = JsonSerializer.Deserialize<Request>(JSONData); // Parse/Deserialize the json data
            foreach (var item in deserializedJson.NIC) //access to each NIC values, only need Rx & Tx
            {
                Console.WriteLine($"Bitrate for Rx: " + CalculateBitRate(item.Rx) + " Mb/s");
                Console.WriteLine($"Bitrate for Tx: " + CalculateBitRate(item.Tx) + " Mb/s");

            }


        }

        private static long CalculateBitRate(string octets)
        {
            long numberOctet = Int64.Parse(octets);
            long bits = (numberOctet * 8 * 2); // 8bits in one octet, 2hz   if the results is needed in MB/s, just delete the number 8
            long bitRate = bits / 1000000; //from bits to Megabits
            return bitRate;
        }


    }

    class Request
    {
        //PROPERTIES 
        public String Device { get; set; }
        public String Model { get; set; }
        public List<nic> NIC { get; set; }
    }

    class nic
    {
        //NIC PROPERTIES
        public String Desccription { set; get; }
        public String MAC { set; get; }
        public String Timestamp { set; get; }
        public String Rx { set; get; }
        public String Tx { set; get; }

    }
}