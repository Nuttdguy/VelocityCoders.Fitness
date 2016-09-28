using VelocityCoders.FitnessPractice.Models;
using System.Data;
using System.Data.SqlClient;

namespace VelocityCoders.FitnessPractice.DAL
{
    public static class StateDAL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET ITEM | BY STATE-ID =======||
        public static State GetItem(int stateId)
        {
            State tmpItem = new State();

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetState", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetItem);
                    myCommand.Parameters.AddWithValue("StateId", stateId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            tmpItem = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tmpItem;
        }

        #endregion

        #endregion

        #region SECTION 2 ||=======  GET COLLECTION  =======||

        #region ||=======  GET COLLECTION | ALL =======||
        public static StateCollection GetCollection()
        {
            StateCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetState", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpCollection = new StateCollection();
                            while (myReader.Read())
                            {
                                tmpCollection.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tmpCollection;             
        }

        #endregion

        #endregion

        #region SECTION 3 ||=======  INSERT OR UPDATE ITEM  =======||

        #region ||========  INSERT ITEM | BY STATE-ID =======||
        public static int SaveItem(State stateObj)
        {
            int result = 0;
            ExecuteEnum queryId = ExecuteEnum.InsertItem;

            if (stateObj.StateId > 0)
                queryId = ExecuteEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteState", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (stateObj.StateId > 0)
                        myCommand.Parameters.AddWithValue("@StateId", stateObj.StateId);
                    if (!string.IsNullOrEmpty(stateObj.StateName))
                        myCommand.Parameters.AddWithValue("@StateName", stateObj.StateName);
                    if (!string.IsNullOrEmpty(stateObj.StateAbbreviation))
                        myCommand.Parameters.AddWithValue("@StateAbbreviation", stateObj.StateAbbreviation);
                    if (!string.IsNullOrEmpty(stateObj.ShortName))
                        myCommand.Parameters.AddWithValue("@ShortName", stateObj.ShortName);

                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return result;
        }
        #endregion

        #endregion

        #region SECTION 4 ||=======  DELETE ITEM  =======||

        #region ||========  DELETE ITEM | BY STATE-ID  =======||
        public static int DeleteItem(int stateId)
        {
            int deletedItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteState", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@StateId", stateId);
                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    deletedItem = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return deletedItem;
        }
        #endregion

        #endregion


        #region SECTION 3 ||=======  HYDRATE OBJECT  =======||
        public static State FillDataRecord(IDataReader myReader)
        {
            State tmpObj = new State();

            tmpObj.StateId = myReader.GetInt32(myReader.GetOrdinal("StateId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("StateName")))
                tmpObj.StateName = myReader.GetString(myReader.GetOrdinal("StateName"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("ShortName")))
                tmpObj.ShortName = myReader.GetString(myReader.GetOrdinal("ShortName"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("StateAbbreviation")))
                tmpObj.StateAbbreviation = myReader.GetString(myReader.GetOrdinal("StateAbbreviation"));

            return tmpObj;
        }

        #endregion

    }
}
