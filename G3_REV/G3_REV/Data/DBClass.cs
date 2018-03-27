using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;


namespace G3_REV.Data
{
    class DBClass :BaseServ
    {
        int result;
        public DBClass()
        {
            result = 0;
        }

        #region Process Data

        public DataTable getpro_name(int idPost, bool? isActived)
        {
            return GetDataTable("[pro_name]", idPost, isActived);
        }


        public object setpro(int autoid, string name)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@id", SqlDbType.Int),
                new SqlParameter("@name", SqlDbType.NVarChar,500),
                };
            parameters[0].Value = autoid;
            parameters[1].Value = name;
            return ExecuteScalar("[pro_name]", parameters);
        }

        #endregion
        

        #region Helper
        public virtual object ExecuteScalar(string ProcedureName, params object[] Parameters)
        {
            return SqlHelper.ExecuteScalar(dbConnString, ProcedureName, Parameters);
        }

        public virtual int ExecuteNonQuery(string ProcedureName, params object[] Parameters)
        {
            return SqlHelper.ExecuteNonQuery(dbConnString, ProcedureName, Parameters);

        }
        public virtual DataRow GetDataRow(string ProcedureName, params object[] Parameters)
        {
            return GetDataRow(0, ProcedureName, Parameters);
        }
        public virtual DataRow GetDataRow(int RowIndex, string ProcedureName, params object[] Parameters)
        {
            DataTable dt = GetDataTable(0, ProcedureName, Parameters);
            DataRow dr = null;

            if (dt != null)
            {
                if (RowIndex >= 0 && RowIndex < dt.Rows.Count)
                {
                    dr = dt.Rows[RowIndex];
                }
                dt.Dispose();
            }
            return dr;
        }
        public static DataTable GetDataTable(int TableIndex, string ProcedureName, params object[] Parameters)
        {
            DataSet ds = GetDataSet(ProcedureName, Parameters);
            DataTable dt = null;
            if (ds != null && ds.Tables.Count > 0)
            {
                if (TableIndex >= 0 && TableIndex < ds.Tables.Count)
                    dt = ds.Tables[TableIndex];

                ds.Dispose();
            }
            return dt;
        }

        public static DataTable GetDataTable(string ProcedureName, params object[] Parameters)
        {
            DataSet ds = GetDataSet(ProcedureName, Parameters);
            DataTable dt = null;
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                ds.Dispose();
            }
            return dt;
        }

        public static DataSet GetDataSet(string ProcedureName, params object[] Parameters)
        {
            //try
            //{
            return SqlHelper.ExecuteDataset(dbConnString, ProcedureName, Parameters);
            //}
            //catch
            //{
            //    return SqlHelper.ExecuteDataset(dbConnString1, ProcedureName, Parameters);
            //}
        }
        public object ExecuteScalarSQL(string sql)
        {
            return SqlHelper.ExecuteScalar(dbConnString, CommandType.Text, sql);
        }
        public object ExecuteNonQuerySQL(string sql)
        {
            return SqlHelper.ExecuteNonQuery(dbConnString, CommandType.Text, sql);
        }
        #endregion
        
    }
}
