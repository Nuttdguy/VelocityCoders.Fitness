using System;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.FitnessPractice.Models;


namespace VelocityCoders.FitnessPractice.DAL
{
    public class FitnessClassDAL
    {
        #region GET_ITEM
        public static FitnessClass GetItem(int fitnessClassId)
        {
            FitnessClass tmpItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetFitnessClass", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetItem);
                    myCommand.Parameters.AddWithValue("@FitnessClassId", fitnessClassId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            tmpItem = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                }
            }
            return tmpItem;
        }
        #endregion


        #region GET_COLLECTION
        public static FitnessClassCollectionList GetCollection()
        {
            FitnessClassCollectionList tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetFitnessClass", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.HasRows)
                        {
                            tmpList = new FitnessClassCollectionList();
                            while (myReader.Read())
                            {
                                tmpList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
            }
            return tmpList;
        }

        #endregion


        #region HELPER METHOD
        public static FitnessClass FillDataRecord(IDataReader myDataRecord)
        {
            FitnessClass myObject = new FitnessClass();
            myObject.FitnessClassId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("FitnessClassId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FitnessClassName")))
                myObject.FitnessClassName = myDataRecord.GetString(myDataRecord.GetOrdinal("FitnessClassName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Description")))
                myObject.Description = myDataRecord.GetString(myDataRecord.GetOrdinal("Description"));

            return myObject;
        }
        #endregion
    }


}
