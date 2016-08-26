using System;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.FitnessPractice.Models;

namespace VelocityCoders.FitnessPractice.DAL
{
    //== STEP 3.1: THE METHOD IS INVOKED AND THE CODE EXECUTION BEGINS IN THIS DAL CLASS
    //== DEPENDING ON THE METHOD INVOKED
    public class PersonDAL
    {
        #region GET_ITEM
        //== THIS METHOD IS OF A PERSON CLASS DATA TYPE AND HAS A PARAMETER SIGNATURE OF INT
        public static Person GetItem(int personId)
        {
            //== A NULL INSTANCE OF PERSON OBJECT IS CREATED; THIS ALLOWS TMPITEM TO HAVE PERSON MEMBERS/PROPERTIES
            //== THAT ARE RETURNED TO THE CALLING METHOD LATER
            Person tmpItem = null;

            //== A CLASS THAT HAS METHODS AND PROPERTIES TO CONNECT TO SQL-SERVER IS INSTANTIATED HERE
            //== THE INSTANTIATION OF THE CLASS IS ACCEPTING A STRING PARAMETER
            //== THE PARAMETER IS REFERRING TO ANOTHER CLASS WITH A PROPERTY OF CONNECTIONSTRING THAT CONTAINS CREDENTIALS TO ENABLE CONNECTION TO SQL-SERVER
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                //== THEN AN OBJECT OF CLASS SQLCOMMAND IS INSTANTIATED WITH TWO PARAMETERS
                //== THE FIRST IS THE NAME OF THE STORED-PROCEDURE THAT WILL USED
                //== WHILE THE SECOND IS THE STRING VALUES OF MYCONNECTION - WHICH CONTAINS CREDENTIALS TO ACCESS SQL-SERVER
                using (SqlCommand myCommand = new SqlCommand("usp_GetPerson", myConnection))
                {
                    //== THIS SETS THE COMMANDTYPE PROPERTY TO AN ENUM OF COMMANDTYPE FOR STORED_PROCEDURE
                    myCommand.CommandType = CommandType.StoredProcedure;
                    //== THIS SETS AND ADDS THE PARAMETERS OF QUERYID AND PERSONID INTO A COLLECTION OBJECT
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetItem);
                    myCommand.Parameters.AddWithValue("@PersonId", personId);

                    //== THIS INVOKES THE SQLCONNECTION METHOD OF OPEN TO CONNECTION WITH SQL-SERVER
                    myConnection.Open();
                    //== EXECUTE READER IS THEN INVOKED; LOADING/PARSING PERMISSION RIGHTS TO A VARIBALE OF MYREADER OF SQLDATAREADER TYPE
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        //== MYREADER INSTANCE OF CLASS SQLDATAREADER THAN INVOKES READ METHOD
                        //== IF THERE ARE ROWS TO READ, THE IF STATEMENT EVALUATES TO TRUE
                        //== IF NOT, THE IF STATMENT EVALUATES TO FALSE AND SKIPS THE CODE BLOCK
                        if(myReader.Read())
                        {
                            //== THE VARIABLE OF PERSON TYPE IS USED HERE SO THAT THE OBJECT IS
                            //== AVAILABLE TO ITS DECLARATION SCOPE
                            //== THE METHOD FILLDATA RECORD IS INVOKED HERE PASSING IN VALUES OF
                            //== MYREADER.
                            tmpItem = FillDataRecord(myReader);
                            //== DATA OF THE REQUESTED PERSON ID IS THEN RETURNED AND ASSIGNED TO TMPITEM OF PERSON TYPE
                        }
                        //== THE CLOSE METHOD IS THEN INVOKED; CLOSING THE CONNECTION TO SQL-SERVER
                        myReader.Close();
                    }
                }
            }
            //== THE OBJECT WITH PROPERTY VALUES OF THE PERSONID ARE NOW RETURNED TO THE CALLING NETHOD IN THE .CS FILE
            return tmpItem;
        }
        #endregion

        #region GET_COLLECTION
        public static PersonCollectionList GetCollection()
        {
            PersonCollectionList tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetPerson", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", QuerySelectType.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.HasRows)
                        {
                            tmpList = new PersonCollectionList();
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

        #region HELPER METHOD THAT SETS PROPERTIES USING DATA FROM SQL SERVER INTO A NEW OBJECT OF CLASS TYPE (I.E. PERSON)
        //== MYDATARECORD PARAMETER IS THEN DEFINED IN THIS METHOD AS IDATARECORD INTERFACE TYPE
        public static Person FillDataRecord(IDataRecord myDataRecord)
        {
            //== A NEW OBJECT OF PERSON TYPE IS THEN INSTANTIATED AND CREATED
            Person myPersonObject = new Person();
            //== THE PROPERTY PERSONID OF THE NEW INSTANCE OF PERSON OBJECT IS SET
            myPersonObject.personId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PersonId"));

            //== IF STATEMENT IS USED HERE TO CHECK WHETHER DATA EXISTS; IF TRUE, SET THE PROPERTY
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FirstName")))
                myPersonObject.firstName = myDataRecord.GetString(myDataRecord.GetOrdinal("FirstName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LastName")))
                myPersonObject.lastName = myDataRecord.GetString(myDataRecord.GetOrdinal("LastName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DisplayFirstName")))
                myPersonObject.displayFirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("DisplayFirstName"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Gender")))
                myPersonObject.gender = myDataRecord.GetString(myDataRecord.GetOrdinal("Gender"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("BirthDate")))
                myPersonObject.BirthDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("BirthDate"));

            //== RETURNS THE PERSON OBJECT TO THE CALLING METHOD
            return myPersonObject;
        } 

        #endregion

    }
}
