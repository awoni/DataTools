using System;
using System.IO;

namespace TsvToSql
{
    public class Program
    {
        public void Main(string[] args)
        {
            TsvToSql("Tsv/Project.txt", "Sql/Project.txt", "Project");
            TsvToSql("Tsv/MemberProfile.txt", "Sql/MemberProfile.txt", "MemberProfile");
        }

        private void TsvToSql(string src, string destibation, string tableName)
        {
            string[] projects = File.ReadAllText(src).Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            string sql = "";
            string[] items = new string[] { };
            string[] dataType = new string[] { };
            int n = 0;

            foreach (var s in projects)
            {
                if (n == 0)
                {
                    items = s.Split('\t');
                    n++;
                }
                else if (n == 1)
                {
                    dataType = s.Split('\t');
                    n++;
                }
                else
                {
                    sql += $"INSERT INTO[dbo].[{tableName}] (";
                    foreach (var item in items)
                    {
                        sql += "[" + item.Trim() + "],";
                    }
                    sql = sql.Remove(sql.Length - 1) + ")\r\nVALUES(";
                    string[] data = s.Split('\t');
                    for (int m = 0; m < data.Length; m++)
                    {
                        if (dataType[m].Trim() == "string")
                            sql += "N'" + data[m] + "',";
                        else if (dataType[m].Contains("DateTime"))
                            sql += "'" + data[m].Replace('/', '-') + "',";
                        else
                            sql += data[m] + ",";
                    }
                    sql = sql.Remove(sql.Length - 1) + ");\r\n";
                }
            }

            File.WriteAllText(destibation, sql);
        }
    }
}
