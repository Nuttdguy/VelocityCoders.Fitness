using System.Data;
using System.Data.SqlClient;
using VelocityCoders.FitnessPractice.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessPractice.DAL
{
    public class EntityTypeDAL
    {

        #region SECTION 1 ||=======  GET_ITEM | BY ENTITY-TYPE-ID  =======||
        public static EntityType GetItem(int entityTypeId)
        {
            EntityType tmpItem = null;

            using (SqlConnection myConnect = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntityType", myConnect))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@EntityTypeId", entityTypeId);

                    myConnect.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        tmpItem = new EntityType();
                        if(myReader.Read())
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

        #region SECTION 2 ||=======  GET_COLLECTION | BY ENTITY-ENUM/EMPLOYEE-TYPE  =======||
        public static EntityTypeCollectionList GetCollection(EntityIdEnum employeeType, SelectEnum entityType)
        {
            EntityTypeCollectionList tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", entityType);
                    myCommand.Parameters.AddWithValue("@EntityId", employeeType);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpList = new EntityTypeCollectionList();
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

        #region SECTION 3 ||=======  GET_COLLECTION  | BY ENTITY-ID =======||
        public static EntityTypeCollectionList GetCollection(EntityIdEnum emailType)
        {
            EntityTypeCollectionList tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetCollectionById);
                    myCommand.Parameters.AddWithValue("@EntityId", emailType);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpList = new EntityTypeCollectionList();
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

        #region SECTION 4 ||=======  GET_COLLECTION  | ALL =======||
        public static EntityTypeCollectionList GetCollection()
        {
            EntityTypeCollectionList tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.HasRows)
                        {
                            tmpList = new EntityTypeCollectionList();
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

        #region SECTION 2.1 ||=======  GET_COLLECTION | BY ENTITY-ENUM/EMPLOYEE-TYPE  =======||
        public static EntityTypeCollectionList GetCollection(int entityId)
        {
            EntityTypeCollectionList tmpList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", SelectEnum.GetCollectionById);
                    myCommand.Parameters.AddWithValue("@EntityId", entityId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tmpList = new EntityTypeCollectionList();
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

        #region SECTION 5 ||=======  INSERT ITEM | BY ENTITY-ID & ENTITY-TYPE-TO-SAVE  =======||
        public static int Save(int entityId, EntityType entityTypeToSave)
        {
            int result = 0;
            ExecuteEnum queryId = ExecuteEnum.InsertItem;

            if (entityTypeToSave.EntityTypeId > 0)
                queryId = ExecuteEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@EntityId", entityId);
                    myCommand.Parameters.AddWithValue("@EntityTypeId", entityTypeToSave.EntityTypeId);

                    if (entityTypeToSave.EntityTypeName != null)
                        myCommand.Parameters.AddWithValue("@EntityTypeName", entityTypeToSave.EntityTypeName);
                    if (entityTypeToSave.DisplayName != null)
                        myCommand.Parameters.AddWithValue("@DisplayName", entityTypeToSave.DisplayName);
                    if (entityTypeToSave.Description != null)
                        myCommand.Parameters.AddWithValue("@Description", entityTypeToSave.Description);

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

        #region SECTION 6 ||=======  DELETE  =======||
        public static bool Delete(int entityTypeId)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@EntityTypeId", entityTypeId);
                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    result = (int)myCommand.Parameters["@ReturnValue"].Value;

                }
                myConnection.Close();
            }
            return result > 0;
        }

        #endregion

        #region HELPER METHOD
        public static EntityType FillDataRecord(IDataReader myDataRecord)
        {
            EntityType myObject = new EntityType();

                myObject.EntityTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EntityTypeId"));

                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EntityId")))
                    myObject.EntityId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EntityId"));
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Description")))
                    myObject.Description = myDataRecord.GetString(myDataRecord.GetOrdinal("Description"));
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DisplayName")))
                    myObject.DisplayName = myDataRecord.GetString(myDataRecord.GetOrdinal("DisplayName"));
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EntityTypeName")))
                    myObject.EntityTypeName = myDataRecord.GetString(myDataRecord.GetOrdinal("EntityTypeName"));

            return myObject;

        }
        #endregion

    }
}
