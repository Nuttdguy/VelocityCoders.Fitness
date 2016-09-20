using VelocityCoders.FitnessPractice.Models;
using System.Data;
using System.Data.SqlClient;

namespace VelocityCoders.FitnessPractice.DAL
{
    public static class GymDAL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET ITEM | BY GYM-ID  =======||
        public static Gym GetItem(int gymId)
        {
            Gym tmpItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetGym", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@GymId", gymId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpItem = new Gym();
                            while (myReader.Read())
                            {
                                tmpItem = FillDataRecord(myReader);
                            }
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

        #region ||=======  GET COLLECTION | ALL  =======||
        public static GymCollection GetCollection()
        {
            GymCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetGym", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpCollection = new GymCollection();
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

        #region ||========  INSERT ITEM | BY GYM-ID  =======||
        public static int SaveItem(int gymId, Gym gymObj)
        {
            int result;
            ExecuteEnum queryId = ExecuteEnum.InsertItem;

            if (queryId > 0)
                queryId = ExecuteEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteGym", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (gymObj.GymId > 0)
                        myCommand.Parameters.AddWithValue("@LocationId", gymObj.GymId);
                    if (!string.IsNullOrEmpty(gymObj.Name))
                        myCommand.Parameters.AddWithValue("@Name", gymObj.Name);
                    if (!string.IsNullOrEmpty(gymObj.Abbreviation))
                        myCommand.Parameters.AddWithValue("@Abbreviation", gymObj.Abbreviation);
                    if (!string.IsNullOrEmpty(gymObj.Description))
                        myCommand.Parameters.AddWithValue("@Description", gymObj.Description);
                    if (!string.IsNullOrEmpty(gymObj.Website))
                        myCommand.Parameters.AddWithValue("@Website", gymObj.Website);

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

        #region ||=======  DELETE ITEM | BY GYM-ID  =======||
        public static int DeleteItem(int gymId)
        {
            int deletedItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteGym", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@GymId", gymId);
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

        #region SECTION 5 ||=======  HYDRATE OBJECT  =======||
        public static Gym FillDataRecord(IDataReader myReader)
        {
            Gym tmpObj = new Gym();

            tmpObj.GymId = myReader.GetInt32(myReader.GetOrdinal("GymId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("Name")))
                tmpObj.Name = myReader.GetString(myReader.GetOrdinal("Name"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("Abbreviation")))
                tmpObj.Abbreviation = myReader.GetString(myReader.GetOrdinal("Abbreviation"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("Description")))
                tmpObj.Description = myReader.GetString(myReader.GetOrdinal("Description"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("Website")))
                tmpObj.Website = myReader.GetString(myReader.GetOrdinal("Website"));

            return tmpObj;
        }

        #endregion

    }
}
