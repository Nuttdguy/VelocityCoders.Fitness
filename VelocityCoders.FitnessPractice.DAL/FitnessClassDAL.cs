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

        #region GET FITNESS CLASS BY INSTRUCTOR
        public static FitnessClassCollectionList GetCollectionbyId(int instructId)
        {
            FitnessClassCollectionList tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetFitnessClass", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollectionByInstructor);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
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


        #region SECTION 3 ||=======  SAVE ITEM  =======||
        public static int SaveItem(FitnessClass fcItem)
        {
            int recordId = 0;
            QueryExecuteType query = QueryExecuteType.InsertItem;

            //if (fcItem.FitnessClassId > 0)
            //    query = QueryExecuteType.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteFitnessClass", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", query);
                    myCommand.Parameters.AddWithValue("@FitnessClassId", fcItem.FitnessClassId);
                    myCommand.Parameters.AddWithValue("@FitnessClassName", fcItem.FitnessClassName);
                    myCommand.Parameters.AddWithValue("@Description", fcItem.Description);
                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    recordId = (int)myCommand.Parameters["@ReturnValue"].Value;

                }
                myConnection.Close();
            }
            return recordId;
        }

        #endregion

        #region SECTION 4 ||=======  DELETE ITEM  =======||
        public static int DeleteItem(int fcId)
        {
            int deleteId = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteFitnessClass", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QueryExecuteType.DeleteItem);
                    myCommand.Parameters.AddWithValue("@FitnessClassId", fcId);

                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    deleteId = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return deleteId;
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

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("InstructorFitnessClassId")))
            //    myObject.InstructorFitnessClassId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("InstructorFitnessClassId"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FirstName")))
            //    myObject.FirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("FirstName"));
            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LastName")))
            //    myObject.LastName = myDataRecord.GetString(myDataRecord.GetOrdinal("LastName"));
            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("InstructorId")))
            //    myObject.InstructorId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("InstructorId"));


            return myObject;
        }
        #endregion
    }


}
