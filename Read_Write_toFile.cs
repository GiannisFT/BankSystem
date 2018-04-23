using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankSystem
{
    class Read_Write_toFile
    {
        public string[,] ReadFile(string filepath)
        {
            string whole_file = File.ReadAllText(filepath);
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int num_rows = lines.Length;
            int num_cols = lines[0].Split(',').Length;
            string[,] values = new string[num_rows, num_cols];
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }
            return values;
        }

        public static void WriteFile(string filepath, string[,] updatedArray)
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                for (int x = 0; x < updatedArray.GetLength(0); x++)
                {
                    string content = "";
                    for (int y = 0; y < updatedArray.GetLength(1); y++)
                    {
                        // Append content variable with column content and add a comma as a delimiter
                        content += updatedArray[x, y].ToString() + ",";
                    }
                    // Trim the last comma to avoid an ever growing amount of columns resulting in errors
                    if (content.Length > 1)
                    {
                        content = content.TrimEnd().Substring(0, content.Length - 1);
                        sw.WriteLine(content);
                    }
                }
            }
        }
    }
}
