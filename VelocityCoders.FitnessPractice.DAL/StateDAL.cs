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
                using (SqlCommand myCommand = new SqlCommand("usp_GetItem", myConnection))
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
                using (SqlCommand myCommand = new SqlCommand("usp_GetCollection", myConnection))
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

        #region SECTION 3 ||=======  HYDRATE OBJECT  =======||
        public static State FillDataRecord(IDataReader myReader)
        {
            State tmpObj = new State();

            tmpObj.StateId = myReader.GetInt32(myReader.GetOrdinal("StateId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("Name")))
                tmpObj.Name = myReader.GetString(myReader.GetOrdinal("Name"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("ShortName")))
                tmpObj.ShortName = myReader.GetString(myReader.GetOrdinal("ShortName"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("Abbreviation")))
                tmpObj.Abbreviation = myReader.GetString(myReader.GetOrdinal("Abbreviation"));

            return tmpObj;
        }

        #endregion

    }
}
