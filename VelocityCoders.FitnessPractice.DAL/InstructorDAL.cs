using System;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.FitnessPractice.Models;

namespace VelocityCoders.FitnessPractice.DAL
{
    public class InstructorDAL
    {

        #region DELETE INSTRUCTOR FROM TABLE
        public static bool Delete(int instructorId)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteInstructor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QueryExecuteType.DeleteItem);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return result > 0;
        }

        #endregion

        #region INSERT AND/OR UPDATE RECORD | RETURN INT VALUE OF AFFECTED RECORD
        public static int Save(Instructor instructorToSave)
        {
            int result = 0;
            QueryExecuteType queryId = QueryExecuteType.InsertItem;

            if (instructorToSave.InstructorId > 0)
                queryId = QueryExecuteType.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteInstructor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorToSave.InstructorId);
                    myCommand.Parameters.AddWithValue("@PersonId", instructorToSave.PersonId);

                    if (instructorToSave.HireDate != DateTime.MinValue)
                        myCommand.Parameters.AddWithValue("@HireDate", instructorToSave.HireDate.ToShortDateString());
                    if (instructorToSave.TermDate != DateTime.MinValue)
                        myCommand.Parameters.AddWithValue("@TermDate", instructorToSave.TermDate.ToShortDateString());
                    if (instructorToSave.Description != null)
                        myCommand.Parameters.AddWithValue("@Description", instructorToSave.Description);

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

        #region GET_ITEM | RETURN ROW RECORD
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

        #region GET_COLLECTION | INSTRUCTOR ENTITY ONLY
        public static InstructorCollectionList GetCollection()
        {
            InstructorCollectionList tmpList = null;

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
                            tmpList = new InstructorCollectionList();
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

        #region GET_COLLECTION | INSTRUCTOR AND PERSON
        public static InstructorCollectionList GetCollection(QuerySelectType queryId)
        {
            InstructorCollectionList tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetInstructor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpList = new InstructorCollectionList();
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

            //==== Person properties
            myObject.PersonId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PersonId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FirstName")))
                myObject.FirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("FirstName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LastName")))
                myObject.LastName = myDataRecord.GetString(myDataRecord.GetOrdinal("LastName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DisplayFirstName")))
                myObject.DisplayFirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("DisplayFirstName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Gender")))
                myObject.Gender = myDataRecord.GetString(myDataRecord.GetOrdinal("Gender"));

            //==== Instructor properties
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("InstructorId")))
                myObject.InstructorId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("InstructorId"));
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
