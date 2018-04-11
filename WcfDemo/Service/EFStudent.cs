using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Common;
using Entity;

namespace Service
{
    public class EFStudent:IStudent
    {
        public List<Student> GetInfo(string strWhere)
        {
            List<Student> listData = new List<Student>();
            string strSql = "select * from student";
            DataTable dt= DbHelperSQL.Query(strSql).Tables[0];
            if (null != dt && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Student model = new Student();
                    model.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    model.Name = dt.Rows[i]["Name"].ToString();
                    model.Age = Convert.ToInt32(dt.Rows[i]["Age"]);
                    model.Grade = dt.Rows[i]["Grade"].ToString();
                    model.Address = dt.Rows[i]["Address"].ToString();
                    listData.Add(model);
                }
            }
            return listData;
        }

        public bool Add(Student model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into student values ");
            strSql.Append(" ( ");
            strSql.Append(" " + model.ID + ", ");
            strSql.Append(" '" + model.Name + "', ");
            strSql.Append(" " + model.Age + ", ");
            strSql.Append(" '" + model.Grade + "', ");
            strSql.Append(" '" + model.Address + "' ");
            strSql.Append(" ) ");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Student model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update student set ");
            strSql.Append(" Name= '" + model.Name + "', ");
            strSql.Append(" Age= " + model.Age + ", ");
            strSql.Append(" Grade= '" + model.Grade + "', ");
            strSql.Append(" Address= '" + model.Address + "' ");
            strSql.Append(" Where ID=" + model.ID + " ");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from student where ID=" + id + " ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Exist(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ID from student where ID=" + id + " ");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (null != dt && dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
