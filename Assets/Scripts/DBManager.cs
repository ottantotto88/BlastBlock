
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

public class DBManager 
{
    public static int ReadBestScore()
    {
        int bestScore = 0;
        //creating db connection
        string connection = "URI=file:" + Application.persistentDataPath + "/high_scores";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        IDbCommand dbcmd;
        IDataReader reader;

        dbcmd = dbcon.CreateCommand();
        string q_createTable =
          "CREATE TABLE IF NOT EXISTS scores (val INTEGER)";
        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();

        IDbCommand cmnd_read = dbcon.CreateCommand();
        string query = "SELECT * FROM scores";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        while (reader.Read())
        {
            bestScore = reader.GetInt32(0);
        }
        dbcon.Close();
        return bestScore;
        
    }

    public static void InsertBestScore(int bestScore) 
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/high_scores";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        IDbCommand delCmd;
        delCmd = dbcon.CreateCommand();
        delCmd.CommandText = "DELETE FROM scores";
        delCmd.ExecuteReader();

        IDbCommand insCmd;
        insCmd = dbcon.CreateCommand();
        insCmd.CommandText = "INSERT INTO scores(val) values(" + bestScore + ");";
        insCmd.ExecuteReader();

        dbcon.Close();
    }
}
