using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    class Model
    {
        private SqlConnection connectSQL;

        public Model()
        {
            FileStream SettingsFile = new FileStream("settings.txt", FileMode.Open);
            StreamReader reader = new StreamReader(SettingsFile);
            String connectString = reader.ReadToEnd();
            connectSQL = new SqlConnection(connectString);
            connectSQL.Open();
            connectSQL.Close();
        }

        public String[] GetStatusBoxFilling()
        {
            SqlCommand cmd = new SqlCommand("SelectStatus", connectSQL);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            List<String> result = new List<String>();

            connectSQL.Open();

            var SelectResult = cmd.ExecuteReader();
            while (SelectResult.Read())
            {
                result.Add(SelectResult.GetString(0));
            }

            connectSQL.Close();
            return result.ToArray<String>();
        }

        public String[] GetDepsBoxFilling()
        {
            SqlCommand cmd = new SqlCommand("SelectDeps", connectSQL);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            List<String> result = new List<String>();

            connectSQL.Open();

            var SelectResult = cmd.ExecuteReader();
            while (SelectResult.Read())
            {
                result.Add(SelectResult.GetString(0));
            }

            connectSQL.Close();
            return result.ToArray<String>();
        }

        public String[] GetPostsBoxFilling()
        {
            SqlCommand cmd = new SqlCommand("SelectPosts", connectSQL);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            List<String> result = new List<String>();

            connectSQL.Open();
            var SelectResult = cmd.ExecuteReader();
            while (SelectResult.Read())
            {
                result.Add(SelectResult.GetString(0));
            }

            connectSQL.Close();
            return result.ToArray<String>();
        }

        public DataSet GetPersonsTable(String status, String dep, String post, String secondName)
        {
            SqlCommand cmd = new SqlCommand("SelectPersons", connectSQL);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.SelectCommand.Parameters.AddWithValue("@stat", status);
            da.SelectCommand.Parameters.AddWithValue("@dep", dep);
            da.SelectCommand.Parameters.AddWithValue("@post", post);
            da.SelectCommand.Parameters.AddWithValue("@second_name", secondName);

            DataSet result = new DataSet();
            
            connectSQL.Open();

            da.Fill(result);

            connectSQL.Close();
            
            return result;
        }

        public DataSet GetStatisticTable(DateTime dateStart, DateTime dateEnd, bool employs)
        {
            SqlCommand cmd;
            if (employs)
            {
                cmd = new SqlCommand("StatisticEmploy", connectSQL);
            }
            else
            {
                cmd = new SqlCommand("StatisticUnemploy", connectSQL);
            }

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.SelectCommand.Parameters.AddWithValue("@date1", dateStart);
            da.SelectCommand.Parameters.AddWithValue("@date2", dateEnd);

            DataSet result = new DataSet();

            connectSQL.Open();

            da.Fill(result);

            connectSQL.Close();

            return result;
        }
    }
}
