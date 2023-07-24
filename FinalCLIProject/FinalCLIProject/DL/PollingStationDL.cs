using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalCLIProject.BL;
using FinalCLIProject.UI;
namespace FinalCLIProject.DL
{
    class PollingStationDL
    {
        private static List<PollingStation> pollingStations = new List<PollingStation>();
        public static void AddPs(PollingStation ps)
        {
            pollingStations.Add(ps);
        }
        public static List<PollingStation> getPollingStations()
        {
            return pollingStations;
        }
        public static void deletePs(int index)
        {
            pollingStations.RemoveAt(index);
        }
        public static void updatePs(PollingStation update, int index)
        {
            pollingStations.Insert(index, update);
            updatePsFile();
        }
        public static void updatePsFile()
        {
            string path = "PSfile.txt";
            StreamWriter file = new StreamWriter(path, false);
            for (int idx = 0; idx < pollingStations.Count; idx++)
            {
                file.WriteLine(pollingStations[idx].getName() + "," + pollingStations[idx].getCode() + "," + pollingStations[idx].getArea());
            }
            file.Flush();
            file.Close();
        }
        
        public static void storeToPsFile(PollingStation p)
        {
            string path = "PSfile.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(p.getName() + "," + p.getCode() + "," + p.getArea());
            file.Flush();
            file.Close();

        }
       
        public static void loadDatafromPsfile()
        {
            string path = "PSfile.txt";
            string name, code, area;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length >= 3)
                    {
                        name = data[0];
                        code = data[1];
                        area = data[2];
                        PollingStation p = new PollingStation(name, code, area);
                        pollingStations.Add(p);
                    }

                }
            }
        }
        public static bool validPS(string PsName, string PsCode)
        {
            bool flag = true;
            for (int index = 0; index < pollingStations.Count; index++)
            {
                if (PsName == pollingStations[index].getName() && PsCode == pollingStations[index].getCode())
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public static int indexOfPs(string p)
        {
            int index = -1;
            for (int idx = 0; idx < pollingStations.Count; idx++)
            {
                if (pollingStations[idx].getName() == p)
                {
                    index = idx;
                    break;
                }
            }
            return index;
        }
        public static PollingStation searchPs(string name)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (PollingStation p in pollingStations)
            {
                if (p.getName() == name)
                {
                    return p;
                }
            }
            return null;

        }
    }
}
