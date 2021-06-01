﻿using Dapper;
using EJournalDAL.Models.BaseModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EJournalDAL.Repository
{
    public class StudentsRepository
    {
        string connectionString;
        public StudentsRepository()
        {
            connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=EJournalDB; Integrated Security=True;";
        }

        public List<StudentDTO> GetAll()
        {
            List<StudentDTO> students = new List<StudentDTO>();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetAllStudents";
                students = db.Query<StudentDTO>(connectionQuery).ToList<StudentDTO>();
            }
            return students;
        }

        public StudentDTO GetOne(int id)
        {
            StudentDTO student = null;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec GetStudent @Id";
                student = db.Query<StudentDTO>(connectionQuery, new { id }).FirstOrDefault();
            }
            return student;
        }

        public StudentDTO Create(StudentDTO student)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec AddStudent @Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @AdreementNumber";
                int? userId = db.Query<int>(connectionQuery, student).FirstOrDefault();
                student.Id = userId;
            }
            return student;
        }

        public void Update(StudentDTO student)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = " exec UpdateStudent @Id @Name, @Surname, @Email, @Phone, @Git, @City, @Ranking, @AdreementNumber";
                db.Execute(connectionQuery, student);
            }
        }

        public void DeleteSoft(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec DeleteStudent @id";
                db.Execute(connectionQuery, new { id });
            }
        }

        public void DeleteOne(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec ";
                db.Execute(connectionQuery, new { Id });
            }
        }

        public void DeleteAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec ";
                db.Execute(connectionQuery);
            }
        }

        public void HardDelete(StudentDTO studentDTO)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string connectionQuery = "exec HardDeleteStudent @Id";
                db.Execute(connectionQuery, new { studentDTO.Id});
            }
        }
    }
}
