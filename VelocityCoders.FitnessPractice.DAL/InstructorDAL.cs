using System;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.FitnessPractice.Models;

namespace VelocityCoders.FitnessPractice.DAL
{
    public class InstructorDAL
    {
        #region GET_ITEM
        public static Instructor GetItem(int instructorId)
        {
            Instructor tmpItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetInstructor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetItem);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorId);

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
        public static Instructor GetCollection()
        {
            Instructor tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetInstructor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpList = new Instructor();
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

        #region HELPER METHOD | ASSIST THE RETRIEVAL OF DATA FROM SQL-SERVER DATABASE

        public static Instructor FillDataRecord(IDataRecord myDataRecord)
        {
            Instructor myObject = new Instructor();
            myObject.InstructorId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("InstructorId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("PersonId")))
                myObject.PersonId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PersonId"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HireDate")))
                myObject.HireDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("HireDate"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("TermDate")))
                myObject.TermDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("TermDate"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Description")))
                myObject.Description = myDataRecord.GetString(myDataRecord.GetOrdinal("Description"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CreateDate")))
                myObject.CreateDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("CreateDate"));

            return myObject;

        }
        #endregion
    }
}
