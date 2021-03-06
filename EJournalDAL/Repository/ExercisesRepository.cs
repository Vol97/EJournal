using Dapper;
using EJournalDAL.Models;
using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace EJournalDAL.Repository
{
    public class ExercisesRepository: IExercisesRepository
    {
        string connectionString;
        public ExercisesRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["EJournalDB"].ToString();
        }

        public int AddExerciseToStudent(ExerciseDTO exerciseDTO, DataTable dt)
        {
            string command = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}]";

            var parameters = new DynamicParameters();
            parameters.Add("@IdGroup", exerciseDTO.IdGroup);
            parameters.Add("@Description", exerciseDTO.Description);
            parameters.Add("@ExerciseType", exerciseDTO.ExerciseType);
            parameters.Add("@Deadline", exerciseDTO.Deadline);
            parameters.Add("@StudentExerciseVariable", dt.AsTableValuedParameter("[EJournal].[StudentExercise]"));
            parameters.Add("@IdExercise", DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }

            return parameters.Get<int>("@IdExercise");
        }

        public void UpdateStudentExercise(ExerciseDTO exerciseDTO, DataTable dt)
        {
            string command = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}]";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", exerciseDTO.Id);
            parameters.Add("@IdGroup", exerciseDTO.IdGroup);
            parameters.Add("@Description", exerciseDTO.Description);
            parameters.Add("@ExerciseType", exerciseDTO.ExerciseType);
            parameters.Add("@Deadline", exerciseDTO.Deadline);
            parameters.Add("@StudentExercise", dt.AsTableValuedParameter("[EJournal].[StudentExercise]"));

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(command, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<ExerciseDTO> GetExercisesByGroup (int IdGroup)
        {
            string command = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @IdGroup";
            List<ExerciseDTO> exercisesDTO = new List<ExerciseDTO>();

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Query<ExerciseDTO, StudentExerciseDTO, ExerciseDTO>(command,

                    (exercise, student) =>
                    {
                        ExerciseDTO currentExercise = null;
                        
                        foreach (var exerciseDTO in exercisesDTO)
                        {
                            if (exerciseDTO.Id == exercise.Id)
                            {
                                currentExercise = exerciseDTO;
                                break;
                            }
                        }

                        if (currentExercise is null)
                        {
                            currentExercise = exercise;
                            exercisesDTO.Add(exercise);
                            currentExercise.StudentsExercisesDTO = new List<StudentExerciseDTO>();
                        }

                        if (student != null)
                        {
                            currentExercise.StudentsExercisesDTO.Add(student);
                        }

                        return currentExercise;
                    },
                    splitOn: "Id, IdStudent"
                    , param: new { IdGroup });
            }

            return exercisesDTO;
        }

        public void DeleteStudentExercise(int id)
        {
            string command = $"[EJournal].[{MethodBase.GetCurrentMethod().Name}] @Id";

            using(IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute(command, new { id });
            }
        }
    }
}

