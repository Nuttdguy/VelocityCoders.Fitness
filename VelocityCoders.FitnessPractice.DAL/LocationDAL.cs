using VelocityCoders.FitnessPractice.Models;
using System.Data;
using System.Data.SqlClient;

namespace VelocityCoders.FitnessPractice.DAL
{
    public static class LocationDAL
    {

        #region SECTION 1 ||=======  GET ITEM  =======||

        #region ||=======  GET ITEM | BY LOCATION-ID =======||
        public static Location GetItem(int locationId)
        {
            Location tmpItem = new Location();

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLocation", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@LocationId", locationId);

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

        #region ||=======  GET COLLECTION | ALL  =======||
        public static LocationCollection GetCollection()
        {
            LocationCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLocation", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpCollection = new LocationCollection();
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

        #region ||=======  GET COLLECTION | BY LOCATION-ID  =======||
        public static LocationCollection GetCollection(int locationId)
        {
            LocationCollection tmpCollection = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLocation", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetCollection);
                    myCommand.Parameters.AddWithValue("@LocationId", locationId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpCollection = new LocationCollection();
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

        #region ||========  INSERT ITEM | BY LOCATION-OBJ  =======||
        public static int SaveItem(Location locationObj)
        {
            int result;
            ExecuteEnum queryId = ExecuteEnum.InsertItem;

            if (queryId > 0)
                queryId = ExecuteEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLocation", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (locationObj.LocationId > 0)
                        myCommand.Parameters.AddWithValue("@LocationId", locationId);
                    if (locationObj.Gym.GymId > 0)
                        myCommand.Parameters.AddWithValue("@GymId", locationObj.Gym.GymId);
                    if (locationObj.State.StateId > 0)
                        myCommand.Parameters.AddWithValue("@StateId", locationObj.State.StateId);
                    if (!string.IsNullOrEmpty(locationObj.LocationName))
                        myCommand.Parameters.AddWithValue("@LocationName", locationObj.LocationName);
                    if (!string.IsNullOrEmpty(locationObj.Address01))
                        myCommand.Parameters.AddWithValue("@Address01", locationObj.Address01);
                    if (!string.IsNullOrEmpty(locationObj.Address02))
                        myCommand.Parameters.AddWithValue("@Address02", locationObj.Address02);
                    if (!string.IsNullOrEmpty(locationObj.City))
                        myCommand.Parameters.AddWithValue("@City", locationObj.City);
                    if (!string.IsNullOrEmpty(locationObj.ZipCode))
                        myCommand.Parameters.AddWithValue("@ZipCode", locationObj.ZipCode);
                    if (!string.IsNullOrEmpty(locationObj.ZipCodePlusFour))
                        myCommand.Parameters.AddWithValue("@ZipCodePlusFour", locationObj.ZipCodePlusFour);

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

        #region ||========  INSERT ITEM | BY LOCATION-ID =======||
        public static int SaveItem(int locationId, Location locationObj)
        {
            int result;
            ExecuteEnum queryId = ExecuteEnum.InsertItem;

            if (queryId > 0)
                queryId = ExecuteEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLocation", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (locationObj.LocationId > 0)
                        myCommand.Parameters.AddWithValue("@LocationId", locationId);
                    if (locationObj.Gym.GymId > 0)
                        myCommand.Parameters.AddWithValue("@GymId", locationObj.Gym.GymId);
                    if (locationObj.State.StateId > 0)
                        myCommand.Parameters.AddWithValue("@StateId", locationObj.State.StateId);
                    if (!string.IsNullOrEmpty(locationObj.LocationName))
                        myCommand.Parameters.AddWithValue("@LocationName", locationObj.LocationName);
                    if (!string.IsNullOrEmpty(locationObj.Address01))
                        myCommand.Parameters.AddWithValue("@Address01", locationObj.Address01);
                    if (!string.IsNullOrEmpty(locationObj.Address02))
                        myCommand.Parameters.AddWithValue("@Address02", locationObj.Address02);
                    if (!string.IsNullOrEmpty(locationObj.City))
                        myCommand.Parameters.AddWithValue("@City", locationObj.City);
                    if (!string.IsNullOrEmpty(locationObj.ZipCode))
                        myCommand.Parameters.AddWithValue("@ZipCode", locationObj.ZipCode);
                    if (!string.IsNullOrEmpty(locationObj.ZipCodePlusFour))
                        myCommand.Parameters.AddWithValue("@ZipCodePlusFour", locationObj.ZipCodePlusFour);

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

        #region ||========  DELETE ITEM | BY LOCATION-ID  =======||
        public static int DeleteItem(int locationId)
        {
            int deletedItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLocation", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@LocationId", locationId);
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
        public static Location FillDataRecord(IDataReader myReader)
        {
            Location tmpObj = new Location();

            tmpObj.LocationId = myReader.GetInt32(myReader.GetOrdinal("LocationId"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("GymName")))
                tmpObj.Gym.GymName = myReader.GetString(myReader.GetOrdinal("GymName"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("GymId")))
                tmpObj.Gym.GymId = myReader.GetInt32(myReader.GetOrdinal("GymId"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("LocationName")))
                tmpObj.LocationName = myReader.GetString(myReader.GetOrdinal("LocationName"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("Address01")))
                tmpObj.Address01 = myReader.GetString(myReader.GetOrdinal("Address01"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("Address02")))
                tmpObj.Address02 = myReader.GetString(myReader.GetOrdinal("Address02"));

            if (!myReader.IsDBNull(myReader.GetOrdinal("City")))
                tmpObj.City = myReader.GetString(myReader.GetOrdinal("City"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("ZipCode")))
                tmpObj.ZipCode = myReader.GetString(myReader.GetOrdinal("ZipCode"));
            if (!myReader.IsDBNull(myReader.GetOrdinal("ZipCodePlusFour")))
                tmpObj.ZipCodePlusFour = myReader.GetString(myReader.GetOrdinal("ZipCodePlusFour"));

            return tmpObj;
        }

        #endregion

    }
}
